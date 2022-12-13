namespace Boomwhackers
{
    partial class MusicPlayer
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
            this.components = new System.ComponentModel.Container();
            this.musicPlayerPanel = new System.Windows.Forms.Panel();
            this.noDataLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.noteTimer = new System.Windows.Forms.Timer(this.components);
            this.pauseButton = new System.Windows.Forms.Button();
            this.musicPlayerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // musicPlayerPanel
            // 
            this.musicPlayerPanel.Controls.Add(this.noDataLabel);
            this.musicPlayerPanel.Location = new System.Drawing.Point(9, 56);
            this.musicPlayerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.musicPlayerPanel.Name = "musicPlayerPanel";
            this.musicPlayerPanel.Size = new System.Drawing.Size(582, 300);
            this.musicPlayerPanel.TabIndex = 0;
            // 
            // noDataLabel
            // 
            this.noDataLabel.AutoSize = true;
            this.noDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.noDataLabel.Location = new System.Drawing.Point(116, 0);
            this.noDataLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noDataLabel.Name = "noDataLabel";
            this.noDataLabel.Size = new System.Drawing.Size(377, 26);
            this.noDataLabel.TabIndex = 0;
            this.noDataLabel.Text = "Projekt nima podatkov (not) za prikaz!";
            this.noDataLabel.Visible = false;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(9, 11);
            this.playButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(49, 27);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Začni";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(112, 11);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(54, 27);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Ustavi";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // noteTimer
            // 
            this.noteTimer.Interval = 10;
            this.noteTimer.Tick += new System.EventHandler(this.noteTimer_Tick);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(62, 11);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(46, 27);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pavza";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.musicPlayerPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MusicPlayer";
            this.Text = "Predvajalnik not";
            this.musicPlayerPanel.ResumeLayout(false);
            this.musicPlayerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel musicPlayerPanel;
        private System.Windows.Forms.Label noDataLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Timer noteTimer;
        private System.Windows.Forms.Button pauseButton;
    }
}