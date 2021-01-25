namespace tbvolscroll
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.SaveVolumeBarAppearanceButton = new System.Windows.Forms.Button();
            this.SetBarDimensionsLabel = new System.Windows.Forms.Label();
            this.SetBarWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DimensionXLabel = new System.Windows.Forms.Label();
            this.SetBarHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BarColorLabel = new System.Windows.Forms.Label();
            this.GradientCheckBox = new System.Windows.Forms.CheckBox();
            this.CustomColorCheckBox = new System.Windows.Forms.CheckBox();
            this.ColorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.BarOpacityLabel = new System.Windows.Forms.Label();
            this.BarOpacityTrackBar = new System.Windows.Forms.TrackBar();
            this.OpacityValueLabel = new System.Windows.Forms.Label();
            this.FontStyleLabel = new System.Windows.Forms.Label();
            this.FontStyleButton = new System.Windows.Forms.Button();
            this.CustomFontDialog = new System.Windows.Forms.FontDialog();
            this.AutoHideTimeOutLabel = new System.Windows.Forms.Label();
            this.AutoHideTimeOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.BehaviourGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoRetryAdminCheckBox = new System.Windows.Forms.CheckBox();
            this.SetVolumeStepLabel = new System.Windows.Forms.Label();
            this.SetVolumeStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RestoreDefaultValuesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreviewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOpacityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).BeginInit();
            this.AppearanceGroupBox.SuspendLayout();
            this.BehaviourGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveVolumeBarAppearanceButton
            // 
            this.SaveVolumeBarAppearanceButton.Location = new System.Drawing.Point(372, 450);
            this.SaveVolumeBarAppearanceButton.Name = "SaveVolumeBarAppearanceButton";
            this.SaveVolumeBarAppearanceButton.Size = new System.Drawing.Size(350, 24);
            this.SaveVolumeBarAppearanceButton.TabIndex = 3;
            this.SaveVolumeBarAppearanceButton.Text = "Save and exit";
            this.SaveVolumeBarAppearanceButton.UseVisualStyleBackColor = true;
            this.SaveVolumeBarAppearanceButton.Click += new System.EventHandler(this.SaveBarAppearance);
            // 
            // SetBarDimensionsLabel
            // 
            this.SetBarDimensionsLabel.AutoSize = true;
            this.SetBarDimensionsLabel.Location = new System.Drawing.Point(14, 39);
            this.SetBarDimensionsLabel.Name = "SetBarDimensionsLabel";
            this.SetBarDimensionsLabel.Size = new System.Drawing.Size(327, 39);
            this.SetBarDimensionsLabel.TabIndex = 4;
            this.SetBarDimensionsLabel.Text = "Change the width and height for the volume bar.\r\nDuring runtime, the volume perce" +
    "ntage is added to the width.\r\nDefault value is 30 x 15 pixels.\r\n";
            this.SetBarDimensionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetBarWidthNumericUpDown
            // 
            this.SetBarWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetBarWidthNumericUpDown.Location = new System.Drawing.Point(120, 88);
            this.SetBarWidthNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SetBarWidthNumericUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.SetBarWidthNumericUpDown.Name = "SetBarWidthNumericUpDown";
            this.SetBarWidthNumericUpDown.Size = new System.Drawing.Size(49, 22);
            this.SetBarWidthNumericUpDown.TabIndex = 1;
            this.SetBarWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetBarWidthNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // DimensionXLabel
            // 
            this.DimensionXLabel.AutoSize = true;
            this.DimensionXLabel.Location = new System.Drawing.Point(171, 92);
            this.DimensionXLabel.Name = "DimensionXLabel";
            this.DimensionXLabel.Size = new System.Drawing.Size(12, 13);
            this.DimensionXLabel.TabIndex = 6;
            this.DimensionXLabel.Text = "x";
            this.DimensionXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetBarHeightNumericUpDown
            // 
            this.SetBarHeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetBarHeightNumericUpDown.Location = new System.Drawing.Point(185, 88);
            this.SetBarHeightNumericUpDown.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.SetBarHeightNumericUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.SetBarHeightNumericUpDown.Name = "SetBarHeightNumericUpDown";
            this.SetBarHeightNumericUpDown.Size = new System.Drawing.Size(49, 22);
            this.SetBarHeightNumericUpDown.TabIndex = 2;
            this.SetBarHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetBarHeightNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // BarColorLabel
            // 
            this.BarColorLabel.AutoSize = true;
            this.BarColorLabel.Location = new System.Drawing.Point(40, 139);
            this.BarColorLabel.Name = "BarColorLabel";
            this.BarColorLabel.Size = new System.Drawing.Size(274, 26);
            this.BarColorLabel.TabIndex = 7;
            this.BarColorLabel.Text = "Set the color for the volume bar.\r\nUse the default gradient mode or choose your o" +
    "wn.";
            this.BarColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GradientCheckBox
            // 
            this.GradientCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.GradientCheckBox.AutoSize = true;
            this.GradientCheckBox.Checked = true;
            this.GradientCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GradientCheckBox.Location = new System.Drawing.Point(93, 173);
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
            this.CustomColorCheckBox.Location = new System.Drawing.Point(161, 173);
            this.CustomColorCheckBox.Name = "CustomColorCheckBox";
            this.CustomColorCheckBox.Size = new System.Drawing.Size(71, 23);
            this.CustomColorCheckBox.TabIndex = 9;
            this.CustomColorCheckBox.Text = "Custom ->";
            this.CustomColorCheckBox.UseVisualStyleBackColor = true;
            this.CustomColorCheckBox.Click += new System.EventHandler(this.SetCustomColor);
            // 
            // ColorPreviewPictureBox
            // 
            this.ColorPreviewPictureBox.BackColor = System.Drawing.Color.DodgerBlue;
            this.ColorPreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPreviewPictureBox.Location = new System.Drawing.Point(238, 173);
            this.ColorPreviewPictureBox.Name = "ColorPreviewPictureBox";
            this.ColorPreviewPictureBox.Size = new System.Drawing.Size(23, 23);
            this.ColorPreviewPictureBox.TabIndex = 10;
            this.ColorPreviewPictureBox.TabStop = false;
            // 
            // BarOpacityLabel
            // 
            this.BarOpacityLabel.AutoSize = true;
            this.BarOpacityLabel.Location = new System.Drawing.Point(104, 322);
            this.BarOpacityLabel.Name = "BarOpacityLabel";
            this.BarOpacityLabel.Size = new System.Drawing.Size(146, 26);
            this.BarOpacityLabel.TabIndex = 11;
            this.BarOpacityLabel.Text = "Set the volume bar opacity.\r\nDefault value is 100%.";
            this.BarOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarOpacityTrackBar
            // 
            this.BarOpacityTrackBar.Location = new System.Drawing.Point(77, 348);
            this.BarOpacityTrackBar.Maximum = 100;
            this.BarOpacityTrackBar.Name = "BarOpacityTrackBar";
            this.BarOpacityTrackBar.Size = new System.Drawing.Size(200, 45);
            this.BarOpacityTrackBar.TabIndex = 12;
            this.BarOpacityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BarOpacityTrackBar.Value = 100;
            this.BarOpacityTrackBar.ValueChanged += new System.EventHandler(this.BarOpacityChanged);
            // 
            // OpacityValueLabel
            // 
            this.OpacityValueLabel.AutoSize = true;
            this.OpacityValueLabel.Location = new System.Drawing.Point(123, 370);
            this.OpacityValueLabel.Name = "OpacityValueLabel";
            this.OpacityValueLabel.Size = new System.Drawing.Size(109, 13);
            this.OpacityValueLabel.TabIndex = 13;
            this.OpacityValueLabel.Text = "Current value: 100%";
            this.OpacityValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleLabel
            // 
            this.FontStyleLabel.AutoSize = true;
            this.FontStyleLabel.Location = new System.Drawing.Point(5, 226);
            this.FontStyleLabel.Name = "FontStyleLabel";
            this.FontStyleLabel.Size = new System.Drawing.Size(344, 39);
            this.FontStyleLabel.TabIndex = 14;
            this.FontStyleLabel.Text = "Set the font size and style for the volume bar.\r\nDefault style is Segoe UI Semibo" +
    "ld at 8px.\r\nNote: volume bar height does not scale to font size automatically.";
            this.FontStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontStyleButton
            // 
            this.FontStyleButton.Location = new System.Drawing.Point(133, 273);
            this.FontStyleButton.Name = "FontStyleButton";
            this.FontStyleButton.Size = new System.Drawing.Size(88, 23);
            this.FontStyleButton.TabIndex = 15;
            this.FontStyleButton.Text = "Set font style";
            this.FontStyleButton.UseVisualStyleBackColor = true;
            this.FontStyleButton.Click += new System.EventHandler(this.SetFontStyle);
            // 
            // CustomFontDialog
            // 
            this.CustomFontDialog.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomFontDialog.FontMustExist = true;
            // 
            // AutoHideTimeOutLabel
            // 
            this.AutoHideTimeOutLabel.AutoSize = true;
            this.AutoHideTimeOutLabel.Location = new System.Drawing.Point(17, 28);
            this.AutoHideTimeOutLabel.Name = "AutoHideTimeOutLabel";
            this.AutoHideTimeOutLabel.Size = new System.Drawing.Size(316, 26);
            this.AutoHideTimeOutLabel.TabIndex = 16;
            this.AutoHideTimeOutLabel.Text = "Set the autohide timeout for the volume bar in milliseconds.\r\nDefault value is 10" +
    "00.";
            this.AutoHideTimeOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoHideTimeOutNumericUpDown
            // 
            this.AutoHideTimeOutNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoHideTimeOutNumericUpDown.Location = new System.Drawing.Point(146, 63);
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
            this.AppearanceGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(350, 432);
            this.AppearanceGroupBox.TabIndex = 18;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Appearance";
            // 
            // BehaviourGroupBox
            // 
            this.BehaviourGroupBox.Controls.Add(this.AutoRetryAdminCheckBox);
            this.BehaviourGroupBox.Controls.Add(this.SetVolumeStepLabel);
            this.BehaviourGroupBox.Controls.Add(this.SetVolumeStepNumericUpDown);
            this.BehaviourGroupBox.Controls.Add(this.ThresholdLabel);
            this.BehaviourGroupBox.Controls.Add(this.ThresholdNumericUpDown);
            this.BehaviourGroupBox.Controls.Add(this.AutoHideTimeOutNumericUpDown);
            this.BehaviourGroupBox.Controls.Add(this.AutoHideTimeOutLabel);
            this.BehaviourGroupBox.Location = new System.Drawing.Point(372, 12);
            this.BehaviourGroupBox.Name = "BehaviourGroupBox";
            this.BehaviourGroupBox.Size = new System.Drawing.Size(350, 432);
            this.BehaviourGroupBox.TabIndex = 19;
            this.BehaviourGroupBox.TabStop = false;
            this.BehaviourGroupBox.Text = "Behaviour";
            // 
            // AutoRetryAdminCheckBox
            // 
            this.AutoRetryAdminCheckBox.AutoSize = true;
            this.AutoRetryAdminCheckBox.Location = new System.Drawing.Point(51, 348);
            this.AutoRetryAdminCheckBox.Name = "AutoRetryAdminCheckBox";
            this.AutoRetryAdminCheckBox.Size = new System.Drawing.Size(248, 30);
            this.AutoRetryAdminCheckBox.TabIndex = 22;
            this.AutoRetryAdminCheckBox.Text = "Automatically try to restart as Administrator\r\non initial launch.";
            this.AutoRetryAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // SetVolumeStepLabel
            // 
            this.SetVolumeStepLabel.AutoSize = true;
            this.SetVolumeStepLabel.Location = new System.Drawing.Point(79, 139);
            this.SetVolumeStepLabel.Name = "SetVolumeStepLabel";
            this.SetVolumeStepLabel.Size = new System.Drawing.Size(193, 26);
            this.SetVolumeStepLabel.TabIndex = 21;
            this.SetVolumeStepLabel.Text = "Change the volume step percentage\r\nfor each scroll. Default value is 5.";
            this.SetVolumeStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetVolumeStepNumericUpDown
            // 
            this.SetVolumeStepNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetVolumeStepNumericUpDown.Location = new System.Drawing.Point(151, 177);
            this.SetVolumeStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SetVolumeStepNumericUpDown.Name = "SetVolumeStepNumericUpDown";
            this.SetVolumeStepNumericUpDown.Size = new System.Drawing.Size(49, 22);
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
            this.ThresholdLabel.Location = new System.Drawing.Point(70, 232);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(210, 26);
            this.ThresholdLabel.TabIndex = 19;
            this.ThresholdLabel.Text = "Change the threshold for when precise\r\nscrolling is enabled. Default value is 10." +
    "";
            this.ThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThresholdNumericUpDown
            // 
            this.ThresholdNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThresholdNumericUpDown.Location = new System.Drawing.Point(151, 270);
            this.ThresholdNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThresholdNumericUpDown.Name = "ThresholdNumericUpDown";
            this.ThresholdNumericUpDown.Size = new System.Drawing.Size(49, 22);
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
            this.RestoreDefaultValuesButton.Location = new System.Drawing.Point(12, 450);
            this.RestoreDefaultValuesButton.Name = "RestoreDefaultValuesButton";
            this.RestoreDefaultValuesButton.Size = new System.Drawing.Size(350, 23);
            this.RestoreDefaultValuesButton.TabIndex = 20;
            this.RestoreDefaultValuesButton.Text = "Restore default values";
            this.RestoreDefaultValuesButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultValuesButton.Click += new System.EventHandler(this.RestoreDefaultValues);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 486);
            this.Controls.Add(this.RestoreDefaultValuesButton);
            this.Controls.Add(this.SaveVolumeBarAppearanceButton);
            this.Controls.Add(this.AppearanceGroupBox);
            this.Controls.Add(this.BehaviourGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.LoadBarAppearance);
            ((System.ComponentModel.ISupportInitialize)(this.SetBarWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetBarHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPreviewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarOpacityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoHideTimeOutNumericUpDown)).EndInit();
            this.AppearanceGroupBox.ResumeLayout(false);
            this.AppearanceGroupBox.PerformLayout();
            this.BehaviourGroupBox.ResumeLayout(false);
            this.BehaviourGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveVolumeBarAppearanceButton;
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
    }
}