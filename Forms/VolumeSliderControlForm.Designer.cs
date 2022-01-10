
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
            this.BorderPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PeakMeterPanel = new System.Windows.Forms.Panel();
            this.PeakMeterPictureBox = new System.Windows.Forms.PictureBox();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.AudioDeviceNameLabel = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new tbvolscroll.Classes.TrackBarNoFocus();
            this.BorderPanel.SuspendLayout();
            this.PeakMeterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PeakMeterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderPanel
            // 
            this.BorderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.BorderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderPanel.Controls.Add(this.CloseButton);
            this.BorderPanel.Controls.Add(this.PeakMeterPanel);
            this.BorderPanel.Controls.Add(this.VolumeLabel);
            this.BorderPanel.Controls.Add(this.AudioDeviceNameLabel);
            this.BorderPanel.Controls.Add(this.VolumeTrackBar);
            this.BorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorderPanel.Location = new System.Drawing.Point(0, 0);
            this.BorderPanel.Name = "BorderPanel";
            this.BorderPanel.Size = new System.Drawing.Size(350, 78);
            this.BorderPanel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Location = new System.Drawing.Point(320, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 20);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseFormOnDeactivate);
            // 
            // PeakMeterPanel
            // 
            this.PeakMeterPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PeakMeterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PeakMeterPanel.Controls.Add(this.PeakMeterPictureBox);
            this.PeakMeterPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeakMeterPanel.Location = new System.Drawing.Point(6, 57);
            this.PeakMeterPanel.Name = "PeakMeterPanel";
            this.PeakMeterPanel.Size = new System.Drawing.Size(285, 10);
            this.PeakMeterPanel.TabIndex = 6;
            // 
            // PeakMeterPictureBox
            // 
            this.PeakMeterPictureBox.BackColor = System.Drawing.Color.Lime;
            this.PeakMeterPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.PeakMeterPictureBox.Location = new System.Drawing.Point(0, 0);
            this.PeakMeterPictureBox.Name = "PeakMeterPictureBox";
            this.PeakMeterPictureBox.Size = new System.Drawing.Size(0, 8);
            this.PeakMeterPictureBox.TabIndex = 7;
            this.PeakMeterPictureBox.TabStop = false;
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.Location = new System.Drawing.Point(304, 28);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(41, 28);
            this.VolumeLabel.TabIndex = 2;
            this.VolumeLabel.Text = "0%";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioDeviceNameLabel
            // 
            this.AudioDeviceNameLabel.Location = new System.Drawing.Point(3, 3);
            this.AudioDeviceNameLabel.Name = "AudioDeviceNameLabel";
            this.AudioDeviceNameLabel.Size = new System.Drawing.Size(292, 16);
            this.AudioDeviceNameLabel.TabIndex = 4;
            this.AudioDeviceNameLabel.Text = "Audio Device";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Location = new System.Drawing.Point(-2, 22);
            this.VolumeTrackBar.Maximum = 100;
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(300, 45);
            this.VolumeTrackBar.TabIndex = 3;
            this.VolumeTrackBar.TickFrequency = 4;
            this.VolumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.VolumeTrackBar.Scroll += new System.EventHandler(this.UpdateVolumeFromTrackBar);
            // 
            // VolumeSliderControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(350, 78);
            this.Controls.Add(this.BorderPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VolumeSliderControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tb-vol-scroll";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.CloseFormOnDeactivate);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.BorderPanel.ResumeLayout(false);
            this.BorderPanel.PerformLayout();
            this.PeakMeterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PeakMeterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderPanel;
        private System.Windows.Forms.Label VolumeLabel;
        private Classes.TrackBarNoFocus VolumeTrackBar;
        private System.Windows.Forms.Label AudioDeviceNameLabel;
        private System.Windows.Forms.Panel PeakMeterPanel;
        private System.Windows.Forms.PictureBox PeakMeterPictureBox;
        private System.Windows.Forms.Button CloseButton;
    }
}