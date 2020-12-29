using System;
using System.Windows.Forms;

namespace TbVolScrollNet5.Forms
{
    public partial class SetPreciseThresholdForm : Form
    {
        public SetPreciseThresholdForm()
        {
            InitializeComponent();
        }

        private void SavenewThreshold(object sender, EventArgs e)
        {
            tbvolscroll.Properties.Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;
            tbvolscroll.Properties.Settings.Default.Save();
            Close();
        }

        private void LoadCurrentThreshold(object sender, EventArgs e)
        {
            ThresholdNumericUpDown.Value = tbvolscroll.Properties.Settings.Default.PreciseScrollThreshold;
            
        }
    }
}
