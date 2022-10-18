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

        public Dictionary<float, Note> notes = new Dictionary<float, Note>();

        public NoteType(string displayName, string displayColor)
        {
            this.displayName = displayName;
            this.displayColor = displayColor;
        }

    }
}
