using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbVolScroll_Reloaded
{
    public partial class FrmSetVolumeStep : Form
    {
        public FrmSetVolumeStep()
        {
            InitializeComponent();
        }

        private void SaveNewVolumeStep(object sender, EventArgs e)
        {
            Properties.Settings.Default.VolumeStep = (int)numSetVolumeStep.Value;
            Close();
        }

        private void LoadCurrentVolumeStep(object sender, EventArgs e)
        {
            numSetVolumeStep.Value = Properties.Settings.Default.VolumeStep;
            
        }
    }
}
