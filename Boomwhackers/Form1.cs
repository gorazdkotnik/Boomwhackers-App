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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // show info message
            MessageBox.Show("Boomwhackers are a set of 8 colored tubes that are tuned to the notes of the C major scale. They are used to play music by striking them with the hands or with mallets. They are also used to teach music theory and to teach children how to read music. They are made by Boomwhackers, Inc. in the United States.", "Boomwhackers");
        }
    }
}
