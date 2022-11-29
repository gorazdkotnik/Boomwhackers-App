using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Boomwhackers
{
    public partial class MusicPlayer : Form
    {
        BoomProject openProject;

        int margin = 10;
        int rowHeight = 50;
        int colWidth = 50;

        List<string> noteDisplayColors;

        Dispatcher d;

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

        void PlayNotes()
        {
            playNotesButton.Enabled = false;

            // for each note type
            foreach (NoteType note in openProject.data.notes)
            {
                // for each note in the note type
                foreach (double noteTime in note.notes)
                {
                    // start the animation
                    int delay = (int)(noteTime * 1000);

                    d = Dispatcher.CurrentDispatcher;
                    new Task(() => {
                        System.Threading.Thread.Sleep(delay);

                        d.BeginInvoke(new Action(() =>
                        {
                            // create a new button
                            Button b = CreateButton(margin, margin, note.displayColor);
                            // add the button to the panel
                            musicPlayerPanel.Controls.Add(b);
                            // create a new animator for the button
                            CControlAnimator animator = new CControlAnimator(1, 1, new Point(b.Location.X, musicPlayerPanel.Height - margin - rowHeight));
                            // set the button to be animated
                            animator.control = b;

                            animator.Start();
                        }));
                    }).Start();
                }
            }
        }

        private void playNotesButton_Click(object sender, EventArgs e)
        {
            PlayNotes();
        }

        private void pauseNotesButton_Click(object sender, EventArgs e)
        {

        }

        private void restartNotesButton_Click(object sender, EventArgs e)
        {
            // remove all buttons from the panel
            musicPlayerPanel.Controls.Clear();

            // reset dispatcher
            d = null;

            DrawNoteTypes();
            PlayNotes();
        }
    }
}
