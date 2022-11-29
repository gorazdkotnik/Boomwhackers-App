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
        BoomProject loadedProject;
        string loadedProjectLocation = null;
        EditorController currentEditorController;

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


            /*project = new BoomProject("testProject", location);

            project.data.notes.Add(new NoteType("test", "red")
            {
                notes = new List<float>()
                {
                    1.0f
                }
            });
            jsonData.Text = project.jsonData;*/

        }

        private void InitializeEditor()
        {
            if (currentEditorController != null)
            {
                currentEditorController.Unload();
            }
            currentEditorController = new EditorController(editorPanel, loadedProject);
        }

        public void SaveProject()
        {
            if (loadedProjectLocation != null)
            {
                loadedProject.SaveData(loadedProjectLocation);
            }
        }

        public void SaveProject(string location)
        {
            loadedProject.SaveData(location);
        }


        private void LoadProject(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                loadedProject = new BoomProject(openProjectDialog.FileName);
                loadedProjectLocation = openProjectDialog.FileName;

                InitializeEditor();
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
                loadedProject = frm2Project;
            }
        }

        private void openMusicPlayer_Click(object sender, EventArgs e)
        {
            if (loadedProject == null)
            {
                MessageBox.Show(
                    "Da lahko dostopate do predvajalnika not morate odpreti ali ustvariti projekt.",
                    "Napaka pri odpiranju predvajalnika not", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form musicPlayer = new MusicPlayer(loadedProject);
            musicPlayer.Show();
        }

        private void NewProjectItem_Click(object sender, EventArgs e)
        {
            loadedProject = new BoomProject();
            InitializeEditor();
        }
    }
}
