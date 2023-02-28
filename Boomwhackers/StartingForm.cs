using System;
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
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();

            FillRecentProjects();
        }

        private void FillRecentProjects()
        {
            recentProjectsListBox.Items.Clear();

            for (int i = RecentProjectsData.RecentProjects.Count() - 1; i >= 0; i--)
            {
                recentProjectsListBox.Items.Add(RecentProjectsData.RecentProjects[i].Location);
            }
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            CreateProject form2 = new CreateProject();

            if (form2.ShowDialog() == DialogResult.OK)
            {
                BoomProject frm2Project = form2.project;

                if (frm2Project != null)
                {
                    InitializeEditor(frm2Project);
                }
            }
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            BoomProject project = ProjectManager.LoadProjectDialog();

            if (project != null)
            {
                InitializeEditor(project);
            }
        }

        private void recentProjectsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = recentProjectsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                BoomProject chosenProject = ProjectManager.LoadProject(recentProjectsListBox.SelectedItem.ToString());
                InitializeEditor(chosenProject);
            }
        }

        void InitializeEditor(BoomProject project)
        {
            
        }
    }
}
