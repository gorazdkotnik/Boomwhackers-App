using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomwhackers
{
    public class NoteType
    {
        public string displayName;
        public string displayColor;

        public List<float> notes = new List<float>();

        public NoteType(string displayName, string displayColor)
        {
            this.displayName = displayName;
            this.displayColor = displayColor;
        }

        public override string ToString()
        {
            return "NoteType[displayName=" + displayName + ", displayColor=" + displayColor + "]";
        }

    }
}
