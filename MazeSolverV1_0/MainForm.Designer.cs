namespace MazeSolverV1_0
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MazeGridGB = new System.Windows.Forms.GroupBox();
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DelayTrackBar = new System.Windows.Forms.TrackBar();
            this.solveMazeBtn = new System.Windows.Forms.Button();
            this.Algorithms = new System.Windows.Forms.GroupBox();
            this.dijkstraRB = new System.Windows.Forms.RadioButton();
            this.greedyRB = new System.Windows.Forms.RadioButton();
            this.aStarRB = new System.Windows.Forms.RadioButton();
            this.bfsRB = new System.Windows.Forms.RadioButton();
            this.dfsRB = new System.Windows.Forms.RadioButton();
            this.clearBtn = new System.Windows.Forms.Button();
            this.newGridBtn = new System.Windows.Forms.Button();
            this.colsTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rowsTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.KoordinatesLabel = new System.Windows.Forms.Label();
            this.timeElapsedLabel = new System.Windows.Forms.Label();
            this.outputMsgLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelSourceLink = new System.Windows.Forms.Label();
            this.SourcePathBtn = new System.Windows.Forms.Button();
            this.labelSourcePath = new System.Windows.Forms.Label();
            this.lbSource = new System.Windows.Forms.ListBox();
            this.fileSystemWatcherSource = new System.IO.FileSystemWatcher();
            this.KeyGB = new System.Windows.Forms.GroupBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.MazeGridGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayTrackBar)).BeginInit();
            this.Algorithms.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherSource)).BeginInit();
            this.KeyGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // MazeGridGB
            // 
            this.MazeGridGB.Controls.Add(this.mazePictureBox);
            this.MazeGridGB.Location = new System.Drawing.Point(13, 13);
            this.MazeGridGB.Name = "MazeGridGB";
            this.MazeGridGB.Size = new System.Drawing.Size(350, 350);
            this.MazeGridGB.TabIndex = 0;
            this.MazeGridGB.TabStop = false;
            this.MazeGridGB.Text = "Maze Grid";
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Location = new System.Drawing.Point(6, 20);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(325, 325);
            this.mazePictureBox.TabIndex = 0;
            this.mazePictureBox.TabStop = false;
            this.mazePictureBox.Visible = false;
            this.mazePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mazePictureBox_MouseClick);
            this.mazePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mazePictureBox_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.DelayTrackBar);
            this.groupBox2.Controls.Add(this.solveMazeBtn);
            this.groupBox2.Controls.Add(this.Algorithms);
            this.groupBox2.Controls.Add(this.clearBtn);
            this.groupBox2.Controls.Add(this.newGridBtn);
            this.groupBox2.Controls.Add(this.colsTB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rowsTB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(369, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Menu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Animation Speed";
            // 
            // DelayTrackBar
            // 
            this.DelayTrackBar.Location = new System.Drawing.Point(7, 299);
            this.DelayTrackBar.Maximum = 100;
            this.DelayTrackBar.Name = "DelayTrackBar";
            this.DelayTrackBar.Size = new System.Drawing.Size(171, 45);
            this.DelayTrackBar.TabIndex = 9;
            // 
            // solveMazeBtn
            // 
            this.solveMazeBtn.BackColor = System.Drawing.Color.SpringGreen;
            this.solveMazeBtn.Location = new System.Drawing.Point(6, 251);
            this.solveMazeBtn.Name = "solveMazeBtn";
            this.solveMazeBtn.Size = new System.Drawing.Size(180, 23);
            this.solveMazeBtn.TabIndex = 8;
            this.solveMazeBtn.Text = "Solve Maze";
            this.solveMazeBtn.UseVisualStyleBackColor = false;
            this.solveMazeBtn.Click += new System.EventHandler(this.solveMazeBtn_Click);
            // 
            // Algorithms
            // 
            this.Algorithms.Controls.Add(this.dijkstraRB);
            this.Algorithms.Controls.Add(this.greedyRB);
            this.Algorithms.Controls.Add(this.aStarRB);
            this.Algorithms.Controls.Add(this.bfsRB);
            this.Algorithms.Controls.Add(this.dfsRB);
            this.Algorithms.Location = new System.Drawing.Point(7, 133);
            this.Algorithms.Name = "Algorithms";
            this.Algorithms.Size = new System.Drawing.Size(179, 112);
            this.Algorithms.TabIndex = 7;
            this.Algorithms.TabStop = false;
            this.Algorithms.Text = "Algorithms";
            // 
            // dijkstraRB
            // 
            this.dijkstraRB.AutoSize = true;
            this.dijkstraRB.Location = new System.Drawing.Point(7, 55);
            this.dijkstraRB.Name = "dijkstraRB";
            this.dijkstraRB.Size = new System.Drawing.Size(60, 17);
            this.dijkstraRB.TabIndex = 4;
            this.dijkstraRB.TabStop = true;
            this.dijkstraRB.Text = "Dijkstra";
            this.dijkstraRB.UseVisualStyleBackColor = true;
            // 
            // greedyRB
            // 
            this.greedyRB.AutoSize = true;
            this.greedyRB.Location = new System.Drawing.Point(101, 55);
            this.greedyRB.Name = "greedyRB";
            this.greedyRB.Size = new System.Drawing.Size(59, 17);
            this.greedyRB.TabIndex = 3;
            this.greedyRB.TabStop = true;
            this.greedyRB.Text = "Greedy";
            this.greedyRB.UseVisualStyleBackColor = true;
            // 
            // aStarRB
            // 
            this.aStarRB.AutoSize = true;
            this.aStarRB.Location = new System.Drawing.Point(7, 89);
            this.aStarRB.Name = "aStarRB";
            this.aStarRB.Size = new System.Drawing.Size(36, 17);
            this.aStarRB.TabIndex = 2;
            this.aStarRB.TabStop = true;
            this.aStarRB.Text = "A*";
            this.aStarRB.UseVisualStyleBackColor = true;
            // 
            // bfsRB
            // 
            this.bfsRB.AutoSize = true;
            this.bfsRB.Location = new System.Drawing.Point(102, 20);
            this.bfsRB.Name = "bfsRB";
            this.bfsRB.Size = new System.Drawing.Size(45, 17);
            this.bfsRB.TabIndex = 1;
            this.bfsRB.TabStop = true;
            this.bfsRB.Text = "BFS";
            this.bfsRB.UseVisualStyleBackColor = true;
            // 
            // dfsRB
            // 
            this.dfsRB.AutoSize = true;
            this.dfsRB.Location = new System.Drawing.Point(7, 20);
            this.dfsRB.Name = "dfsRB";
            this.dfsRB.Size = new System.Drawing.Size(46, 17);
            this.dfsRB.TabIndex = 0;
            this.dfsRB.TabStop = true;
            this.dfsRB.Text = "DFS";
            this.dfsRB.UseVisualStyleBackColor = true;
            this.dfsRB.CheckedChanged += new System.EventHandler(this.dfsRB_CheckedChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(10, 104);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(176, 23);
            this.clearBtn.TabIndex = 5;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // newGridBtn
            // 
            this.newGridBtn.Location = new System.Drawing.Point(10, 74);
            this.newGridBtn.Name = "newGridBtn";
            this.newGridBtn.Size = new System.Drawing.Size(176, 23);
            this.newGridBtn.TabIndex = 4;
            this.newGridBtn.Text = "New Grid";
            this.newGridBtn.UseVisualStyleBackColor = true;
            this.newGridBtn.Click += new System.EventHandler(this.newGridBtn_Click);
            // 
            // colsTB
            // 
            this.colsTB.Location = new System.Drawing.Point(114, 37);
            this.colsTB.Name = "colsTB";
            this.colsTB.Size = new System.Drawing.Size(49, 20);
            this.colsTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# of columns (5-83):";
            // 
            // rowsTB
            // 
            this.rowsTB.Location = new System.Drawing.Point(114, 13);
            this.rowsTB.Name = "rowsTB";
            this.rowsTB.Size = new System.Drawing.Size(49, 20);
            this.rowsTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# of rows (5-83):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.KoordinatesLabel);
            this.groupBox3.Controls.Add(this.timeElapsedLabel);
            this.groupBox3.Controls.Add(this.outputMsgLabel);
            this.groupBox3.Location = new System.Drawing.Point(13, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 114);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // KoordinatesLabel
            // 
            this.KoordinatesLabel.AutoSize = true;
            this.KoordinatesLabel.Location = new System.Drawing.Point(242, 51);
            this.KoordinatesLabel.Name = "KoordinatesLabel";
            this.KoordinatesLabel.Size = new System.Drawing.Size(0, 13);
            this.KoordinatesLabel.TabIndex = 14;
            // 
            // timeElapsedLabel
            // 
            this.timeElapsedLabel.AutoSize = true;
            this.timeElapsedLabel.Location = new System.Drawing.Point(6, 52);
            this.timeElapsedLabel.Name = "timeElapsedLabel";
            this.timeElapsedLabel.Size = new System.Drawing.Size(0, 13);
            this.timeElapsedLabel.TabIndex = 13;
            // 
            // outputMsgLabel
            // 
            this.outputMsgLabel.AutoSize = true;
            this.outputMsgLabel.Location = new System.Drawing.Point(6, 39);
            this.outputMsgLabel.Name = "outputMsgLabel";
            this.outputMsgLabel.Size = new System.Drawing.Size(0, 13);
            this.outputMsgLabel.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.pictureBox7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.pictureBox5);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.pictureBox6);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.pictureBox4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(369, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 114);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Legend";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(7, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelSourceLink);
            this.groupBox5.Controls.Add(this.SourcePathBtn);
            this.groupBox5.Controls.Add(this.labelSourcePath);
            this.groupBox5.Controls.Add(this.lbSource);
            this.groupBox5.Location = new System.Drawing.Point(568, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(206, 470);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Files Preview";
            // 
            // labelSourceLink
            // 
            this.labelSourceLink.AutoSize = true;
            this.labelSourceLink.Location = new System.Drawing.Point(3, 44);
            this.labelSourceLink.Name = "labelSourceLink";
            this.labelSourceLink.Size = new System.Drawing.Size(69, 13);
            this.labelSourceLink.TabIndex = 11;
            this.labelSourceLink.Text = "Not Selected";
            // 
            // SourcePathBtn
            // 
            this.SourcePathBtn.Location = new System.Drawing.Point(78, 13);
            this.SourcePathBtn.Name = "SourcePathBtn";
            this.SourcePathBtn.Size = new System.Drawing.Size(75, 23);
            this.SourcePathBtn.TabIndex = 9;
            this.SourcePathBtn.Text = "Choose...";
            this.SourcePathBtn.UseVisualStyleBackColor = true;
            this.SourcePathBtn.Click += new System.EventHandler(this.SourcePathBtn_Click);
            // 
            // labelSourcePath
            // 
            this.labelSourcePath.AutoSize = true;
            this.labelSourcePath.Location = new System.Drawing.Point(6, 20);
            this.labelSourcePath.Name = "labelSourcePath";
            this.labelSourcePath.Size = new System.Drawing.Size(66, 13);
            this.labelSourcePath.TabIndex = 7;
            this.labelSourcePath.Text = "SourcePath:";
            // 
            // lbSource
            // 
            this.lbSource.FormattingEnabled = true;
            this.lbSource.Location = new System.Drawing.Point(6, 78);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(194, 381);
            this.lbSource.TabIndex = 1;
            this.lbSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSource_MouseDoubleClick);
            // 
            // fileSystemWatcherSource
            // 
            this.fileSystemWatcherSource.EnableRaisingEvents = true;
            this.fileSystemWatcherSource.SynchronizingObject = this;
            this.fileSystemWatcherSource.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcherSource_Created);
            this.fileSystemWatcherSource.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcherSource_Deleted);
            // 
            // KeyGB
            // 
            this.KeyGB.Controls.Add(this.KeyLabel);
            this.KeyGB.Location = new System.Drawing.Point(8, 489);
            this.KeyGB.Name = "KeyGB";
            this.KeyGB.Size = new System.Drawing.Size(766, 61);
            this.KeyGB.TabIndex = 15;
            this.KeyGB.TabStop = false;
            this.KeyGB.Text = "Key";
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyLabel.Location = new System.Drawing.Point(6, 20);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(0, 20);
            this.KeyLabel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Empty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Obsticle";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(83, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Target";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Green;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(83, 42);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Start";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Red;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(7, 42);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Frontier";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Blue;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(83, 64);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Closed";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Cyan;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(7, 64);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Path";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(7, 86);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 558);
            this.Controls.Add(this.KeyGB);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MazeGridGB);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.MazeGridGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayTrackBar)).EndInit();
            this.Algorithms.ResumeLayout(false);
            this.Algorithms.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherSource)).EndInit();
            this.KeyGB.ResumeLayout(false);
            this.KeyGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MazeGridGB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar DelayTrackBar;
        private System.Windows.Forms.Button solveMazeBtn;
        private System.Windows.Forms.GroupBox Algorithms;
        private System.Windows.Forms.RadioButton dijkstraRB;
        private System.Windows.Forms.RadioButton greedyRB;
        private System.Windows.Forms.RadioButton aStarRB;
        private System.Windows.Forms.RadioButton bfsRB;
        private System.Windows.Forms.RadioButton dfsRB;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button newGridBtn;
        private System.Windows.Forms.TextBox colsTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rowsTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label outputMsgLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelSourceLink;
        private System.Windows.Forms.Button SourcePathBtn;
        private System.Windows.Forms.Label labelSourcePath;
        private System.Windows.Forms.ListBox lbSource;
        private System.IO.FileSystemWatcher fileSystemWatcherSource;
        private System.Windows.Forms.PictureBox mazePictureBox;
        private System.Windows.Forms.Label timeElapsedLabel;
        private System.Windows.Forms.Label KoordinatesLabel;
        private System.Windows.Forms.GroupBox KeyGB;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
    }
}

