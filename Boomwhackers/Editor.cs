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

        List<Button> noteButtons;

        int margin = 10;
        int rowHeight = 50;
        int colWidth = 50;

        public Editor(BoomProject project)
        {
            openProject = project;

            InitializeComponent();

            RedrawButtons();
        }

        void RedrawButtons()
        {


            // remove old 
            if (noteButtons != null)
            {
                foreach (Button b in noteButtons)
                {
                    b.Dispose();
                }
            }

            // add new

            noteButtons = new List<Button>();
            
            float x = margin;
            float y = margin;

            int row = 0;
            foreach (NoteType noteType in openProject.data.notes)
            {
                y = row * rowHeight + margin;

                foreach (var note in noteType.notes)
                {
                    x = note.Key * colWidth + margin;

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

                    noteButtons.Add(noteBtn);
                    Controls.Add(noteBtn);
                }

                row++;

            }
        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            // Add note at click position in form

            // Get the click position
            Point clickPos = PointToClient(Cursor.Position);

            statusLabel.Text = clickPos.ToString();

            if (clickPos.X < margin || clickPos.Y < margin)
            {
                return;
            }

            float notePosition = (clickPos.X - margin) / colWidth;

            // Get the note type (row) at this y position
            int noteTypeIndex = (clickPos.Y - margin) / rowHeight;

            if (noteTypeIndex >= openProject.data.notes.Count)
            {
                return;
            }

            NoteType noteType = openProject.data.notes[noteTypeIndex];

            // Add the note to the project
            if (!noteType.notes.ContainsKey(notePosition))
            {
                noteType.notes.Add(notePosition, new Note());
            }

            // Redraw the buttons
            RedrawButtons();
        }
    }
}
