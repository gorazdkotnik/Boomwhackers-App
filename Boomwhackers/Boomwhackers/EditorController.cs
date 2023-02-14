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

        int removeButtonSize = 25;

        int firstColumnWidth = 100;

        int leftSideMargin;


        Point mouseDownPos;
        Point lastEndPosition;

        public EditorController(Panel containerPanel, BoomProject project)
        {
            this.containerPanel = containerPanel;

            containerPanel.MouseDown += Editor_MouseDown;
            containerPanel.MouseMove += Editor_MouseMove;
            containerPanel.MouseUp += Editor_MouseUp;

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

            containerPanel.MouseDown -= Editor_MouseDown;
            containerPanel.MouseMove -= Editor_MouseMove;
            containerPanel.MouseUp -= Editor_MouseUp;
        }

        void ChangeMade()
        {
            openProject.madeChanges = true;
        }

        void DrawNoteTypeButton(int row, NoteType noteType)
        {
            int y = row * rowHeight + margin;

            Label typeLabel = new Label()
            {
                Text = noteType.displayName,
                Location = new Point(margin, (int)y),
                Size = new Size(firstColumnWidth - 25, rowHeight),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = ColorTranslator.FromHtml(noteType.displayColor)
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

            AddControlToEditor(typeLabel);
            AddControlToEditor(removeButton);
        }

        void DrawNoteButton(int row, float note, NoteType noteType)
        {
            float x = note * colWidth + leftSideMargin;
            int y = row * rowHeight + margin;

            // Take scroll into account
            x += containerPanel.AutoScrollPosition.X;
            y += containerPanel.AutoScrollPosition.Y;

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
            containerPanel.SuspendLayout();
            // save scroll location
            Point scroll = containerPanel.AutoScrollPosition;

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
                BackColor = Color.LightGray
            };

            addNoteTypeBtn.MouseClick += (sender, e) =>
            {
                AddNoteType addNoteTypeForm = new AddNoteType();

                if (addNoteTypeForm.ShowDialog() == DialogResult.OK)
                {
                    openProject.data.notes.Add(addNoteTypeForm.noteType);

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
                foreach (Control c in containerPanel.Controls)
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

                DrawNoteButton(noteTypeIndex, noteTime, noteType);
            }

            ChangeMade();



            /*// Redraw the buttons
            RedrawButtons();*/
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
                containerPanel.Cursor = Cursors.Hand;
                containerPanel.AutoScrollPosition = new Point(
                    mouseDownPos.X - e.X - lastEndPosition.X,
                    mouseDownPos.Y - e.Y - lastEndPosition.Y
                );
            }
        }

        private void Editor_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMoveDistance(mouseDownPos, new Point(e.X, e.Y)))
            {
                containerPanel.Cursor = Cursors.Default;
                lastEndPosition = containerPanel.AutoScrollPosition;
            } else
            {
                // It's a click
                Editor_MouseClick(sender, e);
            }
        }
    }
}
