using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolverV1_0
{
    public partial class MainForm : Form
    {
        private string mSource;
        private bool mIsDestOK;
        private Cell[,] mMaze;
        int mRows;
        int mCols;
        int mSquareSize;
        int mPaddingTop = 20;
        int mPaddingLeft = 10;
        int mInitGridSize = 10;
        private Dictionary<string, string> mFileNames = new Dictionary<string, string>();
        public static bool dfs, bfs, aStar, greedy, dijkstra;

        public Cell mStartCell;
        public Cell mTargetCell;

        const int MUST_BE_LESS_THAN = 100000000;

        private bool mIsStartOk=true;
        private bool mIsTargetOk=true;

        public static int INFINITY = Int32.MaxValue; // The representation of the infinite
        public static int EMPTY = 0;  // empty cell
        public static int OBST = 1;  // cell with obstacle
        public static int START = 2;  // the position of the robot
        public static int TARGET = 3;  // the position of the target
        public static int FRONTIER = 4;  // cells that form the frontier (OPEN SET)
        public static int CLOSED = 5;  // cells that form the CLOSED SET
        public static int ROUTE = 6;  // cells that form the robot-to-target path

        // Messages to the user

        string msgDrawAndSelect = "\"Paint\" obstacles, then click 'Step-by-Step' or 'Animation'";
        string msgSelectStepByStepEtc = "Click 'Step-by-Step' or 'Animation' or 'Clear'";
        string msgNoSolution = "There is no path to the target !!!";

        public MainForm()
        {
            InitializeComponent();
            this.rowsTB.Text = this.colsTB.Text = this.mInitGridSize.ToString();
            this.mRows = this.mCols = mInitGridSize;
            this.dfsRB.Checked = true;
            this.mMaze = new Cell[this.mRows, this.mCols];
            this.InitMaze();
            this.RepaintWithBMP(0);
            this.mStartCell = new Cell();
            this.mTargetCell = new Cell();


        }
        private void SourcePathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                this.mSource = dialog.SelectedPath;

                labelSourceLink.Text = this.mSource;


                this.fileSystemWatcherSource.Path = this.mSource;
                this.fileSystemWatcherSource.EnableRaisingEvents = true;
                this._readFiles();
                this.lbSource.Items.Clear();
                foreach (string name in this.mFileNames.Keys)
                    this.lbSource.Items.Add(name);
            }
        }

        public void _readFiles()
        {
            string[] dirs = System.IO.Directory.GetFiles(this.mSource, "*.*");
            this.mFileNames.Clear();
            foreach (string file in dirs)
            {
                string[] path = file.Split('\\');
                this.mFileNames.Add(path.Last(), file);
            }
        }

        private void fileSystemWatcherSource_Created(object sender, FileSystemEventArgs e)
        {
            if (!this.mFileNames.ContainsKey(e.FullPath))
            {
                string[] path = e.FullPath.Split('\\');
                this.mFileNames.Add(path.Last(), e.FullPath);
            }
                
            this.lbSource.Items.Add(Path.GetFileName(e.FullPath));
        }

        private void fileSystemWatcherSource_Deleted(object sender, FileSystemEventArgs e)
        {
            this.mFileNames.Remove(Path.GetFileName(e.FullPath));
            this.lbSource.Items.Remove(Path.GetFileName(e.FullPath));
        }
        private void dfsRB_CheckedChanged(object sender, EventArgs e)
        {
            dfs = dfsRB.Checked;
            bfs = aStar = greedy = dijkstra = false;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            //this.InitMaze();
            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mCols; j++)
                {
                    if(this.mMaze[i,j].type == FRONTIER || this.mMaze[i, j].type == ROUTE || this.mMaze[i, j].type == CLOSED )
                    {
                        this.mMaze[i, j].type = EMPTY;
                        this.mMaze[i, j].isVisited = false;
                    }
                    else if(this.mMaze[i, j].type == START || this.mMaze[i, j].type == TARGET)
                    {
                        this.mMaze[i, j].isVisited = false;
                    }
                }
            }
            this.RepaintWithBMP(0);
        }

        private void newGridBtn_Click(object sender, EventArgs e)
        {
            this.mRows = Int32.Parse(this.rowsTB.Text);
            this.mCols = Int32.Parse(this.colsTB.Text);
            this.mMaze = new Cell[this.mRows, this.mCols];
            this.InitMaze();
            this.RepaintWithBMP(0);
        }

        private void lbSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderList = (ListBox)sender;
            var clickedItem = senderList.SelectedItem;
            if (clickedItem != null)
            {
                string path = this.mFileNames[clickedItem.ToString()];
                this.GenerateMazeFromFile(path);
            }
        }

        public void InitMaze()
        {
            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mCols; j++)
                {
                    if (i == 0 && j == mCols - 1)
                    {
                        this.mMaze[i, j] = new Cell(i, j, START);
                    }
                    else if (i == mRows - 1 && j == 0)
                    {
                        this.mMaze[i, j] = new Cell(i, j, TARGET);
                    }
                    else
                    {
                        this.mMaze[i, j] = new Cell(i, j);
                    }


                }

            }
            this.ConnectGraph();
        }

        public void RepaintWithBMP(int delay)
        {
            System.Threading.Thread.Sleep(delay);
            int gridWidth = this.mazePictureBox.Width - 25;
            this.mSquareSize = gridWidth / this.mRows;
            var bmp = new Bitmap(this.mazePictureBox.Width+mSquareSize, this.mazePictureBox.Height+mSquareSize, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (var g = Graphics.FromImage(bmp))
            using (var p = new Pen(Color.Black))
            using (var b = new SolidBrush(Color.White))
            {
                for (int i = 0; i < mRows; i++)
                {
                    for (int j = 0; j < mCols; j++)
                    {
                        int xPosition = (j * mSquareSize) + this.mPaddingLeft;
                        int yPosition = (i * mSquareSize) + this.mPaddingTop;
                        Rectangle rect = new Rectangle(xPosition, yPosition, mSquareSize, mSquareSize);
                        //this.mMaze[i, j].box.SetBounds(xPosition, yPosition, mSquareSzie, mSquareSzie);
                        //Label lbl = new Label();
                        //lbl.Text = i + "," + j;
                        //this.mMaze[i, j].box.Controls.Add(lbl);


                        if (this.mMaze[i, j].type == EMPTY)
                        {
                            b.Color = Color.White;
                            g.FillRectangle(b, rect);
                            p.Color = Color.White;
                            g.DrawRectangle(p, rect);

                        }
                        else if (this.mMaze[i, j].type == START)
                        {
                            b.Color = Color.Red;
                            g.FillRectangle(b, rect);
                            p.Color = Color.Red;
                            g.DrawRectangle(p, rect);
                        }
                        else if (this.mMaze[i, j].type == TARGET)
                        {
                            b.Color = Color.Green;
                            g.FillRectangle(b, rect);
                            p.Color = Color.Green;
                            g.DrawRectangle(p, rect);
                        }
                        else if (this.mMaze[i, j].type == OBST)
                        {
                            b.Color = Color.Black;
                            g.FillRectangle(b, rect);
                            p.Color = Color.Black;
                            g.DrawRectangle(p, rect);
                        }
                        else if (this.mMaze[i, j].type == FRONTIER)
                        {
                            b.Color = Color.Blue;
                            g.FillRectangle(b, rect);
                            p.Color = Color.Blue;
                            g.DrawRectangle(p, rect);
                        }
                        else if (this.mMaze[i, j].type == CLOSED)
                        {
                            b.Color = Color.Cyan;
                            g.FillRectangle(b, rect);
                            p.Color = Color.Cyan;
                            g.DrawRectangle(p, rect);
                        }
                        else if (this.mMaze[i, j].type == ROUTE)
                        {
                            b.Color = Color.Yellow;
                            g.FillRectangle(b, rect);
                            p.Color = Color.Yellow;
                            g.DrawRectangle(p, rect);
                        }
                        
                    }

                }
            }
            this.mazePictureBox.Visible = true;
            this.mazePictureBox.Image = bmp;
            this.mazePictureBox.BringToFront();
            this.mazePictureBox.Refresh();
        }

        public void Repaint()
        {
            int gridWidth = this.MazeGridGB.Size.Width - 25;
            this.mSquareSize = gridWidth / this.mRows;
            MazeGridGB.Controls.Clear();
            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mCols; j++)
                {
                    int xPosition = (j * mSquareSize) + this.mPaddingLeft; 
                    int yPosition = (i * mSquareSize) + this.mPaddingTop; 
                    this.mMaze[i, j].box.SetBounds(xPosition, yPosition, mSquareSize, mSquareSize);
                    //Label lbl = new Label();
                    //lbl.Text = i + "," + j;
                    //this.mMaze[i, j].box.Controls.Add(lbl);


                    if (this.mMaze[i, j].type == EMPTY)
                    {
                        this.mMaze[i, j].box.BackColor = Color.White;
                    }
                    else if (this.mMaze[i, j].type == START)
                    {
                        this.mMaze[i, j].box.BackColor = Color.Red;
                    }
                    else if (this.mMaze[i, j].type == TARGET)
                    {
                        this.mMaze[i, j].box.BackColor = Color.Green;
                    }
                    else if (this.mMaze[i, j].type == OBST)
                    {
                        this.mMaze[i, j].box.BackColor = Color.Black;
                    }
                    else if (this.mMaze[i, j].type == FRONTIER)
                    {
                        this.mMaze[i, j].box.BackColor = Color.Blue;
                    }
                    else if (this.mMaze[i, j].type == CLOSED)
                    {
                        this.mMaze[i, j].box.BackColor = Color.Cyan;
                    }
                    else if (this.mMaze[i, j].type == ROUTE)
                    {
                        this.mMaze[i, j].box.BackColor = Color.Yellow;
                    }
                    EventHandler clickEvent = new EventHandler(PictureBox_Click);
                    this.mMaze[i, j].box.Click += clickEvent; // += used incase other events are used
                                                              //Add to controls to form (display picture box)
                    MazeGridGB.Controls.Add(this.mMaze[i, j].box);
                    this.mMaze[i, j].box.BringToFront();
                }

            }
        }

        public void GenerateMazeFromFile(string path)
        {
            try
            {
                var firstLine = File.ReadLines(path).First();
                List<string> size = firstLine.Split('x').ToList();
                this.mRows = Int32.Parse(size[0]);
                this.mCols = Int32.Parse(size[1]);
                this.rowsTB.Text = this.mRows.ToString();
                this.colsTB.Text = this.mCols.ToString();
                this.mMaze = new Cell[this.mRows, this.mCols];
                var lines = File.ReadLines(path).Skip(1);
                int iCounter = 0;
                foreach (var line in lines)
                {
                    int jCounter = 0;
                    List<string> characters = line.Split(',').ToList();
                    foreach (var singleChar in characters)
                    {
                        if (singleChar == "x")
                        {
                            this.mMaze[iCounter, jCounter] = new Cell(iCounter, jCounter, OBST);
                        }
                        else if (singleChar == "_")
                        {
                            this.mMaze[iCounter, jCounter] = new Cell(iCounter, jCounter, EMPTY);
                        }
                        else if (singleChar == "s")
                        {
                            this.mStartCell = new Cell(iCounter, jCounter, START);
                            this.mMaze[iCounter, jCounter] = this.mStartCell;
                        }
                        else if (singleChar == "t")
                        {
                            this.mTargetCell = new Cell(iCounter, jCounter, TARGET);
                            this.mMaze[iCounter, jCounter] = this.mTargetCell;
                        }
                        jCounter++;

                    }
                    iCounter++;
                }
                this.ConnectGraph();
                this.RepaintWithBMP(0);
            }
            catch(Exception ex)
            {

            }
           
        }

        private void ConnectGraph()
        {
            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mCols; j++)
                {
                    this.mMaze[i, j].neighbors.Clear();
                    if (this.CheckIfFree(i,j))
                    {
                        
                        if (this.CheckIfFree(i + 1, j))
                        {
                            this.mMaze[i, j].neighbors.Add(this.mMaze[i + 1, j]);
                        }
                        if (this.CheckIfFree(i - 1, j))
                        {
                            this.mMaze[i, j].neighbors.Add(this.mMaze[i - 1, j]);
                        }
                        if (this.CheckIfFree(i, j + 1))
                        {
                            this.mMaze[i, j].neighbors.Add(this.mMaze[i, j + 1]);
                        }
                        if (this.CheckIfFree(i, j - 1))
                        {
                            this.mMaze[i, j].neighbors.Add(this.mMaze[i, j - 1]);
                        }
                    }
                    

                }
            }
        }

        private void solveMazeBtn_Click(object sender, EventArgs e)
        {
            if(bfsRB.Checked)
            {
                this.RunBFS();
            }
            else if (dfsRB.Checked)
            {
                this.RunDFS();
            }
            else if (aStarRB.Checked)
            {
                this.RunAStarOrGreedy(true);
            }
            else if (greedyRB.Checked)
            {
                this.RunAStarOrGreedy(false);
            }
        }



        private bool CheckIfFree(int i, int j)
        {
            if (i < 0 || j < 0 || i >= this.mRows || j >= this.mCols)
                return false;
            if (this.mMaze[i, j].type != OBST)
                return true;
            else
                return false;
        }

        private void mazePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int xPosition = (e.X - 10) / this.mSquareSize;
            int yPosition = (e.Y - 20) / this.mSquareSize;
            if(xPosition>=0 && xPosition<this.mCols && yPosition >=0 && yPosition < this.mRows)
            {
                if(this.mMaze[yPosition, xPosition].type == START && this.mIsTargetOk)
                {
                    this.mMaze[yPosition, xPosition].type = EMPTY;
                    this.mIsStartOk = false;
                    this.RepaintWithBMP(0);
                }
                else if(!this.mIsStartOk)
                {
                    this.mMaze[yPosition, xPosition].type = START;
                    this.mIsStartOk = true;
                    this.mStartCell = this.mMaze[yPosition, xPosition];
                    this.RepaintWithBMP(0);
                }
                else if (!this.mIsTargetOk)
                {
                    this.mMaze[yPosition, xPosition].type = TARGET;
                    this.mIsTargetOk = true;
                    this.mTargetCell = this.mMaze[yPosition, xPosition];
                    this.RepaintWithBMP(0);
                }
                else if(this.mMaze[yPosition, xPosition].type == EMPTY)
                {
                    this.mMaze[yPosition, xPosition].type = OBST;
                    this.RepaintWithBMP(0);
                }
                else if (this.mMaze[yPosition, xPosition].type == OBST)
                {
                    this.mMaze[yPosition, xPosition].type = EMPTY;
                    this.RepaintWithBMP(0);
                }
                else if (this.mMaze[yPosition, xPosition].type == TARGET && this.mIsStartOk)
                {
                    this.mMaze[yPosition, xPosition].type = EMPTY;
                    this.mIsTargetOk = false;
                    this.RepaintWithBMP(0);
                }

                this.ConnectGraph();
            }
            
            //this.KoordinatesLabel.Text = String.Format("X: {0}; Y:{1} ", e.X, e.Y);
        }

        private void mazePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //int xPosition = (e.X - 10) / this.mSquareSize;
            //int yPosition = (e.Y - 20) / this.mSquareSize;
            //if (xPosition >= 0 && xPosition < this.mCols && yPosition >= 0 && yPosition < this.mRows)
            //{
            //    this.mMaze[yPosition, xPosition].type = TARGET;
            //    this.RepaintWithBMP(0);
            //}

            //this.KoordinatesLabel.Text = String.Format("X: {0}; Y:{1} ", e.X, e.Y);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == Color.White)
            {
                ((PictureBox)sender).BackColor = Color.Black;
            }
            else if (((PictureBox)sender).BackColor == Color.Black)
            {
                ((PictureBox)sender).BackColor = Color.White;
            }
        }

        private void RunBFS()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                bool isSolution = false;
                var q = new Queue<Cell>();
                q.Enqueue(this.mStartCell);
                int nodeCounter = 0;
                Cell current = new Cell();
                while (q.Count > 0)
                {
                    nodeCounter++;
                    current = q.Dequeue();
                    current.isVisited = true;
                    //this.mMaze[current.x, current.y].box.BackColor =  Color.Cyan;
                    if (this.mMaze[current.x, current.y].type != TARGET && this.mMaze[current.x, current.y].type != START)
                    {
                        this.mMaze[current.x, current.y].type = CLOSED;
                    }


                    if (current.Equals(this.mTargetCell))
                    {
                        isSolution = true;
                        break;
                    }
                    foreach (var n in current.neighbors)
                    {
                        if (!n.isVisited)
                        {
                            //this.mMaze[n.x, n.y].box.BackColor = Color.Blue;
                            if (this.mMaze[n.x, n.y].type != TARGET && this.mMaze[n.x, n.y].type != START)
                            {
                                this.mMaze[n.x, n.y].type = FRONTIER;
                            }
                            n.prev = current;
                            q.Enqueue(n);
                        }

                    }

                    this.RepaintWithBMP(this.DelayTrackBar.Value);

                }
                if (isSolution)
                {
                    int stepCounter = 0;
                    string outputKey = "";
                    while (current.prev != null)
                    {
                        stepCounter++;
                        if (this.mMaze[current.prev.x, current.prev.y].type != START)
                        {
                            this.mMaze[current.prev.x, current.prev.y].type = ROUTE;
                            //this.mMaze[current.x, current.y].box.BackColor = Color.Yellow;
                        }

                        outputKey = outputKey + current.prev.x + current.prev.y;
                        current = current.prev;
                    }
                    this.RepaintWithBMP(0);
                    string message = "Number of traversed nodes: " + nodeCounter + ", number of steps: " + stepCounter;
                    this.outputMsgLabel.Text = message;
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    this.timeElapsedLabel.Text = "Time elapsed: " + elapsed+"ms";
                    this.KeyLabel.Text = this.GetStableHash(outputKey).ToString();
                    
                    
                }
                else
                {
                    string message = "There is no solution";
                    this.outputMsgLabel.Text = message;
                }
            }
            catch (Exception ex) { }
            
            

        }

        public int GetStableHash(string s)
        {
            uint hash = 0;
            // if you care this can be done much faster with unsafe 
            // using fixed char* reinterpreted as a byte*
            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(s))
            {
                hash += b;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            // final avalanche
            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);
            // helpfully we only want positive integer < MUST_BE_LESS_THAN
            // so simple truncate cast is ok if not perfect
            return (int)(hash % MUST_BE_LESS_THAN);
       }

        private void RunDFS()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                bool isSolution = false;
                var s = new Stack<Cell>();
                s.Push(this.mStartCell);
                int nodeCounter = 0;
                Cell current = new Cell();
                while (s.Count > 0)
                {
                    nodeCounter++;
                    current = s.Pop();
                    current.isVisited = true;
                    //this.mMaze[current.x, current.y].box.BackColor =  Color.Cyan;
                    if (this.mMaze[current.x, current.y].type != TARGET && this.mMaze[current.x, current.y].type != START)
                    {
                        this.mMaze[current.x, current.y].type = CLOSED;
                    }


                    if (current.Equals(this.mTargetCell))
                    {
                        isSolution = true;
                        break;
                    }
                    foreach (var n in current.neighbors)
                    {
                        if (!n.isVisited)
                        {
                            //this.mMaze[n.x, n.y].box.BackColor = Color.Blue;
                            if (this.mMaze[n.x, n.y].type != TARGET && this.mMaze[n.x, n.y].type != START)
                            {
                                this.mMaze[n.x, n.y].type = FRONTIER;
                            }
                            n.prev = current;
                            s.Push(n);
                        }

                    }

                    this.RepaintWithBMP(this.DelayTrackBar.Value);

                }
                if (isSolution)
                {
                    int stepCounter = 0;
                    while (current.prev != null)
                    {
                        stepCounter++;
                        if (this.mMaze[current.prev.x, current.prev.y].type != START)
                        {
                            this.mMaze[current.prev.x, current.prev.y].type = ROUTE;
                            //this.mMaze[current.x, current.y].box.BackColor = Color.Yellow;
                        }

                        current = current.prev;
                    }
                    this.RepaintWithBMP(0);
                    string message = "Number of traversed nodes: " + nodeCounter + ", number of steps: " + stepCounter;
                    this.outputMsgLabel.Text = message;
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    this.timeElapsedLabel.Text = "Time elapsed: " + elapsed + "ms";
                }
                else
                {
                    string message = "There is no solution";
                    this.outputMsgLabel.Text = message;
                }
            }
            catch (Exception ex) { }



        }
        public void RunAStarOrGreedy(bool isAStar)
        {
            try
            {
                List<Cell> openSet = new List<Cell>();
                List<Cell> closedSet = new List<Cell>();
                var watch = System.Diagnostics.Stopwatch.StartNew();
                bool isSolution = false;
                int nodeCounter = 0;
                Cell current = new Cell();
                this.mStartCell.f = this.mStartCell.g = this.mStartCell.h = 0;
                openSet.Add(this.mStartCell);
                while(openSet.Count>0)
                {
                    nodeCounter++;
                    openSet = openSet.OrderBy(x => x.f).ToList();
                    current = openSet[0];
                    openSet.RemoveAt(0);
                    closedSet.Add(current);
                    if (this.mMaze[current.x, current.y].type != TARGET && this.mMaze[current.x, current.y].type != START)
                    {
                        this.mMaze[current.x, current.y].type = CLOSED;
                    }
                    if(current.Equals(this.mTargetCell))
                    {
                        isSolution = true;
                        //this.mMaze[this.mTargetCell.x, this.mTargetCell.y].prev = current;
                        break;
                        
                    }
                    foreach (var cell in current.neighbors)
                    {
                        int dxg = current.x - cell.x;
                        int dyg = current.y - cell.y;
                        int dxh = this.mTargetCell.x - cell.x;
                        int dyh = this.mTargetCell.y - cell.y;
                        if(isAStar)
                        {
                            cell.g = current.g + Math.Abs(dxg) + Math.Abs(dyg); //euklid
                        }
                        else
                        {
                            cell.g = 0;
                        }
                        
                        cell.h = Math.Abs(dxh) + Math.Abs(dyh);
                        cell.f = cell.g + cell.h;

                        if(IsCellInList(openSet,cell)==-1)
                        {
                            cell.prev = current;
                        }
                        

                        int openIndex = IsCellInList(openSet, cell);
                        int closedIndex = IsCellInList(closedSet, cell);

                        if (openIndex == -1 && closedIndex == -1)
                        {
                            openSet.Add(cell);
                            if (this.mMaze[cell.x, cell.y].type != TARGET && this.mMaze[cell.x, cell.y].type != START)
                            {
                                this.mMaze[cell.x, cell.y].type = FRONTIER;
                            }
                        }
                        else
                        {
                            if (openIndex > -1)
                            {
                                if (openSet[openIndex].f <= cell.f)
                                {
                                    // ... then eject the new node with state Sj.
                                    // (ie do nothing for this node).
                                    // Else, ...
                                }
                                else
                                {
                                    // ... remove the element (Sj, old) from the list
                                    // to which it belongs ...
                                    openSet.RemoveAt(openIndex);
                                    // ... and add the item (Sj, new) to the OPEN SET.
                                    openSet.Add(cell);
                                    // Update the color of the cell
                                    if (this.mMaze[cell.x, cell.y].type != TARGET && this.mMaze[cell.x, cell.y].type != START)
                                    {
                                        this.mMaze[cell.x, cell.y].type = FRONTIER;
                                    }
                                }
                            }
                            else
                            {
                                if (closedSet[closedIndex].f <= cell.f)
                                {
                                    // ... then eject the new node with state Sj.
                                    // (ie do nothing for this node).
                                    // Else, ...
                                }
                                else
                                {
                                    // ... remove the element (Sj, old) from the list
                                    // to which it belongs ...
                                    closedSet.RemoveAt(closedIndex);
                                    // ... and add the item (Sj, new) to the OPEN SET.
                                    openSet.Add(cell);
                                    // Update the color of the cell
                                    if(this.mMaze[cell.x, cell.y].type != TARGET && this.mMaze[cell.x, cell.y].type != START)
                                    {
                                        this.mMaze[cell.x, cell.y].type = FRONTIER;
                                    }
                                    
                                }
                            }
                        }

                    }
                    this.RepaintWithBMP(this.DelayTrackBar.Value);
                }

                if (isSolution)
                {
                    int stepCounter = 0;
                    while (current.prev != null)
                    {
                        stepCounter++;
                        if (this.mMaze[current.prev.x, current.prev.y].type != START)
                        {
                            this.mMaze[current.prev.x, current.prev.y].type = ROUTE;
                            //this.mMaze[current.x, current.y].box.BackColor = Color.Yellow;
                        }

                        current = current.prev;
                    }
                    this.RepaintWithBMP(0);
                    string message = "Number of traversed nodes: " + nodeCounter + ", number of steps: " + stepCounter;
                    this.outputMsgLabel.Text = message;
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    this.timeElapsedLabel.Text = "Time elapsed: " + elapsed + "ms";
                }
                else
                {
                    string message = "There is no solution";
                    this.outputMsgLabel.Text = message;
                }
                this.RepaintWithBMP(0);

            }
            catch (Exception ex) { }
        }

        private int IsCellInList(List<Cell> list, Cell c)
        {
            int res = 0;
            foreach (var item in list)
            {
                if(item.Equals(c))
                {
                    return res;
                }
                res++;
            }
            return -1;
        }



        public class Cell
        {
            public int x;     //x cooridnates
            public int y;     //y cooridnates
            public int g;     // the value of the function g of A* and Greedy algorithms
            public int h;     // the value of the function h of A* and Greedy algorithms
            public int f;     // the value of the function f of A* and Greedy algorithms
            public int dist;  // the distance of the cell from the initial position of the robot
                      // Ie the label that updates the Dijkstra's algorithm
            public Cell prev; // Each state corresponds to a cell
                        // and each state has a predecessor which
                        // is stored in this variable
             
            public List<Cell> neighbors = new List<Cell>();
            public bool wall;
            public bool open;
            public bool isVisited;

            public PictureBox box;
            public int type;
            public int keyValue;

            public Cell()
            {
                this.neighbors = new List<Cell>();
                this.isVisited = false;
            }

            public Cell(int row, int col)
            {
                this.x = row;
                this.y = col;
                this.type = EMPTY;
                this.box = new PictureBox();
                this.box.BackColor = Color.White;
                this.wall = false;
                this.open = true;
                this.isVisited = false;
                this.neighbors = new List<Cell>();
            }
            public Cell(int row, int col, int type)
            {
                this.x = row;
                this.y = col;
                this.type = type;
                this.box = new PictureBox();
                this.wall = false;
                this.open = true;
                this.isVisited = false;
                this.neighbors = new List<Cell>();
            }

            public override bool Equals(object obj)
            {
                Cell c = (Cell)obj;
                if (this.x == c.x && this.y == c.y)
                    return true;
                else
                    return false;
            }
            public override int GetHashCode()
            {
                return this.x + this.y * 256;
            }
        }

       
    }
    


}
