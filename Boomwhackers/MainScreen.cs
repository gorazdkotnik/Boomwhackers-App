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
            StartingScreen startingSccreen = new StartingScreen();
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


        private void LoadProject(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                loadedProject = new BoomProject(openProjectDialog.FileName);
                loadedProjectLocation = openProjectDialog.FileName;

                InitializeEditor();

                SetStatus("Odprt projekt: " + loadedProjectLocation);
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
