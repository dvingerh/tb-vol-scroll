using System;
using System.Drawing;
using System.Windows.Forms;

namespace tbvolscroll
{
    public partial class SettingsForm : Form
    {
        private readonly MainForm mainForm;
        private bool doSetFont = false;
        public SettingsForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void LoadBarAppearance(object sender, EventArgs e)
        {
            AutoRetryAdminCheckBox.Checked = Properties.Settings.Default.AutoRetryAdmin;
            SetVolumeStepNumericUpDown.Value = Properties.Settings.Default.VolumeStep;
            ThresholdNumericUpDown.Value = Properties.Settings.Default.PreciseScrollThreshold;
            SetBarWidthNumericUpDown.Value = Properties.Settings.Default.BarWidth;
            SetBarHeightNumericUpDown.Value = Properties.Settings.Default.BarHeight;
            AutoHideTimeOutNumericUpDown.Value = Properties.Settings.Default.AutoHideTimeOut;
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
            Properties.Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            Properties.Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Properties.Settings.Default.BarWidth = (int)SetBarWidthNumericUpDown.Value;
            Properties.Settings.Default.BarHeight = (int)SetBarHeightNumericUpDown.Value;

            Properties.Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;


            if (doSetFont)
                Properties.Settings.Default.FontStyle = CustomFontDialog.Font;

            Properties.Settings.Default.UseBarGradient = GradientCheckBox.Checked;
            Properties.Settings.Default.BarColor = ColorPreviewPictureBox.BackColor;
            Properties.Settings.Default.BarOpacity = ((double)(BarOpacityTrackBar.Value) / 100.0);

            Properties.Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

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
                ColorPreviewPictureBox.BackColor = customColor.Color;
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

        private void RestoreDefaultValues(object sender, EventArgs e)
        {
            AutoRetryAdminCheckBox.Checked = false;
            SetVolumeStepNumericUpDown.Value = 5;
            ThresholdNumericUpDown.Value = 10;
            SetBarWidthNumericUpDown.Value = 30;
            SetBarHeightNumericUpDown.Value = 20;
            AutoHideTimeOutNumericUpDown.Value = 1000;
            ColorPreviewPictureBox.BackColor = Color.DodgerBlue;
            BarOpacityTrackBar.Value = 100;
            GradientCheckBox.Checked = true;
            CustomColorCheckBox.Checked = false;
            OpacityValueLabel.Text = "Current value: 100%";
            Properties.Settings.Default.FontStyle = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
        }
    }
}
