namespace tbvolscroll
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
            this.VolumeTextLabel = new System.Windows.Forms.Label();
            this.TrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.RestartAsAdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolumeTextLabel
            // 
            this.VolumeTextLabel.BackColor = System.Drawing.Color.SkyBlue;
            this.VolumeTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VolumeTextLabel.Location = new System.Drawing.Point(0, 0);
            this.VolumeTextLabel.Margin = new System.Windows.Forms.Padding(5);
            this.VolumeTextLabel.Name = "VolumeTextLabel";
            this.VolumeTextLabel.Size = new System.Drawing.Size(125, 20);
            this.VolumeTextLabel.TabIndex = 0;
            this.VolumeTextLabel.Text = "tb-vol-scroll";
            this.VolumeTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VolumeTextLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawVolumeBarBorder);
            // 
            // TrayNotifyIcon
            // 
            this.TrayNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayNotifyIcon.ContextMenuStrip = this.TrayContextMenu;
            this.TrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayNotifyIcon.Icon")));
            this.TrayNotifyIcon.Tag = "tb-vol-scroll";
            this.TrayNotifyIcon.Text = "Initialising...";
            this.TrayNotifyIcon.Visible = true;
            this.TrayNotifyIcon.BalloonTipClicked += new System.EventHandler(this.HandleBalloonTipHide);
            this.TrayNotifyIcon.BalloonTipClosed += new System.EventHandler(this.HandleBalloonTipHide);
            this.TrayNotifyIcon.Click += new System.EventHandler(this.ShowTrayMenuOnClick);
            this.TrayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowVolumeSliderPopupForm);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.BackColor = System.Drawing.SystemColors.Control;
            this.TrayContextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TitleLabelMenuItem,
            this.SeparatorMenuItem1,
            this.AudioPlaybackDevicesMenuItem,
            this.SystemVolumeMixerMenuItem,
            this.VolumeSliderControlMenuItem,
            this.SeparatorMenuItem3,
            this.OptionsMenuItem,
            this.ExitMenuItem});
            this.TrayContextMenu.Name = "trayContextMenu";
            this.TrayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TrayContextMenu.Size = new System.Drawing.Size(200, 168);
            this.TrayContextMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlaySystemSoundTrayMenu);
            // 
            // TitleLabelMenuItem
            // 
            this.TitleLabelMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.TitleLabelMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TitleLabelMenuItem.Enabled = false;
            this.TitleLabelMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TitleLabelMenuItem.Name = "TitleLabelMenuItem";
            this.TitleLabelMenuItem.Size = new System.Drawing.Size(199, 22);
            this.TitleLabelMenuItem.Text = "tb-vol-scroll";
            // 
            // SeparatorMenuItem1
            // 
            this.SeparatorMenuItem1.BackColor = System.Drawing.SystemColors.Menu;
            this.SeparatorMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SeparatorMenuItem1.Name = "SeparatorMenuItem1";
            this.SeparatorMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // AudioPlaybackDevicesMenuItem
            // 
            this.AudioPlaybackDevicesMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.AudioPlaybackDevicesMenuItem.Enabled = false;
            this.AudioPlaybackDevicesMenuItem.Image = global::tbvolscroll.Properties.Resources.speaker;
            this.AudioPlaybackDevicesMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AudioPlaybackDevicesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.AudioPlaybackDevicesMenuItem.Name = "AudioPlaybackDevicesMenuItem";
            this.AudioPlaybackDevicesMenuItem.Size = new System.Drawing.Size(199, 22);
            this.AudioPlaybackDevicesMenuItem.Text = "Audio Playback Devices";
            this.AudioPlaybackDevicesMenuItem.Click += new System.EventHandler(this.AudioDevicesMenuItemClick);
            // 
            // SystemVolumeMixerMenuItem
            // 
            this.SystemVolumeMixerMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.SystemVolumeMixerMenuItem.Enabled = false;
            this.SystemVolumeMixerMenuItem.Image = global::tbvolscroll.Properties.Resources.mixer;
            this.SystemVolumeMixerMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SystemVolumeMixerMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.SystemVolumeMixerMenuItem.Name = "SystemVolumeMixerMenuItem";
            this.SystemVolumeMixerMenuItem.Size = new System.Drawing.Size(199, 22);
            this.SystemVolumeMixerMenuItem.Text = "System Volume Mixer";
            this.SystemVolumeMixerMenuItem.Click += new System.EventHandler(this.VolumeMixerMenuItemClick);
            // 
            // VolumeSliderControlMenuItem
            // 
            this.VolumeSliderControlMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.VolumeSliderControlMenuItem.Enabled = false;
            this.VolumeSliderControlMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("VolumeSliderControlMenuItem.Image")));
            this.VolumeSliderControlMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VolumeSliderControlMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.VolumeSliderControlMenuItem.Name = "VolumeSliderControlMenuItem";
            this.VolumeSliderControlMenuItem.Size = new System.Drawing.Size(199, 22);
            this.VolumeSliderControlMenuItem.Text = "Volume Slider Control";
            this.VolumeSliderControlMenuItem.Click += new System.EventHandler(this.VolumeSliderPopupMenuItemClick);
            // 
            // SeparatorMenuItem3
            // 
            this.SeparatorMenuItem3.BackColor = System.Drawing.SystemColors.Menu;
            this.SeparatorMenuItem3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SeparatorMenuItem3.Name = "SeparatorMenuItem3";
            this.SeparatorMenuItem3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SeparatorMenuItem3.Size = new System.Drawing.Size(196, 6);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.OptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationMenuItem,
            this.CheckForUpdatesMenuItem,
            this.SeperatorMenuItem4,
            this.OpenCurrentDirectoryMenuItem,
            this.OpenStartupDirectoryMenuItem,
            this.SeparatorMenuItem2,
            this.RestartNormalMenuItem,
            this.RestartAsAdminMenuItem});
            this.OptionsMenuItem.Enabled = false;
            this.OptionsMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(199, 22);
            this.OptionsMenuItem.Text = "Options";
            // 
            // ConfigurationMenuItem
            // 
            this.ConfigurationMenuItem.Image = global::tbvolscroll.Properties.Resources.configuration;
            this.ConfigurationMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ConfigurationMenuItem.Name = "ConfigurationMenuItem";
            this.ConfigurationMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ConfigurationMenuItem.Text = "Configuration";
            this.ConfigurationMenuItem.Click += new System.EventHandler(this.OpenConfigureDialog);
            // 
            // CheckForUpdatesMenuItem
            // 
            this.CheckForUpdatesMenuItem.Image = global::tbvolscroll.Properties.Resources.update;
            this.CheckForUpdatesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.CheckForUpdatesMenuItem.Name = "CheckForUpdatesMenuItem";
            this.CheckForUpdatesMenuItem.Size = new System.Drawing.Size(197, 22);
            this.CheckForUpdatesMenuItem.Text = "Check For Updates";
            this.CheckForUpdatesMenuItem.Click += new System.EventHandler(this.OpenCheckForUpdatesForm);
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
            this.OpenCurrentDirectoryMenuItem.Click += new System.EventHandler(this.OpenCurrentLocation);
            // 
            // OpenStartupDirectoryMenuItem
            // 
            this.OpenStartupDirectoryMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.OpenStartupDirectoryMenuItem.Name = "OpenStartupDirectoryMenuItem";
            this.OpenStartupDirectoryMenuItem.Size = new System.Drawing.Size(197, 22);
            this.OpenStartupDirectoryMenuItem.Text = "Open Startup Directory";
            this.OpenStartupDirectoryMenuItem.Click += new System.EventHandler(this.OpenStartupFolder);
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
            this.RestartNormalMenuItem.Click += new System.EventHandler(this.RestartAppNormal);
            // 
            // RestartAsAdminMenuItem
            // 
            this.RestartAsAdminMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.RestartAsAdminMenuItem.Name = "RestartAsAdminMenuItem";
            this.RestartAsAdminMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RestartAsAdminMenuItem.Text = "Restart (Administrator)";
            this.RestartAsAdminMenuItem.Click += new System.EventHandler(this.RestartAppAsAdministrator);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.ExitMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(125, 20);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeTextLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "tb-vol-scroll";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.TrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem TitleLabelMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem1;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationMenuItem;
        public System.Windows.Forms.Label VolumeTextLabel;
        private System.Windows.Forms.ToolStripMenuItem OpenStartupDirectoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartAsAdminMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem3;
        public System.Windows.Forms.NotifyIcon TrayNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeperatorMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem OpenCurrentDirectoryMenuItem;
        public System.Windows.Forms.ContextMenuStrip TrayContextMenu;
        public System.Windows.Forms.ToolStripMenuItem AudioPlaybackDevicesMenuItem;
        public System.Windows.Forms.ToolStripMenuItem VolumeSliderControlMenuItem;
        public System.Windows.Forms.ToolStripMenuItem RestartNormalMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SystemVolumeMixerMenuItem;
        public System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
    }
}

