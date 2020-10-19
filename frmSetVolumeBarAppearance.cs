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
    public partial class frmSetBarAppearance : Form
    {
        private frmMain frmMain;
        private bool doSetFont = false;
        public frmSetBarAppearance(frmMain frmMain)
        {
            this.frmMain = frmMain;
            InitializeComponent();
        }

        private void LoadBarAppearance(object sender, EventArgs e)
        {
            numSetBarWidth.Value = Properties.Settings.Default.BarWidth;
            numSetBarHeight.Value = Properties.Settings.Default.BarHeight;
            picColorPreview.BackColor = Properties.Settings.Default.BarColor;
            tbBarOpacity.Value = Convert.ToInt32(Properties.Settings.Default.BarOpacity * 100);
            if (Properties.Settings.Default.UseBarGradient)
            {
                chkGradient.Checked = true;
                chkSetCustomColor.Checked = false;
            }
            else
            {
                chkGradient.Checked = false;
                chkSetCustomColor.Checked = true;
            }


        }

        private void SaveBarAppearance(object sender, EventArgs e)
        {


            Properties.Settings.Default.BarWidth = (int)numSetBarWidth.Value;
            Properties.Settings.Default.BarHeight = (int)numSetBarHeight.Value;

            if (doSetFont)
                Properties.Settings.Default.FontStyle = fontStyleDialog.Font;

            Properties.Settings.Default.UseBarGradient = chkGradient.Checked;
            Properties.Settings.Default.BarColor = picColorPreview.BackColor;
            Properties.Settings.Default.BarOpacity = ((double)(tbBarOpacity.Value) / 100.0);

            Properties.Settings.Default.Save();

            frmMain.MinimumSize = new Size(Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            frmMain.MaximumSize = new Size(100 + Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            frmMain.Width = 100 + Properties.Settings.Default.BarWidth;
            frmMain.Height = Properties.Settings.Default.BarHeight;
            if (doSetFont)
                frmMain.lblVolumeText.Font = fontStyleDialog.Font;

            Close();
        }

        private void SetCustomColor(object sender, EventArgs e)
        {
            chkSetCustomColor.Checked = true;
            chkGradient.Checked = false;
            ColorDialog customColor = new ColorDialog();
            if (customColor.ShowDialog() == DialogResult.OK)
            {
                picColorPreview.BackColor = customColor.Color;
            }
        }

        private void SetGradient(object sender, EventArgs e)
        {
            chkGradient.Checked = true;
            chkSetCustomColor.Checked = false;
        }

        private void BarOpacityChanged(object sender, EventArgs e)
        {
            lblOpacityValue.Text = "Current value: " + tbBarOpacity.Value + "%";
        }

        private void SetFontStyle(object sender, EventArgs e)
        {
            fontStyleDialog.Font = Properties.Settings.Default.FontStyle;
            DialogResult dialogResult = fontStyleDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                doSetFont = true;
        }
    }
}
