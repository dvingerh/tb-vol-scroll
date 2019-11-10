using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbVolScroll
{
    public partial class FrmSetPreciseThreshold : Form
    {
        public FrmSetPreciseThreshold()
        {
            InitializeComponent();
        }

        private void SavenewThreshold(object sender, EventArgs e)
        {
            Properties.Settings.Default.PreciseScrollThreshold = (int)numSetPreciseThreshold.Value;
            Properties.Settings.Default.Save();
            Close();
        }

        private void LoadCurrentThreshold(object sender, EventArgs e)
        {
            numSetPreciseThreshold.Value = Properties.Settings.Default.PreciseScrollThreshold;
            
        }
    }
}
