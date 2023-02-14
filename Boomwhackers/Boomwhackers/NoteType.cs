﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boomwhackers
{
    public class NoteType
    {
        public string displayName;
        public string displayColor;
        public string soundLocation = null;

        private List<float> _notes = new List<float>();

        private List<float> SortList(List<float> inArr)
        {
            return inArr.OrderBy(x => x).ToList();
        }

        public List<float> notes
        {
            get
            {
                return _notes;
            }
        }

        public void AddNote(float time)
        {
            _notes.Add(time);
            _notes = SortList(_notes);
        }

        public void RemoveNote(float time)
        {
            _notes.Remove(time);
        }


        public NoteType(string displayName, string displayColor)
        {
            this.displayName = displayName;
            this.displayColor = displayColor;
        }

        public override string ToString()
        {
            return "NoteType[displayName=" + displayName + ", displayColor=" + displayColor + "]";
        }

        public void PlaySound()
        {
            if (soundLocation != null)
            {
                // We use this for the default project
                if (soundLocation.StartsWith("resources://"))
                {
                    string resourceName = soundLocation.Substring(12);
                    Stream stream = Properties.Resources.ResourceManager.GetStream(resourceName);
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(stream);
                    player.Play();
                    return;
                }
                else
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundLocation);
                    player.Play();
                }
            }
        }
    }
}
