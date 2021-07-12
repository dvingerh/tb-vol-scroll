
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
            this.PeakMeterProgressBar = new System.Windows.Forms.ProgressBar();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.AudioDeviceLabel = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new tbvolscroll.Classes.TrackBarNoFocus();
            this.BorderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderPanel
            // 
            this.BorderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.BorderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderPanel.Controls.Add(this.PeakMeterProgressBar);
            this.BorderPanel.Controls.Add(this.VolumeLabel);
            this.BorderPanel.Controls.Add(this.AudioDeviceLabel);
            this.BorderPanel.Controls.Add(this.VolumeTrackBar);
            this.BorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorderPanel.Location = new System.Drawing.Point(0, 0);
            this.BorderPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BorderPanel.Name = "BorderPanel";
            this.BorderPanel.Size = new System.Drawing.Size(375, 112);
            this.BorderPanel.TabIndex = 0;
            // 
            // VuMeterProgressBar
            // 
            this.PeakMeterProgressBar.Location = new System.Drawing.Point(8, 85);
            this.PeakMeterProgressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PeakMeterProgressBar.Name = "VuMeterProgressBar";
            this.PeakMeterProgressBar.Size = new System.Drawing.Size(296, 12);
            this.PeakMeterProgressBar.Step = 1;
            this.PeakMeterProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PeakMeterProgressBar.TabIndex = 5;
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.Location = new System.Drawing.Point(326, 21);
            this.VolumeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(44, 56);
            this.VolumeLabel.TabIndex = 2;
            this.VolumeLabel.Text = "0%";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AudioDeviceLabel
            // 
            this.AudioDeviceLabel.Location = new System.Drawing.Point(4, 4);
            this.AudioDeviceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AudioDeviceLabel.Name = "AudioDeviceLabel";
            this.AudioDeviceLabel.Size = new System.Drawing.Size(365, 16);
            this.AudioDeviceLabel.TabIndex = 4;
            this.AudioDeviceLabel.Text = "Audio Device";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Location = new System.Drawing.Point(-2, 24);
            this.VolumeTrackBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VolumeTrackBar.Maximum = 100;
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(320, 56);
            this.VolumeTrackBar.TabIndex = 3;
            this.VolumeTrackBar.TickFrequency = 5;
            this.VolumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.VolumeTrackBar.ValueChanged += new System.EventHandler(this.UpdateVolume);
            // 
            // VolumeSliderPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(375, 112);
            this.Controls.Add(this.BorderPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VolumeSliderPopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tb-vol-scroll";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.CloseFormOnDeacivate);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.BorderPanel.ResumeLayout(false);
            this.BorderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderPanel;
        private System.Windows.Forms.Label VolumeLabel;
        private Classes.TrackBarNoFocus VolumeTrackBar;
        private System.Windows.Forms.Label AudioDeviceLabel;
        private System.Windows.Forms.ProgressBar PeakMeterProgressBar;
    }
}