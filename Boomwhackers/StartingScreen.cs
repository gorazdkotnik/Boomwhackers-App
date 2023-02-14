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
    public partial class StartingScreen : Form
    {
        Form1 mainScreen;
        RecentProjectData recentProjectData;

        public StartingScreen()
        {
            InitializeComponent();
        }

        public StartingScreen(Form1 mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;
            recentProjectData = RecentProjectData.Instance;
            recentProjectData.RecentProjectsListBox = recentProjectsListBox
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            mainScreen.createProjectButton_Click(sender, e);
        }
        
        private void openProjectButton_Click(object sender, EventArgs e)
        {
            mainScreen.LoadProject(sender, e);
        }

        private void openRecentProjectButton_Click(object sender, EventArgs e)
        {
            if (recentProjectsListBox.Text != "")
            {
                mainScreen.LoadProject(recentProjectsListBox.Text);
            } else
            {
                MessageBox.Show("Izberite projekt iz seznama.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
