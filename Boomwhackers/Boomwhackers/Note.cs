using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomwhackers
{
    public class Note
    {
        private NoteType noteType;
        private float time;

        public Note(NoteType noteType, float time)
        {
            this.noteType = noteType;
            this.time = time;
        }

        public Note() : this(new NoteType(), 0) { }

        public NoteType NoteType
        {
            get { return noteType; }
            set { noteType = value; }
        }

        public float Time
        {
            get { return time; }
            set { time = value; }
        }

        public Note Clone()
        {
            return new Note(noteType, time);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", noteType.DisplayName, time);
        }
    }
}
