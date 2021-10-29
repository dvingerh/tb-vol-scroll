namespace tbvolscroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.ApplyConfigurationButton = new System.Windows.Forms.Button();
            this.SetBarDimensionsLabel = new System.Windows.Forms.Label();
            this.SetBarWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetBarHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BarColorLabel = new System.Windows.Forms.Label();
            this.GradientColorCheckBox = new System.Windows.Forms.CheckBox();
            this.SolidColorCheckBox = new System.Windows.Forms.CheckBox();
            this.BarOpacityLabel = new System.Windows.Forms.Label();
            this.BarOpacityTrackBar = new System.Windows.Forms.TrackBar();
            this.OpacityValueLabel = new System.Windows.Forms.Label();
            this.FontStyleLabel = new System.Windows.Forms.Label();
            this.FontStyleButton = new System.Windows.Forms.Button();
            this.CustomFontDialog = new System.Windows.Forms.FontDialog();
            this.AppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.FontPreviewLabel = new System.Windows.Forms.Label();
            this.PixelsLabel = new System.Windows.Forms.Label();
            this.ColorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.AutoRetryAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.BehaviourGroupBox = new System.Windows.Forms.GroupBox();
            this.ManualPreciseVolumeCheckBox = new System.Windows.Forms.CheckBox();
            this.ReverseScrollingDirectionCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableSwitchPlaybackDeviceOption = new System.Windows.Forms.CheckBox();
            this.EnableMuteUnmuteOption = new System.Windows.Forms.CheckBox();
            this.Percent2Label = new System.Windows.Forms.Label();
            this.Percent1Label = new System.Windows.Forms.Label();
            this.MillisecondsLabel = new System.Windows.Forms.Label();
            this.SetVolumeStepLabel = new System.Windows.Forms.Label();
            this.SetVolumeStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoHideTimeOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoHideTimeOutLabel = new System.Windows.Forms.Label();
            this.RestoreDefaultValuesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOpacityTrackBar)).BeginInit();
            this.AppearanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreviewPictureBox)).BeginInit();
            this.BehaviourGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplyConfigurationButton
            // 
            this.ApplyConfigurationButton.Enabled = false;
            this.ApplyConfigurationButton.Location = new System.Drawing.Point(328, 237);
            this.ApplyConfigurationButton.Name = "ApplyConfigurationButton";
            this.ApplyConfigurationButton.Size = new System.Drawing.Size(341, 32);
            this.ApplyConfigurationButton.TabIndex = 12;
            this.ApplyConfigurationButton.Text = "Apply changes";
            this.ApplyConfigurationButton.UseVisualStyleBackColor = true;
            this.ApplyConfigurationButton.Click += new System.EventHandler(this.ApplyBarConfiguration);
            // 
            // SetBarDimensionsLabel
            // 
            this.SetBarDimensionsLabel.AutoSize = true;
            this.SetBarDimensionsLabel.Location = new System.Drawing.Point(15, 25);
            this.SetBarDimensionsLabel.Name = "SetBarDimensionsLabel";
            this.SetBarDimensionsLabel.Size = new System.Drawing.Size(115, 26);
            this.SetBarDimensionsLabel.TabIndex = 4;
            this.SetBarDimensionsLabel.Text = "Volume bar padding:\r\n(width x height)";
            this.SetBarDimensionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetBarWidthNumericUpDown
            // 
            this.SetBarWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetBarWidthNumericUpDown.Location = new System.Drawing.Point(151, 26);
            this.SetBarWidthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SetBarWidthNumericUpDown.Name = "SetBarWidthNumericUpDown";
            this.SetBarWidthNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.SetBarWidthNumericUpDown.TabIndex = 6;
            this.SetBarWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetBarWidthNumericUpDown.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // SetBarHeightNumericUpDown
            // 
            this.SetBarHeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetBarHeightNumericUpDown.Location = new System.Drawing.Point(227, 26);
            this.SetBarHeightNumericUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.SetBarHeightNumericUpDown.Name = "SetBarHeightNumericUpDown";
            this.SetBarHeightNumericUpDown.Size = new System.Drawing.Size(63, 22);
            this.SetBarHeightNumericUpDown.TabIndex = 7;
            this.SetBarHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetBarHeightNumericUpDown.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // BarColorLabel
            // 
            this.BarColorLabel.AutoSize = true;
            this.BarColorLabel.Location = new System.Drawing.Point(15, 82);
            this.BarColorLabel.Name = "BarColorLabel";
            this.BarColorLabel.Size = new System.Drawing.Size(104, 13);
            this.BarColorLabel.TabIndex = 7;
            this.BarColorLabel.Text = "Volume bar colour:";
            this.BarColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GradientColorCheckBox
            // 
            this.GradientColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.GradientColorCheckBox.Checked = true;
            this.GradientColorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GradientColorCheckBox.Location = new System.Drawing.Point(151, 73);
            this.GradientColorCheckBox.Name = "GradientColorCheckBox";
            this.GradientColorCheckBox.Size = new System.Drawing.Size(70, 30);
            this.GradientColorCheckBox.TabIndex = 8;
            this.GradientColorCheckBox.Text = "Gradient";
            this.GradientColorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GradientColorCheckBox.UseVisualStyleBackColor = true;
            this.GradientColorCheckBox.Click += new System.EventHandler(this.SetGradientColor);
            // 
            // SolidColorCheckBox
            // 
            this.SolidColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.SolidColorCheckBox.Location = new System.Drawing.Point(227, 73);
            this.SolidColorCheckBox.Name = "SolidColorCheckBox";
            this.SolidColorCheckBox.Size = new System.Drawing.Size(63, 30);
            this.SolidColorCheckBox.TabIndex = 9;
            this.SolidColorCheckBox.Text = "Solid";
            this.SolidColorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SolidColorCheckBox.UseVisualStyleBackColor = true;
            this.SolidColorCheckBox.Click += new System.EventHandler(this.SetSolidColor);
            // 
            // BarOpacityLabel
            // 
            this.BarOpacityLabel.AutoSize = true;
            this.BarOpacityLabel.Location = new System.Drawing.Point(15, 183);
            this.BarOpacityLabel.Name = "BarOpacityLabel";
            this.BarOpacityLabel.Size = new System.Drawing.Size(108, 13);
            this.BarOpacityLabel.TabIndex = 11;
            this.BarOpacityLabel.Text = "Volume bar opacity:";
            this.BarOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarOpacityTrackBar
            // 
            this.BarOpacityTrackBar.AutoSize = false;
            this.BarOpacityTrackBar.Location = new System.Drawing.Point(144, 181);
            this.BarOpacityTrackBar.Maximum = 100;
            this.BarOpacityTrackBar.Name = "BarOpacityTrackBar";
            this.BarOpacityTrackBar.Size = new System.Drawing.Size(139, 25);
            this.BarOpacityTrackBar.TabIndex = 11;
            this.BarOpacityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BarOpacityTrackBar.Value = 100;
            this.BarOpacityTrackBar.ValueChanged += new System.EventHandler(this.BarOpacityChanged);
            // 
            // OpacityValueLabel
            // 
            this.OpacityValueLabel.AutoSize = true;
            this.OpacityValueLabel.Location = new System.Drawing.Point(289, 183);
            this.OpacityValueLabel.Name = "OpacityValueLabel";
            this.OpacityValueLabel.Size = new System.Drawing.Size(34, 13);
            this.OpacityValueLabel.TabIndex = 13;
            this.OpacityValueLabel.Text = "100%";
            this.OpacityValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleLabel
            // 
            this.FontStyleLabel.AutoSize = true;
            this.FontStyleLabel.Location = new System.Drawing.Point(15, 133);
            this.FontStyleLabel.Name = "FontStyleLabel";
            this.FontStyleLabel.Size = new System.Drawing.Size(115, 13);
            this.FontStyleLabel.TabIndex = 14;
            this.FontStyleLabel.Text = "Volume bar text font:";
            this.FontStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleButton
            // 
            this.FontStyleButton.Location = new System.Drawing.Point(151, 128);
            this.FontStyleButton.Name = "FontStyleButton";
            this.FontStyleButton.Size = new System.Drawing.Size(70, 30);
            this.FontStyleButton.TabIndex = 10;
            this.FontStyleButton.Text = "Select font";
            this.FontStyleButton.UseVisualStyleBackColor = true;
            this.FontStyleButton.Click += new System.EventHandler(this.SetFontStyle);
            // 
            // CustomFontDialog
            // 
            this.CustomFontDialog.FontMustExist = true;
            // 
            // AppearanceGroupBox
            // 
            this.AppearanceGroupBox.Controls.Add(this.FontPreviewLabel);
            this.AppearanceGroupBox.Controls.Add(this.PixelsLabel);
            this.AppearanceGroupBox.Controls.Add(this.SetBarDimensionsLabel);
            this.AppearanceGroupBox.Controls.Add(this.FontStyleButton);
            this.AppearanceGroupBox.Controls.Add(this.FontStyleLabel);
            this.AppearanceGroupBox.Controls.Add(this.OpacityValueLabel);
            this.AppearanceGroupBox.Controls.Add(this.SetBarHeightNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.BarOpacityLabel);
            this.AppearanceGroupBox.Controls.Add(this.BarColorLabel);
            this.AppearanceGroupBox.Controls.Add(this.ColorPreviewPictureBox);
            this.AppearanceGroupBox.Controls.Add(this.GradientColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.SolidColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.BarOpacityTrackBar);
            this.AppearanceGroupBox.Controls.Add(this.SetBarWidthNumericUpDown);
            this.AppearanceGroupBox.Location = new System.Drawing.Point(329, 9);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(340, 222);
            this.AppearanceGroupBox.TabIndex = 18;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Appearance";
            // 
            // FontPreviewLabel
            // 
            this.FontPreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontPreviewLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.FontPreviewLabel.Location = new System.Drawing.Point(227, 129);
            this.FontPreviewLabel.Name = "FontPreviewLabel";
            this.FontPreviewLabel.Size = new System.Drawing.Size(96, 28);
            this.FontPreviewLabel.TabIndex = 17;
            this.FontPreviewLabel.Text = "Aa 50%";
            this.FontPreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PixelsLabel
            // 
            this.PixelsLabel.AutoSize = true;
            this.PixelsLabel.Location = new System.Drawing.Point(293, 30);
            this.PixelsLabel.Name = "PixelsLabel";
            this.PixelsLabel.Size = new System.Drawing.Size(36, 13);
            this.PixelsLabel.TabIndex = 16;
            this.PixelsLabel.Text = "pixels";
            this.PixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorPreviewPictureBox
            // 
            this.ColorPreviewPictureBox.BackColor = System.Drawing.Color.SkyBlue;
            this.ColorPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPreviewPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorPreviewPictureBox.Location = new System.Drawing.Point(296, 74);
            this.ColorPreviewPictureBox.Name = "ColorPreviewPictureBox";
            this.ColorPreviewPictureBox.Size = new System.Drawing.Size(27, 28);
            this.ColorPreviewPictureBox.TabIndex = 10;
            this.ColorPreviewPictureBox.TabStop = false;
            this.ColorPreviewPictureBox.Click += new System.EventHandler(this.PickBarColor);
            // 
            // AutoRetryAdminCheckBox
            // 
            this.AutoRetryAdminCheckBox.AutoSize = true;
            this.AutoRetryAdminCheckBox.Location = new System.Drawing.Point(18, 230);
            this.AutoRetryAdminCheckBox.Name = "AutoRetryAdminCheckBox";
            this.AutoRetryAdminCheckBox.Size = new System.Drawing.Size(262, 17);
            this.AutoRetryAdminCheckBox.TabIndex = 5;
            this.AutoRetryAdminCheckBox.Text = "Request Administrator permissions on startup";
            this.AutoRetryAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // BehaviourGroupBox
            // 
            this.BehaviourGroupBox.Controls.Add(this.ManualPreciseVolumeCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.ReverseScrollingDirectionCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.EnableSwitchPlaybackDeviceOption);
            this.BehaviourGroupBox.Controls.Add(this.EnableMuteUnmuteOption);
            this.BehaviourGroupBox.Controls.Add(this.AutoRetryAdminCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.Percent2Label);
            this.BehaviourGroupBox.Controls.Add(this.Percent1Label);
            this.BehaviourGroupBox.Controls.Add(this.MillisecondsLabel);
            this.BehaviourGroupBox.Controls.Add(this.SetVolumeStepLabel);
            this.BehaviourGroupBox.Controls.Add(this.SetVolumeStepNumericUpDown);
            this.BehaviourGroupBox.Controls.Add(this.ThresholdLabel);
            this.BehaviourGroupBox.Controls.Add(this.ThresholdNumericUpDown);
            this.BehaviourGroupBox.Controls.Add(this.AutoHideTimeOutNumericUpDown);
            this.BehaviourGroupBox.Controls.Add(this.AutoHideTimeOutLabel);
            this.BehaviourGroupBox.Location = new System.Drawing.Point(12, 9);
            this.BehaviourGroupBox.Name = "BehaviourGroupBox";
            this.BehaviourGroupBox.Size = new System.Drawing.Size(310, 290);
            this.BehaviourGroupBox.TabIndex = 19;
            this.BehaviourGroupBox.TabStop = false;
            this.BehaviourGroupBox.Text = "Behaviour";
            // 
            // ManualPreciseVolumeCheckBox
            // 
            this.ManualPreciseVolumeCheckBox.AutoSize = true;
            this.ManualPreciseVolumeCheckBox.Location = new System.Drawing.Point(18, 193);
            this.ManualPreciseVolumeCheckBox.Name = "ManualPreciseVolumeCheckBox";
            this.ManualPreciseVolumeCheckBox.Size = new System.Drawing.Size(256, 30);
            this.ManualPreciseVolumeCheckBox.TabIndex = 26;
            this.ManualPreciseVolumeCheckBox.Text = "Manually activate precise volume scroll mode\r\nwhen holding down the ALT key";
            this.ManualPreciseVolumeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReverseScrollingDirectionCheckBox
            // 
            this.ReverseScrollingDirectionCheckBox.AutoSize = true;
            this.ReverseScrollingDirectionCheckBox.Location = new System.Drawing.Point(18, 258);
            this.ReverseScrollingDirectionCheckBox.Name = "ReverseScrollingDirectionCheckBox";
            this.ReverseScrollingDirectionCheckBox.Size = new System.Drawing.Size(249, 17);
            this.ReverseScrollingDirectionCheckBox.TabIndex = 25;
            this.ReverseScrollingDirectionCheckBox.Text = "Reverse scrolling direction for scroll actions";
            this.ReverseScrollingDirectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableSwitchPlaybackDeviceOption
            // 
            this.EnableSwitchPlaybackDeviceOption.AutoSize = true;
            this.EnableSwitchPlaybackDeviceOption.Location = new System.Drawing.Point(18, 157);
            this.EnableSwitchPlaybackDeviceOption.Name = "EnableSwitchPlaybackDeviceOption";
            this.EnableSwitchPlaybackDeviceOption.Size = new System.Drawing.Size(277, 30);
            this.EnableSwitchPlaybackDeviceOption.TabIndex = 4;
            this.EnableSwitchPlaybackDeviceOption.Text = "Switch between available audio playback devices\r\nwhen holding down the SHIFT key";
            this.EnableSwitchPlaybackDeviceOption.UseVisualStyleBackColor = true;
            // 
            // EnableMuteUnmuteOption
            // 
            this.EnableMuteUnmuteOption.AutoSize = true;
            this.EnableMuteUnmuteOption.Location = new System.Drawing.Point(18, 121);
            this.EnableMuteUnmuteOption.Name = "EnableMuteUnmuteOption";
            this.EnableMuteUnmuteOption.Size = new System.Drawing.Size(267, 30);
            this.EnableMuteUnmuteOption.TabIndex = 3;
            this.EnableMuteUnmuteOption.Text = "Mute and unmute active audio playback device\r\nwhen holding down the CTRL key";
            this.EnableMuteUnmuteOption.UseVisualStyleBackColor = true;
            // 
            // Percent2Label
            // 
            this.Percent2Label.AutoSize = true;
            this.Percent2Label.Location = new System.Drawing.Point(251, 60);
            this.Percent2Label.Name = "Percent2Label";
            this.Percent2Label.Size = new System.Drawing.Size(46, 13);
            this.Percent2Label.TabIndex = 24;
            this.Percent2Label.Text = "percent";
            this.Percent2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Percent1Label
            // 
            this.Percent1Label.AutoSize = true;
            this.Percent1Label.Location = new System.Drawing.Point(251, 28);
            this.Percent1Label.Name = "Percent1Label";
            this.Percent1Label.Size = new System.Drawing.Size(46, 13);
            this.Percent1Label.TabIndex = 23;
            this.Percent1Label.Text = "percent";
            this.Percent1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MillisecondsLabel
            // 
            this.MillisecondsLabel.AutoSize = true;
            this.MillisecondsLabel.Location = new System.Drawing.Point(253, 95);
            this.MillisecondsLabel.Name = "MillisecondsLabel";
            this.MillisecondsLabel.Size = new System.Drawing.Size(21, 13);
            this.MillisecondsLabel.TabIndex = 17;
            this.MillisecondsLabel.Text = "ms";
            this.MillisecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetVolumeStepLabel
            // 
            this.SetVolumeStepLabel.AutoSize = true;
            this.SetVolumeStepLabel.Location = new System.Drawing.Point(15, 28);
            this.SetVolumeStepLabel.Name = "SetVolumeStepLabel";
            this.SetVolumeStepLabel.Size = new System.Drawing.Size(142, 13);
            this.SetVolumeStepLabel.TabIndex = 21;
            this.SetVolumeStepLabel.Text = "Normal volume scroll step:";
            this.SetVolumeStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetVolumeStepNumericUpDown
            // 
            this.SetVolumeStepNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetVolumeStepNumericUpDown.Location = new System.Drawing.Point(186, 25);
            this.SetVolumeStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SetVolumeStepNumericUpDown.Name = "SetVolumeStepNumericUpDown";
            this.SetVolumeStepNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.SetVolumeStepNumericUpDown.TabIndex = 2;
            this.SetVolumeStepNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetVolumeStepNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SetVolumeStepNumericUpDown.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(15, 60);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(168, 13);
            this.ThresholdLabel.TabIndex = 19;
            this.ThresholdLabel.Text = "Precise volume scroll threshold:";
            this.ThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThresholdNumericUpDown
            // 
            this.ThresholdNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThresholdNumericUpDown.Location = new System.Drawing.Point(186, 58);
            this.ThresholdNumericUpDown.Name = "ThresholdNumericUpDown";
            this.ThresholdNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.ThresholdNumericUpDown.TabIndex = 3;
            this.ThresholdNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThresholdNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ThresholdNumericUpDown.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // AutoHideTimeOutNumericUpDown
            // 
            this.AutoHideTimeOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoHideTimeOutNumericUpDown.Location = new System.Drawing.Point(186, 91);
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
            this.AutoHideTimeOutNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.AutoHideTimeOutNumericUpDown.TabIndex = 1;
            this.AutoHideTimeOutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AutoHideTimeOutNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AutoHideTimeOutNumericUpDown.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
            // 
            // AutoHideTimeOutLabel
            // 
            this.AutoHideTimeOutLabel.AutoSize = true;
            this.AutoHideTimeOutLabel.Location = new System.Drawing.Point(15, 93);
            this.AutoHideTimeOutLabel.Name = "AutoHideTimeOutLabel";
            this.AutoHideTimeOutLabel.Size = new System.Drawing.Size(149, 13);
            this.AutoHideTimeOutLabel.TabIndex = 16;
            this.AutoHideTimeOutLabel.Text = "Auto-hide volume bar after:";
            this.AutoHideTimeOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestoreDefaultValuesButton
            // 
            this.RestoreDefaultValuesButton.Location = new System.Drawing.Point(328, 275);
            this.RestoreDefaultValuesButton.Name = "RestoreDefaultValuesButton";
            this.RestoreDefaultValuesButton.Size = new System.Drawing.Size(341, 23);
            this.RestoreDefaultValuesButton.TabIndex = 13;
            this.RestoreDefaultValuesButton.Text = "Restore default values";
            this.RestoreDefaultValuesButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultValuesButton.Click += new System.EventHandler(this.RestoreDefaultValues);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.RestoreDefaultValuesButton);
            this.Controls.Add(this.ApplyConfigurationButton);
            this.Controls.Add(this.AppearanceGroupBox);
            this.Controls.Add(this.BehaviourGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmCloseWithoutSaving);
            this.Load += new System.EventHandler(this.LoadBarConfiguration);
            ((System.ComponentModel.ISupportInitialize)(this.SetBarWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOpacityTrackBar)).EndInit();
            this.AppearanceGroupBox.ResumeLayout(false);
            this.AppearanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreviewPictureBox)).EndInit();
            this.BehaviourGroupBox.ResumeLayout(false);
            this.BehaviourGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplyConfigurationButton;
        private System.Windows.Forms.Label SetBarDimensionsLabel;
        private System.Windows.Forms.NumericUpDown SetBarWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown SetBarHeightNumericUpDown;
        private System.Windows.Forms.Label BarColorLabel;
        private System.Windows.Forms.CheckBox GradientColorCheckBox;
        private System.Windows.Forms.CheckBox SolidColorCheckBox;
        private System.Windows.Forms.PictureBox ColorPreviewPictureBox;
        private System.Windows.Forms.Label BarOpacityLabel;
        private System.Windows.Forms.TrackBar BarOpacityTrackBar;
        private System.Windows.Forms.Label OpacityValueLabel;
        private System.Windows.Forms.Label FontStyleLabel;
        private System.Windows.Forms.Button FontStyleButton;
        private System.Windows.Forms.FontDialog CustomFontDialog;
        private System.Windows.Forms.GroupBox AppearanceGroupBox;
        private System.Windows.Forms.GroupBox BehaviourGroupBox;
        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.NumericUpDown ThresholdNumericUpDown;
        private System.Windows.Forms.Label SetVolumeStepLabel;
        private System.Windows.Forms.NumericUpDown SetVolumeStepNumericUpDown;
        private System.Windows.Forms.CheckBox AutoRetryAdminCheckBox;
        private System.Windows.Forms.Button RestoreDefaultValuesButton;
        private System.Windows.Forms.Label Percent2Label;
        private System.Windows.Forms.Label Percent1Label;
        private System.Windows.Forms.CheckBox EnableMuteUnmuteOption;
        private System.Windows.Forms.CheckBox EnableSwitchPlaybackDeviceOption;
        private System.Windows.Forms.Label FontPreviewLabel;
        private System.Windows.Forms.CheckBox ReverseScrollingDirectionCheckBox;
        private System.Windows.Forms.CheckBox ManualPreciseVolumeCheckBox;
        private System.Windows.Forms.Label PixelsLabel;
        private System.Windows.Forms.Label MillisecondsLabel;
        private System.Windows.Forms.NumericUpDown AutoHideTimeOutNumericUpDown;
        private System.Windows.Forms.Label AutoHideTimeOutLabel;
    }
}