using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public partial class ConfigurationForm : Form
    {
        private readonly MainForm mainForm;
        private bool doSetFont = false;
        public ConfigurationForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void LoadBarConfiguration(object sender, EventArgs e)
        {
            EnableSwitchPlaybackDeviceOption.Checked = Settings.Default.SwitchDefaultPlaybackDeviceShortcut;
            ReverseScrollingDirectionCheckBox.Checked = Settings.Default.ReverseScrollingDirection;
            EnableMuteUnmuteOption.Checked = Settings.Default.ToggleMuteShortcut;
            ManualPreciseVolumeCheckBox.Checked = Settings.Default.ManualPreciseVolumeShortcut;
            AutoRetryAdminCheckBox.Checked = Settings.Default.AutoRetryAdmin;
            SetVolumeStepNumericUpDown.Value = Settings.Default.VolumeStep;
            ThresholdNumericUpDown.Value = Settings.Default.PreciseScrollThreshold;
            SetBarWidthNumericUpDown.Value = Settings.Default.BarWidthPadding;
            SetBarHeightNumericUpDown.Value = Settings.Default.BarHeightPadding;
            AutoHideTimeOutNumericUpDown.Value = Settings.Default.AutoHideTimeOut;
            ColorPreviewPictureBox.BackColor = Settings.Default.BarColor;
            BarOpacityTrackBar.Value = Convert.ToInt32(Settings.Default.BarOpacity * 100);
            CustomFontDialog.Font = Settings.Default.FontStyle;
            FontPreviewLabel.Font = Settings.Default.FontStyle;
            if (Settings.Default.UseBarGradient)
            {
                GradientColorCheckBox.Checked = true;
                SolidColorCheckBox.Checked = false;
            }
            else
            {
                GradientColorCheckBox.Checked = false;
                SolidColorCheckBox.Checked = true;
            }

            Control.ControlCollection appearanceControls = AppearanceGroupBox.Controls;
            Control.ControlCollection behaviourControls = BehaviourGroupBox.Controls;
            foreach (Control ctrl in appearanceControls)
            {
                if (ctrl is CheckBox box)
                {
                    box.CheckedChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is NumericUpDown down)
                {
                    down.ValueChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is TrackBar bar)
                {
                    bar.ValueChanged += new EventHandler(OnSettingsChanged);
                }
            }

            foreach (Control ctrl in behaviourControls)
            {
                if (ctrl is CheckBox box)
                {
                    box.CheckedChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is NumericUpDown down)
                {
                    down.ValueChanged += new EventHandler(OnSettingsChanged);
                }
                if (ctrl is TrackBar bar)
                {
                    bar.ValueChanged += new EventHandler(OnSettingsChanged);
                }
            }
            BehaviourGroupBox.Focus();
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            RestoreDefaultValuesButton.Enabled = true;
        }

        private void ApplyBarConfiguration(object sender, EventArgs e)
        {
            Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Settings.Default.BarWidthPadding = (int)SetBarWidthNumericUpDown.Value;
            Settings.Default.BarHeightPadding = (int)SetBarHeightNumericUpDown.Value;

            Settings.Default.SwitchDefaultPlaybackDeviceShortcut = EnableSwitchPlaybackDeviceOption.Checked;
            Settings.Default.ToggleMuteShortcut = EnableMuteUnmuteOption.Checked;
            Settings.Default.ReverseScrollingDirection = ReverseScrollingDirectionCheckBox.Checked;
            Settings.Default.ManualPreciseVolumeShortcut = ManualPreciseVolumeCheckBox.Checked;

            Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;


            if (doSetFont)
                Settings.Default.FontStyle = CustomFontDialog.Font;

            Settings.Default.UseBarGradient = GradientColorCheckBox.Checked;
            Settings.Default.BarColor = ColorPreviewPictureBox.BackColor;
            Settings.Default.BarOpacity = BarOpacityTrackBar.Value / 100.0;

            Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

            Settings.Default.Save();

            if (doSetFont)
                mainForm.VolumeTextLabel.Font = CustomFontDialog.Font;
           
            SizeF newMinSizes = mainForm.CalculateBarSize("100%");
            mainForm.MinimumSize = new Size(Settings.Default.BarWidthPadding + (int)newMinSizes.Width, Settings.Default.BarHeightPadding + 5 + (int)newMinSizes.Height);
            mainForm.Width = mainForm.MinimumSize.Width;
            mainForm.Height = mainForm.MinimumSize.Height;
            BehaviourGroupBox.Focus();
            ApplyConfigurationButton.Enabled = false;
        }

        private void SetSolidColor(object sender, EventArgs e)
        {
            SolidColorCheckBox.Checked = true;
            GradientColorCheckBox.Checked = false;
            ColorPreviewPictureBox.Image = null;
        }

        private void SetGradientColor(object sender, EventArgs e)
        {
            GradientColorCheckBox.Checked = true;
            SolidColorCheckBox.Checked = false;
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
                FontPreviewLabel.Font = CustomFontDialog.Font;
                OnSettingsChanged(null, null);
            }
        }

        private void RestoreDefaultValues(object sender, EventArgs e)
        {
            RestoreDefaultValuesButton.Enabled = false;
            AutoRetryAdminCheckBox.Checked = false;
            EnableMuteUnmuteOption.Checked = false;
            EnableSwitchPlaybackDeviceOption.Checked = false;
            ReverseScrollingDirectionCheckBox.Checked = false;
            ManualPreciseVolumeCheckBox.Checked = false;
            SetVolumeStepNumericUpDown.Value = 5;
            ThresholdNumericUpDown.Value = 10;
            SetBarWidthNumericUpDown.Value = 0;
            SetBarHeightNumericUpDown.Value = 0;
            AutoHideTimeOutNumericUpDown.Value = 1000;
            ColorPreviewPictureBox.BackColor = Color.SkyBlue;
            BarOpacityTrackBar.Value = 100;
            GradientColorCheckBox.Checked = true;
            SolidColorCheckBox.Checked = false;
            OpacityValueLabel.Text = $"{BarOpacityTrackBar.Value}%";
            Settings.Default.FontStyle = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            CustomFontDialog.Font = Settings.Default.FontStyle;
            FontPreviewLabel.Font = CustomFontDialog.Font;
            RestoreDefaultValuesButton.Enabled = false;
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
                    e.Cancel = true;
            }
        }
    }
}
