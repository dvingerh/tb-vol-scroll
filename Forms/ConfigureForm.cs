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

        private void LoadBarConfiguration(object sender, EventArgs e)
        {
            SwitchAudioPlaybackDevicesCheckBox.Checked = Settings.Default.SwitchDefaultPlaybackDeviceShortcut;
            ToggleMuteCheckBox.Checked = Settings.Default.ToggleMuteShortcut;
            AutoRetryAdminCheckBox.Checked = Settings.Default.AutoRetryAdmin;
            SetVolumeStepNumericUpDown.Value = Settings.Default.VolumeStep;
            ThresholdNumericUpDown.Value = Settings.Default.PreciseScrollThreshold;
            SetBarWidthNumericUpDown.Value = Settings.Default.BarWidthPadding;
            SetBarHeightNumericUpDown.Value = Settings.Default.BarHeightPadding;
            AutoHideTimeOutNumericUpDown.Value = Settings.Default.AutoHideTimeOut;
            ColorPreviewPictureBox.BackColor = Settings.Default.BarColor;
            BarOpacityTrackBar.Value = Convert.ToInt32(Settings.Default.BarOpacity * 100);
            CustomFontDialog.Font = Settings.Default.FontStyle;
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

            Control.ControlCollection appearanceControls = AppearanceGroupBox.Controls;
            Control.ControlCollection behaviorControls = BehaviorGroupBox.Controls;
            foreach (Control ctrl in appearanceControls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).CheckedChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is NumericUpDown)
                {
                    ((NumericUpDown)ctrl).ValueChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is TrackBar)
                {
                    ((TrackBar)ctrl).ValueChanged += new EventHandler(OnSettingsChanged);
                }
            }

            foreach (Control ctrl in behaviorControls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).CheckedChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is NumericUpDown)
                {
                    ((NumericUpDown)ctrl).ValueChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is TrackBar)
                {
                    ((TrackBar)ctrl).ValueChanged += new EventHandler(OnSettingsChanged);
                }
            }
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
        }

        private void SaveBarConfiguration(object sender, EventArgs e)
        {
            Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Settings.Default.BarWidthPadding = (int)SetBarWidthNumericUpDown.Value;
            Settings.Default.BarHeightPadding = (int)SetBarHeightNumericUpDown.Value;

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
            mainForm.MinimumSize = new Size(Settings.Default.BarWidthPadding + (int)newMinSizes.Width, Settings.Default.BarHeightPadding + (int)newMinSizes.Height);
            mainForm.Width = mainForm.MinimumSize.Width;
            mainForm.Height = mainForm.MinimumSize.Height;

            ApplyConfigurationButton.Enabled = false;
        }

        private void SetCustomColor(object sender, EventArgs e)
        {
            CustomColorCheckBox.Checked = true;
            GradientCheckBox.Checked = false;
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
            {
                doSetFont = true;
                OnSettingsChanged(null, null);
            }
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
            CustomFontDialog.Font = Settings.Default.FontStyle;
        }

        private void PickBarColor(object sender, EventArgs e)
        {
            ColorDialog customColor = new ColorDialog
            {
                Color = ColorPreviewPictureBox.BackColor,
                FullOpen = true
            };
            if (customColor.ShowDialog() == DialogResult.OK)
            {
                ColorPreviewPictureBox.BackColor = customColor.Color;
                OnSettingsChanged(null, null);
            }
        }

        private void ConfirmCloseWithoutSaving(object sender, FormClosingEventArgs e)
        {
            if (ApplyConfigurationButton.Enabled == true)
            {
                DialogResult confirmLeave = MessageBox.Show("You have unsaved changes. Leave anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmLeave == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
