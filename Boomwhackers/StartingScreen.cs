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
            recentProjectData = RecentProjectData.Instance;
        }

        public StartingScreen(Form1 mainScreen)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            mainScreen.createProjectButton_Click(sender, e);
        }
        
        private void openProjectButton_Click(object sender, EventArgs e)
        {
            mainScreen.LoadProject(sender, e);
        }
    }
}
