namespace Boomwhackers
{
    partial class StartingForm
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
            this.SuspendLayout();
            // 
            // startingLabel
            // 
            this.startingLabel.AutoSize = true;
            this.startingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F);
            this.startingLabel.Location = new System.Drawing.Point(10, 11);
            this.startingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startingLabel.Name = "startingLabel";
            this.startingLabel.Size = new System.Drawing.Size(71, 29);
            this.startingLabel.TabIndex = 0;
            this.startingLabel.Text = "Začni";
            // 
            // openProjectButton
            // 
            this.openProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openProjectButton.Location = new System.Drawing.Point(213, 57);
            this.openProjectButton.Margin = new System.Windows.Forms.Padding(2);
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Size = new System.Drawing.Size(189, 298);
            this.openProjectButton.TabIndex = 1;
            this.openProjectButton.Text = "Odpri projekt";
            this.openProjectButton.UseVisualStyleBackColor = true;
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // createProjectButton
            // 
            this.createProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createProjectButton.Location = new System.Drawing.Point(14, 57);
            this.createProjectButton.Margin = new System.Windows.Forms.Padding(2);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(185, 298);
            this.createProjectButton.TabIndex = 2;
            this.createProjectButton.Text = "Ustvari nov projekt";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // recentProjectsLabel
            // 
            this.recentProjectsLabel.AutoSize = true;
            this.recentProjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F);
            this.recentProjectsLabel.Location = new System.Drawing.Point(411, 11);
            this.recentProjectsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recentProjectsLabel.Name = "recentProjectsLabel";
            this.recentProjectsLabel.Size = new System.Drawing.Size(188, 29);
            this.recentProjectsLabel.TabIndex = 3;
            this.recentProjectsLabel.Text = "Nedavni projekti";
            // 
            // recentProjectsListBox
            // 
            this.recentProjectsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.recentProjectsListBox.FormattingEnabled = true;
            this.recentProjectsListBox.HorizontalScrollbar = true;
            this.recentProjectsListBox.ItemHeight = 17;
            this.recentProjectsListBox.Location = new System.Drawing.Point(416, 57);
            this.recentProjectsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.recentProjectsListBox.Name = "recentProjectsListBox";
            this.recentProjectsListBox.Size = new System.Drawing.Size(291, 293);
            this.recentProjectsListBox.TabIndex = 4;
            this.recentProjectsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.recentProjectsListBox_MouseDoubleClick);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 366);
            this.Controls.Add(this.recentProjectsListBox);
            this.Controls.Add(this.recentProjectsLabel);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.openProjectButton);
            this.Controls.Add(this.startingLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartingForm";
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
    }
}