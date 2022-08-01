using System;
using System.Windows.Forms;
using tb_vol_scroll.Properties;
using tb_vol_scroll.Classes.Helpers;
using tb_vol_scroll.Classes;
using System.Drawing;
using System.Threading.Tasks;

namespace tb_vol_scroll.Forms
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private FontDialogForm fontPickerDialog;
        private Font statusBarFont;
        private Font trayIconFont;
        private bool isShowingDialog = false;

        private readonly ColorDialog colorPickerDialog = new ColorDialog
        {
            FullOpen = true
        };

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            #region Behavior
            NormalVolumeStepNumericUpDown.Value = Settings.Default.NormalVolumeStep;
            PreciseVolumeThresholdNumericUpDown.Value = Settings.Default.PreciseVolumeThreshold;
            AutoHideTimeOutNumericUpDown.Value = Settings.Default.AutoHideTimeOut;

            CtrlHotkeyCheckBox.Checked = Settings.Default.CtrlHotkeyEnabled;
            ShiftHotkeyCheckBox.Checked = Settings.Default.ShiftHotkeyEnabled;
            AltHotkeyCheckBox.Checked = Settings.Default.AltHotkeyEnabled;

            IgnoreTaskbarVisibilityCheckBox.Checked = Settings.Default.IgnoreTaskbarVisibility;
            InvertScrollingDirectionCheckBox.Checked = Settings.Default.InvertScrollingDirection;
            AutoRetryAdminCheckBox.Checked = Settings.Default.AutoRetryAdmin;

            foreach (Control ctrl in Utils.GetAllControls(BehaviorTabPage))
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
            #endregion

            #region Appearance
            DisplayStatusBarScrollActionsCheckBox.Checked = Settings.Default.DisplayStatusBarScrollActions;
            StatusBarWidthPaddingNumericUpDown.Value = Settings.Default.StatusBarWidthPadding;
            StatusBarHeightPaddingNumericUpDown.Value = Settings.Default.StatusBarHeightPadding;
            StatusBarOpacityTrackBar.Value = Convert.ToInt32(Settings.Default.StatusBarOpacity * 100);
            statusBarFont = Settings.Default.StatusBarFontStyle;
            StatusBarFontStyleValueLabel.Text = GetFontDetails(statusBarFont);

            TrayIconOverrideAutoSettingsCheckBox.Checked = Settings.Default.TrayIconOverrideAutoSettings;
            TrayIconTextRenderingHintingComboBox.SelectedIndex = Settings.Default.TrayIconTextRenderingHinting;
            TrayIconWidthNumericUpDown.Value = Settings.Default.TrayIconWidth;
            TrayIconHeightNumericUpDown.Value = Settings.Default.TrayIconHeight;
            TrayIconWidthPaddingNumericUpDown.Value = Settings.Default.TrayIconXAlignment;
            TrayIconHeightPaddingNumericUpDown.Value = Settings.Default.TrayIconYAlignment;
            trayIconFont = Settings.Default.TrayIconFontStyle;
            TrayIconFontStyleValueLabel.Text = GetFontDetails(trayIconFont);

            StatusBarColorValuePictureBox.BackColor = Settings.Default.StatusBarColor;
            StatusBarColorSolidCheckBox.Checked = !Settings.Default.StatusBarColorIsGradient;
            StatusBarColorGradientCheckBox.Checked = Settings.Default.StatusBarColorIsGradient;

            TrayIconColorValuePictureBox.BackColor = Settings.Default.TrayIconColorText;
            TrayIconTextColorSolidCheckBox.Checked = !Settings.Default.TrayIconColorTextIsGradient;
            TrayIconTextColorGradientCheckBox.Checked = Settings.Default.TrayIconColorTextIsGradient;

            StatusBarTextColorValuePictureBox.BackColor = Settings.Default.StatusBarTextColor;
            StatusBarTextColorSolidCheckBox.Checked = !Settings.Default.StatusBarTextColorIsGradient;
            StatusBarTextColorGradientCheckBox.Checked = Settings.Default.StatusBarTextColorIsGradient;

            TrayIconColorRgbValueLabel.Text = $"R: {TrayIconColorValuePictureBox.BackColor.R} " +
            $"G: {TrayIconColorValuePictureBox.BackColor.G} " +
            $"B: {TrayIconColorValuePictureBox.BackColor.B}";

            StatusBarColorRgbValueLabel.Text = $"R: {StatusBarColorValuePictureBox.BackColor.R} " +
            $"G: {StatusBarColorValuePictureBox.BackColor.G} " +
            $"B: {StatusBarColorValuePictureBox.BackColor.B}";

            foreach (Control ctrl in Utils.GetAllControls(AppearanceTabPage))
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
                if (ctrl is ComboBox combox)
                {
                    combox.SelectedIndexChanged += new EventHandler(OnSettingsChanged);
                }
            }
            #endregion

            Utils.InvokeIfRequired(this, () => { fontPickerDialog = new FontDialogForm(); });;
        }


        private void OnSettingsChanged(object sender, EventArgs e)
        {
            ApplyConfigurationButton.Enabled = true;
            RestoreDefaultsButton.Enabled = true;
            
        }

        private void ApplyConfigurationButton_Click(object sender, EventArgs e)
        {
            #region Behavior
            Settings.Default.NormalVolumeStep = (int)NormalVolumeStepNumericUpDown.Value;
            Settings.Default.PreciseVolumeThreshold = (int)PreciseVolumeThresholdNumericUpDown.Value;
            Settings.Default.AutoHideTimeOut = (int)AutoHideTimeOutNumericUpDown.Value;

            Settings.Default.CtrlHotkeyEnabled = CtrlHotkeyCheckBox.Checked;
            Settings.Default.ShiftHotkeyEnabled = ShiftHotkeyCheckBox.Checked;
            Settings.Default.AltHotkeyEnabled = AltHotkeyCheckBox.Checked;
            
            Settings.Default.InvertScrollingDirection = InvertScrollingDirectionCheckBox.Checked;
            Settings.Default.IgnoreTaskbarVisibility = IgnoreTaskbarVisibilityCheckBox.Checked;
            Settings.Default.AutoRetryAdmin = AutoRetryAdminCheckBox.Checked;
            #endregion

            #region Appearance
            Settings.Default.DisplayStatusBarScrollActions = DisplayStatusBarScrollActionsCheckBox.Checked;
            Settings.Default.StatusBarWidthPadding = (int)StatusBarWidthPaddingNumericUpDown.Value;
            Settings.Default.StatusBarHeightPadding = (int)StatusBarHeightPaddingNumericUpDown.Value;
            Settings.Default.StatusBarOpacity = StatusBarOpacityTrackBar.Value / 100.0;
            Font newStatusBarFont = new Font(statusBarFont.FontFamily, statusBarFont.Size, statusBarFont.Style, statusBarFont.Unit);
            Settings.Default.StatusBarFontStyle = newStatusBarFont;


            Settings.Default.TrayIconOverrideAutoSettings = TrayIconOverrideAutoSettingsCheckBox.Checked;
            Settings.Default.TrayIconTextRenderingHinting = TrayIconTextRenderingHintingComboBox.SelectedIndex;
            Settings.Default.TrayIconWidth = (int)TrayIconWidthNumericUpDown.Value;
            Settings.Default.TrayIconHeight = (int)TrayIconHeightNumericUpDown.Value;
            Settings.Default.TrayIconXAlignment = (int)TrayIconWidthPaddingNumericUpDown.Value;
            Settings.Default.TrayIconYAlignment = (int)TrayIconHeightPaddingNumericUpDown.Value;
            Font newTrayIconFont = new Font(trayIconFont.FontFamily, trayIconFont.Size, trayIconFont.Style, trayIconFont.Unit);
            Settings.Default.TrayIconFontStyle = newTrayIconFont;



            Settings.Default.StatusBarColor = StatusBarColorValuePictureBox.BackColor;
            Settings.Default.StatusBarColorIsGradient = StatusBarColorGradientCheckBox.Checked;

            Settings.Default.TrayIconColorText = TrayIconColorValuePictureBox.BackColor;
            Settings.Default.TrayIconColorTextIsGradient = TrayIconTextColorGradientCheckBox.Checked;

            Settings.Default.StatusBarTextColor = StatusBarTextColorValuePictureBox.BackColor;
            Settings.Default.StatusBarTextColorIsGradient = StatusBarTextColorGradientCheckBox.Checked;
            #endregion

            Settings.Default.Save();
            Globals.MainForm.SetAppAppearances(Enums.ActionTriggerType.ConfigurationApplied);
            ApplyConfigurationButton.Enabled = false;


        }

        private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ApplyConfigurationButton.Enabled == true && !isShowingDialog)
            {
                DialogResult confirmLeave = MessageBox.Show("You have unsaved changes. Leave anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmLeave == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void ConfigurationForm_Deactivate(object sender, EventArgs e)
        {
            if (!ApplyConfigurationButton.Enabled && !isShowingDialog)
                Close();
        }

        private void StatusBarSolidColorCheckBox_Click(object sender, EventArgs e)
        {
            isShowingDialog = true;
            
            StatusBarColorSolidCheckBox.Checked = true;
            StatusBarColorGradientCheckBox.Checked = false;

            colorPickerDialog.Color = StatusBarColorValuePictureBox.BackColor;
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                StatusBarColorValuePictureBox.BackColor = colorPickerDialog.Color;
                StatusBarColorRgbValueLabel.Text = $"R: {StatusBarColorValuePictureBox.BackColor.R} " +
                $"G: {StatusBarColorValuePictureBox.BackColor.G} " +
                $"B: {StatusBarColorValuePictureBox.BackColor.B}";
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void StatusBarGradientColorCheckBox_Click(object sender, EventArgs e)
        {
            StatusBarColorSolidCheckBox.Checked = false;
            StatusBarColorGradientCheckBox.Checked = true;

        }

        private void StatusBarOpacityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            StatusBarOpacityValueLabel.Text = $"{StatusBarOpacityTrackBar.Value}%";
        }

        private void TrayIconTextGradientColorCheckBox_Click(object sender, EventArgs e)
        {
            TrayIconTextColorGradientCheckBox.Checked = true;
            TrayIconTextColorSolidCheckBox.Checked = false;
        }

        private void TrayIconTextSolidColorCheckBox_Click(object sender, EventArgs e)
        {
            isShowingDialog = true;

            TrayIconTextColorSolidCheckBox.Checked = true;
            TrayIconTextColorGradientCheckBox.Checked = false;

            colorPickerDialog.Color = TrayIconColorValuePictureBox.BackColor;
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                TrayIconColorValuePictureBox.BackColor = colorPickerDialog.Color;
                TrayIconColorRgbValueLabel.Text =
                $"R: {TrayIconColorValuePictureBox.BackColor.R} " +
                $"G: {TrayIconColorValuePictureBox.BackColor.G} " +
                $"B: {TrayIconColorValuePictureBox.BackColor.B}";
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void TrayIconHintingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(TrayIconTextRenderingHintingComboBox.SelectedIndex)
            {
                case 0:
                    TrayIconTextRenderingHintingDescriptionLabel.Text = "Uses the default hinting";
                    break;
                case 1:
                    TrayIconTextRenderingHintingDescriptionLabel.Text = "Better on dark backgrounds";
                    break;
                case 2:
                    TrayIconTextRenderingHintingDescriptionLabel.Text = "Balanced";
                    break;
                case 3:
                    TrayIconTextRenderingHintingDescriptionLabel.Text = "Better on light backgrounds";
                    break;
            }
        }

        private void StatusBarFontSelectButton_Click(object sender, EventArgs e)
        {
            isShowingDialog = true;
            fontPickerDialog.SelectedFont = statusBarFont;
            DialogResult dialogResult = fontPickerDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                statusBarFont = fontPickerDialog.SelectedFont;
                StatusBarFontStyleValueLabel.Text = GetFontDetails(fontPickerDialog.SelectedFont);
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void TrayIconFontSelectButton_Click(object sender, EventArgs e)
        {
            isShowingDialog = true;
            fontPickerDialog.SelectedFont = trayIconFont;
            DialogResult dialogResult = fontPickerDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                trayIconFont = fontPickerDialog.SelectedFont;
                TrayIconFontStyleValueLabel.Text = GetFontDetails(fontPickerDialog.SelectedFont);
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void StatusBarFontPreviewButton_Click(object sender, EventArgs e)
        {
            PreviewFontStyle(statusBarFont);
        }

        private void TrayIconFontPreviewButton_Click(object sender, EventArgs e)
        {
            if (!TrayIconOverrideAutoSettingsCheckBox.Checked)
            {
                float fontSize = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
                PreviewFontStyle(new Font("Segoe UI Semibold", fontSize, FontStyle.Regular));
            }
            else
                PreviewFontStyle(trayIconFont);
        }

        private string GetFontDetails(Font font)
        {
            return $"{font.Name}; {font.Style}; {font.SizeInPoints}pt";
        }

        private void PreviewFontStyle(Font font)
        {
            isShowingDialog = true;

            Form fontForm = new Form
            {
                Size = Size,
                Text = GetFontDetails(font),
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
                Text = GetFontDetails(font),
                Font = font,
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

        private void RestoreDefaultsButton_Click(object sender, EventArgs e)
        {
            #region Behavior
            NormalVolumeStepNumericUpDown.Value = 5;
            PreciseVolumeThresholdNumericUpDown.Value = 10;
            AutoHideTimeOutNumericUpDown.Value = 1000;

            CtrlHotkeyCheckBox.Checked = false;
            ShiftHotkeyCheckBox.Checked = false;
            AltHotkeyCheckBox.Checked = false;

            IgnoreTaskbarVisibilityCheckBox.Checked = false;
            InvertScrollingDirectionCheckBox.Checked = false;
            AutoRetryAdminCheckBox.Checked = false;
            #endregion

            #region Appearance
            DisplayStatusBarScrollActionsCheckBox.Checked = true;
            StatusBarWidthPaddingNumericUpDown.Value = 5;
            StatusBarHeightPaddingNumericUpDown.Value = 5;
            StatusBarOpacityTrackBar.Value = 100;
            statusBarFont = new Font("Segoe UI Semibold", 9, FontStyle.Bold, GraphicsUnit.Point);
            StatusBarFontStyleValueLabel.Text = GetFontDetails(statusBarFont);

            TrayIconOverrideAutoSettingsCheckBox.Checked = false;
            TrayIconTextRenderingHintingComboBox.SelectedIndex = 0;
            TrayIconWidthNumericUpDown.Value = 32;
            TrayIconHeightNumericUpDown.Value = 32;
            TrayIconWidthPaddingNumericUpDown.Value = 0;
            TrayIconHeightPaddingNumericUpDown.Value = 0;
            trayIconFont = new Font("Segoe UI Semibold", 36, FontStyle.Regular, GraphicsUnit.Point);
            TrayIconFontStyleValueLabel.Text = GetFontDetails(trayIconFont);

            StatusBarColorValuePictureBox.BackColor = Color.SkyBlue;
            StatusBarColorSolidCheckBox.Checked = false;
            StatusBarColorGradientCheckBox.Checked = true;

            TrayIconColorValuePictureBox.BackColor = Color.SkyBlue;
            TrayIconTextColorSolidCheckBox.Checked = false;
            TrayIconTextColorGradientCheckBox.Checked = true;

            StatusBarTextColorValuePictureBox.BackColor = Color.Black;
            StatusBarTextColorSolidCheckBox.Checked = true;
            StatusBarTextColorGradientCheckBox.Checked = false;


            TrayIconColorRgbValueLabel.Text = $"R: {TrayIconColorValuePictureBox.BackColor.R} " +
            $"G: {TrayIconColorValuePictureBox.BackColor.G} " +
            $"B: {TrayIconColorValuePictureBox.BackColor.B}";

            StatusBarColorRgbValueLabel.Text = $"R: {StatusBarColorValuePictureBox.BackColor.R} " +
            $"G: {StatusBarColorValuePictureBox.BackColor.G} " +
            $"B: {StatusBarColorValuePictureBox.BackColor.B}";

            #endregion

            RestoreDefaultsButton.Enabled = false;
            ApplyConfigurationButton.Enabled = true;
        }

        private void StatusBarTextColorSolidCheckBox_Click(object sender, EventArgs e)
        {
            isShowingDialog = true;

            StatusBarTextColorSolidCheckBox.Checked = true;
            StatusBarTextColorGradientCheckBox.Checked = false;

            colorPickerDialog.Color = StatusBarTextColorValuePictureBox.BackColor;
            if (colorPickerDialog.ShowDialog() == DialogResult.OK)
            {
                StatusBarTextColorValuePictureBox.BackColor = colorPickerDialog.Color;
                StatusBarTextColorRgbValueLabel.Text =
                $"R: {StatusBarTextColorValuePictureBox.BackColor.R} " +
                $"G: {StatusBarTextColorValuePictureBox.BackColor.G} " +
                $"B: {StatusBarTextColorValuePictureBox.BackColor.B}";
                OnSettingsChanged(null, null);
            }
            isShowingDialog = false;
        }

        private void StatusBarTextColorGradientCheckBox_Click(object sender, EventArgs e)
        {
            StatusBarTextColorSolidCheckBox.Checked = false;
            StatusBarTextColorGradientCheckBox.Checked = true;
        }

        private void TrayIconOverrideAutoSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!TrayIconOverrideAutoSettingsCheckBox.Checked)
            {
                TrayIconTextRenderingHintingComboBox.Enabled = false;
                TrayIconTextRenderingHintingComboBox.SelectedIndex = 1;

                TrayIconWidthNumericUpDown.Enabled = false;
                TrayIconWidthNumericUpDown.Value = (decimal)(Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale);
                TrayIconHeightNumericUpDown.Enabled = false;
                TrayIconHeightNumericUpDown.Value = (decimal)(Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale);

                TrayIconWidthPaddingNumericUpDown.Enabled = false;
                TrayIconWidthPaddingNumericUpDown.Value = 0;
                TrayIconHeightPaddingNumericUpDown.Enabled = false;
                TrayIconHeightPaddingNumericUpDown.Value = 0;

                float fontSize = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
                TrayIconFontStyleValueLabel.Text = GetFontDetails(new Font("Segoe UI Semibold", fontSize, FontStyle.Regular));
                TrayIconSelectFontStyleButton.Enabled = false;

            }
            else
            {
                TrayIconTextRenderingHintingComboBox.Enabled = true;
                TrayIconTextRenderingHintingComboBox.SelectedIndex = Settings.Default.TrayIconTextRenderingHinting;
                TrayIconWidthNumericUpDown.Enabled = true;
                TrayIconWidthNumericUpDown.Value = Settings.Default.TrayIconWidth;
                TrayIconHeightNumericUpDown.Enabled = true;
                TrayIconHeightNumericUpDown.Value = Settings.Default.TrayIconHeight;

                TrayIconWidthPaddingNumericUpDown.Enabled = true;
                TrayIconWidthPaddingNumericUpDown.Value = Settings.Default.TrayIconXAlignment;
                TrayIconHeightPaddingNumericUpDown.Enabled = true;
                TrayIconHeightPaddingNumericUpDown.Value = Settings.Default.TrayIconYAlignment;

                TrayIconFontStyleValueLabel.Text = GetFontDetails(Settings.Default.TrayIconFontStyle);
                TrayIconSelectFontStyleButton.Enabled = true;



            }
        }
    }
}