using System;
using System.Drawing;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public partial class ConfigurationForm : Form
    {
        private bool doSetVolumeBarFont = false;
        private bool doSetTrayIconFont = false;
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void LoadBarConfiguration(object sender, EventArgs e)
        {
            EnableSwitchPlaybackDeviceOptionCheckBox.Checked = Settings.Default.SwitchDefaultPlaybackDeviceShortcut;
            InvertScrollingDirectionCheckBox.Checked = Settings.Default.InvertScrollingDirection;
            EnableMuteUnmuteOptionCheckBox.Checked = Settings.Default.ToggleMuteShortcut;
            ManualPreciseVolumeCheckBox.Checked = Settings.Default.ManualPreciseVolumeShortcut;
            AutoRetryAdminCheckBox.Checked = Settings.Default.AutoRetryAdmin;
            DisplayTrayIconAsTextCheckBox.Checked = Settings.Default.DisplayTrayIconAsText;
            DisplayVolumeBarScrollingCheckBox.Checked = Settings.Default.DisplayVolumeBarScrolling;
            IgnoreTaskbarVisibilityCheckBox.Checked = Settings.Default.IgnoreTaskbarVisibility;

            TrayIconTextGradientColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextSolidColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextColorPreviewPictureBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconCustomFontDialog.Font = Settings.Default.TrayIconFontStyle;
            TrayIconFontPreviewLabel.Font = TrayIconCustomFontDialog.Font;
            TrayIconDisplayModeAutomaticCheckBox.Checked = Settings.Default.TrayIconIsDisplayModeAutomatic;
            TrayIconDisplayModeUserDefinedCheckBox.Checked = !Settings.Default.TrayIconIsDisplayModeAutomatic;
            TrayIconWidthNumericUpDown.Value = Settings.Default.TrayIconWidth;
            TrayIconHeightNumericUpDown.Value = Settings.Default.TrayIconHeight;
            TrayIconPaddingNumericUpDown.Value = Settings.Default.TrayIconPadding;


            SetVolumeStepNumericUpDown.Value = Settings.Default.VolumeStep;
            ThresholdNumericUpDown.Value = Settings.Default.PreciseScrollThreshold;
            VolumeBarPaddingWidthNumericUpDown.Value = Settings.Default.BarWidthPadding;
            VolumeBarPaddingHeightNumericUpDown.Value = Settings.Default.BarHeightPadding;
            AutoHideTimeOutNumericUpDown.Value = Settings.Default.AutoHideTimeOut;
            VolumeBarColorPreviewPictureBox.BackColor = Settings.Default.VolumeBarSolidColor;
            TrayIconTextColorPreviewPictureBox.BackColor = Settings.Default.TrayIconTextSolidColor;
            VolumeBarOpacityTrackBar.Value = Convert.ToInt32(Settings.Default.VolumeBarOpacity * 100);
            VolumeBarCustomFontDialog.Font = Settings.Default.VolumeBarFontStyle;
            VolumeBarFontPreviewLabel.Font = Settings.Default.VolumeBarFontStyle;

            TrayIconTextRenderingHintComboBox.SelectedIndex = Settings.Default.TextRenderingHintType;

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
            if (Settings.Default.TrayIconIsDisplayModeAutomatic)
            {
                TrayIconDisplayModeAutomaticCheckBox.Checked = true;
                TrayIconDisplayModeUserDefinedCheckBox.Checked = false;
            }
            else
            {
                TrayIconDisplayModeAutomaticCheckBox.Checked = false;
                TrayIconDisplayModeUserDefinedCheckBox.Checked = true;
            }

            TrayIconTextGradientColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextSolidColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextColorPreviewPictureBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconDisplayModeAutomaticCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconDisplayModeUserDefinedCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconWidthNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconHeightNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconPaddingNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconFontStyleButton.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextRenderingHintComboBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;


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
                if (ctrl is ComboBox cBox)
                {
                    cBox.SelectedIndexChanged += new EventHandler(OnSettingsChanged);
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
            AppearanceGroupBox.Focus();
        }

        private void OnSettingsChanged(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            RestoreDefaultValuesButton.Enabled = true;
            TrayIconTextGradientColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextSolidColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextColorPreviewPictureBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconDisplayModeAutomaticCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconDisplayModeUserDefinedCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconWidthNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconHeightNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconPaddingNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconFontStyleButton.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextRenderingHintComboBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;

        }

        private void ApplyBarConfiguration(object sender, EventArgs e)
        {
            Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            Settings.Default.VolumeStep = (int)SetVolumeStepNumericUpDown.Value;
            Settings.Default.BarWidthPadding = (int)VolumeBarPaddingWidthNumericUpDown.Value;
            Settings.Default.BarHeightPadding = (int)VolumeBarPaddingHeightNumericUpDown.Value;

            Settings.Default.SwitchDefaultPlaybackDeviceShortcut = EnableSwitchPlaybackDeviceOptionCheckBox.Checked;
            Settings.Default.ToggleMuteShortcut = EnableMuteUnmuteOptionCheckBox.Checked;
            Settings.Default.InvertScrollingDirection = InvertScrollingDirectionCheckBox.Checked;
            Settings.Default.ManualPreciseVolumeShortcut = ManualPreciseVolumeCheckBox.Checked;
            Settings.Default.DisplayVolumeBarScrolling = DisplayVolumeBarScrollingCheckBox.Checked;
            Settings.Default.IgnoreTaskbarVisibility = IgnoreTaskbarVisibilityCheckBox.Checked;

            Settings.Default.PreciseScrollThreshold = (int)ThresholdNumericUpDown.Value;


            if (doSetVolumeBarFont)
                Settings.Default.VolumeBarFontStyle = VolumeBarCustomFontDialog.Font;
            if (doSetTrayIconFont)
                Settings.Default.TrayIconFontStyle = TrayIconCustomFontDialog.Font;

            Settings.Default.VolumeBarUseGradientColor = VolumeBarGradientColorCheckBox.Checked;
            Settings.Default.VolumeBarSolidColor = VolumeBarColorPreviewPictureBox.BackColor;
            Settings.Default.VolumeBarOpacity = VolumeBarOpacityTrackBar.Value / 100.0;

            Settings.Default.DisplayTrayIconAsText = DisplayTrayIconAsTextCheckBox.Checked;
            Settings.Default.TrayIconTextUseGradientColor = TrayIconTextGradientColorCheckBox.Checked;
            Settings.Default.TrayIconTextSolidColor = TrayIconTextColorPreviewPictureBox.BackColor;
            Settings.Default.TrayIconIsDisplayModeAutomatic = TrayIconDisplayModeAutomaticCheckBox.Checked;
            Settings.Default.TrayIconWidth = (int)TrayIconWidthNumericUpDown.Value;
            Settings.Default.TrayIconHeight = (int)TrayIconHeightNumericUpDown.Value;
            Settings.Default.TrayIconPadding = (int)TrayIconPaddingNumericUpDown.Value;

            Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

            Settings.Default.TextRenderingHintType = TrayIconTextRenderingHintComboBox.SelectedIndex;
            Globals.TextRenderingHintType = TrayIconTextRenderingHintComboBox.SelectedIndex;

            Settings.Default.Save();

            if (doSetVolumeBarFont)
                Globals.MainForm.VolumeTextLabel.Font = VolumeBarCustomFontDialog.Font;
           
            Size newMinSizes = Utils.CalculateLabelSize(Globals.MainForm.VolumeTextLabel, "100%");
            Globals.MainForm.MinimumSize = new Size(Settings.Default.BarWidthPadding + newMinSizes.Width, Settings.Default.BarHeightPadding + 5 + newMinSizes.Height);
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

        private void SetVolumeBarFontStyle(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            VolumeBarCustomFontDialog.Font = Settings.Default.VolumeBarFontStyle;
            DialogResult dialogResult = VolumeBarCustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                doSetVolumeBarFont = true;
                VolumeBarFontPreviewLabel.Font = VolumeBarCustomFontDialog.Font;
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
            InvertScrollingDirectionCheckBox.Checked = false;
            ManualPreciseVolumeCheckBox.Checked = false;
            SetVolumeStepNumericUpDown.Value = 5;
            ThresholdNumericUpDown.Value = 10;
            VolumeBarPaddingWidthNumericUpDown.Value = 0;
            VolumeBarPaddingHeightNumericUpDown.Value = 0;
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
            Settings.Default.VolumeBarFontStyle = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            VolumeBarCustomFontDialog.Font = Settings.Default.VolumeBarFontStyle;
            VolumeBarFontPreviewLabel.Font = VolumeBarCustomFontDialog.Font;
            TrayIconCustomFontDialog.Font = Settings.Default.TrayIconFontStyle;
            TrayIconFontPreviewLabel.Font = TrayIconCustomFontDialog.Font;
            TrayIconWidthNumericUpDown.Enabled = TrayIconDisplayModeAutomaticCheckBox.Checked;
            TrayIconHeightNumericUpDown.Enabled = TrayIconDisplayModeAutomaticCheckBox.Checked;
            TrayIconWidthNumericUpDown.Value = 32;
            TrayIconHeightNumericUpDown.Value = 32;
            TrayIconPaddingNumericUpDown.Value = 1;
            TrayIconFontStyleButton.Enabled = TrayIconDisplayModeAutomaticCheckBox.Checked;
            TrayIconTextRenderingHintComboBox.SelectedIndex = 1;
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

        private void CloseOnDeactivate(object sender, EventArgs e)
        {
            if (!ApplyConfigurationButton.Enabled)
                Close();
        }

        private void SetTrayIconDisplayModeAutomatic(object sender, EventArgs e)
        {
            TrayIconDisplayModeAutomaticCheckBox.Checked = true;
            TrayIconDisplayModeUserDefinedCheckBox.Checked = false;
            TrayIconWidthNumericUpDown.Enabled = false;
            TrayIconHeightNumericUpDown.Enabled = false;
            TrayIconPaddingNumericUpDown.Enabled = false;
            TrayIconFontStyleButton.Enabled = false;
        }

        private void SetTrayIconDisplayModeUserDefinedCheckBox(object sender, EventArgs e)
        {
            TrayIconDisplayModeAutomaticCheckBox.Checked = false;
            TrayIconDisplayModeUserDefinedCheckBox.Checked = true;
            TrayIconWidthNumericUpDown.Enabled = true;
            TrayIconHeightNumericUpDown.Enabled = true;
            TrayIconPaddingNumericUpDown.Enabled = true;
            TrayIconFontStyleButton.Enabled = true;

        }

        private void SetTrayIconFontStyle(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            TrayIconCustomFontDialog.Font = Settings.Default.TrayIconFontStyle;
            DialogResult dialogResult = TrayIconCustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                doSetTrayIconFont = true;
                TrayIconFontPreviewLabel.Font = TrayIconCustomFontDialog.Font;
                OnSettingsChanged(null, null);
            }
            else
                ApplyConfigurationButton.Enabled = false;
        }
    }
}
