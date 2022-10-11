namespace Boomwhackers
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
            this.button1 = new System.Windows.Forms.Button();
            this.jsonData = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 407);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Shrani projekt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveProject);
            // 
            // jsonData
            // 
            this.jsonData.Location = new System.Drawing.Point(101, 28);
            this.jsonData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.jsonData.Multiline = true;
            this.jsonData.Name = "jsonData";
            this.jsonData.Size = new System.Drawing.Size(539, 342);
            this.jsonData.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(625, 407);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Naloži projekt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LoadProject);
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(625, 377);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(159, 23);
            this.createProjectButton.TabIndex = 3;
            this.createProjectButton.Text = "Ustvari projekt";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.jsonData);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Boomwhackers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox jsonData;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button createProjectButton;
    }
}

