using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        float startPlayTime = 0;
        float pausedTime = 0;
        bool paused = false;
        float lastTickTime = 0;

        float playSpeedBpm = 60;

        int removedNotes = 0; // To keep track of how many notes have finished playing

        List<NoteButton> displayedNotes = new List<NoteButton>();

        public MusicPlayer(BoomProject project)
        {
            openProject = project;

            InitializeComponent();

            ResetPlayer();
        }

        NoteButton CreateButton(int x, int y, string color)
        {
            NoteButton b = new NoteButton();
            b.Location = new Point(x, y);
            b.Size = new Size(colWidth, rowHeight);
            b.BackColor = ColorTranslator.FromHtml(color);
            b.Enabled = false;

            return b;
        }

        void DrawNoteTypes()
        {
            if (openProject.data.notes.Count < 1)
            {
                noDataLabel.Visible = true;
                return;
            }

            int x = margin;

            foreach (NoteType noteType in openProject.data.notes)
            {

                NoteButton b = CreateButton(x, musicPlayerPanel.Height - margin - rowHeight, noteType.displayColor);
                musicPlayerPanel.Controls.Add(b);


                x += colWidth + margin;
            }
        }

        void ResetPlayer()
        {
            foreach (NoteButton b in displayedNotes)
            {
                b.Dispose();
            }

            displayedNotes.Clear();

            DrawNoteTypes();

            startPlayTime = 0;
            lastTickTime = 0;
        }

        // use Environment.TickCount for time

        private void playButton_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                paused = false;
                startPlayTime = startPlayTime + (Environment.TickCount - pausedTime);
                lastTickTime = Environment.TickCount - startPlayTime;
            }
            else
            {
                startPlayTime = Environment.TickCount;
            }

            playButton.Enabled = false;
            pauseButton.Enabled = true;
            stopButton.Enabled = true;

            noteTimer.Start();

            removedNotes = 0;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            paused = true;
            pausedTime = Environment.TickCount;

            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = true;

            noteTimer.Stop();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ResetPlayer();

            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;

            noteTimer.Stop();

            removedNotes = 0;
        }

        // TODO: display only one notebutton per note
        private void noteTimer_Tick(object sender, EventArgs e)
        {
            int notesCount = 0;

            // Add new notes
            int noteTypeIndex = 0;
            foreach (NoteType noteType in openProject.data.notes)
            {
                foreach (float noteBeat in noteType.notes)
                {
                    notesCount++;

                    float noteTime = noteBeat * (60000 / playSpeedBpm);
                    if (noteTime > lastTickTime && noteTime <= Environment.TickCount - startPlayTime)
                    {
                        NoteButton b = CreateButton(margin + noteTypeIndex * (colWidth + margin), margin, noteType.displayColor);
                        musicPlayerPanel.Controls.Add(b);
                        displayedNotes.Add(b);
                    }
                }

                noteTypeIndex++;
            }


            // Move displayed notes and remove old ones
            List<NoteButton> notesToRemove = new List<NoteButton>();
            foreach (NoteButton b in displayedNotes)
            {
                b.Location = new Point(b.Location.X, b.Location.Y + 5);

                if (b.Location.Y >= musicPlayerPanel.Height - margin - rowHeight)
                {
                    notesToRemove.Add(b);

                    removedNotes++;
                }
            }


            // Check if done
            if (removedNotes >= notesCount)
            {
                MessageBox.Show(removedNotes.ToString() + "/" + notesCount.ToString());

                stopButton_Click(null, null);
            }

            lastTickTime = Environment.TickCount - startPlayTime;
        }
    }
}
