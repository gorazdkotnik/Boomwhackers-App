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
    public partial class Form1 : Form
    {
        BoomProject project;
        OpenFileDialog openProjectDialog = new OpenFileDialog()
        {
            FileName = "Izberi projekt",
            Filter = BoomProject.filter,
            Title = "Odpri Boomwhackers projekt"
        };
        public Form1()
        {
            InitializeComponent();

            string location = "C:\\Users\\anzeb\\TestBoomwhackers\\Test1";
            BoomProject project = new BoomProject("testProject", location);
        }

        private void SaveProject(object sender, EventArgs e)
        {
            project.SaveData();
        }

        private void LoadProject(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                project = new BoomProject(openProjectDialog.FileName);
                jsonData.Text = project.jsonData;
            }
        }
    }
}
