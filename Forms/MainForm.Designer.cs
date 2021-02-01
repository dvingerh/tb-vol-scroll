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
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenStartupFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartAsAdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolumeTextLabel
            // 
            this.VolumeTextLabel.BackColor = System.Drawing.Color.DodgerBlue;
            this.VolumeTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VolumeTextLabel.Location = new System.Drawing.Point(0, 0);
            this.VolumeTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VolumeTextLabel.Name = "VolumeTextLabel";
            this.VolumeTextLabel.Size = new System.Drawing.Size(120, 23);
            this.VolumeTextLabel.TabIndex = 0;
            this.VolumeTextLabel.Text = "tb-vol-scroll";
            this.VolumeTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VolumeTextLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawVolumeBarBorder);
            // 
            // TrayNotifyIcon
            // 
            this.TrayNotifyIcon.ContextMenuStrip = this.TrayContextMenu;
            this.TrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayNotifyIcon.Icon")));
            this.TrayNotifyIcon.Tag = "tb-vol-scroll";
            this.TrayNotifyIcon.Text = "tb-vol-scroll - Loading";
            this.TrayNotifyIcon.Visible = true;
            this.TrayNotifyIcon.Click += new System.EventHandler(this.ShowTrayMenuOnClick);
            this.TrayNotifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UpdateTrayIconText);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.BackColor = System.Drawing.SystemColors.Control;
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TitleLabelMenuItem,
            this.SeparatorMenuItem1,
            this.OptionsMenuItem,
            this.ExitMenuItem});
            this.TrayContextMenu.Name = "trayContextMenu";
            this.TrayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TrayContextMenu.ShowCheckMargin = true;
            this.TrayContextMenu.ShowImageMargin = false;
            this.TrayContextMenu.Size = new System.Drawing.Size(140, 76);
            // 
            // TitleLabelMenuItem
            // 
            this.TitleLabelMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLabelMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TitleLabelMenuItem.Enabled = false;
            this.TitleLabelMenuItem.Name = "TitleLabelMenuItem";
            this.TitleLabelMenuItem.Size = new System.Drawing.Size(139, 22);
            this.TitleLabelMenuItem.Text = "tb-vol-scroll";
            // 
            // SeparatorMenuItem1
            // 
            this.SeparatorMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.SeparatorMenuItem1.Name = "SeparatorMenuItem1";
            this.SeparatorMenuItem1.Size = new System.Drawing.Size(136, 6);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.OptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.SeparatorMenuItem2,
            this.OpenStartupFolderMenuItem,
            this.RestartMenuItem});
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(139, 22);
            this.OptionsMenuItem.Text = "Options";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SettingsMenuItem.Text = "Settings";
            this.SettingsMenuItem.Click += new System.EventHandler(this.OpenSettingsDialog);
            // 
            // SeparatorMenuItem2
            // 
            this.SeparatorMenuItem2.Name = "SeparatorMenuItem2";
            this.SeparatorMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // OpenStartupFolderMenuItem
            // 
            this.OpenStartupFolderMenuItem.Name = "OpenStartupFolderMenuItem";
            this.OpenStartupFolderMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenStartupFolderMenuItem.Text = "Open startup folder";
            this.OpenStartupFolderMenuItem.Click += new System.EventHandler(this.OpenStartupFolder);
            // 
            // RestartMenuItem
            // 
            this.RestartMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestartNormalMenuItem,
            this.RestartAsAdminMenuItem});
            this.RestartMenuItem.Name = "RestartMenuItem";
            this.RestartMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RestartMenuItem.Text = "Restart application";
            // 
            // RestartNormalMenuItem
            // 
            this.RestartNormalMenuItem.Name = "RestartNormalMenuItem";
            this.RestartNormalMenuItem.Size = new System.Drawing.Size(208, 22);
            this.RestartNormalMenuItem.Text = "Restart";
            this.RestartNormalMenuItem.Click += new System.EventHandler(this.RestartAppNormal);
            // 
            // RestartAsAdminMenuItem
            // 
            this.RestartAsAdminMenuItem.Name = "RestartAsAdminMenuItem";
            this.RestartAsAdminMenuItem.Size = new System.Drawing.Size(208, 22);
            this.RestartAsAdminMenuItem.Text = "Restart (as Administrator)";
            this.RestartAsAdminMenuItem.Click += new System.EventHandler(this.RestartAppAsAdministrator);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(120, 23);
            this.ControlBox = false;
            this.Controls.Add(this.VolumeTextLabel);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.TrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon TrayNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip TrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem TitleLabelMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartMenuItem;
        private System.Windows.Forms.ToolStripSeparator SeparatorMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartNormalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartAsAdminMenuItem;
        public System.Windows.Forms.Label VolumeTextLabel;
        private System.Windows.Forms.ToolStripMenuItem OpenStartupFolderMenuItem;
    }
}

