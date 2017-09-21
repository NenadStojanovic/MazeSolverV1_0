using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolverV1_0
{
    public partial class MainForm : Form
    {
        public static bool dfs, bfs, aStar, greedy, dijkstra;
        public PictureBox[,] mazeTiles;
        private MyMaze maze;
        public MainForm()
        {
            InitializeComponent();
            this.rowsTB.Text = this.colsTB.Text = "10";
            this.maze = new MyMaze(Int32.Parse(this.rowsTB.Text), Int32.Parse(this.colsTB.Text));
            this.dfsRB.Checked = true;
            maze.Repaint();
            
        }

        public MainForm(bool second)
        {
            InitializeComponent();
        }

        private void dfsRB_CheckedChanged(object sender, EventArgs e)
        {
            dfs = dfsRB.Checked;
            bfs = aStar = greedy = dijkstra = false;
        }

        public class Cell
        {
            public int row;   // the row number of the cell(row 0 is the top)
            public int col;   // the column number of the cell (Column 0 is the left)
            public int g;     // the value of the function g of A* and Greedy algorithms
            public int h;     // the value of the function h of A* and Greedy algorithms
            public int f;     // the value of the function h of A* and Greedy algorithms
            public int dist;  // the distance of the cell from the initial position of the robot
                              // Ie the label that updates the Dijkstra's algorithm
            public Cell prev; // Each state corresponds to a cell
                              // and each state has a predecessor which
                              // is stored in this variable

            public Cell(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        } // end nested class Cell

        public class MyMaze
        {
            private int dimensionX, dimensionY; // dimension of maze
            private int gridDimensionX, gridDimensionY; // dimension of output grid
            private char[,] mazeGrid; // output grid
            private MazeCell[,] cells; // 2d array of Cells
            private Random random = new Random(); // The random object

            // initialize with x and y the same
            public MyMaze(int aDimension)
            {
                // Initialize
                dimensionX = aDimension;
                dimensionY = aDimension;
                gridDimensionX = aDimension;
                gridDimensionY = aDimension;
                mazeGrid = new char[gridDimensionX, gridDimensionY];
                init();
                generateMaze();
            }
            // constructor
            public MyMaze(int xDimension, int yDimension)
            {
                dimensionX = xDimension;
                dimensionY = yDimension;
                gridDimensionX = xDimension;
                gridDimensionY = yDimension;
                mazeGrid = new char[gridDimensionX, gridDimensionY];
                init();
                generateMaze();
            }

            private void init()
            {
                // create cells
                cells = new MazeCell[dimensionX, dimensionY];
                grid = new int[rows, columns];
                for (int x = 0; x < dimensionX; x++)
                {
                    for (int y = 0; y < dimensionY; y++)
                    {
                        cells[x, y] = new MazeCell(x, y, false); // create cell (see Cell constructor)
                    }
                }
            }

            // inner class to represent a cell
            public class MazeCell
            {

                public int x, y; // coordinates
                                 // cells this cell is connected to
                public List<MazeCell> neighbors = new List<MazeCell>();
                // impassable cell
                public bool wall = true;
                // if true, has yet to be used in generation
                public bool open = true;
                // construct MazeCell at x, y
                public MazeCell(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                    this.wall = true;
                }
                // construct MazeCell at x, y and with whether it isWall
                public MazeCell(int x, int y, bool isWall)
                {
                    this.x = x;
                    this.y = y;
                    this.wall = isWall;
                }
                // add a neighbor to this cell, and this cell as a neighbor to the other
                public void addNeighbor(MazeCell other)
                {
                    if (!this.neighbors.Contains(other))
                    { // avoid duplicates
                        this.neighbors.Add(other);
                    }
                    if (!other.neighbors.Contains(this))
                    { // avoid duplicates
                        other.neighbors.Add(this);
                    }
                }
                // used in updateGrid()
                public bool isCellBelowNeighbor()
                {
                    return this.neighbors.Contains(new MazeCell(this.x, this.y + 1));
                }
                // used in updateGrid()
                public bool isCellRightNeighbor()
                {
                    return this.neighbors.Contains(new MazeCell(this.x + 1, this.y));
                }

                override public bool Equals(Object other)
                {

                    MazeCell otherCell = (MazeCell)other;
                    return (this.x == otherCell.x && this.y == otherCell.y);
                }

                override public int GetHashCode()
                {
                    // random hash code method designed to be usually unique
                    return this.x + this.y * 256;
                }

            }
            // generate from upper left (In computing the y increases down often)
            private void generateMaze()
            {
                generateMaze(0, 0);
            }
            // generate the maze from coordinates x, y
            private void generateMaze(int x, int y)
            {
                generateMaze(getCell(x, y)); // generate from Cell
            }

            // used to get a Cell at x, y; returns null out of bounds
            public MazeCell getCell(int x, int y)
            {
                try
                {
                    return cells[x, y];
                }
                catch (Exception e)
                { // catch out of bounds
                    return null;
                }
            }

            private void generateMaze(MazeCell startAt)
            {
                // don't generate from cell not there
                if (startAt == null) return;
                startAt.open = false; // indicate cell closed for generation
                List<MazeCell> cellsList = new List<MazeCell>();
                cellsList.Add(startAt);

                while (cellsList.Count > 0)
                {
                    MazeCell cell;
                    // this is to reduce but not completely eliminate the number
                    // of long twisting halls with short easy to detect branches
                    // which results in easy mazes
                    if (random.Next(10) == 0)
                    {
                        int index = random.Next(cellsList.Count);
                        cell = cellsList[index];
                        cellsList.RemoveAt(index);
                    }

                    else
                    {
                        int index = cellsList.Count - 1;
                        cell = cellsList[index];
                        cellsList.RemoveAt(index);
                    }
                    // for collection
                    List<MazeCell> neighbors = new List<MazeCell>();
                    // cells that could potentially be neighbors
                    MazeCell[] potentialNeighbors = new MazeCell[]{
                        getCell(cell.x + 1, cell.y),
                        getCell(cell.x, cell.y + 1),
                        getCell(cell.x - 1, cell.y),
                        getCell(cell.x, cell.y - 1)
                    };
                    foreach (MazeCell other in potentialNeighbors)
                    {
                        // skip if outside, is a wall or is not opened
                        if (other == null || other.wall || !other.open) continue;
                        neighbors.Add(other);
                    }
                    if (neighbors.Count == 0) continue;
                    // get random cell
                    MazeCell selected = neighbors[random.Next(neighbors.Count)];
                    // add as neighbor
                    selected.open = false; // indicate cell closed for generation
                    cell.addNeighbor(selected);
                    cellsList.Add(cell);
                    cellsList.Add(selected);
                }
                updateGrid();
            }
            // draw the maze
            public void updateGrid()
            {
                char backChar = ' ', wallChar = 'X', cellChar = ' ';
                // fill background
                for (int x = 0; x < gridDimensionX; x++)
                {
                    for (int y = 0; y < gridDimensionY; y++)
                    {
                        mazeGrid[x, y] = backChar;
                    }
                }
                // build walls
                for (int x = 0; x < gridDimensionX; x++)
                {
                    for (int y = 0; y < gridDimensionY; y++)
                    {
                        if (x % 2 == 0 || y % 2 == 0)
                            mazeGrid[x, y] = wallChar;
                    }
                }
                // make meaningful representation
                for (int x = 0; x < dimensionX; x++)
                {
                    for (int y = 0; y < dimensionY; y++)
                    {
                        MazeCell current = getCell(x, y);
                        int gridX = x * 2 + 1, gridY = y * 2 + 1;
                        mazeGrid[gridX, gridY] = cellChar;
                        if (current.isCellBelowNeighbor())
                        {
                            mazeGrid[gridX, gridY + 1] = cellChar;
                        }
                        if (current.isCellRightNeighbor())
                        {
                            mazeGrid[gridX + 1, gridY] = cellChar;
                        }
                    }
                }

                // We create a clean grid ...
                searching = false;
                endOfSearch = false;
                fillGrid();
                // ... and copy into it the positions of obstacles
                // created by the maze construction algorithm
                for (int x = 0; x < gridDimensionX; x++)
                {
                    for (int y = 0; y < gridDimensionY; y++)
                    {
                        if (mazeGrid[x, y] == wallChar && grid[x, y] != ROBOT && grid[x, y] != TARGET)
                        {
                            grid[x, y] = OBST;
                        }
                    }
                }
            }

            int INFINITY = Int32.MaxValue; // The representation of the infinite
            int EMPTY = 0;  // empty cell
            int OBST = 1;  // cell with obstacle
            int ROBOT = 2;  // the position of the robot
            int TARGET = 3;  // the position of the target
            int FRONTIER = 4;  // cells that form the frontier (OPEN SET)
            int CLOSED = 5;  // cells that form the CLOSED SET
            int ROUTE = 6;  // cells that form the robot-to-target path

            // Messages to the user

            string msgDrawAndSelect = "\"Paint\" obstacles, then click 'Step-by-Step' or 'Animation'";
            string msgSelectStepByStepEtc = "Click 'Step-by-Step' or 'Animation' or 'Clear'";
            string msgNoSolution = "There is no path to the target !!!";

            /*
             **********************************************************
             *          Variables of class MazePanel
             **********************************************************
             */
            int rows = 10,           // the number of rows of the grid
                  columns = 10,           // the number of columns of the grid
                  squareSize;  // the cell size in pixels

            public List<Cell> openSet = new List<Cell>();// the OPEN SET
            public List<Cell> closedSet = new List<Cell>();// the CLOSED SET
            public List<Cell> graph = new List<Cell>();// the set of vertices of the graph
                                                       // to be explored by Dijkstra's algorithm

            public Cell robotStart; // the initial position of the robot
            public Cell targetPos;  // the position of the target

            public int[,] grid;        // the grid
            public bool found;       // flag that the goal was found
            public bool searching;   // flag that the search is in progress
            public bool endOfSearch; // flag that the search came to an end
            public int delay;           // time delay of animation (in msec)
            public int expanded;        // the number of nodes that have been expanded


            MainForm form = new MainForm(true);
            // the Timer which governs the execution speed of the animation
            public Timer timer;


            /**
            * Gives initial values ​​for the cells in the grid.
             * With the first click on button 'Clear' clears the data
             * of any search was performed (Frontier, Closed Set, Route)
             * and leaves intact the obstacles and the robot and target positions
             * in order to be able to run another algorithm
             * with the same data.
             * With the second click removes any obstacles also.
             */
            private void fillGrid()
            {
                if (searching || endOfSearch)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            if (grid[r, c] == FRONTIER || grid[r, c] == CLOSED || grid[r, c] == ROUTE)
                            {
                                grid[r, c] = EMPTY;
                            }
                            if (grid[r, c] == ROBOT)
                            {
                                robotStart = new Cell(r, c);
                            }
                            if (grid[r, c] == TARGET)
                            {
                                targetPos = new Cell(r, c);
                            }
                        }
                    }
                    searching = false;
                }
                else
                {
                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            grid[r, c] = EMPTY;
                        }
                    }
                    robotStart = new Cell(rows - 2, 1);
                    targetPos = new Cell(1, columns - 2);
                }
                if (aStar || greedy)
                {
                    robotStart.g = 0;
                    robotStart.h = 0;
                    robotStart.f = 0;
                }
                expanded = 0;
                found = false;
                searching = false;
                endOfSearch = false;

                // The first step of the other four algorithms is here
                // 1. OPEN SET: = [So], CLOSED SET: = []
                openSet.Clear();
                openSet.Add(robotStart);
                closedSet.Clear();

                grid[targetPos.row, targetPos.col] = TARGET;
                grid[robotStart.row, robotStart.col] = ROBOT;
                // message.setText(msgDrawAndSelect);
               
                //timer.Stop();
                Repaint();

            } // end fillGrid()

            public void Repaint()
            {
                this.squareSize = 500 / this.rows;
                form.mazeTiles = new PictureBox[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        form.mazeTiles[i, j] = new PictureBox();
                        //calculate size and location
                        int xPosition = (i * squareSize) + 13; //13 is padding from left
                        int yPosition = (j * squareSize) + 45; //45 is padding from top
                        form.mazeTiles[i, j].SetBounds(xPosition, yPosition, squareSize, squareSize);

                        if (grid[i, j] == EMPTY)
                        {
                            form.mazeTiles[i, j].BackColor = Color.White;
                        }
                        else if (grid[i, j] == ROBOT)
                        {
                            form.mazeTiles[i, j].BackColor = Color.Red;
                        }
                        else if (grid[i, j] == TARGET)
                        {
                            form.mazeTiles[i, j].BackColor = Color.Green;
                        }
                        else if (grid[i, j] == OBST)
                        {
                            form.mazeTiles[i, j].BackColor = Color.Black;
                        }
                        else if (grid[i, j] == FRONTIER)
                        {
                            form.mazeTiles[i, j].BackColor = Color.Blue;
                        }
                        else if (grid[i, j] == CLOSED)
                        {
                            form.mazeTiles[i, j].BackColor = Color.Cyan;
                        }
                        else if (grid[i, j] == ROUTE)
                        {
                            form.mazeTiles[i, j].BackColor = Color.Yellow;
                        }
                        EventHandler clickEvent = new EventHandler(PictureBox_Click);
                        form.mazeTiles[i, j].Click += clickEvent; // += used incase other events are used
                                                             //Add to controls to form (display picture box)
                        form.Controls.Add(form.mazeTiles[i, j]);
                    }
                }
            }

            private void PictureBox_Click(object sender, EventArgs e)
            {
                if(((PictureBox)sender).BackColor==Color.White)
                {
                    ((PictureBox)sender).BackColor = Color.Black;
                }
                else
                {
                    ((PictureBox)sender).BackColor = Color.White;
                }
            }
        }
        
    }

    


}
