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
    public partial class Editor : Form
    {
        BoomProject openProject;

        List<Control> editorControls;

        int margin = 10;
        int rowHeight = 50;
        int colWidth = 50;

        int buttonWidth = 45;
        int buttonHeight = 45;

        int firstColumnWidth = 100;

        int leftSideMargin;

        public Editor(BoomProject project)
        {
            leftSideMargin = firstColumnWidth + margin * 2;

            openProject = project;

            InitializeComponent();

            RedrawButtons();
        }

        public void AddControlToEditor(Control control)
        {
            EditorPanel.Controls.Add(control);

            editorControls.Add(control);
        }

        void RedrawButtons()
        {
            this.SuspendLayout();
            // save scroll location
            Point scroll = EditorPanel.AutoScrollPosition;

            // remove old 
            if (editorControls != null)
            {
                foreach (Control b in editorControls)
                {
                    b.Dispose();
                }
            }

            // add new

            editorControls = new List<Control>();

            float x = margin + firstColumnWidth + margin;
            float y = margin;

            int row = 0;
            foreach (NoteType noteType in openProject.data.notes)
            {
                y = row * rowHeight + margin;

                Label typeLabel = new Label()
                {
                    Text = noteType.displayName,
                    Location = new Point(margin, (int)y),
                    Size = new Size(firstColumnWidth, rowHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = ColorTranslator.FromHtml(noteType.displayColor)
                };

                AddControlToEditor(typeLabel);

                foreach (var note in noteType.notes)
                {
                    x = note * colWidth + leftSideMargin;

                    NoteButton noteBtn = new NoteButton()
                    {
                        Location = new Point((int)x, (int)y),
                        Size = new Size(buttonWidth, buttonHeight),
                        BackColor = ColorTranslator.FromHtml(noteType.displayColor),
                        TabStop = false,
                        Enabled = false,
                    };

                    /*noteBtn.MouseClick += (sender, e) =>
                    {
                        noteType.notes.Remove(note.Key);
                        RedrawButtons();
                    };*/

                    AddControlToEditor(noteBtn);
                }

                row++;
            }

            // "+" button to add new notetype

            Button addNoteTypeBtn = new Button()
            {
                Text = "+",
                Location = new Point(margin, (int)y + rowHeight + margin),
                Size = new Size(firstColumnWidth, rowHeight),
                BackColor = Color.LightGray
            };

            addNoteTypeBtn.MouseClick += (sender, e) =>
            {
                AddNoteType addNoteTypeForm = new AddNoteType();

                if (addNoteTypeForm.ShowDialog() == DialogResult.OK)
                {
                    openProject.data.notes.Add(addNoteTypeForm.noteType);
                    //MessageBox.Show("Note type added: " + addNoteTypeForm.noteType.ToString());
                    RedrawButtons();
                }
            };

            AddControlToEditor(addNoteTypeBtn);

            // restore scroll location
            EditorPanel.AutoScrollPosition = new Point(-scroll.X, -scroll.Y);

            this.ResumeLayout();

        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            // Add note at click position in form

            // Get the click position inside editor control
            Point clickPos = EditorPanel.PointToClient(Cursor.Position);

            // add scroll
            clickPos.X -= EditorPanel.AutoScrollPosition.X;
            clickPos.Y -= EditorPanel.AutoScrollPosition.Y;

            statusLabel.Text = clickPos.ToString();

            if (clickPos.X < leftSideMargin || clickPos.Y < margin)
            {
                return;
            }

            float noteTime = (clickPos.X - leftSideMargin) / colWidth;

            // Get the note type (row) at this y position
            int noteTypeIndex = (clickPos.Y - margin) / rowHeight;

            if (noteTypeIndex >= openProject.data.notes.Count)
            {
                return;
            }

            NoteType noteType = openProject.data.notes[noteTypeIndex];

            //MessageBox.Show("Obstaja? " + noteTime + " : " + noteType.notes.ContainsKey(noteTime));

            // Add the note to the project
            if (noteType.notes.Contains(noteTime))
            {
                noteType.RemoveNote(noteTime);
            }
            else
            {
                noteType.AddNote(noteTime);
            }

            // Redraw the buttons
            RedrawButtons();
        }
    }
}
