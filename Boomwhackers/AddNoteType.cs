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
        public static string filter = "Sound files (*.wav)|*.wav|All files (*.*)|*.*";
        public NoteType noteType;
        public string noteSoundLocation = null;

        private OpenFileDialog openSoundDialog = new OpenFileDialog()
        {
            FileName = "Izberi zvok",
            Filter = filter,
            Title = "Izberi zvok note",
            InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE")
        };

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

            noteType = new NoteType(noteName.Text.Trim(), hexColor);

            if (noteSoundLocation != null)
            {
                noteType.soundLocation = noteSoundLocation;
            }

            Close();
        }

        private void selectNoteSoundButton_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openSoundDialog.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                noteSoundLocation = openSoundDialog.FileName;
            }

        }
    }
}
