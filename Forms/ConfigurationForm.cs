using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public partial class ConfigurationForm : Form
    {
        private bool doSetFont = false;
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void LoadBarConfiguration(object sender, EventArgs e)
        {
            EnableSwitchPlaybackDeviceOptionCheckBox.Checked = Settings.Default.SwitchDefaultPlaybackDeviceShortcut;
            ReverseScrollingDirectionCheckBox.Checked = Settings.Default.ReverseScrollingDirection;
            EnableMuteUnmuteOptionCheckBox.Checked = Settings.Default.ToggleMuteShortcut;
            ManualPreciseVolumeCheckBox.Checked = Settings.Default.ManualPreciseVolumeShortcut;
            AutoRetryAdminCheckBox.Checked = Settings.Default.AutoRetryAdmin;
            DisplayTrayIconAsTextCheckBox.Checked = Settings.Default.DisplayTrayIconAsText;
            DisplayVolumeBarScrollingCheckBox.Checked = Settings.Default.DisplayVolumeBarScrolling;


            TrayIconTextGradientColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextSolidColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextColorPreviewPictureBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;


            SetVolumeStepNumericUpDown.Value = Settings.Default.VolumeStep;
            ThresholdNumericUpDown.Value = Settings.Default.PreciseScrollThreshold;
            SetVolumeBarWidthNumericUpDown.Value = Settings.Default.BarWidthPadding;
            SetVolumeBarHeightNumericUpDown.Value = Settings.Default.BarHeightPadding;
            AutoHideTimeOutNumericUpDown.Value = Settings.Default.AutoHideTimeOut;
            VolumeBarColorPreviewPictureBox.BackColor = Settings.Default.VolumeBarSolidColor;
            TrayIconTextColorPreviewPictureBox.BackColor = Settings.Default.TrayIconTextSolidColor;
            VolumeBarOpacityTrackBar.Value = Convert.ToInt32(Settings.Default.VolumeBarOpacity * 100);
            CustomFontDialog.Font = Settings.Default.FontStyle;
            FontPreviewLabel.Font = Settings.Default.FontStyle;
            if (Settings.Default.VolumeBarUseGradientColor)
            {
                VolumeBarGradientColorCheckBox.Checked = true;
                VolumeBarSolidColorCheckBox.Checked = false;
            }
            else
            {
                VolumeBarGradientColorCheckBox.Checked = false;
                VolumeBarSolidColorCheckBox.Checked = true;
            }

            if (Settings.Default.TrayIconTextUseGradientColor)
            {
                TrayIconTextGradientColorCheckBox.Checked = true;
                TrayIconTextSolidColorCheckBox.Checked = false;
            }
            else
            {
                TrayIconTextGradientColorCheckBox.Checked = false;
                TrayIconTextSolidColorCheckBox.Checked = true;

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
            TrayIconTextGradientColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextSolidColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextColorPreviewPictureBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;

        }

        private void ApplyBarConfiguration(object sender, EventArgs e)
        {
            Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Settings.Default.BarWidthPadding = (int)SetVolumeBarWidthNumericUpDown.Value;
            Settings.Default.BarHeightPadding = (int)SetVolumeBarHeightNumericUpDown.Value;

            Settings.Default.SwitchDefaultPlaybackDeviceShortcut = EnableSwitchPlaybackDeviceOptionCheckBox.Checked;
            Settings.Default.ToggleMuteShortcut = EnableMuteUnmuteOptionCheckBox.Checked;
            Settings.Default.ReverseScrollingDirection = ReverseScrollingDirectionCheckBox.Checked;
            Settings.Default.ManualPreciseVolumeShortcut = ManualPreciseVolumeCheckBox.Checked;
            Settings.Default.DisplayVolumeBarScrolling = DisplayVolumeBarScrollingCheckBox.Checked;

            Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;


            if (doSetFont)
                Settings.Default.FontStyle = CustomFontDialog.Font;

            Settings.Default.VolumeBarUseGradientColor = VolumeBarGradientColorCheckBox.Checked;
            Settings.Default.VolumeBarSolidColor = VolumeBarColorPreviewPictureBox.BackColor;
            Settings.Default.VolumeBarOpacity = VolumeBarOpacityTrackBar.Value / 100.0;

            Settings.Default.DisplayTrayIconAsText = DisplayTrayIconAsTextCheckBox.Checked;
            Settings.Default.TrayIconTextUseGradientColor = TrayIconTextGradientColorCheckBox.Checked;
            Settings.Default.TrayIconTextSolidColor = TrayIconTextColorPreviewPictureBox.BackColor;

            Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

            Settings.Default.Save();

            if (doSetFont)
                Globals.MainForm.VolumeTextLabel.Font = CustomFontDialog.Font;
           
            SizeF newMinSizes = Utils.CalculateVolumeBarSize(Globals.MainForm.VolumeTextLabel, "100%");
            Globals.MainForm.MinimumSize = new Size(Settings.Default.BarWidthPadding + (int)newMinSizes.Width, Settings.Default.BarHeightPadding + 5 + (int)newMinSizes.Height);
            Globals.MainForm.Width = Globals.MainForm.MinimumSize.Width;
            Globals.MainForm.Height = Globals.MainForm.MinimumSize.Height;
            Globals.MainForm.SetTrayIcon();
            ApplyConfigurationButton.Enabled = false;
            BehaviourGroupBox.Focus();
        }

        private void SetVolumeBarSolidColor(object sender, EventArgs e)
        {
            VolumeBarSolidColorCheckBox.Checked = true;
            VolumeBarGradientColorCheckBox.Checked = false;
            VolumeBarColorPreviewPictureBox.Image = null;
        }

        private void SetVolumeBarGradientColor(object sender, EventArgs e)
        {
            VolumeBarGradientColorCheckBox.Checked = true;
            VolumeBarSolidColorCheckBox.Checked = false;
        }

        private void VolumeBarOpacityChanged(object sender, EventArgs e)
        {
            VolumeBarOpacityValueLabel.Text = $"{VolumeBarOpacityTrackBar.Value}%";
        }

        private void SetFontStyle(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            CustomFontDialog.Font = Settings.Default.FontStyle;
            DialogResult dialogResult = CustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                doSetFont = true;
                FontPreviewLabel.Font = CustomFontDialog.Font;
                OnSettingsChanged(null, null);
            }
            else
                ApplyConfigurationButton.Enabled = false;
        }

        private void RestoreDefaultValues(object sender, EventArgs e)
        {
            RestoreDefaultValuesButton.Enabled = false;
            AutoRetryAdminCheckBox.Checked = false;
            EnableMuteUnmuteOptionCheckBox.Checked = false;
            EnableSwitchPlaybackDeviceOptionCheckBox.Checked = false;
            ReverseScrollingDirectionCheckBox.Checked = false;
            ManualPreciseVolumeCheckBox.Checked = false;
            SetVolumeStepNumericUpDown.Value = 5;
            ThresholdNumericUpDown.Value = 10;
            SetVolumeBarWidthNumericUpDown.Value = 0;
            SetVolumeBarHeightNumericUpDown.Value = 0;
            AutoHideTimeOutNumericUpDown.Value = 1000;
            TrayIconTextGradientColorCheckBox.Checked = true;
            TrayIconTextSolidColorCheckBox.Checked = false;
            DisplayVolumeBarScrollingCheckBox.Checked = true;
            DisplayTrayIconAsTextCheckBox.Checked = false;
            VolumeBarColorPreviewPictureBox.BackColor = Color.SkyBlue;
            TrayIconTextColorPreviewPictureBox.BackColor = Color.SkyBlue;
            VolumeBarOpacityTrackBar.Value = 100;
            VolumeBarGradientColorCheckBox.Checked = true;
            VolumeBarSolidColorCheckBox.Checked = false;
            VolumeBarOpacityValueLabel.Text = $"{VolumeBarOpacityTrackBar.Value}%";
            Settings.Default.FontStyle = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            CustomFontDialog.Font = Settings.Default.FontStyle;
            FontPreviewLabel.Font = CustomFontDialog.Font;
            RestoreDefaultValuesButton.Enabled = false;
        }

        private void PickVolumeBarColor(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            ColorDialog customColor = new ColorDialog
            {
                Color = VolumeBarColorPreviewPictureBox.BackColor,
                FullOpen = true
            };
            if (customColor.ShowDialog() == DialogResult.OK)
            {
                VolumeBarColorPreviewPictureBox.BackColor = customColor.Color;
                OnSettingsChanged(null, null);
            }
            else
                ApplyConfigurationButton.Enabled = false;
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

        private void SetNotificationTextGradientColor(object sender, EventArgs e)
        {
            TrayIconTextGradientColorCheckBox.Checked = true;
            TrayIconTextSolidColorCheckBox.Checked = false;
        }

        private void SetNotificationTextSolidColor(object sender, EventArgs e)
        {
            TrayIconTextSolidColorCheckBox.Checked = true;
            TrayIconTextGradientColorCheckBox.Checked = false;
            TrayIconTextColorPreviewPictureBox.Image = null;
        }

        private void PickNotificationTextColor(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            ColorDialog customColor = new ColorDialog
            {
                Color = TrayIconTextColorPreviewPictureBox.BackColor,
                FullOpen = true
            };
            if (customColor.ShowDialog() == DialogResult.OK)
            {
                TrayIconTextColorPreviewPictureBox.BackColor = customColor.Color;
                OnSettingsChanged(null, null);
            }
            else
                ApplyConfigurationButton.Enabled = false;
        }

        private void ConfigurationForm_Deactivate(object sender, EventArgs e)
        {
            if (!ApplyConfigurationButton.Enabled)
                Close();
        }
    }
}
