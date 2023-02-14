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

            this.KeyDown += new KeyEventHandler(Form_KeyDown);

        }

        // Hot keys handler
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) // Ctrl-S Save
            {
                // Stops other controls on the form receiving event.
                e.SuppressKeyPress = true;

                SaveProject();
            }
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

        private void SetStatus(string text)
        {
            statusLabel.Text = text;
        }

        private void ClearStatus()
        {
            statusLabel.Text = "";
        }

        void SaveProject()
        {
            if (loadedProjectLocation != null)
            {
                loadedProject.SaveData(loadedProjectLocation);

                SetStatus("Projekt shranjen: " + loadedProjectLocation);
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

                SetStatus("Projekt shranjen kot: " + saveProjectDialog.FileName);
            }
        }


        public void LoadProject(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                LoadProject(openProjectDialog.FileName);
            }
        }

        public void LoadProject(string location)
        {
            loadedProject = new BoomProject(location);
            loadedProjectLocation = location;

            InitializeEditor();

            SetStatus("Odprt projekt: " + loadedProjectLocation);
            recentProjectData.AddProject(new RecentProject(loadedProjectLocation));
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loadedProject != null && loadedProject.madeChanges)
            {
                e.Cancel = true;

                DialogResult result = MessageBox.Show("Ali želite shraniti spremembe?", "Shranjevanje sprememb", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveProject();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }
        }
    }
}
