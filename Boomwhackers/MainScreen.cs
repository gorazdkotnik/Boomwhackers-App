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

        SaveFileDialog saveProjectDialog = new SaveFileDialog()
        {
            Title = "Izberi, kam shraniti projekt",
            InitialDirectory = location,
            AddExtension = true,
            Filter = BoomProject.filter,
        };

        RecentProjectData recentProjectData = RecentProjectData.Instance;

        public Form1()
        {
            InitializeComponent();
            InitializeStartingScreen();


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
        
        private void InitializeStartingScreen()
        {
            StartingScreen startingSccreen = new StartingScreen(this);
            startingSccreen.Show();
        }

        void SaveProject()
        {
            if (loadedProjectLocation != null)
            {
                loadedProject.SaveData(loadedProjectLocation);
            }
            else
            {
                SaveProjectAs();
            }
        }

        void SaveProjectAs()
        {
            if (saveProjectDialog.ShowDialog() == DialogResult.OK)
            {
                loadedProject.SaveData(saveProjectDialog.FileName);
                loadedProjectLocation = saveProjectDialog.FileName;
            }
        }


        public void LoadProject(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                loadedProject = new BoomProject(openProjectDialog.FileName);
                loadedProjectLocation = openProjectDialog.FileName;

                InitializeEditor();
                recentProjectData.AddProject(new RecentProject(loadedProjectLocation));
            }
        }

        public void createProjectButton_Click(object sender, EventArgs e)
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
                InitializeEditor();
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
            loadedProjectLocation = null;
            InitializeEditor();
        }

        private void SaveProjectItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void SaveProjectAsItem_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }
    }
}
