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

        public NoteType(string displayName, string displayColor)
        {
            this.displayName = displayName;
            this.displayColor = displayColor;
        }

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
    }
}
