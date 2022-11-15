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
    /* Non-focusable custom control */
    public partial class NoteButton : UserControl
    {
        public NoteButton()
        {
            InitializeComponent();
        }

        public NoteButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}
