using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomwhackers
{
    class NoteType
    {
        private string displayName;
        private string displayColor;

        private int noteValue;

        public NoteType(string displayName, string displayColor, int noteValue)
        {
            this.displayName = displayName;
            this.displayColor = displayColor;
            this.noteValue = noteValue;
        }

        public NoteType() : this("C", "White", 0) { }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public string DisplayColor
        {
            get { return displayColor; }
            set { displayColor = value; }
        }

        public int NoteValue
        {
            get { return noteValue; }
            set { noteValue = value; }
        }
    }
}
