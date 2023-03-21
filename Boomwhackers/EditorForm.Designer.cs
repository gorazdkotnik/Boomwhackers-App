namespace Boomwhackers
{
    partial class EditorForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewProjectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenProjectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProjectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProjectAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewProjectItem,
            this.OpenProjectItem,
            this.SaveProjectItem,
            this.SaveProjectAsItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.testToolStripMenuItem.Text = "Datoteka";
            // 
            // NewProjectItem
            // 
            this.NewProjectItem.Name = "NewProjectItem";
            this.NewProjectItem.Size = new System.Drawing.Size(176, 22);
            this.NewProjectItem.Text = "Nov projekt";
            this.NewProjectItem.Click += new System.EventHandler(this.NewProjectItem_Click);
            // 
            // OpenProjectItem
            // 
            this.OpenProjectItem.Name = "OpenProjectItem";
            this.OpenProjectItem.Size = new System.Drawing.Size(176, 22);
            this.OpenProjectItem.Text = "Odpri projekt";
            this.OpenProjectItem.Click += new System.EventHandler(this.LoacProject_click);
            // 
            // SaveProjectItem
            // 
            this.SaveProjectItem.Name = "SaveProjectItem";
            this.SaveProjectItem.Size = new System.Drawing.Size(176, 22);
            this.SaveProjectItem.Text = "Shrani projekt";
            this.SaveProjectItem.Click += new System.EventHandler(this.SaveProjectItem_Click);
            // 
            // SaveProjectAsItem
            // 
            this.SaveProjectAsItem.Name = "SaveProjectAsItem";
            this.SaveProjectAsItem.Size = new System.Drawing.Size(176, 22);
            this.SaveProjectAsItem.Text = "Shrani projekt kot...";
            this.SaveProjectAsItem.Click += new System.EventHandler(this.SaveProjectAsItem_Click);
            // 
            // editorPanel
            // 
            this.editorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorPanel.AutoScroll = true;
            this.editorPanel.AutoScrollMargin = new System.Drawing.Size(500, 500);
            this.editorPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editorPanel.Location = new System.Drawing.Point(12, 27);
            this.editorPanel.Name = "editorPanel";
            this.editorPanel.Size = new System.Drawing.Size(1086, 417);
            this.editorPanel.TabIndex = 7;
            this.editorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseDown);
            this.editorPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseMove);
            this.editorPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Editor_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Predvajaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openMusicPlayer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1110, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 539);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editorPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditorForm";
            this.Text = "Boomwhackers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenProjectItem;
        private System.Windows.Forms.ToolStripMenuItem SaveProjectItem;
        private System.Windows.Forms.ToolStripMenuItem SaveProjectAsItem;
        private System.Windows.Forms.ToolStripMenuItem NewProjectItem;
        private System.Windows.Forms.Panel editorPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

