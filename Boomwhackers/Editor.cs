using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boomwhackers
{
    public partial class Editor : Form
    {
        BoomProject openProject;
        public Editor(BoomProject project)
        {
            openProject = project;

            // Show the notes
            

            InitializeComponent();
        }
    }
}
