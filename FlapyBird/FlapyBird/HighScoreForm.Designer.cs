﻿namespace FlapyBird
{
    partial class HighScoresForm
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
            this.listBoxHighScores = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxHighScores
            // 
            this.listBoxHighScores.BackColor = System.Drawing.Color.Cyan;
            this.listBoxHighScores.FormattingEnabled = true;
            this.listBoxHighScores.ItemHeight = 16;
            this.listBoxHighScores.Location = new System.Drawing.Point(16, 15);
            this.listBoxHighScores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxHighScores.Name = "listBoxHighScores";
            this.listBoxHighScores.Size = new System.Drawing.Size(372, 292);
            this.listBoxHighScores.TabIndex = 0;
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(405, 322);
            this.Controls.Add(this.listBoxHighScores);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HighScoresForm";
            this.Text = "High Scores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHighScores;
    }
}
