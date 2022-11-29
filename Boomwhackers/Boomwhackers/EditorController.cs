using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boomwhackers
{
    internal class EditorController
    {
        private Panel containerPanel;

        BoomProject openProject;

        List<Control> editorControls;

        int margin = 10;
        int rowHeight = 50;
        int colWidth = 50;

        int buttonWidth = 45;
        int buttonHeight = 45;

        int firstColumnWidth = 100;

        int leftSideMargin;

        public EditorController(Panel containerPanel, BoomProject project)
        {
            this.containerPanel = containerPanel;

            containerPanel.MouseClick += Editor_MouseClick;

            leftSideMargin = firstColumnWidth + margin * 2;

            openProject = project;

            RedrawButtons();
        }

        public void AddControlToEditor(Control control)
        {
            containerPanel.Controls.Add(control);

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

        public void Unload()
        {
            ClearButtons();

            containerPanel.MouseClick -= Editor_MouseClick;
        }

        void ChangeMade()
        {
            openProject.madeChanges = true;
        }

        void RedrawButtons()
        {
            containerPanel.SuspendLayout();
            // save scroll location
            Point scroll = containerPanel.AutoScrollPosition;

            // remove old 
            ClearButtons();

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

                    ChangeMade();
                }
            };

            AddControlToEditor(addNoteTypeBtn);

            // restore scroll location
            containerPanel.AutoScrollPosition = new Point(-scroll.X, -scroll.Y);

            containerPanel.ResumeLayout();

        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            // Add note at click position in form

            // Get the click position inside editor control
            Point clickPos = containerPanel.PointToClient(Cursor.Position);

            // add scroll
            clickPos.X -= containerPanel.AutoScrollPosition.X;
            clickPos.Y -= containerPanel.AutoScrollPosition.Y;


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

            ChangeMade();

            // Redraw the buttons
            RedrawButtons();
        }
    }
}
