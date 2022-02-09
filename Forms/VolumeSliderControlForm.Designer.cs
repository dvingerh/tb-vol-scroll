
namespace tbvolscroll.Forms
{
    partial class VolumeSliderControlForm
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
            this.components = new System.ComponentModel.Container();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.AudioDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.PeakMeterPanel = new System.Windows.Forms.Panel();
            this.PeakMeterPictureBox = new System.Windows.Forms.PictureBox();
            this.AudioDeviceNameLabel = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeSliderTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).BeginInit();
            this.PeakMeterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeakMeterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.Location = new System.Drawing.Point(271, 8);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(42, 16);
            this.VolumeLabel.TabIndex = 14;
            this.VolumeLabel.Text = "0%";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AudioDevicePictureBox
            // 
            this.AudioDevicePictureBox.Location = new System.Drawing.Point(3, 3);
            this.AudioDevicePictureBox.Name = "AudioDevicePictureBox";
            this.AudioDevicePictureBox.Size = new System.Drawing.Size(24, 24);
            this.AudioDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioDevicePictureBox.TabIndex = 13;
            this.AudioDevicePictureBox.TabStop = false;
            // 
            // PeakMeterPanel
            // 
            this.PeakMeterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeakMeterPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PeakMeterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PeakMeterPanel.Controls.Add(this.PeakMeterPictureBox);
            this.PeakMeterPanel.Controls.Add(this.pictureBox1);
            this.PeakMeterPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PeakMeterPanel.Location = new System.Drawing.Point(7, 66);
            this.PeakMeterPanel.Name = "PeakMeterPanel";
            this.PeakMeterPanel.Size = new System.Drawing.Size(305, 10);
            this.PeakMeterPanel.TabIndex = 12;
            // 
            // PeakMeterPictureBox
            // 
            this.PeakMeterPictureBox.BackColor = System.Drawing.Color.Lime;
            this.PeakMeterPictureBox.Location = new System.Drawing.Point(0, 0);
            this.PeakMeterPictureBox.Name = "PeakMeterPictureBox";
            this.PeakMeterPictureBox.Size = new System.Drawing.Size(0, 8);
            this.PeakMeterPictureBox.TabIndex = 7;
            this.PeakMeterPictureBox.TabStop = false;
            // 
            // AudioDeviceNameLabel
            // 
            this.AudioDeviceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioDeviceNameLabel.AutoEllipsis = true;
            this.AudioDeviceNameLabel.Location = new System.Drawing.Point(29, 8);
            this.AudioDeviceNameLabel.Name = "AudioDeviceNameLabel";
            this.AudioDeviceNameLabel.Size = new System.Drawing.Size(233, 16);
            this.AudioDeviceNameLabel.TabIndex = 11;
            this.AudioDeviceNameLabel.Text = "Audio Device";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeTrackBar.Location = new System.Drawing.Point(5, 31);
            this.VolumeTrackBar.Maximum = 100;
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(315, 45);
            this.VolumeTrackBar.TabIndex = 10;
            this.VolumeTrackBar.TickFrequency = 2;
            this.VolumeTrackBar.Scroll += new System.EventHandler(this.UpdateVolumeFromTrackBar);
            this.VolumeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlaySound);
            // 
            // VolumeSliderTooltip
            // 
            this.VolumeSliderTooltip.AutomaticDelay = 0;
            this.VolumeSliderTooltip.AutoPopDelay = 0;
            this.VolumeSliderTooltip.InitialDelay = 0;
            this.VolumeSliderTooltip.ReshowDelay = 100;
            this.VolumeSliderTooltip.UseAnimation = false;
            this.VolumeSliderTooltip.UseFading = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 8);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // VolumeSliderControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(325, 85);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.AudioDevicePictureBox);
            this.Controls.Add(this.PeakMeterPanel);
            this.Controls.Add(this.AudioDeviceNameLabel);
            this.Controls.Add(this.VolumeTrackBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VolumeSliderControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.AvoidControlFocus);
            this.Deactivate += new System.EventHandler(this.CloseFormOnDeactivate);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawVolumeSliderBorder);
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).EndInit();
            this.PeakMeterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PeakMeterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.PictureBox AudioDevicePictureBox;
        private System.Windows.Forms.Panel PeakMeterPanel;
        private System.Windows.Forms.PictureBox PeakMeterPictureBox;
        private System.Windows.Forms.Label AudioDeviceNameLabel;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.ToolTip VolumeSliderTooltip;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}