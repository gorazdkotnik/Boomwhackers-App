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

        static string location = "C:\\Users\\anzeb\\TestBoomwhackers\\Test1";
        
        OpenFileDialog openProjectDialog = new OpenFileDialog()
        {
            FileName = "Izberi projekt",
            Filter = BoomProject.filter,
            Title = "Odpri Boomwhackers projekt",
            InitialDirectory = location
        };

        public Form1()
        {
            InitializeComponent();


            project = new BoomProject("testProject", location);

            project.data.notes.Add(new NoteType("test", "red")
            {
                notes = new List<float>()
                {
                    1.0f
                }
            });
            jsonData.Text = project.jsonData;

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

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            CreateProject form2 = new CreateProject();
            form2.FormClosing += frm2_FormClosing;
            form2.Show();
        }

        private void frm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            BoomProject frm2Project = ((CreateProject)sender).project;

            if (frm2Project != null)
            {
                project = frm2Project;
                jsonData.Text = project.jsonData;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form editor = new Editor(project);
            editor.Show();
        }

        private void openMusicPlayer_Click(object sender, EventArgs e)
        {
            Form musicPlayer = new MusicPlayer(project);
            musicPlayer.Show();
        }
    }
}
