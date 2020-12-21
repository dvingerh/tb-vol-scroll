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
    public partial class SetPreciseThresholdForm : Form
    {
        public SetPreciseThresholdForm()
        {
            InitializeComponent();
        }

        private void SavenewThreshold(object sender, EventArgs e)
        {
            Properties.Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;
            Properties.Settings.Default.Save();
            Close();
        }

        private void LoadCurrentThreshold(object sender, EventArgs e)
        {
            ThresholdNumericUpDown.Value = Properties.Settings.Default.PreciseScrollThreshold;
            
        }
    }
}
