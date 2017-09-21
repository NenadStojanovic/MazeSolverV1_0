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
        int mSquareSzie;
        int mPaddingTop = 20;
        int mPaddingLeft = 10;
        int mInitGridSize = 20;
        private Dictionary<string, string> mFileNames = new Dictionary<string, string>();
        public static bool dfs, bfs, aStar, greedy, dijkstra;

        public static int  INFINITY = Int32.MaxValue; // The representation of the infinite
        public static int  EMPTY = 0;  // empty cell
        public static int  OBST = 1;  // cell with obstacle
        public static int  START = 2;  // the position of the robot
        public static int  TARGET = 3;  // the position of the target
        public static int  FRONTIER = 4;  // cells that form the frontier (OPEN SET)
        public static int  CLOSED = 5;  // cells that form the CLOSED SET
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
            this.Repaint();


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
                this.mIsDestOK = true;
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
                this.mFileNames.Add(e.FullPath, Path.GetFileName(e.FullPath));
            this.lbSource.Items.Add(Path.GetFileName(e.FullPath));
        }

        private void fileSystemWatcherSource_Deleted(object sender, FileSystemEventArgs e)
        {
            this.mFileNames.Remove(Path.GetFileName(e.FullPath));
            this.lbSource.Items.Remove(Path.GetFileName(e.FullPath));
        }

        public PictureBox[,] mazeTiles;
        //private MyMaze maze;
       

        private void dfsRB_CheckedChanged(object sender, EventArgs e)
        {
            dfs = dfsRB.Checked;
            bfs = aStar = greedy = dijkstra = false;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.InitMaze();
            this.Repaint();
        }

        private void newGridBtn_Click(object sender, EventArgs e)
        {
            this.mRows = Int32.Parse(this.rowsTB.Text);
            this.mCols = Int32.Parse(this.colsTB.Text);
            this.mMaze = new Cell[this.mRows, this.mCols];
            this.InitMaze();
            this.Repaint();
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
                    if (i==0 && j==mCols-1)
                    {
                        this.mMaze[i, j] = new Cell(i, j,START);
                    }
                    else if(i == mRows-1 && j == 0)
                    {
                        this.mMaze[i, j] = new Cell(i, j, TARGET);
                    }
                    else
                    {
                        this.mMaze[i, j] = new Cell(i, j);
                    }
                        
                    
                }

            }
        }

        public void Repaint()
        {
            int gridWidth = this.MazeGridGB.Size.Width-25;
            this.mSquareSzie = gridWidth / this.mRows;
            MazeGridGB.Controls.Clear();
            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mCols; j++)
                {
                    int xPosition = (i * mSquareSzie) + this.mPaddingLeft; //13 is padding from left
                    int yPosition = (j * mSquareSzie) + this.mPaddingTop; //45 is padding from top
                    this.mMaze[i, j].box.SetBounds(xPosition, yPosition, mSquareSzie, mSquareSzie);
                    


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
            var firstLine = File.ReadLines(path).First();
            List<string> size = firstLine.Split('x').ToList();
            this.mRows = Int32.Parse(size[0]);
            this.mCols = Int32.Parse(size[1]);
            this.mMaze = new Cell[this.mRows, this.mCols];
            var lines = File.ReadLines(path).Skip(1);
            int iCounter = 0;
            foreach (var line in lines)
            {
                int jCounter = 0;
                List<string> characters = line.Split(',').ToList();
                foreach (var singleChar in characters)
                {
                    if(singleChar=="x")
                    {
                        this.mMaze[iCounter, jCounter] = new Cell(iCounter, jCounter, OBST);
                    }
                    else if (singleChar == "_")
                    {
                        this.mMaze[iCounter, jCounter] = new Cell(iCounter, jCounter, EMPTY);
                    }
                    else if (singleChar == "s")
                    {
                        this.mMaze[iCounter, jCounter] = new Cell(iCounter, jCounter, START);
                    }
                    else if (singleChar == "t")
                    {
                        this.mMaze[iCounter, jCounter] = new Cell(iCounter, jCounter, TARGET);
                    }
                    jCounter++;

                }
                iCounter++;
            }
            this.Repaint();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BackColor == Color.White)
            {
                ((PictureBox)sender).BackColor = Color.Black;
            }
            else
            {
                ((PictureBox)sender).BackColor = Color.White;
            }
        }

        private class Cell
        {
            public int x;     //x cooridnates
            public int y;     //y cooridnates
            public int g;     // the value of the function g of A* and Greedy algorithms
            public int h;     // the value of the function h of A* and Greedy algorithms
            public int f;     // the value of the function h of A* and Greedy algorithms
            public int dist;  // the distance of the cell from the initial position of the robot
                      // Ie the label that updates the Dijkstra's algorithm
            public Cell prev; // Each state corresponds to a cell
                        // and each state has a predecessor which
                        // is stored in this variable
             
            public List<Cell> neighbors = new List<Cell>();
            public bool wall;
            public bool open;

            public PictureBox box;
            public int type;
            public int keyValue;

            public Cell(int row, int col)
            {
                this.x = row;
                this.y = col;
                this.type = EMPTY;
                this.box = new PictureBox();
                this.box.BackColor = Color.White;
                this.wall = false;
                this.open = true;
            }
            public Cell(int row, int col, int type)
            {
                this.x = row;
                this.y = col;
                this.type = type;
                this.box = new PictureBox();
                this.wall = false;
                this.open = true;
            }
        }

       
    }
    


}
