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
            mainScreen.FormClosing += MainScreen_FormClosing;

            recentProjectData = RecentProjectData.Instance;
            recentProjectData.RecentProjectsListBox = recentProjectsListBox;
        }

        private void ShowMainScreen()
        {
            mainScreen.Visible = true;
            this.Visible = false;
        }

        private void HideMainScreen()
        {
            mainScreen.Visible = false;
            this.Visible = true;
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideMainScreen();
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            mainScreen.createProjectButton_Click(sender, e);
        }
        
        private void openProjectButton_Click(object sender, EventArgs e)
        {
            mainScreen.LoadProject(sender, e);
            ShowMainScreen();
        }

        private void openRecentProjectButton_Click(object sender, EventArgs e)
        {
            if (recentProjectsListBox.Text != "")
            {
                mainScreen.LoadProject(recentProjectsListBox.Text);
                ShowMainScreen();
            } else
            {
                MessageBox.Show("Izberite projekt iz seznama.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartingScreen_Shown(object sender, EventArgs e)
        {
            HideMainScreen();
        }

        private void StartingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
