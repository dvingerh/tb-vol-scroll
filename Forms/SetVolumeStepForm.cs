using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll
{
    public partial class SetVolumeStepForm : Form
    {
        public SetVolumeStepForm()
        {
            InitializeComponent();
        }

        private void SaveNewVolumeStep(object sender, EventArgs e)
        {
            Properties.Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Properties.Settings.Default.Save();
            Close();
        }

        private void LoadCurrentVolumeStep(object sender, EventArgs e)
        {
            SetVolumeStepNumericUpDown.Value = Properties.Settings.Default.VolumeStep;
            
        }
    }
}
