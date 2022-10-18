using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomwhackers
{
    public class Note
    {
        public float length;
        
        public Note(float length = 1f)
        {
            this.length = length;
        }

        public override string ToString()
        {
            return string.Format("{0}", length.ToString());
        }
    }
}
