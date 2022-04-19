
using tb_vol_scroll.Classes.ControlsEx;

namespace tb_vol_scroll.Forms
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ApplyConfigurationButton = new System.Windows.Forms.Button();
            this.RestoreDefaultsButton = new System.Windows.Forms.Button();
            this.ConfigurationTabControl = new System.Windows.Forms.TabControl();
            this.BehaviorTabPage = new System.Windows.Forms.TabPage();
            this.BehaviorGeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.SetVolumeStepLabel = new System.Windows.Forms.Label();
            this.AutoHideTimeOutLabel = new System.Windows.Forms.Label();
            this.AutoHideTimeOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PreciseVolumeThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.NormalVolumeStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PreciseVolumeThresholdLabel = new System.Windows.Forms.Label();
            this.AutoHideTimeOutMillisecondsLabel = new System.Windows.Forms.Label();
            this.NormalVolumePercentLabel = new System.Windows.Forms.Label();
            this.BehaviorHotkeysGroupBox = new System.Windows.Forms.GroupBox();
            this.CtrlHotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.AltHotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.ShiftHotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.BehaviorMiscGroupBox = new System.Windows.Forms.GroupBox();
            this.IgnoreTaskbarVisibilityCheckBox = new System.Windows.Forms.CheckBox();
            this.InvertScrollingDirectionCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRetryAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.AppearanceTabPage = new System.Windows.Forms.TabPage();
            this.AppearanceTrayIconGroupBox = new System.Windows.Forms.GroupBox();
            this.TrayIconTextRenderingHintingDescriptionLabel = new System.Windows.Forms.Label();
            this.TrayIconAlignmentLabel = new System.Windows.Forms.Label();
            this.TrayIconHeightPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TrayIconPaddingPixelsLabel = new System.Windows.Forms.Label();
            this.TrayIconFontStyleValueLabel = new System.Windows.Forms.Label();
            this.TrayIconOverrideAutoSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.TrayIconPreviewFontStyleButton = new System.Windows.Forms.Button();
            this.TrayIconTextRenderingHintingComboBox = new System.Windows.Forms.ComboBox();
            this.TrayIconSelectFontStyleButton = new System.Windows.Forms.Button();
            this.TrayIconFontStyleLabel = new System.Windows.Forms.Label();
            this.TrayIconTextRenderingHintingLabel = new System.Windows.Forms.Label();
            this.TrayIconWidthPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TrayIconSizesPixelsLabel = new System.Windows.Forms.Label();
            this.TrayIconSizeLabel = new System.Windows.Forms.Label();
            this.TrayIconHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TrayIconWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AppearanceStatusBarGoupBox = new System.Windows.Forms.GroupBox();
            this.DisplayStatusBarScrollActionsCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusBarPaddingPixelsLabel = new System.Windows.Forms.Label();
            this.StatusBarPaddingLabel = new System.Windows.Forms.Label();
            this.StatusBarOpacityValueLabel = new System.Windows.Forms.Label();
            this.StatusBarHeightPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StatusBarOpacityLabel = new System.Windows.Forms.Label();
            this.StatusBarOpacityTrackBar = new System.Windows.Forms.TrackBar();
            this.StatusBarWidthPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StatusBarFontStyleValueLabel = new System.Windows.Forms.Label();
            this.StatusBarPreviewFontStyleButton = new System.Windows.Forms.Button();
            this.StatusBarSelectFontStyleButton = new System.Windows.Forms.Button();
            this.StatusBarFontStyleLabel = new System.Windows.Forms.Label();
            this.AppearanceColorsGroupBox = new System.Windows.Forms.GroupBox();
            this.StatusBarTextColorRgbValueLabel = new System.Windows.Forms.Label();
            this.StatusBarTextColorLabel = new System.Windows.Forms.Label();
            this.StatusBarTextColorValuePictureBox = new System.Windows.Forms.PictureBox();
            this.StatusBarTextColorGradientCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusBarTextColorSolidCheckBox = new System.Windows.Forms.CheckBox();
            this.TrayIconColorRgbValueLabel = new System.Windows.Forms.Label();
            this.StatusBarColorRgbValueLabel = new System.Windows.Forms.Label();
            this.TrayIconColorLabel = new System.Windows.Forms.Label();
            this.TrayIconColorValuePictureBox = new System.Windows.Forms.PictureBox();
            this.TrayIconTextColorGradientCheckBox = new System.Windows.Forms.CheckBox();
            this.TrayIconTextColorSolidCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusBarColorLabel = new System.Windows.Forms.Label();
            this.StatusBarColorValuePictureBox = new System.Windows.Forms.PictureBox();
            this.StatusBarColorGradientCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusBarColorSolidCheckBox = new System.Windows.Forms.CheckBox();
            this.ConfigurationTabControl.SuspendLayout();
            this.BehaviorTabPage.SuspendLayout();
            this.BehaviorGeneralGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreciseVolumeThresholdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalVolumeStepNumericUpDown)).BeginInit();
            this.BehaviorHotkeysGroupBox.SuspendLayout();
            this.BehaviorMiscGroupBox.SuspendLayout();
            this.AppearanceTabPage.SuspendLayout();
            this.AppearanceTrayIconGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconHeightPaddingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconWidthPaddingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconWidthNumericUpDown)).BeginInit();
            this.AppearanceStatusBarGoupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarHeightPaddingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarOpacityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarWidthPaddingNumericUpDown)).BeginInit();
            this.AppearanceColorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarTextColorValuePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconColorValuePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarColorValuePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplyConfigurationButton
            // 
            this.ApplyConfigurationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyConfigurationButton.Enabled = false;
            this.ApplyConfigurationButton.Location = new System.Drawing.Point(468, 378);
            this.ApplyConfigurationButton.Name = "ApplyConfigurationButton";
            this.ApplyConfigurationButton.Size = new System.Drawing.Size(100, 25);
            this.ApplyConfigurationButton.TabIndex = 28;
            this.ApplyConfigurationButton.Text = "Apply";
            this.ApplyConfigurationButton.UseVisualStyleBackColor = true;
            this.ApplyConfigurationButton.Click += new System.EventHandler(this.ApplyConfigurationButton_Click);
            // 
            // RestoreDefaultsButton
            // 
            this.RestoreDefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RestoreDefaultsButton.Location = new System.Drawing.Point(362, 378);
            this.RestoreDefaultsButton.Name = "RestoreDefaultsButton";
            this.RestoreDefaultsButton.Size = new System.Drawing.Size(100, 25);
            this.RestoreDefaultsButton.TabIndex = 27;
            this.RestoreDefaultsButton.Text = "Restore defaults";
            this.RestoreDefaultsButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultsButton.Click += new System.EventHandler(this.RestoreDefaultsButton_Click);
            // 
            // ConfigurationTabControl
            // 
            this.ConfigurationTabControl.Controls.Add(this.BehaviorTabPage);
            this.ConfigurationTabControl.Controls.Add(this.AppearanceTabPage);
            this.ConfigurationTabControl.Location = new System.Drawing.Point(12, 12);
            this.ConfigurationTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.ConfigurationTabControl.Multiline = true;
            this.ConfigurationTabControl.Name = "ConfigurationTabControl";
            this.ConfigurationTabControl.Padding = new System.Drawing.Point(0, 0);
            this.ConfigurationTabControl.SelectedIndex = 0;
            this.ConfigurationTabControl.Size = new System.Drawing.Size(560, 360);
            this.ConfigurationTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.ConfigurationTabControl.TabIndex = 0;
            // 
            // BehaviorTabPage
            // 
            this.BehaviorTabPage.BackColor = System.Drawing.Color.White;
            this.BehaviorTabPage.Controls.Add(this.BehaviorGeneralGroupBox);
            this.BehaviorTabPage.Controls.Add(this.BehaviorHotkeysGroupBox);
            this.BehaviorTabPage.Controls.Add(this.BehaviorMiscGroupBox);
            this.BehaviorTabPage.Location = new System.Drawing.Point(4, 22);
            this.BehaviorTabPage.Name = "BehaviorTabPage";
            this.BehaviorTabPage.Size = new System.Drawing.Size(552, 334);
            this.BehaviorTabPage.TabIndex = 1;
            this.BehaviorTabPage.Text = "Behavior";
            // 
            // BehaviorGeneralGroupBox
            // 
            this.BehaviorGeneralGroupBox.Controls.Add(this.SetVolumeStepLabel);
            this.BehaviorGeneralGroupBox.Controls.Add(this.AutoHideTimeOutLabel);
            this.BehaviorGeneralGroupBox.Controls.Add(this.AutoHideTimeOutNumericUpDown);
            this.BehaviorGeneralGroupBox.Controls.Add(this.PreciseVolumeThresholdNumericUpDown);
            this.BehaviorGeneralGroupBox.Controls.Add(this.ThresholdLabel);
            this.BehaviorGeneralGroupBox.Controls.Add(this.NormalVolumeStepNumericUpDown);
            this.BehaviorGeneralGroupBox.Controls.Add(this.PreciseVolumeThresholdLabel);
            this.BehaviorGeneralGroupBox.Controls.Add(this.AutoHideTimeOutMillisecondsLabel);
            this.BehaviorGeneralGroupBox.Controls.Add(this.NormalVolumePercentLabel);
            this.BehaviorGeneralGroupBox.Location = new System.Drawing.Point(6, 6);
            this.BehaviorGeneralGroupBox.Name = "BehaviorGeneralGroupBox";
            this.BehaviorGeneralGroupBox.Size = new System.Drawing.Size(540, 116);
            this.BehaviorGeneralGroupBox.TabIndex = 41;
            this.BehaviorGeneralGroupBox.TabStop = false;
            this.BehaviorGeneralGroupBox.Text = "General";
            // 
            // SetVolumeStepLabel
            // 
            this.SetVolumeStepLabel.AutoSize = true;
            this.SetVolumeStepLabel.Location = new System.Drawing.Point(6, 21);
            this.SetVolumeStepLabel.Name = "SetVolumeStepLabel";
            this.SetVolumeStepLabel.Size = new System.Drawing.Size(142, 13);
            this.SetVolumeStepLabel.TabIndex = 34;
            this.SetVolumeStepLabel.Text = "Normal volume scroll step:";
            this.SetVolumeStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoHideTimeOutLabel
            // 
            this.AutoHideTimeOutLabel.AutoSize = true;
            this.AutoHideTimeOutLabel.Location = new System.Drawing.Point(6, 83);
            this.AutoHideTimeOutLabel.Name = "AutoHideTimeOutLabel";
            this.AutoHideTimeOutLabel.Size = new System.Drawing.Size(143, 13);
            this.AutoHideTimeOutLabel.TabIndex = 26;
            this.AutoHideTimeOutLabel.Text = "Auto-hide status bar after:";
            this.AutoHideTimeOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoHideTimeOutNumericUpDown
            // 
            this.AutoHideTimeOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoHideTimeOutNumericUpDown.Location = new System.Drawing.Point(181, 81);
            this.AutoHideTimeOutNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.AutoHideTimeOutNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.AutoHideTimeOutNumericUpDown.Name = "AutoHideTimeOutNumericUpDown";
            this.AutoHideTimeOutNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.AutoHideTimeOutNumericUpDown.TabIndex = 2;
            this.AutoHideTimeOutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AutoHideTimeOutNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // PreciseVolumeThresholdNumericUpDown
            // 
            this.PreciseVolumeThresholdNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreciseVolumeThresholdNumericUpDown.Location = new System.Drawing.Point(181, 51);
            this.PreciseVolumeThresholdNumericUpDown.Name = "PreciseVolumeThresholdNumericUpDown";
            this.PreciseVolumeThresholdNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.PreciseVolumeThresholdNumericUpDown.TabIndex = 1;
            this.PreciseVolumeThresholdNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PreciseVolumeThresholdNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(6, 53);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(168, 13);
            this.ThresholdLabel.TabIndex = 30;
            this.ThresholdLabel.Text = "Precise volume scroll threshold:";
            this.ThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NormalVolumeStepNumericUpDown
            // 
            this.NormalVolumeStepNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NormalVolumeStepNumericUpDown.Location = new System.Drawing.Point(181, 19);
            this.NormalVolumeStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NormalVolumeStepNumericUpDown.Name = "NormalVolumeStepNumericUpDown";
            this.NormalVolumeStepNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.NormalVolumeStepNumericUpDown.TabIndex = 0;
            this.NormalVolumeStepNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NormalVolumeStepNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // PreciseVolumeThresholdLabel
            // 
            this.PreciseVolumeThresholdLabel.AutoSize = true;
            this.PreciseVolumeThresholdLabel.Location = new System.Drawing.Point(242, 52);
            this.PreciseVolumeThresholdLabel.Name = "PreciseVolumeThresholdLabel";
            this.PreciseVolumeThresholdLabel.Size = new System.Drawing.Size(45, 13);
            this.PreciseVolumeThresholdLabel.TabIndex = 39;
            this.PreciseVolumeThresholdLabel.Text = "Percent";
            this.PreciseVolumeThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoHideTimeOutMillisecondsLabel
            // 
            this.AutoHideTimeOutMillisecondsLabel.AutoSize = true;
            this.AutoHideTimeOutMillisecondsLabel.Location = new System.Drawing.Point(242, 85);
            this.AutoHideTimeOutMillisecondsLabel.Name = "AutoHideTimeOutMillisecondsLabel";
            this.AutoHideTimeOutMillisecondsLabel.Size = new System.Drawing.Size(71, 13);
            this.AutoHideTimeOutMillisecondsLabel.TabIndex = 27;
            this.AutoHideTimeOutMillisecondsLabel.Text = "Milliseconds";
            this.AutoHideTimeOutMillisecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NormalVolumePercentLabel
            // 
            this.NormalVolumePercentLabel.AutoSize = true;
            this.NormalVolumePercentLabel.Location = new System.Drawing.Point(242, 22);
            this.NormalVolumePercentLabel.Name = "NormalVolumePercentLabel";
            this.NormalVolumePercentLabel.Size = new System.Drawing.Size(45, 13);
            this.NormalVolumePercentLabel.TabIndex = 37;
            this.NormalVolumePercentLabel.Text = "Percent";
            this.NormalVolumePercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BehaviorHotkeysGroupBox
            // 
            this.BehaviorHotkeysGroupBox.Controls.Add(this.CtrlHotkeyCheckBox);
            this.BehaviorHotkeysGroupBox.Controls.Add(this.AltHotkeyCheckBox);
            this.BehaviorHotkeysGroupBox.Controls.Add(this.ShiftHotkeyCheckBox);
            this.BehaviorHotkeysGroupBox.Location = new System.Drawing.Point(6, 130);
            this.BehaviorHotkeysGroupBox.Name = "BehaviorHotkeysGroupBox";
            this.BehaviorHotkeysGroupBox.Size = new System.Drawing.Size(540, 95);
            this.BehaviorHotkeysGroupBox.TabIndex = 42;
            this.BehaviorHotkeysGroupBox.TabStop = false;
            this.BehaviorHotkeysGroupBox.Text = "Hotkeys";
            // 
            // CtrlHotkeyCheckBox
            // 
            this.CtrlHotkeyCheckBox.AutoSize = true;
            this.CtrlHotkeyCheckBox.Location = new System.Drawing.Point(9, 21);
            this.CtrlHotkeyCheckBox.Name = "CtrlHotkeyCheckBox";
            this.CtrlHotkeyCheckBox.Size = new System.Drawing.Size(444, 17);
            this.CtrlHotkeyCheckBox.TabIndex = 3;
            this.CtrlHotkeyCheckBox.Text = "Mute and unmute active audio playback device when holding down the CTRL key";
            this.CtrlHotkeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // AltHotkeyCheckBox
            // 
            this.AltHotkeyCheckBox.AutoSize = true;
            this.AltHotkeyCheckBox.Location = new System.Drawing.Point(9, 68);
            this.AltHotkeyCheckBox.Name = "AltHotkeyCheckBox";
            this.AltHotkeyCheckBox.Size = new System.Drawing.Size(425, 17);
            this.AltHotkeyCheckBox.TabIndex = 5;
            this.AltHotkeyCheckBox.Text = "Manually activate precise volume scroll mode when holding down the ALT key";
            this.AltHotkeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShiftHotkeyCheckBox
            // 
            this.ShiftHotkeyCheckBox.AutoSize = true;
            this.ShiftHotkeyCheckBox.Location = new System.Drawing.Point(9, 44);
            this.ShiftHotkeyCheckBox.Name = "ShiftHotkeyCheckBox";
            this.ShiftHotkeyCheckBox.Size = new System.Drawing.Size(458, 17);
            this.ShiftHotkeyCheckBox.TabIndex = 4;
            this.ShiftHotkeyCheckBox.Text = "Switch between available audio playback devices when holding down the SHIFT key";
            this.ShiftHotkeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // BehaviorMiscGroupBox
            // 
            this.BehaviorMiscGroupBox.Controls.Add(this.IgnoreTaskbarVisibilityCheckBox);
            this.BehaviorMiscGroupBox.Controls.Add(this.InvertScrollingDirectionCheckBox);
            this.BehaviorMiscGroupBox.Controls.Add(this.AutoRetryAdminCheckBox);
            this.BehaviorMiscGroupBox.Location = new System.Drawing.Point(6, 234);
            this.BehaviorMiscGroupBox.Name = "BehaviorMiscGroupBox";
            this.BehaviorMiscGroupBox.Size = new System.Drawing.Size(540, 95);
            this.BehaviorMiscGroupBox.TabIndex = 43;
            this.BehaviorMiscGroupBox.TabStop = false;
            this.BehaviorMiscGroupBox.Text = "Misc.";
            // 
            // IgnoreTaskbarVisibilityCheckBox
            // 
            this.IgnoreTaskbarVisibilityCheckBox.AutoSize = true;
            this.IgnoreTaskbarVisibilityCheckBox.Location = new System.Drawing.Point(9, 21);
            this.IgnoreTaskbarVisibilityCheckBox.Name = "IgnoreTaskbarVisibilityCheckBox";
            this.IgnoreTaskbarVisibilityCheckBox.Size = new System.Drawing.Size(404, 17);
            this.IgnoreTaskbarVisibilityCheckBox.TabIndex = 6;
            this.IgnoreTaskbarVisibilityCheckBox.Text = "Always handle scroll actions regardless of the taskbar being visible or not";
            this.IgnoreTaskbarVisibilityCheckBox.UseVisualStyleBackColor = true;
            // 
            // InvertScrollingDirectionCheckBox
            // 
            this.InvertScrollingDirectionCheckBox.AutoSize = true;
            this.InvertScrollingDirectionCheckBox.Location = new System.Drawing.Point(9, 44);
            this.InvertScrollingDirectionCheckBox.Name = "InvertScrollingDirectionCheckBox";
            this.InvertScrollingDirectionCheckBox.Size = new System.Drawing.Size(239, 17);
            this.InvertScrollingDirectionCheckBox.TabIndex = 7;
            this.InvertScrollingDirectionCheckBox.Text = "Invert scrolling direction for scroll actions";
            this.InvertScrollingDirectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoRetryAdminCheckBox
            // 
            this.AutoRetryAdminCheckBox.AutoSize = true;
            this.AutoRetryAdminCheckBox.Location = new System.Drawing.Point(9, 67);
            this.AutoRetryAdminCheckBox.Name = "AutoRetryAdminCheckBox";
            this.AutoRetryAdminCheckBox.Size = new System.Drawing.Size(262, 17);
            this.AutoRetryAdminCheckBox.TabIndex = 8;
            this.AutoRetryAdminCheckBox.Text = "Request Administrator permissions on startup";
            this.AutoRetryAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppearanceTabPage
            // 
            this.AppearanceTabPage.AutoScroll = true;
            this.AppearanceTabPage.AutoScrollMargin = new System.Drawing.Size(0, 5);
            this.AppearanceTabPage.BackColor = System.Drawing.Color.White;
            this.AppearanceTabPage.Controls.Add(this.AppearanceTrayIconGroupBox);
            this.AppearanceTabPage.Controls.Add(this.AppearanceStatusBarGoupBox);
            this.AppearanceTabPage.Controls.Add(this.AppearanceColorsGroupBox);
            this.AppearanceTabPage.Location = new System.Drawing.Point(4, 22);
            this.AppearanceTabPage.Name = "AppearanceTabPage";
            this.AppearanceTabPage.Size = new System.Drawing.Size(552, 334);
            this.AppearanceTabPage.TabIndex = 0;
            this.AppearanceTabPage.Text = "Appearance";
            // 
            // AppearanceTrayIconGroupBox
            // 
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconTextRenderingHintingDescriptionLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconAlignmentLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconHeightPaddingNumericUpDown);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconPaddingPixelsLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconFontStyleValueLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconOverrideAutoSettingsCheckBox);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconPreviewFontStyleButton);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconTextRenderingHintingComboBox);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconSelectFontStyleButton);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconFontStyleLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconTextRenderingHintingLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconWidthPaddingNumericUpDown);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconSizesPixelsLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconSizeLabel);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconHeightNumericUpDown);
            this.AppearanceTrayIconGroupBox.Controls.Add(this.TrayIconWidthNumericUpDown);
            this.AppearanceTrayIconGroupBox.Location = new System.Drawing.Point(6, 154);
            this.AppearanceTrayIconGroupBox.Name = "AppearanceTrayIconGroupBox";
            this.AppearanceTrayIconGroupBox.Size = new System.Drawing.Size(525, 175);
            this.AppearanceTrayIconGroupBox.TabIndex = 1;
            this.AppearanceTrayIconGroupBox.TabStop = false;
            this.AppearanceTrayIconGroupBox.Text = "Tray Icon";
            // 
            // TrayIconTextRenderingHintingDescriptionLabel
            // 
            this.TrayIconTextRenderingHintingDescriptionLabel.AutoSize = true;
            this.TrayIconTextRenderingHintingDescriptionLabel.Location = new System.Drawing.Point(273, 53);
            this.TrayIconTextRenderingHintingDescriptionLabel.Name = "TrayIconTextRenderingHintingDescriptionLabel";
            this.TrayIconTextRenderingHintingDescriptionLabel.Size = new System.Drawing.Size(132, 13);
            this.TrayIconTextRenderingHintingDescriptionLabel.TabIndex = 58;
            this.TrayIconTextRenderingHintingDescriptionLabel.Text = "Uses the default hinting";
            // 
            // TrayIconAlignmentLabel
            // 
            this.TrayIconAlignmentLabel.AutoSize = true;
            this.TrayIconAlignmentLabel.Location = new System.Drawing.Point(6, 138);
            this.TrayIconAlignmentLabel.Name = "TrayIconAlignmentLabel";
            this.TrayIconAlignmentLabel.Size = new System.Drawing.Size(110, 13);
            this.TrayIconAlignmentLabel.TabIndex = 57;
            this.TrayIconAlignmentLabel.Text = "Tray icon alignment:\r\n";
            this.TrayIconAlignmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrayIconHeightPaddingNumericUpDown
            // 
            this.TrayIconHeightPaddingNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconHeightPaddingNumericUpDown.Location = new System.Drawing.Point(196, 136);
            this.TrayIconHeightPaddingNumericUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.TrayIconHeightPaddingNumericUpDown.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            -2147483648});
            this.TrayIconHeightPaddingNumericUpDown.Name = "TrayIconHeightPaddingNumericUpDown";
            this.TrayIconHeightPaddingNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.TrayIconHeightPaddingNumericUpDown.TabIndex = 22;
            this.TrayIconHeightPaddingNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrayIconPaddingPixelsLabel
            // 
            this.TrayIconPaddingPixelsLabel.AutoSize = true;
            this.TrayIconPaddingPixelsLabel.Location = new System.Drawing.Point(273, 139);
            this.TrayIconPaddingPixelsLabel.Name = "TrayIconPaddingPixelsLabel";
            this.TrayIconPaddingPixelsLabel.Size = new System.Drawing.Size(119, 13);
            this.TrayIconPaddingPixelsLabel.TabIndex = 55;
            this.TrayIconPaddingPixelsLabel.Text = "Pixels (width x height)";
            this.TrayIconPaddingPixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrayIconFontStyleValueLabel
            // 
            this.TrayIconFontStyleValueLabel.AutoEllipsis = true;
            this.TrayIconFontStyleValueLabel.AutoSize = true;
            this.TrayIconFontStyleValueLabel.Location = new System.Drawing.Point(273, 83);
            this.TrayIconFontStyleValueLabel.Name = "TrayIconFontStyleValueLabel";
            this.TrayIconFontStyleValueLabel.Size = new System.Drawing.Size(179, 13);
            this.TrayIconFontStyleValueLabel.TabIndex = 45;
            this.TrayIconFontStyleValueLabel.Text = "Segoe UI Semibold; Regular; 36pt";
            // 
            // TrayIconOverrideAutoSettingsCheckBox
            // 
            this.TrayIconOverrideAutoSettingsCheckBox.AutoSize = true;
            this.TrayIconOverrideAutoSettingsCheckBox.Location = new System.Drawing.Point(9, 21);
            this.TrayIconOverrideAutoSettingsCheckBox.Name = "TrayIconOverrideAutoSettingsCheckBox";
            this.TrayIconOverrideAutoSettingsCheckBox.Size = new System.Drawing.Size(235, 17);
            this.TrayIconOverrideAutoSettingsCheckBox.TabIndex = 15;
            this.TrayIconOverrideAutoSettingsCheckBox.Text = "Override the automatic tray icon settings";
            this.TrayIconOverrideAutoSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // TrayIconPreviewFontStyleButton
            // 
            this.TrayIconPreviewFontStyleButton.Location = new System.Drawing.Point(195, 78);
            this.TrayIconPreviewFontStyleButton.Name = "TrayIconPreviewFontStyleButton";
            this.TrayIconPreviewFontStyleButton.Size = new System.Drawing.Size(72, 24);
            this.TrayIconPreviewFontStyleButton.TabIndex = 18;
            this.TrayIconPreviewFontStyleButton.Text = "Preview";
            this.TrayIconPreviewFontStyleButton.UseVisualStyleBackColor = true;
            this.TrayIconPreviewFontStyleButton.Click += new System.EventHandler(this.TrayIconFontPreviewButton_Click);
            // 
            // TrayIconTextRenderingHintingComboBox
            // 
            this.TrayIconTextRenderingHintingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrayIconTextRenderingHintingComboBox.FormattingEnabled = true;
            this.TrayIconTextRenderingHintingComboBox.ItemHeight = 13;
            this.TrayIconTextRenderingHintingComboBox.Items.AddRange(new object[] {
            "System Default",
            "ClearType",
            "Anti-Alias",
            "Single Bit Per Pixel"});
            this.TrayIconTextRenderingHintingComboBox.Location = new System.Drawing.Point(121, 50);
            this.TrayIconTextRenderingHintingComboBox.Name = "TrayIconTextRenderingHintingComboBox";
            this.TrayIconTextRenderingHintingComboBox.Size = new System.Drawing.Size(146, 21);
            this.TrayIconTextRenderingHintingComboBox.TabIndex = 16;
            this.TrayIconTextRenderingHintingComboBox.SelectedIndexChanged += new System.EventHandler(this.TrayIconHintingComboBox_SelectedIndexChanged);
            // 
            // TrayIconSelectFontStyleButton
            // 
            this.TrayIconSelectFontStyleButton.Location = new System.Drawing.Point(120, 78);
            this.TrayIconSelectFontStyleButton.Name = "TrayIconSelectFontStyleButton";
            this.TrayIconSelectFontStyleButton.Size = new System.Drawing.Size(72, 24);
            this.TrayIconSelectFontStyleButton.TabIndex = 17;
            this.TrayIconSelectFontStyleButton.Text = "Select...";
            this.TrayIconSelectFontStyleButton.UseVisualStyleBackColor = true;
            this.TrayIconSelectFontStyleButton.Click += new System.EventHandler(this.TrayIconFontSelectButton_Click);
            // 
            // TrayIconFontStyleLabel
            // 
            this.TrayIconFontStyleLabel.AutoSize = true;
            this.TrayIconFontStyleLabel.Location = new System.Drawing.Point(6, 83);
            this.TrayIconFontStyleLabel.Name = "TrayIconFontStyleLabel";
            this.TrayIconFontStyleLabel.Size = new System.Drawing.Size(80, 13);
            this.TrayIconFontStyleLabel.TabIndex = 43;
            this.TrayIconFontStyleLabel.Text = "Tray icon font:";
            this.TrayIconFontStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrayIconTextRenderingHintingLabel
            // 
            this.TrayIconTextRenderingHintingLabel.AutoSize = true;
            this.TrayIconTextRenderingHintingLabel.Location = new System.Drawing.Point(6, 53);
            this.TrayIconTextRenderingHintingLabel.Name = "TrayIconTextRenderingHintingLabel";
            this.TrayIconTextRenderingHintingLabel.Size = new System.Drawing.Size(96, 13);
            this.TrayIconTextRenderingHintingLabel.TabIndex = 53;
            this.TrayIconTextRenderingHintingLabel.Text = "Tray icon hinting:";
            // 
            // TrayIconWidthPaddingNumericUpDown
            // 
            this.TrayIconWidthPaddingNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconWidthPaddingNumericUpDown.Location = new System.Drawing.Point(121, 136);
            this.TrayIconWidthPaddingNumericUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.TrayIconWidthPaddingNumericUpDown.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            -2147483648});
            this.TrayIconWidthPaddingNumericUpDown.Name = "TrayIconWidthPaddingNumericUpDown";
            this.TrayIconWidthPaddingNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.TrayIconWidthPaddingNumericUpDown.TabIndex = 21;
            this.TrayIconWidthPaddingNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrayIconSizesPixelsLabel
            // 
            this.TrayIconSizesPixelsLabel.AutoSize = true;
            this.TrayIconSizesPixelsLabel.Location = new System.Drawing.Point(273, 110);
            this.TrayIconSizesPixelsLabel.Name = "TrayIconSizesPixelsLabel";
            this.TrayIconSizesPixelsLabel.Size = new System.Drawing.Size(119, 13);
            this.TrayIconSizesPixelsLabel.TabIndex = 50;
            this.TrayIconSizesPixelsLabel.Text = "Pixels (width x height)";
            this.TrayIconSizesPixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrayIconSizeLabel
            // 
            this.TrayIconSizeLabel.AutoSize = true;
            this.TrayIconSizeLabel.Location = new System.Drawing.Point(6, 110);
            this.TrayIconSizeLabel.Name = "TrayIconSizeLabel";
            this.TrayIconSizeLabel.Size = new System.Drawing.Size(77, 13);
            this.TrayIconSizeLabel.TabIndex = 49;
            this.TrayIconSizeLabel.Text = "Tray icon size:\r\n";
            this.TrayIconSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrayIconHeightNumericUpDown
            // 
            this.TrayIconHeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconHeightNumericUpDown.Location = new System.Drawing.Point(196, 108);
            this.TrayIconHeightNumericUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.TrayIconHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TrayIconHeightNumericUpDown.Name = "TrayIconHeightNumericUpDown";
            this.TrayIconHeightNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.TrayIconHeightNumericUpDown.TabIndex = 20;
            this.TrayIconHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TrayIconHeightNumericUpDown.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // TrayIconWidthNumericUpDown
            // 
            this.TrayIconWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconWidthNumericUpDown.Location = new System.Drawing.Point(121, 108);
            this.TrayIconWidthNumericUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.TrayIconWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TrayIconWidthNumericUpDown.Name = "TrayIconWidthNumericUpDown";
            this.TrayIconWidthNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.TrayIconWidthNumericUpDown.TabIndex = 19;
            this.TrayIconWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TrayIconWidthNumericUpDown.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // AppearanceStatusBarGoupBox
            // 
            this.AppearanceStatusBarGoupBox.Controls.Add(this.DisplayStatusBarScrollActionsCheckBox);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarPaddingPixelsLabel);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarPaddingLabel);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarOpacityValueLabel);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarHeightPaddingNumericUpDown);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarOpacityLabel);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarOpacityTrackBar);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarWidthPaddingNumericUpDown);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarFontStyleValueLabel);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarPreviewFontStyleButton);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarSelectFontStyleButton);
            this.AppearanceStatusBarGoupBox.Controls.Add(this.StatusBarFontStyleLabel);
            this.AppearanceStatusBarGoupBox.Location = new System.Drawing.Point(6, 6);
            this.AppearanceStatusBarGoupBox.Name = "AppearanceStatusBarGoupBox";
            this.AppearanceStatusBarGoupBox.Size = new System.Drawing.Size(525, 140);
            this.AppearanceStatusBarGoupBox.TabIndex = 0;
            this.AppearanceStatusBarGoupBox.TabStop = false;
            this.AppearanceStatusBarGoupBox.Text = "Status Bar";
            // 
            // DisplayStatusBarScrollActionsCheckBox
            // 
            this.DisplayStatusBarScrollActionsCheckBox.AutoSize = true;
            this.DisplayStatusBarScrollActionsCheckBox.Checked = true;
            this.DisplayStatusBarScrollActionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayStatusBarScrollActionsCheckBox.Location = new System.Drawing.Point(9, 21);
            this.DisplayStatusBarScrollActionsCheckBox.Name = "DisplayStatusBarScrollActionsCheckBox";
            this.DisplayStatusBarScrollActionsCheckBox.Size = new System.Drawing.Size(303, 17);
            this.DisplayStatusBarScrollActionsCheckBox.TabIndex = 9;
            this.DisplayStatusBarScrollActionsCheckBox.Text = "Display the status bar while performing a scroll action";
            this.DisplayStatusBarScrollActionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // StatusBarPaddingPixelsLabel
            // 
            this.StatusBarPaddingPixelsLabel.AutoSize = true;
            this.StatusBarPaddingPixelsLabel.Location = new System.Drawing.Point(273, 53);
            this.StatusBarPaddingPixelsLabel.Name = "StatusBarPaddingPixelsLabel";
            this.StatusBarPaddingPixelsLabel.Size = new System.Drawing.Size(119, 13);
            this.StatusBarPaddingPixelsLabel.TabIndex = 31;
            this.StatusBarPaddingPixelsLabel.Text = "Pixels (width x height)";
            this.StatusBarPaddingPixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBarPaddingLabel
            // 
            this.StatusBarPaddingLabel.AutoSize = true;
            this.StatusBarPaddingLabel.Location = new System.Drawing.Point(6, 53);
            this.StatusBarPaddingLabel.Name = "StatusBarPaddingLabel";
            this.StatusBarPaddingLabel.Size = new System.Drawing.Size(109, 13);
            this.StatusBarPaddingLabel.TabIndex = 22;
            this.StatusBarPaddingLabel.Text = "Status bar padding:\r\n";
            this.StatusBarPaddingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarOpacityValueLabel
            // 
            this.StatusBarOpacityValueLabel.AutoSize = true;
            this.StatusBarOpacityValueLabel.Location = new System.Drawing.Point(273, 111);
            this.StatusBarOpacityValueLabel.Name = "StatusBarOpacityValueLabel";
            this.StatusBarOpacityValueLabel.Size = new System.Drawing.Size(34, 13);
            this.StatusBarOpacityValueLabel.TabIndex = 29;
            this.StatusBarOpacityValueLabel.Text = "100%";
            this.StatusBarOpacityValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBarHeightPaddingNumericUpDown
            // 
            this.StatusBarHeightPaddingNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusBarHeightPaddingNumericUpDown.Location = new System.Drawing.Point(197, 51);
            this.StatusBarHeightPaddingNumericUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.StatusBarHeightPaddingNumericUpDown.Name = "StatusBarHeightPaddingNumericUpDown";
            this.StatusBarHeightPaddingNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.StatusBarHeightPaddingNumericUpDown.TabIndex = 11;
            this.StatusBarHeightPaddingNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusBarHeightPaddingNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // StatusBarOpacityLabel
            // 
            this.StatusBarOpacityLabel.AutoSize = true;
            this.StatusBarOpacityLabel.Location = new System.Drawing.Point(6, 112);
            this.StatusBarOpacityLabel.Name = "StatusBarOpacityLabel";
            this.StatusBarOpacityLabel.Size = new System.Drawing.Size(102, 13);
            this.StatusBarOpacityLabel.TabIndex = 28;
            this.StatusBarOpacityLabel.Text = "Status bar opacity:";
            this.StatusBarOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusBarOpacityTrackBar
            // 
            this.StatusBarOpacityTrackBar.AutoSize = false;
            this.StatusBarOpacityTrackBar.Location = new System.Drawing.Point(114, 108);
            this.StatusBarOpacityTrackBar.Maximum = 100;
            this.StatusBarOpacityTrackBar.Name = "StatusBarOpacityTrackBar";
            this.StatusBarOpacityTrackBar.Size = new System.Drawing.Size(158, 24);
            this.StatusBarOpacityTrackBar.TabIndex = 14;
            this.StatusBarOpacityTrackBar.TickFrequency = 6;
            this.StatusBarOpacityTrackBar.Value = 100;
            this.StatusBarOpacityTrackBar.ValueChanged += new System.EventHandler(this.StatusBarOpacityTrackBar_ValueChanged);
            // 
            // StatusBarWidthPaddingNumericUpDown
            // 
            this.StatusBarWidthPaddingNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusBarWidthPaddingNumericUpDown.Location = new System.Drawing.Point(121, 51);
            this.StatusBarWidthPaddingNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.StatusBarWidthPaddingNumericUpDown.Name = "StatusBarWidthPaddingNumericUpDown";
            this.StatusBarWidthPaddingNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.StatusBarWidthPaddingNumericUpDown.TabIndex = 10;
            this.StatusBarWidthPaddingNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusBarWidthPaddingNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // StatusBarFontStyleValueLabel
            // 
            this.StatusBarFontStyleValueLabel.AutoEllipsis = true;
            this.StatusBarFontStyleValueLabel.AutoSize = true;
            this.StatusBarFontStyleValueLabel.Location = new System.Drawing.Point(273, 83);
            this.StatusBarFontStyleValueLabel.Name = "StatusBarFontStyleValueLabel";
            this.StatusBarFontStyleValueLabel.Size = new System.Drawing.Size(173, 13);
            this.StatusBarFontStyleValueLabel.TabIndex = 37;
            this.StatusBarFontStyleValueLabel.Text = "Segoe UI Semibold; Regular; 9pt";
            // 
            // StatusBarPreviewFontStyleButton
            // 
            this.StatusBarPreviewFontStyleButton.Location = new System.Drawing.Point(196, 77);
            this.StatusBarPreviewFontStyleButton.Name = "StatusBarPreviewFontStyleButton";
            this.StatusBarPreviewFontStyleButton.Size = new System.Drawing.Size(72, 24);
            this.StatusBarPreviewFontStyleButton.TabIndex = 13;
            this.StatusBarPreviewFontStyleButton.Text = "Preview";
            this.StatusBarPreviewFontStyleButton.UseVisualStyleBackColor = true;
            this.StatusBarPreviewFontStyleButton.Click += new System.EventHandler(this.StatusBarFontPreviewButton_Click);
            // 
            // StatusBarSelectFontStyleButton
            // 
            this.StatusBarSelectFontStyleButton.Location = new System.Drawing.Point(120, 77);
            this.StatusBarSelectFontStyleButton.Name = "StatusBarSelectFontStyleButton";
            this.StatusBarSelectFontStyleButton.Size = new System.Drawing.Size(72, 24);
            this.StatusBarSelectFontStyleButton.TabIndex = 12;
            this.StatusBarSelectFontStyleButton.Text = "Select...";
            this.StatusBarSelectFontStyleButton.UseVisualStyleBackColor = true;
            this.StatusBarSelectFontStyleButton.Click += new System.EventHandler(this.StatusBarFontSelectButton_Click);
            // 
            // StatusBarFontStyleLabel
            // 
            this.StatusBarFontStyleLabel.AutoSize = true;
            this.StatusBarFontStyleLabel.Location = new System.Drawing.Point(6, 83);
            this.StatusBarFontStyleLabel.Name = "StatusBarFontStyleLabel";
            this.StatusBarFontStyleLabel.Size = new System.Drawing.Size(87, 13);
            this.StatusBarFontStyleLabel.TabIndex = 35;
            this.StatusBarFontStyleLabel.Text = "Status bar font:";
            this.StatusBarFontStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppearanceColorsGroupBox
            // 
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarTextColorRgbValueLabel);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarTextColorLabel);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarTextColorValuePictureBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarTextColorGradientCheckBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarTextColorSolidCheckBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.TrayIconColorRgbValueLabel);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarColorRgbValueLabel);
            this.AppearanceColorsGroupBox.Controls.Add(this.TrayIconColorLabel);
            this.AppearanceColorsGroupBox.Controls.Add(this.TrayIconColorValuePictureBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.TrayIconTextColorGradientCheckBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.TrayIconTextColorSolidCheckBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarColorLabel);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarColorValuePictureBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarColorGradientCheckBox);
            this.AppearanceColorsGroupBox.Controls.Add(this.StatusBarColorSolidCheckBox);
            this.AppearanceColorsGroupBox.Location = new System.Drawing.Point(6, 337);
            this.AppearanceColorsGroupBox.Name = "AppearanceColorsGroupBox";
            this.AppearanceColorsGroupBox.Size = new System.Drawing.Size(525, 130);
            this.AppearanceColorsGroupBox.TabIndex = 2;
            this.AppearanceColorsGroupBox.TabStop = false;
            this.AppearanceColorsGroupBox.Text = "Colors";
            // 
            // StatusBarTextColorRgbValueLabel
            // 
            this.StatusBarTextColorRgbValueLabel.AutoSize = true;
            this.StatusBarTextColorRgbValueLabel.Location = new System.Drawing.Point(309, 27);
            this.StatusBarTextColorRgbValueLabel.Name = "StatusBarTextColorRgbValueLabel";
            this.StatusBarTextColorRgbValueLabel.Size = new System.Drawing.Size(70, 13);
            this.StatusBarTextColorRgbValueLabel.TabIndex = 52;
            this.StatusBarTextColorRgbValueLabel.Text = "R: 0 G: 0 B: 0";
            // 
            // StatusBarTextColorLabel
            // 
            this.StatusBarTextColorLabel.AutoSize = true;
            this.StatusBarTextColorLabel.Location = new System.Drawing.Point(6, 27);
            this.StatusBarTextColorLabel.Name = "StatusBarTextColorLabel";
            this.StatusBarTextColorLabel.Size = new System.Drawing.Size(113, 13);
            this.StatusBarTextColorLabel.TabIndex = 50;
            this.StatusBarTextColorLabel.Text = "Status bar text color:";
            this.StatusBarTextColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarTextColorValuePictureBox
            // 
            this.StatusBarTextColorValuePictureBox.BackColor = System.Drawing.Color.Black;
            this.StatusBarTextColorValuePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusBarTextColorValuePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.StatusBarTextColorValuePictureBox.Location = new System.Drawing.Point(276, 22);
            this.StatusBarTextColorValuePictureBox.Name = "StatusBarTextColorValuePictureBox";
            this.StatusBarTextColorValuePictureBox.Size = new System.Drawing.Size(27, 23);
            this.StatusBarTextColorValuePictureBox.TabIndex = 51;
            this.StatusBarTextColorValuePictureBox.TabStop = false;
            // 
            // StatusBarTextColorGradientCheckBox
            // 
            this.StatusBarTextColorGradientCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.StatusBarTextColorGradientCheckBox.Location = new System.Drawing.Point(120, 21);
            this.StatusBarTextColorGradientCheckBox.Name = "StatusBarTextColorGradientCheckBox";
            this.StatusBarTextColorGradientCheckBox.Size = new System.Drawing.Size(72, 25);
            this.StatusBarTextColorGradientCheckBox.TabIndex = 48;
            this.StatusBarTextColorGradientCheckBox.Text = "Gradient";
            this.StatusBarTextColorGradientCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBarTextColorGradientCheckBox.UseVisualStyleBackColor = true;
            this.StatusBarTextColorGradientCheckBox.Click += new System.EventHandler(this.StatusBarTextColorGradientCheckBox_Click);
            // 
            // StatusBarTextColorSolidCheckBox
            // 
            this.StatusBarTextColorSolidCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.StatusBarTextColorSolidCheckBox.Checked = true;
            this.StatusBarTextColorSolidCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusBarTextColorSolidCheckBox.Location = new System.Drawing.Point(195, 21);
            this.StatusBarTextColorSolidCheckBox.Name = "StatusBarTextColorSolidCheckBox";
            this.StatusBarTextColorSolidCheckBox.Size = new System.Drawing.Size(72, 25);
            this.StatusBarTextColorSolidCheckBox.TabIndex = 49;
            this.StatusBarTextColorSolidCheckBox.Text = "Solid...";
            this.StatusBarTextColorSolidCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBarTextColorSolidCheckBox.UseVisualStyleBackColor = true;
            this.StatusBarTextColorSolidCheckBox.Click += new System.EventHandler(this.StatusBarTextColorSolidCheckBox_Click);
            // 
            // TrayIconColorRgbValueLabel
            // 
            this.TrayIconColorRgbValueLabel.AutoSize = true;
            this.TrayIconColorRgbValueLabel.Location = new System.Drawing.Point(309, 89);
            this.TrayIconColorRgbValueLabel.Name = "TrayIconColorRgbValueLabel";
            this.TrayIconColorRgbValueLabel.Size = new System.Drawing.Size(106, 13);
            this.TrayIconColorRgbValueLabel.TabIndex = 47;
            this.TrayIconColorRgbValueLabel.Text = "R: 135 G: 206 B: 235";
            // 
            // StatusBarColorRgbValueLabel
            // 
            this.StatusBarColorRgbValueLabel.AutoSize = true;
            this.StatusBarColorRgbValueLabel.Location = new System.Drawing.Point(309, 58);
            this.StatusBarColorRgbValueLabel.Name = "StatusBarColorRgbValueLabel";
            this.StatusBarColorRgbValueLabel.Size = new System.Drawing.Size(106, 13);
            this.StatusBarColorRgbValueLabel.TabIndex = 46;
            this.StatusBarColorRgbValueLabel.Text = "R: 135 G: 206 B: 235";
            // 
            // TrayIconColorLabel
            // 
            this.TrayIconColorLabel.AutoSize = true;
            this.TrayIconColorLabel.Location = new System.Drawing.Point(6, 89);
            this.TrayIconColorLabel.Name = "TrayIconColorLabel";
            this.TrayIconColorLabel.Size = new System.Drawing.Size(84, 13);
            this.TrayIconColorLabel.TabIndex = 30;
            this.TrayIconColorLabel.Text = "Tray icon color:";
            this.TrayIconColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrayIconColorValuePictureBox
            // 
            this.TrayIconColorValuePictureBox.BackColor = System.Drawing.Color.SkyBlue;
            this.TrayIconColorValuePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconColorValuePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.TrayIconColorValuePictureBox.Location = new System.Drawing.Point(276, 84);
            this.TrayIconColorValuePictureBox.Name = "TrayIconColorValuePictureBox";
            this.TrayIconColorValuePictureBox.Size = new System.Drawing.Size(27, 23);
            this.TrayIconColorValuePictureBox.TabIndex = 31;
            this.TrayIconColorValuePictureBox.TabStop = false;
            // 
            // TrayIconTextColorGradientCheckBox
            // 
            this.TrayIconTextColorGradientCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.TrayIconTextColorGradientCheckBox.Checked = true;
            this.TrayIconTextColorGradientCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TrayIconTextColorGradientCheckBox.Location = new System.Drawing.Point(120, 83);
            this.TrayIconTextColorGradientCheckBox.Name = "TrayIconTextColorGradientCheckBox";
            this.TrayIconTextColorGradientCheckBox.Size = new System.Drawing.Size(72, 25);
            this.TrayIconTextColorGradientCheckBox.TabIndex = 25;
            this.TrayIconTextColorGradientCheckBox.Text = "Gradient";
            this.TrayIconTextColorGradientCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TrayIconTextColorGradientCheckBox.UseVisualStyleBackColor = true;
            this.TrayIconTextColorGradientCheckBox.Click += new System.EventHandler(this.TrayIconTextGradientColorCheckBox_Click);
            // 
            // TrayIconTextColorSolidCheckBox
            // 
            this.TrayIconTextColorSolidCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.TrayIconTextColorSolidCheckBox.Location = new System.Drawing.Point(195, 83);
            this.TrayIconTextColorSolidCheckBox.Name = "TrayIconTextColorSolidCheckBox";
            this.TrayIconTextColorSolidCheckBox.Size = new System.Drawing.Size(72, 25);
            this.TrayIconTextColorSolidCheckBox.TabIndex = 26;
            this.TrayIconTextColorSolidCheckBox.Text = "Solid...";
            this.TrayIconTextColorSolidCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TrayIconTextColorSolidCheckBox.UseVisualStyleBackColor = true;
            this.TrayIconTextColorSolidCheckBox.Click += new System.EventHandler(this.TrayIconTextSolidColorCheckBox_Click);
            // 
            // StatusBarColorLabel
            // 
            this.StatusBarColorLabel.AutoSize = true;
            this.StatusBarColorLabel.Location = new System.Drawing.Point(6, 58);
            this.StatusBarColorLabel.Name = "StatusBarColorLabel";
            this.StatusBarColorLabel.Size = new System.Drawing.Size(91, 13);
            this.StatusBarColorLabel.TabIndex = 26;
            this.StatusBarColorLabel.Text = "Status bar color:";
            this.StatusBarColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarColorValuePictureBox
            // 
            this.StatusBarColorValuePictureBox.BackColor = System.Drawing.Color.SkyBlue;
            this.StatusBarColorValuePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusBarColorValuePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.StatusBarColorValuePictureBox.Location = new System.Drawing.Point(276, 53);
            this.StatusBarColorValuePictureBox.Name = "StatusBarColorValuePictureBox";
            this.StatusBarColorValuePictureBox.Size = new System.Drawing.Size(27, 23);
            this.StatusBarColorValuePictureBox.TabIndex = 27;
            this.StatusBarColorValuePictureBox.TabStop = false;
            // 
            // StatusBarColorGradientCheckBox
            // 
            this.StatusBarColorGradientCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.StatusBarColorGradientCheckBox.Checked = true;
            this.StatusBarColorGradientCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusBarColorGradientCheckBox.Location = new System.Drawing.Point(120, 52);
            this.StatusBarColorGradientCheckBox.Name = "StatusBarColorGradientCheckBox";
            this.StatusBarColorGradientCheckBox.Size = new System.Drawing.Size(72, 25);
            this.StatusBarColorGradientCheckBox.TabIndex = 23;
            this.StatusBarColorGradientCheckBox.Text = "Gradient";
            this.StatusBarColorGradientCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBarColorGradientCheckBox.UseVisualStyleBackColor = true;
            this.StatusBarColorGradientCheckBox.Click += new System.EventHandler(this.StatusBarGradientColorCheckBox_Click);
            // 
            // StatusBarColorSolidCheckBox
            // 
            this.StatusBarColorSolidCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.StatusBarColorSolidCheckBox.Location = new System.Drawing.Point(195, 52);
            this.StatusBarColorSolidCheckBox.Name = "StatusBarColorSolidCheckBox";
            this.StatusBarColorSolidCheckBox.Size = new System.Drawing.Size(72, 25);
            this.StatusBarColorSolidCheckBox.TabIndex = 24;
            this.StatusBarColorSolidCheckBox.Text = "Solid...";
            this.StatusBarColorSolidCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusBarColorSolidCheckBox.UseVisualStyleBackColor = true;
            this.StatusBarColorSolidCheckBox.Click += new System.EventHandler(this.StatusBarSolidColorCheckBox_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 416);
            this.Controls.Add(this.RestoreDefaultsButton);
            this.Controls.Add(this.ApplyConfigurationButton);
            this.Controls.Add(this.ConfigurationTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration (tb-vol-scroll)";
            this.Deactivate += new System.EventHandler(this.ConfigurationForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.ConfigurationTabControl.ResumeLayout(false);
            this.BehaviorTabPage.ResumeLayout(false);
            this.BehaviorGeneralGroupBox.ResumeLayout(false);
            this.BehaviorGeneralGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreciseVolumeThresholdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalVolumeStepNumericUpDown)).EndInit();
            this.BehaviorHotkeysGroupBox.ResumeLayout(false);
            this.BehaviorHotkeysGroupBox.PerformLayout();
            this.BehaviorMiscGroupBox.ResumeLayout(false);
            this.BehaviorMiscGroupBox.PerformLayout();
            this.AppearanceTabPage.ResumeLayout(false);
            this.AppearanceTrayIconGroupBox.ResumeLayout(false);
            this.AppearanceTrayIconGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconHeightPaddingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconWidthPaddingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconWidthNumericUpDown)).EndInit();
            this.AppearanceStatusBarGoupBox.ResumeLayout(false);
            this.AppearanceStatusBarGoupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarHeightPaddingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarOpacityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarWidthPaddingNumericUpDown)).EndInit();
            this.AppearanceColorsGroupBox.ResumeLayout(false);
            this.AppearanceColorsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarTextColorValuePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconColorValuePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBarColorValuePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigurationTabControl;
        private System.Windows.Forms.TabPage AppearanceTabPage;
        private System.Windows.Forms.TabPage BehaviorTabPage;
        private System.Windows.Forms.CheckBox IgnoreTaskbarVisibilityCheckBox;
        private System.Windows.Forms.CheckBox AltHotkeyCheckBox;
        private System.Windows.Forms.CheckBox InvertScrollingDirectionCheckBox;
        private System.Windows.Forms.CheckBox ShiftHotkeyCheckBox;
        private System.Windows.Forms.CheckBox CtrlHotkeyCheckBox;
        private System.Windows.Forms.CheckBox AutoRetryAdminCheckBox;
        private System.Windows.Forms.Label PreciseVolumeThresholdLabel;
        private System.Windows.Forms.Label NormalVolumePercentLabel;
        private System.Windows.Forms.Label AutoHideTimeOutMillisecondsLabel;
        private System.Windows.Forms.Label SetVolumeStepLabel;
        private System.Windows.Forms.NumericUpDown NormalVolumeStepNumericUpDown;
        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.NumericUpDown PreciseVolumeThresholdNumericUpDown;
        private System.Windows.Forms.NumericUpDown AutoHideTimeOutNumericUpDown;
        private System.Windows.Forms.Label AutoHideTimeOutLabel;
        private System.Windows.Forms.GroupBox BehaviorGeneralGroupBox;
        private System.Windows.Forms.GroupBox BehaviorHotkeysGroupBox;
        private System.Windows.Forms.GroupBox BehaviorMiscGroupBox;
        private System.Windows.Forms.Button ApplyConfigurationButton;
        private System.Windows.Forms.Button RestoreDefaultsButton;
        private System.Windows.Forms.GroupBox AppearanceStatusBarGoupBox;
        private System.Windows.Forms.CheckBox DisplayStatusBarScrollActionsCheckBox;
        private System.Windows.Forms.Label StatusBarPaddingPixelsLabel;
        private System.Windows.Forms.Label StatusBarPaddingLabel;
        private System.Windows.Forms.Label StatusBarOpacityValueLabel;
        private System.Windows.Forms.NumericUpDown StatusBarHeightPaddingNumericUpDown;
        private System.Windows.Forms.Label StatusBarOpacityLabel;
        private System.Windows.Forms.Label StatusBarColorLabel;
        private System.Windows.Forms.PictureBox StatusBarColorValuePictureBox;
        private System.Windows.Forms.CheckBox StatusBarColorGradientCheckBox;
        private System.Windows.Forms.CheckBox StatusBarColorSolidCheckBox;
        private System.Windows.Forms.TrackBar StatusBarOpacityTrackBar;
        private System.Windows.Forms.NumericUpDown StatusBarWidthPaddingNumericUpDown;
        private System.Windows.Forms.GroupBox AppearanceColorsGroupBox;
        private System.Windows.Forms.Label TrayIconColorLabel;
        private System.Windows.Forms.PictureBox TrayIconColorValuePictureBox;
        private System.Windows.Forms.CheckBox TrayIconTextColorGradientCheckBox;
        private System.Windows.Forms.CheckBox TrayIconTextColorSolidCheckBox;
        private System.Windows.Forms.Label StatusBarFontStyleValueLabel;
        private System.Windows.Forms.Button StatusBarPreviewFontStyleButton;
        private System.Windows.Forms.Button StatusBarSelectFontStyleButton;
        private System.Windows.Forms.Label StatusBarFontStyleLabel;
        private System.Windows.Forms.Label TrayIconFontStyleValueLabel;
        private System.Windows.Forms.Button TrayIconPreviewFontStyleButton;
        private System.Windows.Forms.Button TrayIconSelectFontStyleButton;
        private System.Windows.Forms.Label TrayIconFontStyleLabel;
        private System.Windows.Forms.Label StatusBarColorRgbValueLabel;
        private System.Windows.Forms.Label TrayIconColorRgbValueLabel;
        private System.Windows.Forms.GroupBox AppearanceTrayIconGroupBox;
        private System.Windows.Forms.ComboBox TrayIconTextRenderingHintingComboBox;
        private System.Windows.Forms.Label TrayIconTextRenderingHintingLabel;
        private System.Windows.Forms.NumericUpDown TrayIconWidthPaddingNumericUpDown;
        private System.Windows.Forms.Label TrayIconSizesPixelsLabel;
        private System.Windows.Forms.Label TrayIconSizeLabel;
        private System.Windows.Forms.NumericUpDown TrayIconHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown TrayIconWidthNumericUpDown;
        private System.Windows.Forms.CheckBox TrayIconOverrideAutoSettingsCheckBox;
        private System.Windows.Forms.Label TrayIconPaddingPixelsLabel;
        private System.Windows.Forms.NumericUpDown TrayIconHeightPaddingNumericUpDown;
        private System.Windows.Forms.Label TrayIconAlignmentLabel;
        private System.Windows.Forms.Label TrayIconTextRenderingHintingDescriptionLabel;
        private System.Windows.Forms.Label StatusBarTextColorRgbValueLabel;
        private System.Windows.Forms.Label StatusBarTextColorLabel;
        private System.Windows.Forms.PictureBox StatusBarTextColorValuePictureBox;
        private System.Windows.Forms.CheckBox StatusBarTextColorGradientCheckBox;
        private System.Windows.Forms.CheckBox StatusBarTextColorSolidCheckBox;
    }
}