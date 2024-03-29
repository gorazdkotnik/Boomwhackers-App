﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boomwhackers
{
    public partial class CreateProject : Form
    {
        public BoomProject project { get; set; }

        public CreateProject()
        {
            InitializeComponent();
        }

        private void folderBrowserButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                projectRootTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string projectName = projectNameTextBox.Text;
            string projectRoot = projectRootTextBox.Text;

            if (projectName.Trim() == "")
            {
                MessageBox.Show("Ime projekta ne sme biti prazno.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectRoot.Trim() == "")
            {
                MessageBox.Show("Pot do projekta ne sme biti prazna.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                project = new BoomProject();

                string location = projectRoot + "\\" + projectName + ".boom";
                project.SaveData(location);

                RecentProjectsData.AddProject(new RecentProject(location));

                DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
