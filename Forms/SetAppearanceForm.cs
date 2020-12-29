using System;
using System.Drawing;
using System.Windows.Forms;

namespace TbVolScrollNet5.Forms
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
            SetBarWidthNumericUpDown.Value = tbvolscroll.Properties.Settings.Default.BarWidth;
            SetBarHeightNumericUpDown.Value = tbvolscroll.Properties.Settings.Default.BarHeight;
            ColorPreviewPictureBox.BackColor = tbvolscroll.Properties.Settings.Default.BarColor;
            BarOpacityTrackBar.Value = Convert.ToInt32(tbvolscroll.Properties.Settings.Default.BarOpacity * 100);
            if (tbvolscroll.Properties.Settings.Default.UseBarGradient)
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


            tbvolscroll.Properties.Settings.Default.BarWidth = (int)SetBarWidthNumericUpDown.Value;
            tbvolscroll.Properties.Settings.Default.BarHeight = (int)SetBarHeightNumericUpDown.Value;

            if (doSetFont)
                tbvolscroll.Properties.Settings.Default.FontStyle = CustomFontDialog.Font;

            tbvolscroll.Properties.Settings.Default.UseBarGradient = GradientCheckBox.Checked;
            tbvolscroll.Properties.Settings.Default.BarColor = ColorPreviewPictureBox.BackColor;
            tbvolscroll.Properties.Settings.Default.BarOpacity = ((double)(BarOpacityTrackBar.Value) / 100.0);

            tbvolscroll.Properties.Settings.Default.Save();

            mainForm.MinimumSize = new Size(tbvolscroll.Properties.Settings.Default.BarWidth, tbvolscroll.Properties.Settings.Default.BarHeight);
            mainForm.MaximumSize = new Size(100 + tbvolscroll.Properties.Settings.Default.BarWidth, tbvolscroll.Properties.Settings.Default.BarHeight);
            mainForm.Width = 100 + tbvolscroll.Properties.Settings.Default.BarWidth;
            mainForm.Height = tbvolscroll.Properties.Settings.Default.BarHeight;
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
            CustomFontDialog.Font = tbvolscroll.Properties.Settings.Default.FontStyle;
            DialogResult dialogResult = CustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
                doSetFont = true;
        }
    }
}
