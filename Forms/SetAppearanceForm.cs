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
    public partial class SetAppearanceForm : Form
    {
        private readonly MainForm mainForm;
        private bool doSetFont = false;
        public SetAppearanceForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void LoadBarAppearance(object sender, EventArgs e)
        {
            SetBarWidthNumericUpDown.Value = Properties.Settings.Default.BarWidth;
            SetBarHeightNumericUpDown.Value = Properties.Settings.Default.BarHeight;
            ColorPreviewPictureBox.BackColor = Properties.Settings.Default.BarColor;
            BarOpacityTrackBar.Value = Convert.ToInt32(Properties.Settings.Default.BarOpacity * 100);
            if (Properties.Settings.Default.UseBarGradient)
            {
                GradientCheckBox.Checked = true;
                CustomColorCheckBox.Checked = false;
            }
            else
            {
                GradientCheckBox.Checked = false;
                CustomColorCheckBox.Checked = true;
            }


        }

        private void SaveBarAppearance(object sender, EventArgs e)
        {


            Properties.Settings.Default.BarWidth = (int)SetBarWidthNumericUpDown.Value;
            Properties.Settings.Default.BarHeight = (int)SetBarHeightNumericUpDown.Value;

            if (doSetFont)
                Properties.Settings.Default.FontStyle = CustomFontDialog.Font;

            Properties.Settings.Default.UseBarGradient = GradientCheckBox.Checked;
            Properties.Settings.Default.BarColor = ColorPreviewPictureBox.BackColor;
            Properties.Settings.Default.BarOpacity = ((double)(BarOpacityTrackBar.Value) / 100.0);

            Properties.Settings.Default.Save();

            mainForm.MinimumSize = new Size(Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            mainForm.MaximumSize = new Size(100 + Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            mainForm.Width = 100 + Properties.Settings.Default.BarWidth;
            mainForm.Height = Properties.Settings.Default.BarHeight;
            if (doSetFont)
                mainForm.VolumeTextLabel.Font = CustomFontDialog.Font;

            Close();
        }

        private void SetCustomColor(object sender, EventArgs e)
        {
            CustomColorCheckBox.Checked = true;
            GradientCheckBox.Checked = false;
            ColorDialog customColor = new ColorDialog();
            if (customColor.ShowDialog() == DialogResult.OK)
            {
                ColorPreviewPictureBox.BackColor = customColor.Color;
            }
        }

        private void SetGradient(object sender, EventArgs e)
        {
            GradientCheckBox.Checked = true;
            CustomColorCheckBox.Checked = false;
        }

        private void BarOpacityChanged(object sender, EventArgs e)
        {
            OpacityValueLabel.Text = "Current value: " + BarOpacityTrackBar.Value + "%";
        }

        private void SetFontStyle(object sender, EventArgs e)
        {
            CustomFontDialog.Font = Properties.Settings.Default.FontStyle;
            DialogResult dialogResult = CustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                doSetFont = true;
        }
    }
}
