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
        public int noteTypeIndex;
        int animLen = 100;

        Color origColor;

        Timer animTimer = new Timer();
        public NoteButton()
        {
            InitializeComponent();
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
        internal void Animate()
        {
            origColor = BackColor;
            BackColor = Color.White;

            // Go back in 0.25s
            animTimer.Interval = animLen;

            animTimer.Tick += ResetBackColor;

            animTimer.Start();
        }

        void ResetBackColor(object sender, EventArgs e)
        {
            BackColor = origColor;

        }
    }
}
