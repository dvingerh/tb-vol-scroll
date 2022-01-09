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
            this.SetVolumeBarPaddingLabel = new System.Windows.Forms.Label();
            this.SetVolumeBarWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetVolumeBarHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VolumeBarColorLabel = new System.Windows.Forms.Label();
            this.VolumeBarGradientColorCheckBox = new System.Windows.Forms.CheckBox();
            this.VolumeBarSolidColorCheckBox = new System.Windows.Forms.CheckBox();
            this.VolumeBarOpacityLabel = new System.Windows.Forms.Label();
            this.VolumeBarOpacityTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeBarOpacityValueLabel = new System.Windows.Forms.Label();
            this.FontStyleLabel = new System.Windows.Forms.Label();
            this.FontStyleButton = new System.Windows.Forms.Button();
            this.CustomFontDialog = new System.Windows.Forms.FontDialog();
            this.AppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.TextRenderingHintComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DisplayVolumeBarScrollingCheckBox = new System.Windows.Forms.CheckBox();
            this.TrayIconTextColorLabel = new System.Windows.Forms.Label();
            this.TrayIconTextColorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.TrayIconTextGradientColorCheckBox = new System.Windows.Forms.CheckBox();
            this.TrayIconTextSolidColorCheckBox = new System.Windows.Forms.CheckBox();
            this.DisplayTrayIconAsTextCheckBox = new System.Windows.Forms.CheckBox();
            this.FontPreviewLabel = new System.Windows.Forms.Label();
            this.VolumeBarPaddingPixelsLabel = new System.Windows.Forms.Label();
            this.VolumeBarColorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.AutoRetryAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.BehaviourGroupBox = new System.Windows.Forms.GroupBox();
            this.ManualPreciseVolumeCheckBox = new System.Windows.Forms.CheckBox();
            this.ReverseScrollingDirectionCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableSwitchPlaybackDeviceOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableMuteUnmuteOptionCheckBox = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeBarWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeBarHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBarOpacityTrackBar)).BeginInit();
            this.AppearanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconTextColorPreviewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBarColorPreviewPictureBox)).BeginInit();
            this.BehaviourGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplyConfigurationButton
            // 
            this.ApplyConfigurationButton.Enabled = false;
            this.ApplyConfigurationButton.Location = new System.Drawing.Point(328, 312);
            this.ApplyConfigurationButton.Name = "ApplyConfigurationButton";
            this.ApplyConfigurationButton.Size = new System.Drawing.Size(341, 25);
            this.ApplyConfigurationButton.TabIndex = 19;
            this.ApplyConfigurationButton.Text = "Apply changes";
            this.ApplyConfigurationButton.UseVisualStyleBackColor = true;
            this.ApplyConfigurationButton.Click += new System.EventHandler(this.ApplyBarConfiguration);
            // 
            // SetVolumeBarPaddingLabel
            // 
            this.SetVolumeBarPaddingLabel.AutoSize = true;
            this.SetVolumeBarPaddingLabel.Location = new System.Drawing.Point(15, 54);
            this.SetVolumeBarPaddingLabel.Name = "SetVolumeBarPaddingLabel";
            this.SetVolumeBarPaddingLabel.Size = new System.Drawing.Size(115, 26);
            this.SetVolumeBarPaddingLabel.TabIndex = 4;
            this.SetVolumeBarPaddingLabel.Text = "Volume bar padding:\r\n(width x height)";
            this.SetVolumeBarPaddingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetVolumeBarWidthNumericUpDown
            // 
            this.SetVolumeBarWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetVolumeBarWidthNumericUpDown.Location = new System.Drawing.Point(151, 55);
            this.SetVolumeBarWidthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SetVolumeBarWidthNumericUpDown.Name = "SetVolumeBarWidthNumericUpDown";
            this.SetVolumeBarWidthNumericUpDown.Size = new System.Drawing.Size(70, 22);
            this.SetVolumeBarWidthNumericUpDown.TabIndex = 9;
            this.SetVolumeBarWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SetVolumeBarHeightNumericUpDown
            // 
            this.SetVolumeBarHeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetVolumeBarHeightNumericUpDown.Location = new System.Drawing.Point(227, 55);
            this.SetVolumeBarHeightNumericUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.SetVolumeBarHeightNumericUpDown.Name = "SetVolumeBarHeightNumericUpDown";
            this.SetVolumeBarHeightNumericUpDown.Size = new System.Drawing.Size(63, 22);
            this.SetVolumeBarHeightNumericUpDown.TabIndex = 10;
            this.SetVolumeBarHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VolumeBarColorLabel
            // 
            this.VolumeBarColorLabel.AutoSize = true;
            this.VolumeBarColorLabel.Location = new System.Drawing.Point(15, 95);
            this.VolumeBarColorLabel.Name = "VolumeBarColorLabel";
            this.VolumeBarColorLabel.Size = new System.Drawing.Size(97, 13);
            this.VolumeBarColorLabel.TabIndex = 7;
            this.VolumeBarColorLabel.Text = "Volume bar color:";
            this.VolumeBarColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VolumeBarGradientColorCheckBox
            // 
            this.VolumeBarGradientColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.VolumeBarGradientColorCheckBox.Checked = true;
            this.VolumeBarGradientColorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VolumeBarGradientColorCheckBox.Location = new System.Drawing.Point(151, 89);
            this.VolumeBarGradientColorCheckBox.Name = "VolumeBarGradientColorCheckBox";
            this.VolumeBarGradientColorCheckBox.Size = new System.Drawing.Size(70, 25);
            this.VolumeBarGradientColorCheckBox.TabIndex = 11;
            this.VolumeBarGradientColorCheckBox.Text = "Gradient";
            this.VolumeBarGradientColorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VolumeBarGradientColorCheckBox.UseVisualStyleBackColor = true;
            this.VolumeBarGradientColorCheckBox.Click += new System.EventHandler(this.SetVolumeBarGradientColor);
            // 
            // VolumeBarSolidColorCheckBox
            // 
            this.VolumeBarSolidColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.VolumeBarSolidColorCheckBox.Location = new System.Drawing.Point(227, 89);
            this.VolumeBarSolidColorCheckBox.Name = "VolumeBarSolidColorCheckBox";
            this.VolumeBarSolidColorCheckBox.Size = new System.Drawing.Size(63, 25);
            this.VolumeBarSolidColorCheckBox.TabIndex = 12;
            this.VolumeBarSolidColorCheckBox.Text = "Solid";
            this.VolumeBarSolidColorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VolumeBarSolidColorCheckBox.UseVisualStyleBackColor = true;
            this.VolumeBarSolidColorCheckBox.Click += new System.EventHandler(this.SetVolumeBarSolidColor);
            // 
            // VolumeBarOpacityLabel
            // 
            this.VolumeBarOpacityLabel.AutoSize = true;
            this.VolumeBarOpacityLabel.Location = new System.Drawing.Point(15, 165);
            this.VolumeBarOpacityLabel.Name = "VolumeBarOpacityLabel";
            this.VolumeBarOpacityLabel.Size = new System.Drawing.Size(108, 13);
            this.VolumeBarOpacityLabel.TabIndex = 11;
            this.VolumeBarOpacityLabel.Text = "Volume bar opacity:";
            this.VolumeBarOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeBarOpacityTrackBar
            // 
            this.VolumeBarOpacityTrackBar.AutoSize = false;
            this.VolumeBarOpacityTrackBar.Location = new System.Drawing.Point(144, 162);
            this.VolumeBarOpacityTrackBar.Maximum = 100;
            this.VolumeBarOpacityTrackBar.Name = "VolumeBarOpacityTrackBar";
            this.VolumeBarOpacityTrackBar.Size = new System.Drawing.Size(139, 25);
            this.VolumeBarOpacityTrackBar.TabIndex = 14;
            this.VolumeBarOpacityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBarOpacityTrackBar.Value = 100;
            this.VolumeBarOpacityTrackBar.ValueChanged += new System.EventHandler(this.VolumeBarOpacityChanged);
            // 
            // VolumeBarOpacityValueLabel
            // 
            this.VolumeBarOpacityValueLabel.AutoSize = true;
            this.VolumeBarOpacityValueLabel.Location = new System.Drawing.Point(289, 165);
            this.VolumeBarOpacityValueLabel.Name = "VolumeBarOpacityValueLabel";
            this.VolumeBarOpacityValueLabel.Size = new System.Drawing.Size(34, 13);
            this.VolumeBarOpacityValueLabel.TabIndex = 13;
            this.VolumeBarOpacityValueLabel.Text = "100%";
            this.VolumeBarOpacityValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleLabel
            // 
            this.FontStyleLabel.AutoSize = true;
            this.FontStyleLabel.Location = new System.Drawing.Point(15, 132);
            this.FontStyleLabel.Name = "FontStyleLabel";
            this.FontStyleLabel.Size = new System.Drawing.Size(115, 13);
            this.FontStyleLabel.TabIndex = 14;
            this.FontStyleLabel.Text = "Volume bar text font:";
            this.FontStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleButton
            // 
            this.FontStyleButton.Location = new System.Drawing.Point(151, 126);
            this.FontStyleButton.Name = "FontStyleButton";
            this.FontStyleButton.Size = new System.Drawing.Size(70, 25);
            this.FontStyleButton.TabIndex = 13;
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
            this.AppearanceGroupBox.Controls.Add(this.TextRenderingHintComboBox);
            this.AppearanceGroupBox.Controls.Add(this.label1);
            this.AppearanceGroupBox.Controls.Add(this.DisplayVolumeBarScrollingCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.TrayIconTextColorLabel);
            this.AppearanceGroupBox.Controls.Add(this.TrayIconTextColorPreviewPictureBox);
            this.AppearanceGroupBox.Controls.Add(this.TrayIconTextGradientColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.TrayIconTextSolidColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.DisplayTrayIconAsTextCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.FontPreviewLabel);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarPaddingPixelsLabel);
            this.AppearanceGroupBox.Controls.Add(this.SetVolumeBarPaddingLabel);
            this.AppearanceGroupBox.Controls.Add(this.FontStyleButton);
            this.AppearanceGroupBox.Controls.Add(this.FontStyleLabel);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarOpacityValueLabel);
            this.AppearanceGroupBox.Controls.Add(this.SetVolumeBarHeightNumericUpDown);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarOpacityLabel);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarColorLabel);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarColorPreviewPictureBox);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarGradientColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarSolidColorCheckBox);
            this.AppearanceGroupBox.Controls.Add(this.VolumeBarOpacityTrackBar);
            this.AppearanceGroupBox.Controls.Add(this.SetVolumeBarWidthNumericUpDown);
            this.AppearanceGroupBox.Location = new System.Drawing.Point(329, 9);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(340, 297);
            this.AppearanceGroupBox.TabIndex = 18;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Appearance";
            // 
            // TextRenderingHintComboBox
            // 
            this.TextRenderingHintComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TextRenderingHintComboBox.FormattingEnabled = true;
            this.TextRenderingHintComboBox.ItemHeight = 13;
            this.TextRenderingHintComboBox.Items.AddRange(new object[] {
            "System Default",
            "ClearType",
            "Anti-Alias",
            "Single Bit Per Pixel"});
            this.TextRenderingHintComboBox.Location = new System.Drawing.Point(151, 262);
            this.TextRenderingHintComboBox.Name = "TextRenderingHintComboBox";
            this.TextRenderingHintComboBox.Size = new System.Drawing.Size(172, 21);
            this.TextRenderingHintComboBox.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text rendering hint:";
            // 
            // DisplayVolumeBarScrollingCheckBox
            // 
            this.DisplayVolumeBarScrollingCheckBox.AutoSize = true;
            this.DisplayVolumeBarScrollingCheckBox.Checked = true;
            this.DisplayVolumeBarScrollingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayVolumeBarScrollingCheckBox.Location = new System.Drawing.Point(18, 27);
            this.DisplayVolumeBarScrollingCheckBox.Name = "DisplayVolumeBarScrollingCheckBox";
            this.DisplayVolumeBarScrollingCheckBox.Size = new System.Drawing.Size(290, 17);
            this.DisplayVolumeBarScrollingCheckBox.TabIndex = 8;
            this.DisplayVolumeBarScrollingCheckBox.Text = "Display volume bar while scrolling to adjust volume";
            this.DisplayVolumeBarScrollingCheckBox.UseVisualStyleBackColor = true;
            // 
            // TrayIconTextColorLabel
            // 
            this.TrayIconTextColorLabel.AutoSize = true;
            this.TrayIconTextColorLabel.Location = new System.Drawing.Point(15, 234);
            this.TrayIconTextColorLabel.Name = "TrayIconTextColorLabel";
            this.TrayIconTextColorLabel.Size = new System.Drawing.Size(106, 13);
            this.TrayIconTextColorLabel.TabIndex = 23;
            this.TrayIconTextColorLabel.Text = "Tray icon text color:";
            this.TrayIconTextColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrayIconTextColorPreviewPictureBox
            // 
            this.TrayIconTextColorPreviewPictureBox.BackColor = System.Drawing.Color.SkyBlue;
            this.TrayIconTextColorPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrayIconTextColorPreviewPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrayIconTextColorPreviewPictureBox.Enabled = false;
            this.TrayIconTextColorPreviewPictureBox.Location = new System.Drawing.Point(296, 228);
            this.TrayIconTextColorPreviewPictureBox.Name = "TrayIconTextColorPreviewPictureBox";
            this.TrayIconTextColorPreviewPictureBox.Size = new System.Drawing.Size(27, 23);
            this.TrayIconTextColorPreviewPictureBox.TabIndex = 26;
            this.TrayIconTextColorPreviewPictureBox.TabStop = false;
            this.TrayIconTextColorPreviewPictureBox.Click += new System.EventHandler(this.PickNotificationTextColor);
            // 
            // TrayIconTextGradientColorCheckBox
            // 
            this.TrayIconTextGradientColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.TrayIconTextGradientColorCheckBox.Checked = true;
            this.TrayIconTextGradientColorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TrayIconTextGradientColorCheckBox.Enabled = false;
            this.TrayIconTextGradientColorCheckBox.Location = new System.Drawing.Point(151, 227);
            this.TrayIconTextGradientColorCheckBox.Name = "TrayIconTextGradientColorCheckBox";
            this.TrayIconTextGradientColorCheckBox.Size = new System.Drawing.Size(70, 25);
            this.TrayIconTextGradientColorCheckBox.TabIndex = 16;
            this.TrayIconTextGradientColorCheckBox.Text = "Gradient";
            this.TrayIconTextGradientColorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TrayIconTextGradientColorCheckBox.UseVisualStyleBackColor = true;
            this.TrayIconTextGradientColorCheckBox.Click += new System.EventHandler(this.SetNotificationTextGradientColor);
            // 
            // TrayIconTextSolidColorCheckBox
            // 
            this.TrayIconTextSolidColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.TrayIconTextSolidColorCheckBox.Enabled = false;
            this.TrayIconTextSolidColorCheckBox.Location = new System.Drawing.Point(227, 227);
            this.TrayIconTextSolidColorCheckBox.Name = "TrayIconTextSolidColorCheckBox";
            this.TrayIconTextSolidColorCheckBox.Size = new System.Drawing.Size(63, 25);
            this.TrayIconTextSolidColorCheckBox.TabIndex = 17;
            this.TrayIconTextSolidColorCheckBox.Text = "Solid";
            this.TrayIconTextSolidColorCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TrayIconTextSolidColorCheckBox.UseVisualStyleBackColor = true;
            this.TrayIconTextSolidColorCheckBox.Click += new System.EventHandler(this.SetNotificationTextSolidColor);
            // 
            // DisplayTrayIconAsTextCheckBox
            // 
            this.DisplayTrayIconAsTextCheckBox.AutoSize = true;
            this.DisplayTrayIconAsTextCheckBox.Location = new System.Drawing.Point(18, 204);
            this.DisplayTrayIconAsTextCheckBox.Name = "DisplayTrayIconAsTextCheckBox";
            this.DisplayTrayIconAsTextCheckBox.Size = new System.Drawing.Size(269, 17);
            this.DisplayTrayIconAsTextCheckBox.TabIndex = 15;
            this.DisplayTrayIconAsTextCheckBox.Text = "Display tray icon as text instead of speaker icon";
            this.DisplayTrayIconAsTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // FontPreviewLabel
            // 
            this.FontPreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontPreviewLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.FontPreviewLabel.Location = new System.Drawing.Point(227, 127);
            this.FontPreviewLabel.Name = "FontPreviewLabel";
            this.FontPreviewLabel.Size = new System.Drawing.Size(96, 23);
            this.FontPreviewLabel.TabIndex = 17;
            this.FontPreviewLabel.Text = "Aa 50%";
            this.FontPreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeBarPaddingPixelsLabel
            // 
            this.VolumeBarPaddingPixelsLabel.AutoSize = true;
            this.VolumeBarPaddingPixelsLabel.Location = new System.Drawing.Point(293, 57);
            this.VolumeBarPaddingPixelsLabel.Name = "VolumeBarPaddingPixelsLabel";
            this.VolumeBarPaddingPixelsLabel.Size = new System.Drawing.Size(36, 13);
            this.VolumeBarPaddingPixelsLabel.TabIndex = 16;
            this.VolumeBarPaddingPixelsLabel.Text = "pixels";
            this.VolumeBarPaddingPixelsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeBarColorPreviewPictureBox
            // 
            this.VolumeBarColorPreviewPictureBox.BackColor = System.Drawing.Color.SkyBlue;
            this.VolumeBarColorPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VolumeBarColorPreviewPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeBarColorPreviewPictureBox.Location = new System.Drawing.Point(296, 90);
            this.VolumeBarColorPreviewPictureBox.Name = "VolumeBarColorPreviewPictureBox";
            this.VolumeBarColorPreviewPictureBox.Size = new System.Drawing.Size(27, 23);
            this.VolumeBarColorPreviewPictureBox.TabIndex = 10;
            this.VolumeBarColorPreviewPictureBox.TabStop = false;
            this.VolumeBarColorPreviewPictureBox.Click += new System.EventHandler(this.PickVolumeBarColor);
            // 
            // AutoRetryAdminCheckBox
            // 
            this.AutoRetryAdminCheckBox.AutoSize = true;
            this.AutoRetryAdminCheckBox.Location = new System.Drawing.Point(18, 285);
            this.AutoRetryAdminCheckBox.Name = "AutoRetryAdminCheckBox";
            this.AutoRetryAdminCheckBox.Size = new System.Drawing.Size(262, 17);
            this.AutoRetryAdminCheckBox.TabIndex = 6;
            this.AutoRetryAdminCheckBox.Text = "Request Administrator permissions on startup";
            this.AutoRetryAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // BehaviourGroupBox
            // 
            this.BehaviourGroupBox.Controls.Add(this.ManualPreciseVolumeCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.ReverseScrollingDirectionCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.EnableSwitchPlaybackDeviceOptionCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.EnableMuteUnmuteOptionCheckBox);
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
            this.BehaviourGroupBox.Size = new System.Drawing.Size(310, 355);
            this.BehaviourGroupBox.TabIndex = 19;
            this.BehaviourGroupBox.TabStop = false;
            this.BehaviourGroupBox.Text = "Behaviour";
            // 
            // ManualPreciseVolumeCheckBox
            // 
            this.ManualPreciseVolumeCheckBox.AutoSize = true;
            this.ManualPreciseVolumeCheckBox.Location = new System.Drawing.Point(18, 238);
            this.ManualPreciseVolumeCheckBox.Name = "ManualPreciseVolumeCheckBox";
            this.ManualPreciseVolumeCheckBox.Size = new System.Drawing.Size(256, 30);
            this.ManualPreciseVolumeCheckBox.TabIndex = 5;
            this.ManualPreciseVolumeCheckBox.Text = "Manually activate precise volume scroll mode\r\nwhen holding down the ALT key";
            this.ManualPreciseVolumeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReverseScrollingDirectionCheckBox
            // 
            this.ReverseScrollingDirectionCheckBox.AutoSize = true;
            this.ReverseScrollingDirectionCheckBox.Location = new System.Drawing.Point(18, 319);
            this.ReverseScrollingDirectionCheckBox.Name = "ReverseScrollingDirectionCheckBox";
            this.ReverseScrollingDirectionCheckBox.Size = new System.Drawing.Size(249, 17);
            this.ReverseScrollingDirectionCheckBox.TabIndex = 7;
            this.ReverseScrollingDirectionCheckBox.Text = "Reverse scrolling direction for scroll actions";
            this.ReverseScrollingDirectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableSwitchPlaybackDeviceOptionCheckBox
            // 
            this.EnableSwitchPlaybackDeviceOptionCheckBox.AutoSize = true;
            this.EnableSwitchPlaybackDeviceOptionCheckBox.Location = new System.Drawing.Point(18, 194);
            this.EnableSwitchPlaybackDeviceOptionCheckBox.Name = "EnableSwitchPlaybackDeviceOptionCheckBox";
            this.EnableSwitchPlaybackDeviceOptionCheckBox.Size = new System.Drawing.Size(277, 30);
            this.EnableSwitchPlaybackDeviceOptionCheckBox.TabIndex = 4;
            this.EnableSwitchPlaybackDeviceOptionCheckBox.Text = "Switch between available audio playback devices\r\nwhen holding down the SHIFT key";
            this.EnableSwitchPlaybackDeviceOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableMuteUnmuteOptionCheckBox
            // 
            this.EnableMuteUnmuteOptionCheckBox.AutoSize = true;
            this.EnableMuteUnmuteOptionCheckBox.Location = new System.Drawing.Point(18, 148);
            this.EnableMuteUnmuteOptionCheckBox.Name = "EnableMuteUnmuteOptionCheckBox";
            this.EnableMuteUnmuteOptionCheckBox.Size = new System.Drawing.Size(267, 30);
            this.EnableMuteUnmuteOptionCheckBox.TabIndex = 3;
            this.EnableMuteUnmuteOptionCheckBox.Text = "Mute and unmute active audio playback device\r\nwhen holding down the CTRL key";
            this.EnableMuteUnmuteOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // Percent2Label
            // 
            this.Percent2Label.AutoSize = true;
            this.Percent2Label.Location = new System.Drawing.Point(251, 63);
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
            this.MillisecondsLabel.Location = new System.Drawing.Point(253, 100);
            this.MillisecondsLabel.Name = "MillisecondsLabel";
            this.MillisecondsLabel.Size = new System.Drawing.Size(21, 13);
            this.MillisecondsLabel.TabIndex = 17;
            this.MillisecondsLabel.Text = "ms";
            this.MillisecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetVolumeStepLabel
            // 
            this.SetVolumeStepLabel.AutoSize = true;
            this.SetVolumeStepLabel.Location = new System.Drawing.Point(15, 27);
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
            this.SetVolumeStepNumericUpDown.TabIndex = 0;
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
            this.ThresholdLabel.Location = new System.Drawing.Point(15, 63);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(168, 13);
            this.ThresholdLabel.TabIndex = 19;
            this.ThresholdLabel.Text = "Precise volume scroll threshold:";
            this.ThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThresholdNumericUpDown
            // 
            this.ThresholdNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThresholdNumericUpDown.Location = new System.Drawing.Point(186, 61);
            this.ThresholdNumericUpDown.Name = "ThresholdNumericUpDown";
            this.ThresholdNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.ThresholdNumericUpDown.TabIndex = 1;
            this.ThresholdNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThresholdNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // AutoHideTimeOutNumericUpDown
            // 
            this.AutoHideTimeOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoHideTimeOutNumericUpDown.Location = new System.Drawing.Point(186, 96);
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
            this.AutoHideTimeOutNumericUpDown.TabIndex = 2;
            this.AutoHideTimeOutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AutoHideTimeOutNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // AutoHideTimeOutLabel
            // 
            this.AutoHideTimeOutLabel.AutoSize = true;
            this.AutoHideTimeOutLabel.Location = new System.Drawing.Point(15, 98);
            this.AutoHideTimeOutLabel.Name = "AutoHideTimeOutLabel";
            this.AutoHideTimeOutLabel.Size = new System.Drawing.Size(149, 13);
            this.AutoHideTimeOutLabel.TabIndex = 16;
            this.AutoHideTimeOutLabel.Text = "Auto-hide volume bar after:";
            this.AutoHideTimeOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestoreDefaultValuesButton
            // 
            this.RestoreDefaultValuesButton.Location = new System.Drawing.Point(328, 339);
            this.RestoreDefaultValuesButton.Name = "RestoreDefaultValuesButton";
            this.RestoreDefaultValuesButton.Size = new System.Drawing.Size(341, 25);
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
            this.ClientSize = new System.Drawing.Size(684, 376);
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
            this.Deactivate += new System.EventHandler(this.CloseOnDeactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmCloseWithoutSaving);
            this.Load += new System.EventHandler(this.LoadBarConfiguration);
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeBarWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeBarHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBarOpacityTrackBar)).EndInit();
            this.AppearanceGroupBox.ResumeLayout(false);
            this.AppearanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrayIconTextColorPreviewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBarColorPreviewPictureBox)).EndInit();
            this.BehaviourGroupBox.ResumeLayout(false);
            this.BehaviourGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplyConfigurationButton;
        private System.Windows.Forms.Label SetVolumeBarPaddingLabel;
        private System.Windows.Forms.NumericUpDown SetVolumeBarWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown SetVolumeBarHeightNumericUpDown;
        private System.Windows.Forms.Label VolumeBarColorLabel;
        private System.Windows.Forms.CheckBox VolumeBarGradientColorCheckBox;
        private System.Windows.Forms.CheckBox VolumeBarSolidColorCheckBox;
        private System.Windows.Forms.PictureBox VolumeBarColorPreviewPictureBox;
        private System.Windows.Forms.Label VolumeBarOpacityLabel;
        private System.Windows.Forms.TrackBar VolumeBarOpacityTrackBar;
        private System.Windows.Forms.Label VolumeBarOpacityValueLabel;
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
        private System.Windows.Forms.CheckBox EnableMuteUnmuteOptionCheckBox;
        private System.Windows.Forms.CheckBox EnableSwitchPlaybackDeviceOptionCheckBox;
        private System.Windows.Forms.Label FontPreviewLabel;
        private System.Windows.Forms.CheckBox ReverseScrollingDirectionCheckBox;
        private System.Windows.Forms.CheckBox ManualPreciseVolumeCheckBox;
        private System.Windows.Forms.Label VolumeBarPaddingPixelsLabel;
        private System.Windows.Forms.Label MillisecondsLabel;
        private System.Windows.Forms.NumericUpDown AutoHideTimeOutNumericUpDown;
        private System.Windows.Forms.Label AutoHideTimeOutLabel;
        private System.Windows.Forms.CheckBox DisplayTrayIconAsTextCheckBox;
        private System.Windows.Forms.Label TrayIconTextColorLabel;
        private System.Windows.Forms.PictureBox TrayIconTextColorPreviewPictureBox;
        private System.Windows.Forms.CheckBox TrayIconTextGradientColorCheckBox;
        private System.Windows.Forms.CheckBox TrayIconTextSolidColorCheckBox;
        private System.Windows.Forms.CheckBox DisplayVolumeBarScrollingCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TextRenderingHintComboBox;
    }
}