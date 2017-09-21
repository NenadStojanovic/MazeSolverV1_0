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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.solveMazeBtn = new System.Windows.Forms.Button();
            this.Algorithms = new System.Windows.Forms.GroupBox();
            this.dijkstraRB = new System.Windows.Forms.RadioButton();
            this.greedyRB = new System.Windows.Forms.RadioButton();
            this.aStarRB = new System.Windows.Forms.RadioButton();
            this.bfsRB = new System.Windows.Forms.RadioButton();
            this.dfsRB = new System.Windows.Forms.RadioButton();
            this.generateMazeBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.newGridBtn = new System.Windows.Forms.Button();
            this.colsTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rowsTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outputMsgLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelSourceLink = new System.Windows.Forms.Label();
            this.SourcePathBtn = new System.Windows.Forms.Button();
            this.labelSourcePath = new System.Windows.Forms.Label();
            this.lbSource = new System.Windows.Forms.ListBox();
            this.fileSystemWatcherSource = new System.IO.FileSystemWatcher();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.Algorithms.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MazeGridGB
            // 
            this.MazeGridGB.Location = new System.Drawing.Point(13, 13);
            this.MazeGridGB.Name = "MazeGridGB";
            this.MazeGridGB.Size = new System.Drawing.Size(350, 350);
            this.MazeGridGB.TabIndex = 0;
            this.MazeGridGB.TabStop = false;
            this.MazeGridGB.Text = "Maze Grid";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.solveMazeBtn);
            this.groupBox2.Controls.Add(this.Algorithms);
            this.groupBox2.Controls.Add(this.generateMazeBtn);
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(7, 299);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(171, 45);
            this.trackBar1.TabIndex = 9;
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
            this.dijkstraRB.Location = new System.Drawing.Point(7, 89);
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
            this.aStarRB.Location = new System.Drawing.Point(6, 55);
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
            // generateMazeBtn
            // 
            this.generateMazeBtn.Location = new System.Drawing.Point(10, 103);
            this.generateMazeBtn.Name = "generateMazeBtn";
            this.generateMazeBtn.Size = new System.Drawing.Size(156, 23);
            this.generateMazeBtn.TabIndex = 6;
            this.generateMazeBtn.Text = "Generate Maze";
            this.generateMazeBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(91, 74);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 5;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // newGridBtn
            // 
            this.newGridBtn.Location = new System.Drawing.Point(10, 74);
            this.newGridBtn.Name = "newGridBtn";
            this.newGridBtn.Size = new System.Drawing.Size(75, 23);
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
            this.groupBox3.Controls.Add(this.outputMsgLabel);
            this.groupBox3.Location = new System.Drawing.Point(13, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 85);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // outputMsgLabel
            // 
            this.outputMsgLabel.AutoSize = true;
            this.outputMsgLabel.Location = new System.Drawing.Point(134, 42);
            this.outputMsgLabel.Name = "outputMsgLabel";
            this.outputMsgLabel.Size = new System.Drawing.Size(19, 13);
            this.outputMsgLabel.TabIndex = 12;
            this.outputMsgLabel.Text = "***";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(369, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 85);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Legend";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelSourceLink);
            this.groupBox5.Controls.Add(this.SourcePathBtn);
            this.groupBox5.Controls.Add(this.labelSourcePath);
            this.groupBox5.Controls.Add(this.lbSource);
            this.groupBox5.Location = new System.Drawing.Point(568, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(206, 441);
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
            this.lbSource.Size = new System.Drawing.Size(194, 355);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 461);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MazeGridGB);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.Algorithms.ResumeLayout(false);
            this.Algorithms.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcherSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MazeGridGB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button solveMazeBtn;
        private System.Windows.Forms.GroupBox Algorithms;
        private System.Windows.Forms.RadioButton dijkstraRB;
        private System.Windows.Forms.RadioButton greedyRB;
        private System.Windows.Forms.RadioButton aStarRB;
        private System.Windows.Forms.RadioButton bfsRB;
        private System.Windows.Forms.RadioButton dfsRB;
        private System.Windows.Forms.Button generateMazeBtn;
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
    }
}

