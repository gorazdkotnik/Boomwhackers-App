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
    public partial class NoteButton : UserControl
    {
        public NoteButton()
        {
            InitializeComponent();

        }
        public NoteButton(string color)
        {
            InitializeComponent();
            this.BackColor = Color.FromName(color);
        }
    }
}
