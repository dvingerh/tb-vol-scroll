using System;
using System.Drawing;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Forms;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public partial class ConfigurationForm : Form
    {
        private bool doSetVolumeBarFont = false;
        private bool doSetTrayIconFont = false;
        private bool isShowingDialog = false;
        private readonly ColorDialog customColor = new ColorDialog
        {
            FullOpen = true
        };
         FontDialogForm TrayIconCustomFontDialog;
         FontDialogForm VolumeBarCustomFontDialog;

        public ConfigurationForm()
        {
            InitializeComponent();
            TrayIconCustomFontDialog = new FontDialogForm();
            VolumeBarCustomFontDialog = new FontDialogForm();

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
            TrayIconCustomFontDialog.SelectedFont = Settings.Default.TrayIconFontStyle;
            TrayIconFontPreviewLabel.Font = TrayIconCustomFontDialog.SelectedFont;
            TrayIconPropertiesAutomaticCheckBox.Checked = Settings.Default.TrayIconIsDisplayModeAutomatic;
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
            VolumeBarCustomFontDialog.SelectedFont = Settings.Default.VolumeBarFontStyle;
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
                TrayIconPropertiesAutomaticCheckBox.Checked = true;
                TrayIconDisplayModeUserDefinedCheckBox.Checked = false;
            }
            else
            {
                TrayIconPropertiesAutomaticCheckBox.Checked = false;
                TrayIconDisplayModeUserDefinedCheckBox.Checked = true;
            }

            TrayIconTextGradientColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextSolidColorCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextColorPreviewPictureBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconPropertiesAutomaticCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconDisplayModeUserDefinedCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconWidthNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconHeightNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconPaddingNumericUpDown.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconFontStyleButton.Enabled = TrayIconDisplayModeUserDefinedCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconTextRenderingHintComboBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;
            TrayIconFontPreviewLabel.Enabled = DisplayTrayIconAsTextCheckBox.Checked && DisplayTrayIconAsTextCheckBox.Checked;

            Control.ControlCollection appearanceControls = AppearanceGroupBox.Controls;
            Control.ControlCollection behaviourControls = BehaviorGroupBox.Controls;
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
            TrayIconPropertiesAutomaticCheckBox.Enabled = DisplayTrayIconAsTextCheckBox.Checked;
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
            {
                Font newFont = new Font(VolumeBarCustomFontDialog.SelectedFont.FontFamily, VolumeBarCustomFontDialog.SelectedFont.Size, VolumeBarCustomFontDialog.SelectedFont.Style, VolumeBarCustomFontDialog.SelectedFont.Unit);
                Settings.Default.VolumeBarFontStyle = newFont;

            }
            if (doSetTrayIconFont)
            {
                Font newFont = new Font(TrayIconCustomFontDialog.SelectedFont.FontFamily, TrayIconCustomFontDialog.SelectedFont.Size, TrayIconCustomFontDialog.SelectedFont.Style, TrayIconCustomFontDialog.SelectedFont.Unit);
                Settings.Default.TrayIconFontStyle = newFont;
            }

            Settings.Default.VolumeBarUseGradientColor = VolumeBarGradientColorCheckBox.Checked;
            Settings.Default.VolumeBarSolidColor = VolumeBarColorPreviewPictureBox.BackColor;
            Settings.Default.VolumeBarOpacity = VolumeBarOpacityTrackBar.Value / 100.0;

            Settings.Default.DisplayTrayIconAsText = DisplayTrayIconAsTextCheckBox.Checked;
            Settings.Default.TrayIconTextUseGradientColor = TrayIconTextGradientColorCheckBox.Checked;
            Settings.Default.TrayIconTextSolidColor = TrayIconTextColorPreviewPictureBox.BackColor;
            Settings.Default.TrayIconIsDisplayModeAutomatic = TrayIconPropertiesAutomaticCheckBox.Checked;
            Settings.Default.TrayIconWidth = (int)TrayIconWidthNumericUpDown.Value;
            Settings.Default.TrayIconHeight = (int)TrayIconHeightNumericUpDown.Value;
            Settings.Default.TrayIconPadding = (int)TrayIconPaddingNumericUpDown.Value;

            Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

            Settings.Default.TextRenderingHintType = TrayIconTextRenderingHintComboBox.SelectedIndex;
            Globals.TextRenderingHintType = TrayIconTextRenderingHintComboBox.SelectedIndex;

            Settings.Default.Save();


            if (doSetVolumeBarFont)
                Globals.MainForm.VolumeTextLabel.Font = VolumeBarCustomFontDialog.SelectedFont;
           
            Size newMinSizes = Utils.CalculateLabelSize(Globals.MainForm.VolumeTextLabel, "100%");
            Globals.MainForm.MinimumSize = new Size(Settings.Default.BarWidthPadding + newMinSizes.Width, Settings.Default.BarHeightPadding + 5 + newMinSizes.Height);
            Globals.MainForm.Width = Globals.MainForm.MinimumSize.Width;
            Globals.MainForm.Height = Globals.MainForm.MinimumSize.Height;
            Globals.MainForm.SetTrayIcon();
            ApplyConfigurationButton.Enabled = false;
            BehaviorGroupBox.Focus();
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
            isShowingDialog = true;
            VolumeBarCustomFontDialog.SelectedFont = Settings.Default.VolumeBarFontStyle;
            DialogResult dialogResult = VolumeBarCustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                doSetVolumeBarFont = true;
                VolumeBarFontPreviewLabel.Font = VolumeBarCustomFontDialog.SelectedFont;
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
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
            VolumeBarCustomFontDialog.SelectedFont = Settings.Default.VolumeBarFontStyle;
            VolumeBarFontPreviewLabel.Font = VolumeBarCustomFontDialog.SelectedFont;
            TrayIconCustomFontDialog.SelectedFont = Settings.Default.TrayIconFontStyle;
            TrayIconFontPreviewLabel.Font = TrayIconCustomFontDialog.SelectedFont;
            TrayIconWidthNumericUpDown.Enabled = TrayIconPropertiesAutomaticCheckBox.Checked;
            TrayIconHeightNumericUpDown.Enabled = TrayIconPropertiesAutomaticCheckBox.Checked;
            TrayIconWidthNumericUpDown.Value = 32;
            TrayIconHeightNumericUpDown.Value = 32;
            TrayIconPaddingNumericUpDown.Value = 16;
            TrayIconFontStyleButton.Enabled = TrayIconPropertiesAutomaticCheckBox.Checked;
            TrayIconFontPreviewLabel.Enabled = TrayIconPropertiesAutomaticCheckBox.Checked;
            TrayIconTextRenderingHintComboBox.SelectedIndex = 1;
            RestoreDefaultValuesButton.Enabled = false;
        }

        private void PickVolumeBarColor(object sender, EventArgs e)
        {
            isShowingDialog = true;
            customColor.Color = VolumeBarColorPreviewPictureBox.BackColor;
            if (customColor.ShowDialog() == DialogResult.OK)
            {
                VolumeBarColorPreviewPictureBox.BackColor = customColor.Color;
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void ConfirmCloseWithoutSaving(object sender, FormClosingEventArgs e)
        {
            if (ApplyConfigurationButton.Enabled == true && !isShowingDialog)
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
            isShowingDialog = true;
            customColor.Color = TrayIconTextColorPreviewPictureBox.BackColor;

            if (customColor.ShowDialog() == DialogResult.OK)
            {
                TrayIconTextColorPreviewPictureBox.BackColor = customColor.Color;
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;

        }

        private void CloseOnDeactivate(object sender, EventArgs e)
        {
            if (!ApplyConfigurationButton.Enabled && !isShowingDialog)
                Close();
        }

        private void SetTrayIconDisplayModeAutomatic(object sender, EventArgs e)
        {
            TrayIconPropertiesAutomaticCheckBox.Checked = true;
            TrayIconDisplayModeUserDefinedCheckBox.Checked = false;
            TrayIconWidthNumericUpDown.Enabled = false;
            TrayIconHeightNumericUpDown.Enabled = false;
            TrayIconPaddingNumericUpDown.Enabled = false;
            TrayIconFontStyleButton.Enabled = false;
            TrayIconFontPreviewLabel.Enabled = false;
        }

        private void SetTrayIconDisplayModeUserDefinedCheckBox(object sender, EventArgs e)
        {
            TrayIconPropertiesAutomaticCheckBox.Checked = false;
            TrayIconDisplayModeUserDefinedCheckBox.Checked = true;
            TrayIconWidthNumericUpDown.Enabled = true;
            TrayIconHeightNumericUpDown.Enabled = true;
            TrayIconPaddingNumericUpDown.Enabled = true;
            TrayIconFontStyleButton.Enabled = true;
            TrayIconFontPreviewLabel.Enabled = true;
        }

        private void SetTrayIconFontStyle(object sender, EventArgs e)
        {
            isShowingDialog = true;
            TrayIconCustomFontDialog.SelectedFont = Settings.Default.TrayIconFontStyle;
            DialogResult dialogResult = TrayIconCustomFontDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                doSetTrayIconFont = true;
                TrayIconFontPreviewLabel.Font = TrayIconCustomFontDialog.SelectedFont;
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void PreviewFontStyle(object sender, EventArgs e)
        {
            isShowingDialog = true;
            Label senderLabel = (Label)sender;
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            SizeF textSize = g.MeasureString(senderLabel.Text, senderLabel.Font);

            Form fontForm = new Form
            {
                Size = Size,
                Text = senderLabel.Font.Name + ", " + senderLabel.Font.SizeInPoints + "pt",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowIcon = false,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterParent
            };
            fontForm.Deactivate += delegate { fontForm.Close(); };

            Label textLabel = new Label
            {
                Cursor = Cursors.Hand,
                Text = senderLabel.Text,
                Font = senderLabel.Font,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            textLabel.Click += delegate { fontForm.Close(); };
            
            Panel textPanel = new Panel
            {
                Name = "textPanel",
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill
            };

            fontForm.Controls.Add(textPanel);
            fontForm.Controls.Find("textPanel", true)[0].Controls.Add(textLabel);


            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(textLabel, "Click to close");

            fontForm.ShowDialog();
            isShowingDialog = false;
        }

    }
}
