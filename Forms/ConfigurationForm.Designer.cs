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
            this.DimensionXLabel = new System.Windows.Forms.Label();
            this.SetBarHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BarColorLabel = new System.Windows.Forms.Label();
            this.GradientCheckBox = new System.Windows.Forms.CheckBox();
            this.CustomColorCheckBox = new System.Windows.Forms.CheckBox();
            this.BarOpacityLabel = new System.Windows.Forms.Label();
            this.BarOpacityTrackBar = new System.Windows.Forms.TrackBar();
            this.OpacityValueLabel = new System.Windows.Forms.Label();
            this.FontStyleLabel = new System.Windows.Forms.Label();
            this.FontStyleButton = new System.Windows.Forms.Button();
            this.CustomFontDialog = new System.Windows.Forms.FontDialog();
            this.AutoHideTimeOutLabel = new System.Windows.Forms.Label();
            this.AutoHideTimeOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.PixelsLabel = new System.Windows.Forms.Label();
            this.ColorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.AutoRetryAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.BehaviourGroupBox = new System.Windows.Forms.GroupBox();
            this.SwitchAudioPlaybackDevicesCheckBox = new System.Windows.Forms.CheckBox();
            this.ToggleMuteCheckBox = new System.Windows.Forms.CheckBox();
            this.Percent2Label = new System.Windows.Forms.Label();
            this.Percent1Label = new System.Windows.Forms.Label();
            this.MillisecondsLabel = new System.Windows.Forms.Label();
            this.SetVolumeStepLabel = new System.Windows.Forms.Label();
            this.SetVolumeStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RestoreDefaultValuesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOpacityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).BeginInit();
            this.AppearanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreviewPictureBox)).BeginInit();
            this.BehaviourGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplyConfigurationButton
            // 
            this.ApplyConfigurationButton.Enabled = false;
            this.ApplyConfigurationButton.Location = new System.Drawing.Point(358, 221);
            this.ApplyConfigurationButton.Name = "ApplyConfigurationButton";
            this.ApplyConfigurationButton.Size = new System.Drawing.Size(340, 24);
            this.ApplyConfigurationButton.TabIndex = 3;
            this.ApplyConfigurationButton.Text = "Apply";
            this.ApplyConfigurationButton.UseVisualStyleBackColor = true;
            this.ApplyConfigurationButton.Click += new System.EventHandler(this.ApplyBarConfiguration);
            // 
            // SetBarDimensionsLabel
            // 
            this.SetBarDimensionsLabel.AutoSize = true;
            this.SetBarDimensionsLabel.Location = new System.Drawing.Point(12, 23);
            this.SetBarDimensionsLabel.Name = "SetBarDimensionsLabel";
            this.SetBarDimensionsLabel.Size = new System.Drawing.Size(115, 13);
            this.SetBarDimensionsLabel.TabIndex = 4;
            this.SetBarDimensionsLabel.Text = "Volume bar padding:";
            this.SetBarDimensionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetBarWidthNumericUpDown
            // 
            this.SetBarWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetBarWidthNumericUpDown.Location = new System.Drawing.Point(148, 21);
            this.SetBarWidthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SetBarWidthNumericUpDown.Name = "SetBarWidthNumericUpDown";
            this.SetBarWidthNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.SetBarWidthNumericUpDown.TabIndex = 1;
            this.SetBarWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetBarWidthNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // DimensionXLabel
            // 
            this.DimensionXLabel.AutoSize = true;
            this.DimensionXLabel.Location = new System.Drawing.Point(209, 25);
            this.DimensionXLabel.Name = "DimensionXLabel";
            this.DimensionXLabel.Size = new System.Drawing.Size(12, 13);
            this.DimensionXLabel.TabIndex = 6;
            this.DimensionXLabel.Text = "x";
            this.DimensionXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetBarHeightNumericUpDown
            // 
            this.SetBarHeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetBarHeightNumericUpDown.Location = new System.Drawing.Point(224, 21);
            this.SetBarHeightNumericUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.SetBarHeightNumericUpDown.Name = "SetBarHeightNumericUpDown";
            this.SetBarHeightNumericUpDown.Size = new System.Drawing.Size(55, 22);
            this.SetBarHeightNumericUpDown.TabIndex = 2;
            this.SetBarHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetBarHeightNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // BarColorLabel
            // 
            this.BarColorLabel.AutoSize = true;
            this.BarColorLabel.Location = new System.Drawing.Point(12, 67);
            this.BarColorLabel.Name = "BarColorLabel";
            this.BarColorLabel.Size = new System.Drawing.Size(104, 13);
            this.BarColorLabel.TabIndex = 7;
            this.BarColorLabel.Text = "Volume bar colour:";
            this.BarColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GradientCheckBox
            // 
            this.GradientCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.GradientCheckBox.AutoSize = true;
            this.GradientCheckBox.Checked = true;
            this.GradientCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GradientCheckBox.Location = new System.Drawing.Point(148, 62);
            this.GradientCheckBox.Name = "GradientCheckBox";
            this.GradientCheckBox.Size = new System.Drawing.Size(62, 23);
            this.GradientCheckBox.TabIndex = 8;
            this.GradientCheckBox.Text = "Gradient";
            this.GradientCheckBox.UseVisualStyleBackColor = true;
            this.GradientCheckBox.Click += new System.EventHandler(this.SetGradient);
            // 
            // CustomColorCheckBox
            // 
            this.CustomColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.CustomColorCheckBox.AutoSize = true;
            this.CustomColorCheckBox.Location = new System.Drawing.Point(216, 62);
            this.CustomColorCheckBox.Name = "CustomColorCheckBox";
            this.CustomColorCheckBox.Size = new System.Drawing.Size(71, 23);
            this.CustomColorCheckBox.TabIndex = 9;
            this.CustomColorCheckBox.Text = "Custom ->";
            this.CustomColorCheckBox.UseVisualStyleBackColor = true;
            this.CustomColorCheckBox.Click += new System.EventHandler(this.SetCustomColor);
            // 
            // BarOpacityLabel
            // 
            this.BarOpacityLabel.AutoSize = true;
            this.BarOpacityLabel.Location = new System.Drawing.Point(12, 159);
            this.BarOpacityLabel.Name = "BarOpacityLabel";
            this.BarOpacityLabel.Size = new System.Drawing.Size(108, 13);
            this.BarOpacityLabel.TabIndex = 11;
            this.BarOpacityLabel.Text = "Volume bar opacity:";
            this.BarOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarOpacityTrackBar
            // 
            this.BarOpacityTrackBar.Location = new System.Drawing.Point(141, 156);
            this.BarOpacityTrackBar.Maximum = 100;
            this.BarOpacityTrackBar.Name = "BarOpacityTrackBar";
            this.BarOpacityTrackBar.Size = new System.Drawing.Size(139, 45);
            this.BarOpacityTrackBar.TabIndex = 12;
            this.BarOpacityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BarOpacityTrackBar.Value = 100;
            this.BarOpacityTrackBar.ValueChanged += new System.EventHandler(this.BarOpacityChanged);
            // 
            // OpacityValueLabel
            // 
            this.OpacityValueLabel.AutoSize = true;
            this.OpacityValueLabel.Location = new System.Drawing.Point(286, 159);
            this.OpacityValueLabel.Name = "OpacityValueLabel";
            this.OpacityValueLabel.Size = new System.Drawing.Size(34, 13);
            this.OpacityValueLabel.TabIndex = 13;
            this.OpacityValueLabel.Text = "100%";
            this.OpacityValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleLabel
            // 
            this.FontStyleLabel.AutoSize = true;
            this.FontStyleLabel.Location = new System.Drawing.Point(12, 114);
            this.FontStyleLabel.Name = "FontStyleLabel";
            this.FontStyleLabel.Size = new System.Drawing.Size(115, 13);
            this.FontStyleLabel.TabIndex = 14;
            this.FontStyleLabel.Text = "Volume bar text font:";
            this.FontStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleButton
            // 
            this.FontStyleButton.Location = new System.Drawing.Point(148, 109);
            this.FontStyleButton.Name = "FontStyleButton";
            this.FontStyleButton.Size = new System.Drawing.Size(168, 23);
            this.FontStyleButton.TabIndex = 15;
            this.FontStyleButton.Text = "Set font style";
            this.FontStyleButton.UseVisualStyleBackColor = true;
            this.FontStyleButton.Click += new System.EventHandler(this.SetFontStyle);
            // 
            // CustomFontDialog
            // 
            this.CustomFontDialog.FontMustExist = true;
            // 
            // AutoHideTimeOutLabel
            // 
            this.AutoHideTimeOutLabel.AutoSize = true;
            this.AutoHideTimeOutLabel.Location = new System.Drawing.Point(17, 23);
            this.AutoHideTimeOutLabel.Name = "AutoHideTimeOutLabel";
            this.AutoHideTimeOutLabel.Size = new System.Drawing.Size(165, 13);
            this.AutoHideTimeOutLabel.TabIndex = 16;
            this.AutoHideTimeOutLabel.Text = "Volume bar auto-hide timeout:";
            this.AutoHideTimeOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoHideTimeOutNumericUpDown
            // 
            this.AutoHideTimeOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoHideTimeOutNumericUpDown.Location = new System.Drawing.Point(188, 21);
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
            this.AutoHideTimeOutNumericUpDown.TabIndex = 17;
            this.AutoHideTimeOutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AutoHideTimeOutNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // AppearanceGroupBox
            // 
            this.AppearanceGroupBox.Controls.Add(this.PixelsLabel);
            this.AppearanceGroupBox.Controls.Add(this.SetBarDimensionsLabel);
            this.AppearanceGroupBox.Controls.Add(this.FontStyleButton);
            this.AppearanceGroupBox.Controls.Add(this.SetBarWidthNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.FontStyleLabel);
            this.AppearanceGroupBox.Controls.Add(this.DimensionXLabel);
            this.AppearanceGroupBox.Controls.Add(this.OpacityValueLabel);
            this.AppearanceGroupBox.Controls.Add(this.SetBarHeightNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.BarOpacityLabel);
            this.AppearanceGroupBox.Controls.Add(this.BarColorLabel);
            this.AppearanceGroupBox.Controls.Add(this.ColorPreviewPictureBox);
            this.AppearanceGroupBox.Controls.Add(this.GradientCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.CustomColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.BarOpacityTrackBar);
            this.AppearanceGroupBox.Location = new System.Drawing.Point(357, 12);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(340, 203);
            this.AppearanceGroupBox.TabIndex = 18;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Appearance";
            // 
            // PixelsLabel
            // 
            this.PixelsLabel.AutoSize = true;
            this.PixelsLabel.Location = new System.Drawing.Point(286, 25);
            this.PixelsLabel.Name = "PixelsLabel";
            this.PixelsLabel.Size = new System.Drawing.Size(36, 13);
            this.PixelsLabel.TabIndex = 16;
            this.PixelsLabel.Text = "pixels";
            this.PixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorPreviewPictureBox
            // 
            this.ColorPreviewPictureBox.BackColor = System.Drawing.Color.DodgerBlue;
            this.ColorPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPreviewPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorPreviewPictureBox.Location = new System.Drawing.Point(293, 63);
            this.ColorPreviewPictureBox.Name = "ColorPreviewPictureBox";
            this.ColorPreviewPictureBox.Size = new System.Drawing.Size(21, 21);
            this.ColorPreviewPictureBox.TabIndex = 10;
            this.ColorPreviewPictureBox.TabStop = false;
            this.ColorPreviewPictureBox.Click += new System.EventHandler(this.PickBarColor);
            // 
            // AutoRetryAdminCheckBox
            // 
            this.AutoRetryAdminCheckBox.AutoSize = true;
            this.AutoRetryAdminCheckBox.Location = new System.Drawing.Point(20, 228);
            this.AutoRetryAdminCheckBox.Name = "AutoRetryAdminCheckBox";
            this.AutoRetryAdminCheckBox.Size = new System.Drawing.Size(300, 17);
            this.AutoRetryAdminCheckBox.TabIndex = 22;
            this.AutoRetryAdminCheckBox.Text = "Request Administrator permissions on start if needed";
            this.AutoRetryAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // BehaviourGroupBox
            // 
            this.BehaviourGroupBox.Controls.Add(this.SwitchAudioPlaybackDevicesCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.ToggleMuteCheckBox);
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
            this.BehaviourGroupBox.Location = new System.Drawing.Point(12, 12);
            this.BehaviourGroupBox.Name = "BehaviourGroupBox";
            this.BehaviourGroupBox.Size = new System.Drawing.Size(340, 262);
            this.BehaviourGroupBox.TabIndex = 19;
            this.BehaviourGroupBox.TabStop = false;
            this.BehaviourGroupBox.Text = "Behaviour";
            // 
            // SwitchAudioPlaybackDevicesCheckBox
            // 
            this.SwitchAudioPlaybackDevicesCheckBox.AutoSize = true;
            this.SwitchAudioPlaybackDevicesCheckBox.Location = new System.Drawing.Point(20, 189);
            this.SwitchAudioPlaybackDevicesCheckBox.Name = "SwitchAudioPlaybackDevicesCheckBox";
            this.SwitchAudioPlaybackDevicesCheckBox.Size = new System.Drawing.Size(308, 30);
            this.SwitchAudioPlaybackDevicesCheckBox.TabIndex = 25;
            this.SwitchAudioPlaybackDevicesCheckBox.Text = "Switch between available audio playback devices while\r\nscrolling and holding the " +
    "SHIFT key";
            this.SwitchAudioPlaybackDevicesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ToggleMuteCheckBox
            // 
            this.ToggleMuteCheckBox.AutoSize = true;
            this.ToggleMuteCheckBox.Location = new System.Drawing.Point(20, 151);
            this.ToggleMuteCheckBox.Name = "ToggleMuteCheckBox";
            this.ToggleMuteCheckBox.Size = new System.Drawing.Size(297, 30);
            this.ToggleMuteCheckBox.TabIndex = 23;
            this.ToggleMuteCheckBox.Text = "Mute and unmute system volume while scrolling and\r\nholding the CTRL key";
            this.ToggleMuteCheckBox.UseVisualStyleBackColor = true;
            // 
            // Percent2Label
            // 
            this.Percent2Label.AutoSize = true;
            this.Percent2Label.Location = new System.Drawing.Point(253, 114);
            this.Percent2Label.Name = "Percent2Label";
            this.Percent2Label.Size = new System.Drawing.Size(46, 13);
            this.Percent2Label.TabIndex = 24;
            this.Percent2Label.Text = "percent";
            this.Percent2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Percent1Label
            // 
            this.Percent1Label.AutoSize = true;
            this.Percent1Label.Location = new System.Drawing.Point(253, 67);
            this.Percent1Label.Name = "Percent1Label";
            this.Percent1Label.Size = new System.Drawing.Size(46, 13);
            this.Percent1Label.TabIndex = 23;
            this.Percent1Label.Text = "percent";
            this.Percent1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MillisecondsLabel
            // 
            this.MillisecondsLabel.AutoSize = true;
            this.MillisecondsLabel.Location = new System.Drawing.Point(253, 25);
            this.MillisecondsLabel.Name = "MillisecondsLabel";
            this.MillisecondsLabel.Size = new System.Drawing.Size(70, 13);
            this.MillisecondsLabel.TabIndex = 17;
            this.MillisecondsLabel.Text = "milliseconds";
            this.MillisecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetVolumeStepLabel
            // 
            this.SetVolumeStepLabel.AutoSize = true;
            this.SetVolumeStepLabel.Location = new System.Drawing.Point(17, 67);
            this.SetVolumeStepLabel.Name = "SetVolumeStepLabel";
            this.SetVolumeStepLabel.Size = new System.Drawing.Size(142, 13);
            this.SetVolumeStepLabel.TabIndex = 21;
            this.SetVolumeStepLabel.Text = "Normal volume scroll step:";
            this.SetVolumeStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetVolumeStepNumericUpDown
            // 
            this.SetVolumeStepNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetVolumeStepNumericUpDown.Location = new System.Drawing.Point(188, 65);
            this.SetVolumeStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SetVolumeStepNumericUpDown.Name = "SetVolumeStepNumericUpDown";
            this.SetVolumeStepNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.SetVolumeStepNumericUpDown.TabIndex = 20;
            this.SetVolumeStepNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetVolumeStepNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(17, 114);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(168, 13);
            this.ThresholdLabel.TabIndex = 19;
            this.ThresholdLabel.Text = "Precise volume scroll threshold:";
            this.ThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThresholdNumericUpDown
            // 
            this.ThresholdNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThresholdNumericUpDown.Location = new System.Drawing.Point(188, 112);
            this.ThresholdNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThresholdNumericUpDown.Name = "ThresholdNumericUpDown";
            this.ThresholdNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.ThresholdNumericUpDown.TabIndex = 18;
            this.ThresholdNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThresholdNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // RestoreDefaultValuesButton
            // 
            this.RestoreDefaultValuesButton.Location = new System.Drawing.Point(357, 251);
            this.RestoreDefaultValuesButton.Name = "RestoreDefaultValuesButton";
            this.RestoreDefaultValuesButton.Size = new System.Drawing.Size(340, 23);
            this.RestoreDefaultValuesButton.TabIndex = 20;
            this.RestoreDefaultValuesButton.Text = "Restore default values";
            this.RestoreDefaultValuesButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultValuesButton.Click += new System.EventHandler(this.RestoreDefaultValues);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(709, 286);
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
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).EndInit();
            this.AppearanceGroupBox.ResumeLayout(false);
            this.AppearanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreviewPictureBox)).EndInit();
            this.BehaviourGroupBox.ResumeLayout(false);
            this.BehaviourGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplyConfigurationButton;
        private System.Windows.Forms.Label SetBarDimensionsLabel;
        private System.Windows.Forms.NumericUpDown SetBarWidthNumericUpDown;
        private System.Windows.Forms.Label DimensionXLabel;
        private System.Windows.Forms.NumericUpDown SetBarHeightNumericUpDown;
        private System.Windows.Forms.Label BarColorLabel;
        private System.Windows.Forms.CheckBox GradientCheckBox;
        private System.Windows.Forms.CheckBox CustomColorCheckBox;
        private System.Windows.Forms.PictureBox ColorPreviewPictureBox;
        private System.Windows.Forms.Label BarOpacityLabel;
        private System.Windows.Forms.TrackBar BarOpacityTrackBar;
        private System.Windows.Forms.Label OpacityValueLabel;
        private System.Windows.Forms.Label FontStyleLabel;
        private System.Windows.Forms.Button FontStyleButton;
        private System.Windows.Forms.FontDialog CustomFontDialog;
        private System.Windows.Forms.Label AutoHideTimeOutLabel;
        private System.Windows.Forms.NumericUpDown AutoHideTimeOutNumericUpDown;
        private System.Windows.Forms.GroupBox AppearanceGroupBox;
        private System.Windows.Forms.GroupBox BehaviourGroupBox;
        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.NumericUpDown ThresholdNumericUpDown;
        private System.Windows.Forms.Label SetVolumeStepLabel;
        private System.Windows.Forms.NumericUpDown SetVolumeStepNumericUpDown;
        private System.Windows.Forms.CheckBox AutoRetryAdminCheckBox;
        private System.Windows.Forms.Button RestoreDefaultValuesButton;
        private System.Windows.Forms.Label PixelsLabel;
        private System.Windows.Forms.Label MillisecondsLabel;
        private System.Windows.Forms.Label Percent2Label;
        private System.Windows.Forms.Label Percent1Label;
        private System.Windows.Forms.CheckBox ToggleMuteCheckBox;
        private System.Windows.Forms.CheckBox SwitchAudioPlaybackDevicesCheckBox;
    }
}