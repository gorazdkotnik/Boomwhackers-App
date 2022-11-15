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
    public partial class MusicPlayer : Form
    {
        BoomProject openProject;

        int margin = 10;
        int rowHeight = 50;
        int colWidth = 50;

        List<string> noteDisplayColors;

        public MusicPlayer(BoomProject project)
        {
            openProject = project;

            InitializeComponent();

            DrawNoteTypes();
        }

        List<string> GetUniqueNoteColors()
        {

            List<string> uniqueColors = new List<string>();

            foreach (NoteType note in openProject.data.notes)
            {
                if (!uniqueColors.Contains(note.displayColor))
                {
                    uniqueColors.Add(note.displayColor);
                }
            }
            
            return uniqueColors;

        }

        Button CreateButton(int x, int y, string color)
        {
            Button b = new Button();
            b.Location = new Point(x, y);
            b.Size = new Size(colWidth, rowHeight);
            b.BackColor = ColorTranslator.FromHtml(color);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;

            return b;
        }

        void DrawNoteTypes()
        {
            noteDisplayColors = GetUniqueNoteColors();

            if (noteDisplayColors.Count < 1)
            {
                noDataLabel.Visible = true;
                return;
            }

            int x = margin;

            foreach (string color in noteDisplayColors)
            {

                Button b = CreateButton(x, musicPlayerPanel.Height - margin - rowHeight, color);
                musicPlayerPanel.Controls.Add(b);


                x += colWidth + margin;
            }
        }

        private void playNotesButton_Click(object sender, EventArgs e)
        {
            /*
             "notes":[
                {
                    "displayName":"test",
                    "displayColor":"red",
                    "notes":{
                        "1":{"length":1.0},
                        "2":{"length":1.0},
                        "3":{"length":1.0}
                    }
                }
            ]
            */

            List<Button> buttonsToPlay = new List<Button>();

            foreach (NoteType note in openProject.data.notes)
            {
                int x = margin;

                foreach (string color in noteDisplayColors)
                {
                    if (color == note.displayColor)
                    {
                        Button b = CreateButton(x, margin, color);
                        buttonsToPlay.Add(b);
                    }

                    x += colWidth + margin;
                }
            }

            // Play the buttons

            foreach (Button b in buttonsToPlay)
            {
                musicPlayerPanel.Controls.Add(b);

                CControlAnimator animator = new CControlAnimator(1, 1, new Point(0, musicPlayerPanel.Height - margin - rowHeight));
                animator.control = b;

                animator.Start();
            }
        }

        private void pauseNotesButton_Click(object sender, EventArgs e)
        {

        }
    }
}
