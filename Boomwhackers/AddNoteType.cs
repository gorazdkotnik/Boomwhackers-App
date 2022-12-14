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
    public partial class AddNoteType : Form
    {
        public NoteType noteType;

        public AddNoteType()
        {
            InitializeComponent();
        }

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            // show color picker
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.ShowDialog();

            // set color
            ColorPicker.BackColor = colorPicker.Color;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            // validate form
            DialogResult = DialogResult.OK;
            if (noteName.Text == "")
            {
                DialogResult = DialogResult.Cancel;
            }
            string hexColor = ColorTranslator.ToHtml(ColorPicker.BackColor);

            noteType = new NoteType(noteName.Text, hexColor);

            Close();
        }
    }
}
