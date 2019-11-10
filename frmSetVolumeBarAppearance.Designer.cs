namespace TbVolScroll
{
    partial class frmSetBarAppearance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetBarAppearance));
            this.btnSaveVolumeBarAppearance = new System.Windows.Forms.Button();
            this.lblSetBarDimensions = new System.Windows.Forms.Label();
            this.numSetBarWidth = new System.Windows.Forms.NumericUpDown();
            this.lblDimensionX = new System.Windows.Forms.Label();
            this.numSetBarHeight = new System.Windows.Forms.NumericUpDown();
            this.lblBarColor = new System.Windows.Forms.Label();
            this.chkGradient = new System.Windows.Forms.CheckBox();
            this.chkSetCustomColor = new System.Windows.Forms.CheckBox();
            this.picColorPreview = new System.Windows.Forms.PictureBox();
            this.lblBarOpacity = new System.Windows.Forms.Label();
            this.tbBarOpacity = new System.Windows.Forms.TrackBar();
            this.lblOpacityValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSetBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetBarHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColorPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveVolumeBarAppearance
            // 
            this.btnSaveVolumeBarAppearance.Location = new System.Drawing.Point(130, 276);
            this.btnSaveVolumeBarAppearance.Name = "btnSaveVolumeBarAppearance";
            this.btnSaveVolumeBarAppearance.Size = new System.Drawing.Size(75, 23);
            this.btnSaveVolumeBarAppearance.TabIndex = 3;
            this.btnSaveVolumeBarAppearance.Text = "Save";
            this.btnSaveVolumeBarAppearance.UseVisualStyleBackColor = true;
            this.btnSaveVolumeBarAppearance.Click += new System.EventHandler(this.SaveBarAppearance);
            // 
            // lblSetBarDimensions
            // 
            this.lblSetBarDimensions.AutoSize = true;
            this.lblSetBarDimensions.Location = new System.Drawing.Point(4, 8);
            this.lblSetBarDimensions.Name = "lblSetBarDimensions";
            this.lblSetBarDimensions.Size = new System.Drawing.Size(327, 39);
            this.lblSetBarDimensions.TabIndex = 4;
            this.lblSetBarDimensions.Text = "Change the width and height for the volume bar.\r\nDuring runtime, the volume perce" +
    "ntage is added to the width.\r\nDefault value is 30 x 15 pixels.\r\n";
            this.lblSetBarDimensions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSetBarWidth
            // 
            this.numSetBarWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSetBarWidth.Location = new System.Drawing.Point(110, 57);
            this.numSetBarWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSetBarWidth.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numSetBarWidth.Name = "numSetBarWidth";
            this.numSetBarWidth.Size = new System.Drawing.Size(49, 22);
            this.numSetBarWidth.TabIndex = 1;
            this.numSetBarWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSetBarWidth.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblDimensionX
            // 
            this.lblDimensionX.AutoSize = true;
            this.lblDimensionX.Location = new System.Drawing.Point(161, 61);
            this.lblDimensionX.Name = "lblDimensionX";
            this.lblDimensionX.Size = new System.Drawing.Size(12, 13);
            this.lblDimensionX.TabIndex = 6;
            this.lblDimensionX.Text = "x";
            this.lblDimensionX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSetBarHeight
            // 
            this.numSetBarHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSetBarHeight.Location = new System.Drawing.Point(175, 57);
            this.numSetBarHeight.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numSetBarHeight.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numSetBarHeight.Name = "numSetBarHeight";
            this.numSetBarHeight.Size = new System.Drawing.Size(49, 22);
            this.numSetBarHeight.TabIndex = 2;
            this.numSetBarHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSetBarHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblBarColor
            // 
            this.lblBarColor.AutoSize = true;
            this.lblBarColor.Location = new System.Drawing.Point(30, 108);
            this.lblBarColor.Name = "lblBarColor";
            this.lblBarColor.Size = new System.Drawing.Size(274, 26);
            this.lblBarColor.TabIndex = 7;
            this.lblBarColor.Text = "Set the color for the volume bar.\r\nUse the default gradient mode or choose your o" +
    "wn.";
            this.lblBarColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkGradient
            // 
            this.chkGradient.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGradient.AutoSize = true;
            this.chkGradient.Checked = true;
            this.chkGradient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGradient.Location = new System.Drawing.Point(83, 142);
            this.chkGradient.Name = "chkGradient";
            this.chkGradient.Size = new System.Drawing.Size(62, 23);
            this.chkGradient.TabIndex = 8;
            this.chkGradient.Text = "Gradient";
            this.chkGradient.UseVisualStyleBackColor = true;
            this.chkGradient.Click += new System.EventHandler(this.SetGradient);
            // 
            // chkSetCustomColor
            // 
            this.chkSetCustomColor.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSetCustomColor.AutoSize = true;
            this.chkSetCustomColor.Location = new System.Drawing.Point(151, 142);
            this.chkSetCustomColor.Name = "chkSetCustomColor";
            this.chkSetCustomColor.Size = new System.Drawing.Size(71, 23);
            this.chkSetCustomColor.TabIndex = 9;
            this.chkSetCustomColor.Text = "Custom ->";
            this.chkSetCustomColor.UseVisualStyleBackColor = true;
            this.chkSetCustomColor.Click += new System.EventHandler(this.SetCustomColor);
            // 
            // picColorPreview
            // 
            this.picColorPreview.BackColor = System.Drawing.Color.DodgerBlue;
            this.picColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColorPreview.Location = new System.Drawing.Point(228, 142);
            this.picColorPreview.Name = "picColorPreview";
            this.picColorPreview.Size = new System.Drawing.Size(23, 23);
            this.picColorPreview.TabIndex = 10;
            this.picColorPreview.TabStop = false;
            // 
            // lblBarOpacity
            // 
            this.lblBarOpacity.AutoSize = true;
            this.lblBarOpacity.Location = new System.Drawing.Point(94, 191);
            this.lblBarOpacity.Name = "lblBarOpacity";
            this.lblBarOpacity.Size = new System.Drawing.Size(146, 26);
            this.lblBarOpacity.TabIndex = 11;
            this.lblBarOpacity.Text = "Set the volume bar opacity.\r\nDefault value is 100%.";
            this.lblBarOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbBarOpacity
            // 
            this.tbBarOpacity.Location = new System.Drawing.Point(67, 217);
            this.tbBarOpacity.Maximum = 100;
            this.tbBarOpacity.Name = "tbBarOpacity";
            this.tbBarOpacity.Size = new System.Drawing.Size(200, 45);
            this.tbBarOpacity.TabIndex = 12;
            this.tbBarOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBarOpacity.Value = 100;
            this.tbBarOpacity.ValueChanged += new System.EventHandler(this.BarOpacityChanged);
            // 
            // lblOpacityValue
            // 
            this.lblOpacityValue.Location = new System.Drawing.Point(94, 238);
            this.lblOpacityValue.Name = "lblOpacityValue";
            this.lblOpacityValue.Size = new System.Drawing.Size(146, 20);
            this.lblOpacityValue.TabIndex = 13;
            this.lblOpacityValue.Text = "Current value: 100%";
            this.lblOpacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSetBarAppearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.lblOpacityValue);
            this.Controls.Add(this.lblBarOpacity);
            this.Controls.Add(this.picColorPreview);
            this.Controls.Add(this.chkSetCustomColor);
            this.Controls.Add(this.chkGradient);
            this.Controls.Add(this.lblBarColor);
            this.Controls.Add(this.numSetBarHeight);
            this.Controls.Add(this.lblDimensionX);
            this.Controls.Add(this.btnSaveVolumeBarAppearance);
            this.Controls.Add(this.lblSetBarDimensions);
            this.Controls.Add(this.numSetBarWidth);
            this.Controls.Add(this.tbBarOpacity);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetBarAppearance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Volume Bar Appearance";
            this.Load += new System.EventHandler(this.LoadBarAppearance);
            ((System.ComponentModel.ISupportInitialize)(this.numSetBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetBarHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColorPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBarOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveVolumeBarAppearance;
        private System.Windows.Forms.Label lblSetBarDimensions;
        private System.Windows.Forms.NumericUpDown numSetBarWidth;
        private System.Windows.Forms.Label lblDimensionX;
        private System.Windows.Forms.NumericUpDown numSetBarHeight;
        private System.Windows.Forms.Label lblBarColor;
        private System.Windows.Forms.CheckBox chkGradient;
        private System.Windows.Forms.CheckBox chkSetCustomColor;
        private System.Windows.Forms.PictureBox picColorPreview;
        private System.Windows.Forms.Label lblBarOpacity;
        private System.Windows.Forms.TrackBar tbBarOpacity;
        private System.Windows.Forms.Label lblOpacityValue;
    }
}