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

        int firstColumnWidth = 100;

        int leftSideMargin;

        public Editor(BoomProject project)
        {
            leftSideMargin = firstColumnWidth + margin * 2;
            
            openProject = project;

            InitializeComponent();

            RedrawButtons();
        }

        void RedrawButtons()
        {


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
                    BackColor = Color.FromName(noteType.displayColor)
                };

                editorControls.Add(typeLabel);
                Controls.Add(typeLabel);

                foreach (var note in noteType.notes)
                {
                    x = note.Key * colWidth + leftSideMargin;

                    Button noteBtn = new Button()
                    {
                        Text = note.Value.ToString(),
                        Location = new Point((int)x, (int)y),
                        Size = new Size(colWidth, rowHeight),
                        BackColor = Color.FromName(noteType.displayColor)
                    };

                    noteBtn.Click += (sender, e) =>
                    {
                        noteType.notes.Remove(note.Key);
                        RedrawButtons();
                    };

                    editorControls.Add(noteBtn);
                    Controls.Add(noteBtn);
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

            addNoteTypeBtn.Click += (sender, e) =>
            {
                
            };

            editorControls.Add(addNoteTypeBtn);
            Controls.Add(addNoteTypeBtn);
        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            // Add note at click position in form

            // Get the click position
            Point clickPos = PointToClient(Cursor.Position);

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

            // Add the note to the project
            if (!noteType.notes.ContainsKey(noteTime))
            {
                noteType.notes.Add(noteTime, new Note());
            }

            // Redraw the buttons
            RedrawButtons();
        }
    }
}
