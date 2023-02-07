namespace Boomwhackers
{
    partial class StartingScreen
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
            this.startingLabel = new System.Windows.Forms.Label();
            this.openProjectButton = new System.Windows.Forms.Button();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.recentProjectsLabel = new System.Windows.Forms.Label();
            this.recentProjectsListBox = new System.Windows.Forms.ListBox();
            this.openRecentProjectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startingLabel
            // 
            this.startingLabel.AutoSize = true;
            this.startingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F);
            this.startingLabel.Location = new System.Drawing.Point(13, 13);
            this.startingLabel.Name = "startingLabel";
            this.startingLabel.Size = new System.Drawing.Size(84, 32);
            this.startingLabel.TabIndex = 0;
            this.startingLabel.Text = "Začni";
            // 
            // openProjectButton
            // 
            this.openProjectButton.Location = new System.Drawing.Point(19, 49);
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Size = new System.Drawing.Size(180, 23);
            this.openProjectButton.TabIndex = 1;
            this.openProjectButton.Text = "Odpri nov projekt";
            this.openProjectButton.UseVisualStyleBackColor = true;
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(19, 79);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(180, 23);
            this.createProjectButton.TabIndex = 2;
            this.createProjectButton.Text = "Ustvari nov projekt";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // recentProjectsLabel
            // 
            this.recentProjectsLabel.AutoSize = true;
            this.recentProjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F);
            this.recentProjectsLabel.Location = new System.Drawing.Point(548, 13);
            this.recentProjectsLabel.Name = "recentProjectsLabel";
            this.recentProjectsLabel.Size = new System.Drawing.Size(219, 32);
            this.recentProjectsLabel.TabIndex = 3;
            this.recentProjectsLabel.Text = "Nedavni projekti";
            // 
            // recentProjectsListBox
            // 
            this.recentProjectsListBox.FormattingEnabled = true;
            this.recentProjectsListBox.ItemHeight = 16;
            this.recentProjectsListBox.Location = new System.Drawing.Point(554, 49);
            this.recentProjectsListBox.Name = "recentProjectsListBox";
            this.recentProjectsListBox.Size = new System.Drawing.Size(213, 196);
            this.recentProjectsListBox.TabIndex = 4;
            // 
            // openRecentProjectButton
            // 
            this.openRecentProjectButton.Location = new System.Drawing.Point(554, 252);
            this.openRecentProjectButton.Name = "openRecentProjectButton";
            this.openRecentProjectButton.Size = new System.Drawing.Size(213, 23);
            this.openRecentProjectButton.TabIndex = 5;
            this.openRecentProjectButton.Text = "Odpri nedavni projekt";
            this.openRecentProjectButton.UseVisualStyleBackColor = true;
            // 
            // StartingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openRecentProjectButton);
            this.Controls.Add(this.recentProjectsListBox);
            this.Controls.Add(this.recentProjectsLabel);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.openProjectButton);
            this.Controls.Add(this.startingLabel);
            this.Name = "StartingScreen";
            this.Text = "StartingScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startingLabel;
        private System.Windows.Forms.Button openProjectButton;
        private System.Windows.Forms.Button createProjectButton;
        private System.Windows.Forms.Label recentProjectsLabel;
        private System.Windows.Forms.ListBox recentProjectsListBox;
        private System.Windows.Forms.Button openRecentProjectButton;
    }
}