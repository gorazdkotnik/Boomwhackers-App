using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomwhackers
{
    public class RecentProject
    {
        private string location;

        public RecentProject(string location)
        {
            this.location = location;
        }

        public string Location
        {
            get
            {
                return location;
            }
        }
    }
}
