namespace Boomwhackers
{
    partial class AddNoteType
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
            this.noteName = new System.Windows.Forms.TextBox();
            this.ColorPicker = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectedNoteSoundLabel = new System.Windows.Forms.Label();
            this.selectNoteSoundButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // noteName
            // 
            this.noteName.Location = new System.Drawing.Point(130, 17);
            this.noteName.Name = "noteName";
            this.noteName.Size = new System.Drawing.Size(199, 20);
            this.noteName.TabIndex = 0;
            this.noteName.Text = "\r\n";
            // 
            // ColorPicker
            // 
            this.ColorPicker.Location = new System.Drawing.Point(143, 119);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(87, 27);
            this.ColorPicker.TabIndex = 1;
            this.ColorPicker.Text = "Barva note";
            this.ColorPicker.UseVisualStyleBackColor = true;
            this.ColorPicker.Click += new System.EventHandler(this.ColorPicker_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(143, 172);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(87, 38);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Dodaj";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ime note";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectedNoteSoundLabel);
            this.panel1.Controls.Add(this.selectNoteSoundButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.noteName);
            this.panel1.Controls.Add(this.Submit);
            this.panel1.Controls.Add(this.ColorPicker);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 213);
            this.panel1.TabIndex = 4;
            // 
            // selectedNoteSoundLabel
            // 
            this.selectedNoteSoundLabel.AutoSize = true;
            this.selectedNoteSoundLabel.Location = new System.Drawing.Point(181, 62);
            this.selectedNoteSoundLabel.Name = "selectedNoteSoundLabel";
            this.selectedNoteSoundLabel.Size = new System.Drawing.Size(101, 13);
            this.selectedNoteSoundLabel.TabIndex = 5;
            this.selectedNoteSoundLabel.Text = "Izbrano: Brez zvoka";
            // 
            // selectNoteSoundButton
            // 
            this.selectNoteSoundButton.Location = new System.Drawing.Point(79, 55);
            this.selectNoteSoundButton.Name = "selectNoteSoundButton";
            this.selectNoteSoundButton.Size = new System.Drawing.Size(96, 27);
            this.selectNoteSoundButton.TabIndex = 4;
            this.selectNoteSoundButton.Text = "Izberi zvok note";
            this.selectNoteSoundButton.UseVisualStyleBackColor = true;
            this.selectNoteSoundButton.Click += new System.EventHandler(this.selectNoteSoundButton_Click);
            // 
            // AddNoteType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 238);
            this.Controls.Add(this.panel1);
            this.Name = "AddNoteType";
            this.Text = "Dodajanje note";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox noteName;
        private System.Windows.Forms.Button ColorPicker;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectNoteSoundButton;
        private System.Windows.Forms.Label selectedNoteSoundLabel;
    }
}