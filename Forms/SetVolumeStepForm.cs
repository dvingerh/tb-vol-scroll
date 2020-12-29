using System;
using System.Windows.Forms;

namespace TbVolScrollNet5.Forms
{
    public partial class SetVolumeStepForm : Form
    {
        public SetVolumeStepForm()
        {
            InitializeComponent();
        }

        private void SaveNewVolumeStep(object sender, EventArgs e)
        {
            tbvolscroll.Properties.Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            tbvolscroll.Properties.Settings.Default.Save();
            Close();
        }

        private void LoadCurrentVolumeStep(object sender, EventArgs e)
        {
            SetVolumeStepNumericUpDown.Value = tbvolscroll.Properties.Settings.Default.VolumeStep;
            
        }
    }
}
