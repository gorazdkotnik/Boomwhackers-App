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
            this.musicPlayerPanel = new System.Windows.Forms.Panel();
            this.noDataLabel = new System.Windows.Forms.Label();
            this.playNotesButton = new System.Windows.Forms.Button();
            this.pauseNotesButton = new System.Windows.Forms.Button();
            this.restartNotesButton = new System.Windows.Forms.Button();
            this.musicPlayerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // musicPlayerPanel
            // 
            this.musicPlayerPanel.AutoScroll = true;
            this.musicPlayerPanel.Controls.Add(this.noDataLabel);
            this.musicPlayerPanel.Location = new System.Drawing.Point(12, 69);
            this.musicPlayerPanel.Name = "musicPlayerPanel";
            this.musicPlayerPanel.Size = new System.Drawing.Size(776, 369);
            this.musicPlayerPanel.TabIndex = 0;
            // 
            // noDataLabel
            // 
            this.noDataLabel.AutoSize = true;
            this.noDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.noDataLabel.Location = new System.Drawing.Point(155, 0);
            this.noDataLabel.Name = "noDataLabel";
            this.noDataLabel.Size = new System.Drawing.Size(488, 32);
            this.noDataLabel.TabIndex = 0;
            this.noDataLabel.Text = "Projekt nima podatkov (not) za prikaz!";
            this.noDataLabel.Visible = false;
            // 
            // playNotesButton
            // 
            this.playNotesButton.Location = new System.Drawing.Point(12, 13);
            this.playNotesButton.Name = "playNotesButton";
            this.playNotesButton.Size = new System.Drawing.Size(134, 33);
            this.playNotesButton.TabIndex = 1;
            this.playNotesButton.Text = "Predvajaj note";
            this.playNotesButton.UseVisualStyleBackColor = true;
            this.playNotesButton.Click += new System.EventHandler(this.playNotesButton_Click);
            // 
            // pauseNotesButton
            // 
            this.pauseNotesButton.Location = new System.Drawing.Point(152, 13);
            this.pauseNotesButton.Name = "pauseNotesButton";
            this.pauseNotesButton.Size = new System.Drawing.Size(160, 33);
            this.pauseNotesButton.TabIndex = 2;
            this.pauseNotesButton.Text = "Ustavi predvajanje";
            this.pauseNotesButton.UseVisualStyleBackColor = true;
            this.pauseNotesButton.Click += new System.EventHandler(this.pauseNotesButton_Click);
            // 
            // restartNotesButton
            // 
            this.restartNotesButton.Location = new System.Drawing.Point(319, 13);
            this.restartNotesButton.Name = "restartNotesButton";
            this.restartNotesButton.Size = new System.Drawing.Size(178, 33);
            this.restartNotesButton.TabIndex = 3;
            this.restartNotesButton.Text = "Predvajaj od začetka";
            this.restartNotesButton.UseVisualStyleBackColor = true;
            this.restartNotesButton.Click += new System.EventHandler(this.restartNotesButton_Click);
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restartNotesButton);
            this.Controls.Add(this.pauseNotesButton);
            this.Controls.Add(this.playNotesButton);
            this.Controls.Add(this.musicPlayerPanel);
            this.Name = "MusicPlayer";
            this.Text = "Predvajalnik not";
            this.musicPlayerPanel.ResumeLayout(false);
            this.musicPlayerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel musicPlayerPanel;
        private System.Windows.Forms.Label noDataLabel;
        private System.Windows.Forms.Button playNotesButton;
        private System.Windows.Forms.Button pauseNotesButton;
        private System.Windows.Forms.Button restartNotesButton;
    }
}