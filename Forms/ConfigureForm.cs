using System;
using System.Drawing;
using System.Windows.Forms;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public partial class ConfigureForm : Form
    {
        private readonly MainForm mainForm;
        private bool doSetFont = false;
        public ConfigureForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void LoadBarAppearance(object sender, EventArgs e)
        {
            SwitchAudioPlaybackDevicesCheckBox.Checked = Settings.Default.SwitchDefaultPlaybackDeviceShortcut;
            ToggleMuteCheckBox.Checked = Settings.Default.ToggleMuteShortcut;
            AutoRetryAdminCheckBox.Checked = Settings.Default.AutoRetryAdmin;
            SetVolumeStepNumericUpDown.Value = Settings.Default.VolumeStep;
            ThresholdNumericUpDown.Value = Settings.Default.PreciseScrollThreshold;
            SetBarWidthNumericUpDown.Value = Settings.Default.BarWidth;
            SetBarHeightNumericUpDown.Value = Settings.Default.BarHeight;
            AutoHideTimeOutNumericUpDown.Value = Settings.Default.AutoHideTimeOut;
            ColorPreviewPictureBox.BackColor = Settings.Default.BarColor;
            BarOpacityTrackBar.Value = Convert.ToInt32(Settings.Default.BarOpacity * 100);
            if (Settings.Default.UseBarGradient)
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
            Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Settings.Default.BarWidth = (int)SetBarWidthNumericUpDown.Value;
            Settings.Default.BarHeight = (int)SetBarHeightNumericUpDown.Value;

            Settings.Default.SwitchDefaultPlaybackDeviceShortcut = SwitchAudioPlaybackDevicesCheckBox.Checked;
            Settings.Default.ToggleMuteShortcut = ToggleMuteCheckBox.Checked;


            Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;


            if (doSetFont)
                Settings.Default.FontStyle = CustomFontDialog.Font;

            Settings.Default.UseBarGradient = GradientCheckBox.Checked;
            Settings.Default.BarColor = ColorPreviewPictureBox.BackColor;
            Settings.Default.BarOpacity = BarOpacityTrackBar.Value / 100.0;

            Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

            Settings.Default.Save();

            if (doSetFont)
                mainForm.VolumeTextLabel.Font = CustomFontDialog.Font;

            SizeF newMinSizes = mainForm.CalculateBarSize("0%");
            mainForm.MinimumSize = new Size(Settings.Default.BarWidth + (int)newMinSizes.Width, Settings.Default.BarHeight + (int)newMinSizes.Height);
            mainForm.Width = mainForm.MinimumSize.Width;
            mainForm.Height = mainForm.MinimumSize.Height;

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
            OpacityValueLabel.Text = $"{BarOpacityTrackBar.Value}%";
        }

        private void SetFontStyle(object sender, EventArgs e)
        {
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
            OpacityValueLabel.Text = $"{BarOpacityTrackBar.Value}%";
            Settings.Default.FontStyle = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
        }
    }
}
