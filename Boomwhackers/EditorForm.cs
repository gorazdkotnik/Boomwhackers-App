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
    public partial class EditorForm : Form
    {

        List<Control> editorControls;

        int margin = 10;
        int rowHeight = 50;
        int colWidth = 50;

        int buttonWidth = 45;
        int buttonHeight = 45;

        int removeButtonSize = 25;

        int firstColumnWidth = 100;

        int leftSideMargin;


        Point mouseDownPos;
        Point lastEndPosition;

        BoomProject openProject;


        public EditorForm(BoomProject project)
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(Form_KeyDown);

            leftSideMargin = firstColumnWidth + margin * 2;

            openProject = project;

            RedrawButtons();
        }

        // Hot keys handler
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) // Ctrl-S Save
            {
                // Stops other controls on the form receiving event.
                e.SuppressKeyPress = true;

                ProjectManager.SaveProjectDialog(openProject);
            }
        }

        private void openMusicPlayer_Click(object sender, EventArgs e)
        {
            if (openProject == null)
            {
                MessageBox.Show(
                    "Da lahko dostopate do predvajalnika not morate odpreti ali ustvariti projekt.",
                    "Napaka pri odpiranju predvajalnika not", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form musicPlayer = new PlayerForm(openProject);
            musicPlayer.Show();
        }

        public void LoacProject_click(object sender, EventArgs e)
        {
            BoomProject loadedProject = ProjectManager.LoadProjectDialog();

            if (loadedProject != null)
            {
                openProject = loadedProject;
                RedrawButtons();
            }
        }

        private void NewProjectItem_Click(object sender, EventArgs e)
        {
            BoomProject newProject = ProjectManager.CreateProjectDialog();

            if (newProject != null)
            {
                openProject = newProject;
                RedrawButtons();
            }
        }

        private void SaveProjectItem_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProjectDialog(openProject);
        }

        private void SaveProjectAsItem_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveProjectAsDialog(openProject);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (openProject != null && openProject.madeChanges)
            {
                e.Cancel = true;

                DialogResult result = MessageBox.Show("Ali želite shraniti spremembe?", "Shranjevanje sprememb", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ProjectManager.SaveProjectDialog(openProject);
                    e.Cancel = false;
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

        public void AddControlToEditor(Control control)
        {
            editorPanel.Controls.Add(control);

            editorControls.Add(control);
        }

        private void ClearButtons()
        {
            if (editorControls != null)
            {
                foreach (Control b in editorControls)
                {
                    b.Dispose();
                }
            }
        }

        void ChangeMade()
        {
            openProject.madeChanges = true;
        }

        void DrawNoteTypeButton(int row, NoteType noteType)
        {
            int y = row * rowHeight + margin;

            Button typeButton = new Button()
            {
                Text = noteType.displayName,
                Location = new Point(margin, (int)y),
                Size = new Size(firstColumnWidth - 25, rowHeight),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml(noteType.displayColor)
            };

            typeButton.MouseClick += (sender, e) =>
            {
                EditNoteType editor = new EditNoteType(noteType);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    openProject.data.notes[row] = editor.noteType;

                    RedrawButtons();

                    ChangeMade();
                }
            };

            // Button to remove
            Button removeButton = new Button()
            {
                Text = "X",
                Location = new Point(margin + firstColumnWidth - removeButtonSize, (int)y),
                Size = new Size(removeButtonSize, removeButtonSize),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Red,
            };

            removeButton.MouseClick += (sender, e) =>
            {
                openProject.data.notes.Remove(noteType);

                RedrawButtons();

                ChangeMade();
            };

            AddControlToEditor(typeButton);
            AddControlToEditor(removeButton);
        }

        void DrawNoteButton(int row, float note, NoteType noteType)
        {
            float x = note * colWidth + leftSideMargin;
            int y = row * rowHeight + margin;

            // Take scroll into account
            x += editorPanel.AutoScrollPosition.X;
            y += editorPanel.AutoScrollPosition.Y;

            NoteButton noteBtn = new NoteButton()
            {
                Location = new Point((int)x, (int)y),
                Size = new Size(buttonWidth, buttonHeight),
                BackColor = ColorTranslator.FromHtml(noteType.displayColor),
                TabStop = false,
                Enabled = false,
                noteTypeIndex = row,
                noteTime = note
            };

            /*noteBtn.MouseClick += (sender, e) =>
            {
                noteType.notes.Remove(note);

                noteBtn.Dispose();

            };*/

            AddControlToEditor(noteBtn);
        }

        void RedrawButtons()
        {
            editorPanel.SuspendLayout();
            // save scroll location
            Point scroll = editorPanel.AutoScrollPosition;

            // remove old 
            ClearButtons();

            // add new

            editorControls = new List<Control>();

            int row = 0;
            foreach (NoteType noteType in openProject.data.notes)
            {
                DrawNoteTypeButton(row, noteType);

                foreach (var note in noteType.notes)
                {
                    DrawNoteButton(row, note, noteType);
                }

                row++;
            }

            // "+" button to add new notetype

            Button addNoteTypeBtn = new Button()
            {
                Text = "+",
                Location = new Point(margin, margin + rowHeight * row),
                Size = new Size(firstColumnWidth, rowHeight),
                BackColor = Color.LightGray,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom
            };

            addNoteTypeBtn.MouseClick += (sender, e) =>
            {
                EditNoteType addNoteTypeForm = new EditNoteType();

                if (addNoteTypeForm.ShowDialog() == DialogResult.OK)
                {
                    openProject.data.notes.Add(addNoteTypeForm.noteType);

                    RedrawButtons();

                    ChangeMade();
                }
            };

            AddControlToEditor(addNoteTypeBtn);

            // restore scroll location
            editorPanel.AutoScrollPosition = new Point(-scroll.X, -scroll.Y);

            editorPanel.ResumeLayout();

        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            // Add note at click position in form

            // Get the click position inside editor control
            Point clickPos = editorPanel.PointToClient(Cursor.Position);



            // add scroll
            clickPos.X -= editorPanel.AutoScrollPosition.X;
            clickPos.Y -= editorPanel.AutoScrollPosition.Y;


            if (clickPos.X < leftSideMargin || clickPos.Y < margin)
            {
                return;
            }

            float noteTime = (clickPos.X - leftSideMargin) / colWidth; // Scroll

            // Get the note type (row) at this y position
            int noteTypeIndex = (clickPos.Y - margin) / rowHeight;

            if (noteTypeIndex >= openProject.data.notes.Count)
            {
                return;
            }

            NoteType noteType = openProject.data.notes[noteTypeIndex];

            //MessageBox.Show("Obstaja? " + noteTime); //+ " : " + noteType.notes.ContainsKey(noteTime));

            // Add or remove the note to/from the project
            if (noteType.notes.Contains(noteTime))
            {
                noteType.RemoveNote(noteTime);

                // Remove the button
                foreach (Control c in editorPanel.Controls)
                {
                    if (c is NoteButton)
                    {
                        NoteButton b = (NoteButton)c;

                        if (b.noteTime == noteTime && b.noteTypeIndex == noteTypeIndex)
                        {
                            b.Dispose();
                            break;
                        }
                    }
                }
            }
            else
            {
                noteType.AddNote(noteTime);

                noteType.PlaySound();

                DrawNoteButton(noteTypeIndex, noteTime, noteType);
            }

            ChangeMade();

        }


        private void Editor_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPos = e.Location;
        }

        double pointsDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        bool isMoveDistance(Point a, Point b)
        {
            return pointsDistance(a, b) > 5;
        }

        private void Editor_MouseMove(object sender, MouseEventArgs e)
        {
            // if leftclick
            if (e.Button == MouseButtons.Left && isMoveDistance(mouseDownPos, new Point(e.X, e.Y)))
            {
                editorPanel.Cursor = Cursors.Hand;
                editorPanel.AutoScrollPosition = new Point(
                    mouseDownPos.X - e.X - lastEndPosition.X,
                    mouseDownPos.Y - e.Y - lastEndPosition.Y
                );
            }
        }

        private void Editor_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMoveDistance(mouseDownPos, new Point(e.X, e.Y)))
            {
                editorPanel.Cursor = Cursors.Default;
                lastEndPosition = editorPanel.AutoScrollPosition;
            }
            else
            {
                // It's a click
                Editor_MouseClick(sender, e);
            }
        }
    }
}
