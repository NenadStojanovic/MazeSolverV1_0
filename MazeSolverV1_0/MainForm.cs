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
        private string mSource; //putanja do izvorisnog foldera
        private bool mIsDestOK;
        private Cell[,] mMaze; //matricna reprezentacija lavirinta tj grafa
        int mRows; //broj vrsta lavirinta
        int mCols; //broj kolona lavirinta
        int mSquareSize; //velicina jednog polja
        int mPaddingTop = 20; //pomeraj za iscrtavanje lavirinta
        int mPaddingLeft = 10; //pomeraj za iscrtavanje lavirinta
        int mInitGridSize = 10; //pocetna vrednost velicine lavirinta
        private Dictionary<string, string> mFileNames = new Dictionary<string, string>(); //par kljuc vrednost gde je kljuc ime fajla a vrednost putanja do fajla
        public static bool dfs, bfs, aStar, greedy, dijkstra;

        public Cell mStartCell; //pocetno polje lavirinta
        public Cell mTargetCell; //ciljno polje lavirinta

        public const int MUST_BE_LESS_THAN = 100000000; //vrednost koja se koristi za odsecanje kod generisanja hes vrednosti kljuca
        public const int MAX_VALUE = Int32.MaxValue; //zamena za beskonacnu vrednost kod Dijkstrinog algoritma

        private bool mIsStartOk=true; //pokazatelj da li je startno polje u redu kod validacje lavirinta
        private bool mIsTargetOk=true; //pokazatelj da li je ciljno polje u redu kod validacje lavirinta

        public static int EMPTY = 0;  // prazno polje
        public static int OBST = 1;  // prepreka tj. zid
        public static int START = 2;  // pocetno polje
        public static int TARGET = 3;  // ciljno polje
        public static int FRONTIER = 4;  // polje koje ce naredno biti obradjeno
        public static int CLOSED = 5;  // obradjeno polje
        public static int ROUTE = 6;  // polje koje se nalazi na putu do resenja

        // Messages to the user

        string msgDrawAndSelect = "\"Paint\" obstacles, then click 'Step-by-Step' or 'Animation'";
        string msgSelectStepByStepEtc = "Click 'Step-by-Step' or 'Animation' or 'Clear'";
        string msgNoSolution = "There is no path to the target !!!";

        /// <summary>
        /// Iniciranje glavne forme pri startovanju aplikacije
        /// </summary>
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

        /// <summary>
        /// Dugme za ucitavanje foldera i aktivaciju FileSystemWatcher-a nad datim folderom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// metoda koja kreira mapu putanja i imena fajlova
        /// </summary>
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

        /// <summary>
        /// Event FSW-a kod kreiranja novog fajla u folderu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcherSource_Created(object sender, FileSystemEventArgs e)
        {
            if (!this.mFileNames.ContainsKey(e.FullPath))
            {
                string[] path = e.FullPath.Split('\\');
                this.mFileNames.Add(path.Last(), e.FullPath);
            }
                
            this.lbSource.Items.Add(Path.GetFileName(e.FullPath));
        }

        /// <summary>
        /// Event FSW-a kod brisanja fajla u folderu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Ciscenje lavirinta od prethodne pretrage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Kreiranje nove podloge za lavirint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGridBtn_Click(object sender, EventArgs e)
        {
            this.mRows = Int32.Parse(this.rowsTB.Text);
            this.mCols = Int32.Parse(this.colsTB.Text);
            this.mMaze = new Cell[this.mRows, this.mCols];
            this.InitMaze();
            this.RepaintWithBMP(0);
        }

        /// <summary>
        /// Metoda za odabir konkretnog lavirinta iz liste lavirinata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda koja inicijalizuje pocetne vrednosti praznog lavirinta
        /// </summary>
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

        /// <summary>
        /// Metoda koja ponovo iscrtava lavirint na osnovu vrednosti iz mMaze atributa u obliku bitmap slike, parametar delay oznacava period usporenja tj. kasnjenja u animaciji
        /// </summary>
        /// <param name="delay"></param>
        public void RepaintWithBMP(int delay)
        {
            if(delay>0) //provera kašnjenja
            {
                System.Threading.Thread.Sleep(delay);
            }
            int gridWidth = this.mazePictureBox.Width - 25; //proračun veličine mreže
            this.mSquareSize = gridWidth / this.mRows; //proračun veličine polja
            //kreiranje bitmape odredjene veličine
            var bmp = new Bitmap(this.mazePictureBox.Width+mSquareSize, this.mazePictureBox.Height+mSquareSize, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (var g = Graphics.FromImage(bmp))
            using (var p = new Pen(Color.Black))
            using (var b = new SolidBrush(Color.White))
            { //iteracija kroz sve elemente lavirinta i kreiranje odgovarajućeg Rectangle elementa za svako polje
                for (int i = 0; i < mRows; i++)
                {
                    for (int j = 0; j < mCols; j++)
                    {
                        //proračunavanje pozicije kvadratu u okviru slike
                        int xPosition = (j * mSquareSize) + this.mPaddingLeft;
                        int yPosition = (i * mSquareSize) + this.mPaddingTop;
                        Rectangle rect = new Rectangle(xPosition, yPosition, mSquareSize, mSquareSize);
                        //odabir odgovarajuceg tipa...
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
            //postavljanje bitmape u PictureBox koji predstavlja lavirint u aplikaciji
            this.mazePictureBox.Visible = true;
            this.mazePictureBox.Image = bmp;
            this.mazePictureBox.BringToFront();
            this.mazePictureBox.Refresh();
        }

        /// <summary>
        /// Metoda koja ponovo iscrtava lavirint na osnovu mMaze atributa koristeci PictureBox elemente
        /// </summary>
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

        /// <summary>
        /// Metoda koja za zadati fajl preko putanje parametra path kreira lavirint iz tekstualnog fajla
        /// </summary>
        /// <param name="path"></param>
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

        /// <summary>
        /// Metoda koja povezuje svaki cvor u grafu sa svojim susedima u odnosu na tip polja suseda
        /// </summary>
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

        /// <summary>
        /// Metoda za pokretanje odredjenog postupka za resavanje lavirinta u zavisnosti od korisnikovog izbora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (dijkstraRB.Checked)
            {
                this.RunDijkstra();
            }
        }


        /// <summary>
        /// Metoda koja za zadate koordinate cvora proverava da li ne redstavlja prepreku u lavirintu
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool CheckIfFree(int i, int j)
        {
            if (i < 0 || j < 0 || i >= this.mRows || j >= this.mCols)
                return false;
            if (this.mMaze[i, j].type != OBST)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metoda koja obradjuje interakciju korisnika s lavirintom odnosno rukuje s klikovima korisnika u okviru lavirinta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda koja simulira pronalazak puta u grafu koriscenjem BFS metode
        /// </summary>
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
                    this.timeElapsedLabel.Text = String.Empty;
                    this.KeyLabel.Text = String.Empty;
                }
            }
            catch (Exception ex) { }
                      
        }


        /// <summary>
        /// Metoda koja ulazni string s pretvara u osmocifreni hesirani broj
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int GetStableHash(string s)
        {
            uint hash = 0; //rezultujuća vrednost
            //jednostavno heširanje svakog bajta ulaznog stringa 
            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(s))
            {
                hash += b;
                hash += (hash << 10);
                hash ^= (hash >> 6);
            }
            //još jedna dodatna runda
            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            //odsecanje ključa
            return (int)(hash % MUST_BE_LESS_THAN);
       }

        /// <summary>
        /// Metoda koja simulira pronalazak puta u grafu koriscenjem DFS metode
        /// </summary>
        private void RunDFS()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew(); //Sistemska štoperica za merenje vremena
                bool isSolution = false; //promenljiva koja govori o statusu pronalaska rešenja 
                var s = new Stack<Cell>(); //stek struktura za čuvanje čvorova koje treba obraditi
                s.Push(this.mStartCell); 
                int nodeCounter = 0; //brojač obrađenih čvorova
                Cell current = new Cell();
                string outputKey = "";
                while (s.Count > 0)
                {
                    nodeCounter++;
                    current = s.Pop(); //odabir sledećeg čvora za obradu
                    current.isVisited = true;
                    //this.mMaze[current.x, current.y].box.BackColor =  Color.Cyan;
                    if (this.mMaze[current.x, current.y].type != TARGET && this.mMaze[current.x, current.y].type != START)//postavljanje određene boje polja
                    {
                        this.mMaze[current.x, current.y].type = CLOSED;
                    }


                    if (current.Equals(this.mTargetCell)) //provera da li se stiglo do cilja
                    {
                        isSolution = true;
                        break;
                    }
                    foreach (var n in current.neighbors) //obrada potomaka
                    {
                        if (!n.isVisited)
                        {
                            if (this.mMaze[n.x, n.y].type != TARGET && this.mMaze[n.x, n.y].type != START)
                            {
                                this.mMaze[n.x, n.y].type = FRONTIER;
                            }
                            n.prev = current;
                            s.Push(n);
                        }

                    }

                    this.RepaintWithBMP(this.DelayTrackBar.Value); //ponovno iscrtavanje lavirinta

                }
                if (isSolution) //ukoliko se došlo do rešenja...
                {
                    int stepCounter = 0; //brojač koraka do rešenja
                    while (current.prev != null) //rekonstruisanje puta do rešenja na osnovu prethodnika
                    {
                        stepCounter++;
                        if (this.mMaze[current.prev.x, current.prev.y].type != START)
                        {
                            this.mMaze[current.prev.x, current.prev.y].type = ROUTE;
                        }
                        outputKey = outputKey + current.prev.x + current.prev.y; //izdvajanje ključa
                        current = current.prev;
                    }
                    this.RepaintWithBMP(0);//ponovno iscrtavanje lavirinta sa rešenjem
                    //sledi ispis statističkih podataka
                    string message = "Number of traversed nodes: " + nodeCounter + ", number of steps: " + stepCounter;
                    this.outputMsgLabel.Text = message;
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    this.timeElapsedLabel.Text = "Time elapsed: " + elapsed + "ms";
                    this.KeyLabel.Text = this.GetStableHash(outputKey).ToString(); //heširanje ključa
                }
                else
                {
                    string message = "There is no solution";
                    this.outputMsgLabel.Text = message;
                    this.timeElapsedLabel.Text = String.Empty;
                    this.KeyLabel.Text = String.Empty;
                }
            }
            catch (Exception ex) { }



        }

        /// <summary>
        /// Metoda koja simulira pronalazak puta u grafu koriscenjem A* ili Greedy metode u zavisnosti od parametra isAStar
        /// </summary>
        /// <param name="isAStar"></param>
        public void RunAStarOrGreedy(bool isAStar)
        {
            try
            {
                List<Cell> openSet = new List<Cell>(); //lista čvorova koje treba obraditi
                List<Cell> closedSet = new List<Cell>(); //lista obrađenih čvorova
                var watch = System.Diagnostics.Stopwatch.StartNew(); 
                bool isSolution = false; //status pronalaska rešenja
                int nodeCounter = 0; //bojač obrađenih čvorova
                Cell current = new Cell(); //trenutni čvor za obradu
                string outputKey = "";
                this.mStartCell.f = this.mStartCell.g = this.mStartCell.h = 0; //inicijalne f,g i h vrednosti
                openSet.Add(this.mStartCell);
                while(openSet.Count>0) //petlja za izvršenje algoritma
                {
                    nodeCounter++;
                    openSet = openSet.OrderBy(x => x.f).ToList(); //prioritizacija čvorova po vrednosti f
                    current = openSet[0]; //odabir trenutnog čvora
                    openSet.RemoveAt(0);
                    closedSet.Add(current);
                    if (this.mMaze[current.x, current.y].type != TARGET && this.mMaze[current.x, current.y].type != START)
                    {
                        this.mMaze[current.x, current.y].type = CLOSED;
                    }
                    if(current.Equals(this.mTargetCell)) //ispitivanje pronalaska cilja
                    {
                        isSolution = true;
                        break;      
                    }
                    foreach (var cell in current.neighbors) //obrada sledbenika
                    {
                        //proračun g i h vrednosti za trenutni čvor...
                        int dxg = current.x - cell.x;
                        int dyg = current.y - cell.y;
                        int dxh = this.mTargetCell.x - cell.x;
                        int dyh = this.mTargetCell.y - cell.y;
                        if(isAStar) //... u zavisnosti od odabranog algoritma
                        {
                            cell.g = current.g + Math.Abs(dxg) + Math.Abs(dyg); 
                        }
                        else
                        {
                            cell.g = 0;
                        }
                        cell.h = Math.Abs(dxh) + Math.Abs(dyh);
                        cell.f = cell.g + cell.h;

                        if(IsCellInList(closedSet,cell)==-1) //odredjivanje prethodnika
                        {
                            cell.prev = current;
                        }          
                        int openIndex = IsCellInList(openSet, cell); //promenljive za pomoć pri klasifikaciji čvora u određenu listu
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
                            if (openIndex > -1) //klasifikacija čvora u određenu listu
                            {
                                if (openSet[openIndex].f > cell.f)
                                {
                                    openSet.RemoveAt(openIndex);
                                    openSet.Add(cell);
                                    if (this.mMaze[cell.x, cell.y].type != TARGET && this.mMaze[cell.x, cell.y].type != START)
                                    {
                                        this.mMaze[cell.x, cell.y].type = FRONTIER;
                                    }
                                }
                            }
                            else
                            {
                                if (closedSet[closedIndex].f > cell.f)
                                {
                                    closedSet.RemoveAt(closedIndex);
                                    openSet.Add(cell);
                                    if (this.mMaze[cell.x, cell.y].type != TARGET && this.mMaze[cell.x, cell.y].type != START)
                                    {
                                        this.mMaze[cell.x, cell.y].type = FRONTIER;
                                    }
                                }
                            }
                        }

                    }
                    this.RepaintWithBMP(this.DelayTrackBar.Value); //ponovno iscrtavanje lavirinta s novim korakom
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
                        outputKey = outputKey + current.prev.x + current.prev.y;
                        current = current.prev;
                    }
                    this.RepaintWithBMP(0);
                    string message = "Number of traversed nodes: " + nodeCounter + ", number of steps: " + stepCounter;
                    this.outputMsgLabel.Text = message;
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    this.timeElapsedLabel.Text = "Time elapsed: " + elapsed + "ms";
                    this.KeyLabel.Text = this.GetStableHash(outputKey).ToString();
                }
                else
                {
                    string message = "There is no solution";
                    this.outputMsgLabel.Text = message;
                    this.timeElapsedLabel.Text = String.Empty;
                    this.KeyLabel.Text = String.Empty;
                }
                this.RepaintWithBMP(0);

            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Metoda koja simulira pronalazak puta u grafu koriscenjem Dijkstrinog algoritma
        /// </summary>
        public void RunDijkstra()
        {
            try
            {
                List<Cell> openSet = new List<Cell>(); //lista čvorova koje treba obraditi
                List<Cell> closedSet = new List<Cell>(); //lista obrađenih čvorova
                var watch = System.Diagnostics.Stopwatch.StartNew(); //sistemska štoperica za računanje vremena izvršenja algoritma
                bool isSolution = false; //status pronalaska rešenja
                int nodeCounter = 0; //brojač obrađenih čvorova
                Cell current = new Cell(); //trenutni čvor za obradu
                string outputKey = "";
                this.InitDijkstra(); //inicijalizacija Dijkstrinog algoritma
                openSet.Add(this.mStartCell);
                while (openSet.Count > 0) //petlja za izvršenje algoritma
                {
                    nodeCounter++;
                    openSet = openSet.OrderBy(x => x.dist).ToList(); //prioritizacija čvorova po rastojanju
                    current = openSet[0];
                    openSet.RemoveAt(0);
                    closedSet.Add(current);
                    if (this.mMaze[current.x, current.y].type != TARGET && this.mMaze[current.x, current.y].type != START)
                    {
                        this.mMaze[current.x, current.y].type = CLOSED;
                    }
                    if (current.Equals(this.mTargetCell)) //provera pronalaska rešenja
                    {
                        isSolution = true;
                        break;

                    }
                    foreach (var cell in current.neighbors) //obrada sledbenika
                    { 
                        if(IsCellInList(closedSet,cell) == -1)
                        {
                            int newPathPrice = current.dist + 1; //proračunavanje nove cene puta i...
                            if (cell.dist > newPathPrice) //... upoređivanje sa starom
                            {
                                cell.dist = newPathPrice;
                            }
                            if (this.mMaze[cell.x, cell.y].type != TARGET && this.mMaze[cell.x, cell.y].type != START)
                            {
                                this.mMaze[cell.x, cell.y].type = FRONTIER;
                            }
                            openSet.Add(cell); //dodavanje nogov čvora za obradu
                            cell.prev = current; 
                        }                       
                    }
                    this.RepaintWithBMP(this.DelayTrackBar.Value);//ponovno iscrtavanje lavirinta
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
                        outputKey = outputKey + current.prev.x + current.prev.y;
                        current = current.prev;
                    }
                    this.RepaintWithBMP(0);
                    string message = "Number of traversed nodes: " + nodeCounter + ", number of steps: " + stepCounter;
                    this.outputMsgLabel.Text = message;
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    this.timeElapsedLabel.Text = "Time elapsed: " + elapsed + "ms";
                    this.KeyLabel.Text = this.GetStableHash(outputKey).ToString();
                }
                else
                {
                    string message = "There is no solution";
                    this.outputMsgLabel.Text = message;
                    this.timeElapsedLabel.Text = String.Empty;
                    this.KeyLabel.Text = String.Empty;
                }
                this.RepaintWithBMP(0);

            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Metoda koja sluzi za postavljanje pocetnih vrednosti u cvorovima pre pokretanja Dijkstrinog algoritma
        /// </summary>
        public void InitDijkstra()
        {
            for (int i = 0; i < this.mRows; i++)
            {
                for (int j = 0; j < this.mCols; j++)
                {
                    this.mMaze[i, j].dist = MAX_VALUE;
                }
            }
            this.mMaze[this.mStartCell.x, this.mStartCell.y].dist = 0;
        }

        /// <summary>
        /// Metoda koja proverava da li se objekat c tipa Cell nalazi u listi list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="c"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Pomocna klasa za predstavljanje jednog cvora u grafu
        /// </summary>
        public class Cell
        {
            public int x;     //x koordinata
            public int y;     //y koordinata
            public int g;     // vrednost funkcije g za A* i Greedy algoritme
            public int h;     // vrednost funkcije h za A* i Greedy algoritme
            public int f;     // vrednost funkcije f za A* i Greedy algoritme
            public int dist;  // rastojanje odnosno cena puta kod Dijkstrinog algoritma
                    
            public Cell prev; //prethodnik datog cvora

             
            public List<Cell> neighbors = new List<Cell>(); //lista suseda
            public bool isVisited; //pokazatelj da li je cvor obradjen

            public PictureBox box; //PictureBox koriscen pri iscrtavanju
            public int type; //tip polja: 
            public int keyValue; //vrednost polja koja moze da se koristi pri generisanju kljuca

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
                this.isVisited = false;
                this.neighbors = new List<Cell>();
            }
            public Cell(int row, int col, int type)
            {
                this.x = row;
                this.y = col;
                this.type = type;
                this.box = new PictureBox();
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
