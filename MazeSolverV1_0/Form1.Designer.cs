﻿namespace MazeSolverV1_0
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsTB = new System.Windows.Forms.TextBox();
            this.colsTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newGridBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.generateMazeBtn = new System.Windows.Forms.Button();
            this.Algorithms = new System.Windows.Forms.GroupBox();
            this.dfsRB = new System.Windows.Forms.RadioButton();
            this.bfsRB = new System.Windows.Forms.RadioButton();
            this.aStarRB = new System.Windows.Forms.RadioButton();
            this.greedyRB = new System.Windows.Forms.RadioButton();
            this.dijkstraRB = new System.Windows.Forms.RadioButton();
            this.solveMazeBtn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outputMsgLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.Algorithms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 350);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Grid";
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
            this.groupBox2.Location = new System.Drawing.Point(424, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Menu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# of rows (5-83)";
            // 
            // rowsTB
            // 
            this.rowsTB.Location = new System.Drawing.Point(109, 13);
            this.rowsTB.Name = "rowsTB";
            this.rowsTB.Size = new System.Drawing.Size(49, 20);
            this.rowsTB.TabIndex = 1;
            // 
            // colsTB
            // 
            this.colsTB.Location = new System.Drawing.Point(109, 37);
            this.colsTB.Name = "colsTB";
            this.colsTB.Size = new System.Drawing.Size(49, 20);
            this.colsTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# of columns (5-83)";
            // 
            // newGridBtn
            // 
            this.newGridBtn.Location = new System.Drawing.Point(10, 74);
            this.newGridBtn.Name = "newGridBtn";
            this.newGridBtn.Size = new System.Drawing.Size(75, 23);
            this.newGridBtn.TabIndex = 4;
            this.newGridBtn.Text = "New Grid";
            this.newGridBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(91, 74);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 5;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(7, 299);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(171, 45);
            this.trackBar1.TabIndex = 9;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outputMsgLabel);
            this.groupBox3.Location = new System.Drawing.Point(13, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 85);
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
            this.groupBox4.Location = new System.Drawing.Point(416, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 85);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Legend";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 467);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Algorithms.ResumeLayout(false);
            this.Algorithms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}

