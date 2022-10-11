namespace Boomwhackers
{
    partial class Form2
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
            this.formTitleLabel = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.projectRootLabel = new System.Windows.Forms.Label();
            this.projectRootTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formTitleLabel
            // 
            this.formTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.formTitleLabel.Name = "formTitleLabel";
            this.formTitleLabel.Size = new System.Drawing.Size(800, 23);
            this.formTitleLabel.TabIndex = 0;
            this.formTitleLabel.Text = "Ustvari nov projekt";
            this.formTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(12, 90);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(349, 22);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Location = new System.Drawing.Point(13, 68);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(81, 16);
            this.projectNameLabel.TabIndex = 2;
            this.projectNameLabel.Text = "Ime projekta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // projectRootLabel
            // 
            this.projectRootLabel.AutoSize = true;
            this.projectRootLabel.Location = new System.Drawing.Point(16, 145);
            this.projectRootLabel.Name = "projectRootLabel";
            this.projectRootLabel.Size = new System.Drawing.Size(110, 16);
            this.projectRootLabel.TabIndex = 4;
            this.projectRootLabel.Text = "Lokacija projekta";
            // 
            // projectRootTextBox
            // 
            this.projectRootTextBox.Enabled = false;
            this.projectRootTextBox.Location = new System.Drawing.Point(12, 165);
            this.projectRootTextBox.Name = "projectRootTextBox";
            this.projectRootTextBox.Size = new System.Drawing.Size(349, 22);
            this.projectRootTextBox.TabIndex = 5;
            // 
            // folderBrowserButton
            // 
            this.folderBrowserButton.Location = new System.Drawing.Point(368, 165);
            this.folderBrowserButton.Name = "folderBrowserButton";
            this.folderBrowserButton.Size = new System.Drawing.Size(131, 23);
            this.folderBrowserButton.TabIndex = 6;
            this.folderBrowserButton.Text = "Izberite lokacijo";
            this.folderBrowserButton.UseVisualStyleBackColor = true;
            this.folderBrowserButton.Click += new System.EventHandler(this.folderBrowserButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.folderBrowserButton);
            this.Controls.Add(this.projectRootTextBox);
            this.Controls.Add(this.projectRootLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.formTitleLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formTitleLabel;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label projectRootLabel;
        private System.Windows.Forms.TextBox projectRootTextBox;
        private System.Windows.Forms.Button folderBrowserButton;
    }
}