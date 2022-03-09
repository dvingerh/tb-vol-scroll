
namespace tb_vol_scroll
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TitleLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AudioPlaybackDevicesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemVolumeMixerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeSliderControlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeperatorMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenCurrentDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenStartupDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.RestartNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartAdministratorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarTextLabel = new System.Windows.Forms.Label();
            this.TrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabelMenuItem
            // 
            this.TitleLabelMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLabelMenuItem.Name = "TitleLabelMenuItem";
            this.TitleLabelMenuItem.Size = new System.Drawing.Size(199, 22);
            this.TitleLabelMenuItem.Text = "tb-vol-scroll";
            // 
            // SeparatorMenuItem1
            // 
            this.SeparatorMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.SeparatorMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SeparatorMenuItem1.Name = "SeparatorMenuItem1";
            this.SeparatorMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // AudioPlaybackDevicesMenuItem
            // 
            this.AudioPlaybackDevicesMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.AudioPlaybackDevicesMenuItem.Enabled = false;
            this.AudioPlaybackDevicesMenuItem.Image = global::tb_vol_scroll.Properties.Resources.speaker;
            this.AudioPlaybackDevicesMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AudioPlaybackDevicesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.AudioPlaybackDevicesMenuItem.Name = "AudioPlaybackDevicesMenuItem";
            this.AudioPlaybackDevicesMenuItem.Size = new System.Drawing.Size(199, 22);
            this.AudioPlaybackDevicesMenuItem.Text = "Audio Playback Devices";
            this.AudioPlaybackDevicesMenuItem.Click += new System.EventHandler(this.AudioPlaybackDevicesMenuItem_Click);
            // 
            // SystemVolumeMixerMenuItem
            // 
            this.SystemVolumeMixerMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.SystemVolumeMixerMenuItem.Image = global::tb_vol_scroll.Properties.Resources.mixer;
            this.SystemVolumeMixerMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SystemVolumeMixerMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.SystemVolumeMixerMenuItem.Name = "SystemVolumeMixerMenuItem";
            this.SystemVolumeMixerMenuItem.Size = new System.Drawing.Size(199, 22);
            this.SystemVolumeMixerMenuItem.Text = "System Volume Mixer";
            this.SystemVolumeMixerMenuItem.Click += new System.EventHandler(this.SystemVolumeMixerMenuItem_Click);
            // 
            // VolumeSliderControlMenuItem
            // 
            this.VolumeSliderControlMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.VolumeSliderControlMenuItem.Enabled = false;
            this.VolumeSliderControlMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("VolumeSliderControlMenuItem.Image")));
            this.VolumeSliderControlMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VolumeSliderControlMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.VolumeSliderControlMenuItem.Name = "VolumeSliderControlMenuItem";
            this.VolumeSliderControlMenuItem.Size = new System.Drawing.Size(199, 22);
            this.VolumeSliderControlMenuItem.Text = "Volume Slider Control";
            this.VolumeSliderControlMenuItem.Click += new System.EventHandler(this.VolumeSliderControlMenuItem_Click);
            // 
            // SeparatorMenuItem3
            // 
            this.SeparatorMenuItem3.BackColor = System.Drawing.SystemColors.Control;
            this.SeparatorMenuItem3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SeparatorMenuItem3.Name = "SeparatorMenuItem3";
            this.SeparatorMenuItem3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SeparatorMenuItem3.Size = new System.Drawing.Size(196, 6);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.OptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationMenuItem,
            this.CheckForUpdatesMenuItem,
            this.SeperatorMenuItem4,
            this.OpenCurrentDirectoryMenuItem,
            this.OpenStartupDirectoryMenuItem,
            this.SeparatorMenuItem2,
            this.RestartNormalMenuItem,
            this.RestartAdministratorMenuItem});
            this.OptionsMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(199, 22);
            this.OptionsMenuItem.Text = "Options";
            // 
            // ConfigurationMenuItem
            // 
            this.ConfigurationMenuItem.Image = global::tb_vol_scroll.Properties.Resources.configuration;
            this.ConfigurationMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ConfigurationMenuItem.Name = "ConfigurationMenuItem";
            this.ConfigurationMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ConfigurationMenuItem.Text = "Configuration";
            this.ConfigurationMenuItem.Click += new System.EventHandler(this.ConfigurationMenuItem_Click);
            // 
            // CheckForUpdatesMenuItem
            // 
            this.CheckForUpdatesMenuItem.Image = global::tb_vol_scroll.Properties.Resources.update;
            this.CheckForUpdatesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.CheckForUpdatesMenuItem.Name = "CheckForUpdatesMenuItem";
            this.CheckForUpdatesMenuItem.Size = new System.Drawing.Size(197, 22);
            this.CheckForUpdatesMenuItem.Text = "Check For Updates";
            this.CheckForUpdatesMenuItem.Click += new System.EventHandler(this.CheckForUpdatesMenuItem_Click);
            // 
            // SeperatorMenuItem4
            // 
            this.SeperatorMenuItem4.Name = "SeperatorMenuItem4";
            this.SeperatorMenuItem4.Size = new System.Drawing.Size(194, 6);
            // 
            // OpenCurrentDirectoryMenuItem
            // 
            this.OpenCurrentDirectoryMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.OpenCurrentDirectoryMenuItem.Name = "OpenCurrentDirectoryMenuItem";
            this.OpenCurrentDirectoryMenuItem.Size = new System.Drawing.Size(197, 22);
            this.OpenCurrentDirectoryMenuItem.Text = "Open Current Directory";
            this.OpenCurrentDirectoryMenuItem.Click += new System.EventHandler(this.OpenCurrentDirectoryMenuItem_Click);
            // 
            // OpenStartupDirectoryMenuItem
            // 
            this.OpenStartupDirectoryMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.OpenStartupDirectoryMenuItem.Name = "OpenStartupDirectoryMenuItem";
            this.OpenStartupDirectoryMenuItem.Size = new System.Drawing.Size(197, 22);
            this.OpenStartupDirectoryMenuItem.Text = "Open Startup Directory";
            this.OpenStartupDirectoryMenuItem.Click += new System.EventHandler(this.OpenStartupDirectoryMenuItem_Click);
            // 
            // SeparatorMenuItem2
            // 
            this.SeparatorMenuItem2.Name = "SeparatorMenuItem2";
            this.SeparatorMenuItem2.Size = new System.Drawing.Size(194, 6);
            // 
            // RestartNormalMenuItem
            // 
            this.RestartNormalMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.RestartNormalMenuItem.Name = "RestartNormalMenuItem";
            this.RestartNormalMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RestartNormalMenuItem.Text = "Restart";
            this.RestartNormalMenuItem.Click += new System.EventHandler(this.RestartNormalMenuItem_Click);
            // 
            // RestartAdministratorMenuItem
            // 
            this.RestartAdministratorMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.RestartAdministratorMenuItem.Name = "RestartAdministratorMenuItem";
            this.RestartAdministratorMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RestartAdministratorMenuItem.Text = "Restart (Administrator)";
            this.RestartAdministratorMenuItem.Click += new System.EventHandler(this.RestartAdministratorMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ExitMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // BarTextLabel
            // 
            this.BarTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarTextLabel.Location = new System.Drawing.Point(0, 0);
            this.BarTextLabel.Name = "BarTextLabel";
            this.BarTextLabel.Size = new System.Drawing.Size(120, 23);
            this.BarTextLabel.TabIndex = 0;
            this.BarTextLabel.Text = "tb-vol-scroll";
            this.BarTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BarTextLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.BarTextLabel_Paint);
            // 
            // TrayNotifyIcon
            // 
            this.TrayNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayNotifyIcon.ContextMenuStrip = this.TrayContextMenu;
            this.TrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayNotifyIcon.Icon")));
            this.TrayNotifyIcon.Tag = "tb-vol-scroll";
            this.TrayNotifyIcon.Text = "Loading...";
            this.TrayNotifyIcon.BalloonTipClosed += new System.EventHandler(this.TrayNotifyIcon_BalloonTipClosed);
            this.TrayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotifyIcon_MouseClick);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TitleLabelMenuItem,
            this.SeparatorMenuItem1,
            this.AudioPlaybackDevicesMenuItem,
            this.SystemVolumeMixerMenuItem,
            this.VolumeSliderControlMenuItem,
            this.SeparatorMenuItem3,
            this.OptionsMenuItem,
            this.ExitMenuItem});
            this.TrayContextMenu.Name = "TrayContextMenu";
            this.TrayContextMenu.Size = new System.Drawing.Size(200, 168);
            this.TrayContextMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.TrayContextMenu_Closing);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(120, 23);
            this.ControlBox = false;
            this.Controls.Add(this.BarTextLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tb-vol-scroll";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.TrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label BarTextLabel;
        public System.Windows.Forms.NotifyIcon TrayNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem TitleLabelMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem AudioPlaybackDevicesMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SystemVolumeMixerMenuItem;
        public System.Windows.Forms.ToolStripMenuItem VolumeSliderControlMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeperatorMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem OpenCurrentDirectoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenStartupDirectoryMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem RestartNormalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartAdministratorMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ContextMenuStrip TrayContextMenu;
    }
}

