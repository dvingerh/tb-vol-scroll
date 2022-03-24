
namespace tb_vol_scroll.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolumeSliderControlForm));
            this.PeakMeterPanel = new System.Windows.Forms.Panel();
            this.PeakMeterPictureBox = new System.Windows.Forms.PictureBox();
            this.TruePeakMeterPictureBox = new System.Windows.Forms.PictureBox();
            this.AudioDeviceNameLabel = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeSliderTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.AudioDevicePictureBox = new System.Windows.Forms.PictureBox();
            this.PeakMeterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeakMeterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TruePeakMeterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PeakMeterPanel
            // 
            this.PeakMeterPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PeakMeterPanel.Controls.Add(this.PeakMeterPictureBox);
            this.PeakMeterPanel.Controls.Add(this.TruePeakMeterPictureBox);
            this.PeakMeterPanel.Location = new System.Drawing.Point(12, 79);
            this.PeakMeterPanel.Name = "PeakMeterPanel";
            this.PeakMeterPanel.Size = new System.Drawing.Size(300, 10);
            this.PeakMeterPanel.TabIndex = 12;
            this.PeakMeterPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PeakMeterPanel_Paint);
            // 
            // PeakMeterPictureBox
            // 
            this.PeakMeterPictureBox.BackColor = System.Drawing.Color.Lime;
            this.PeakMeterPictureBox.Location = new System.Drawing.Point(1, 1);
            this.PeakMeterPictureBox.Name = "PeakMeterPictureBox";
            this.PeakMeterPictureBox.Size = new System.Drawing.Size(0, 8);
            this.PeakMeterPictureBox.TabIndex = 7;
            this.PeakMeterPictureBox.TabStop = false;
            // 
            // TruePeakMeterPictureBox
            // 
            this.TruePeakMeterPictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TruePeakMeterPictureBox.Location = new System.Drawing.Point(1, 1);
            this.TruePeakMeterPictureBox.Name = "TruePeakMeterPictureBox";
            this.TruePeakMeterPictureBox.Size = new System.Drawing.Size(0, 8);
            this.TruePeakMeterPictureBox.TabIndex = 8;
            this.TruePeakMeterPictureBox.TabStop = false;
            // 
            // AudioDeviceNameLabel
            // 
            this.AudioDeviceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioDeviceNameLabel.AutoEllipsis = true;
            this.AudioDeviceNameLabel.Location = new System.Drawing.Point(41, 15);
            this.AudioDeviceNameLabel.Name = "AudioDeviceNameLabel";
            this.AudioDeviceNameLabel.Size = new System.Drawing.Size(213, 14);
            this.AudioDeviceNameLabel.TabIndex = 11;
            this.AudioDeviceNameLabel.Text = "Audio Device";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeTrackBar.Location = new System.Drawing.Point(5, 38);
            this.VolumeTrackBar.Maximum = 100;
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(315, 45);
            this.VolumeTrackBar.TabIndex = 10;
            this.VolumeTrackBar.TickFrequency = 2;
            this.VolumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.VolumeTrackBar.Scroll += new System.EventHandler(this.VolumeTrackBar_Scroll);
            this.VolumeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VolumeTrackBar_MouseUp);
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
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.AutoEllipsis = true;
            this.VolumeLabel.Location = new System.Drawing.Point(260, 15);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(52, 14);
            this.VolumeLabel.TabIndex = 14;
            this.VolumeLabel.Text = "Volume";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AudioDevicePictureBox
            // 
            this.AudioDevicePictureBox.Location = new System.Drawing.Point(11, 11);
            this.AudioDevicePictureBox.Name = "AudioDevicePictureBox";
            this.AudioDevicePictureBox.Size = new System.Drawing.Size(24, 24);
            this.AudioDevicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AudioDevicePictureBox.TabIndex = 13;
            this.AudioDevicePictureBox.TabStop = false;
            // 
            // VolumeSliderControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(325, 100);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.AudioDevicePictureBox);
            this.Controls.Add(this.PeakMeterPanel);
            this.Controls.Add(this.AudioDeviceNameLabel);
            this.Controls.Add(this.VolumeTrackBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VolumeSliderControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Volume Slider Control (tb-vol-scroll)";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.VolumeSliderControlForm_Activated);
            this.Deactivate += new System.EventHandler(this.VolumeSliderControlForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VolumeSliderControlForm_FormClosing);
            this.Shown += new System.EventHandler(this.VolumeSliderControlForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VolumeSliderControlForm_Paint);
            this.PeakMeterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PeakMeterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TruePeakMeterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioDevicePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PeakMeterPanel;
        private System.Windows.Forms.PictureBox PeakMeterPictureBox;
        private System.Windows.Forms.Label AudioDeviceNameLabel;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.ToolTip VolumeSliderTooltip;
        private System.Windows.Forms.PictureBox TruePeakMeterPictureBox;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.PictureBox AudioDevicePictureBox;
    }
}