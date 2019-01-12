namespace TbVolScroll
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResetVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVolumePerc = new System.Windows.Forms.Label();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "TbVolScroll";
            this.trayIcon.BalloonTipTitle = "TbVolScroll";
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Tag = "TbVolScroll";
            this.trayIcon.Text = "TbVolScroll";
            this.trayIcon.Visible = true;
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.BackColor = System.Drawing.Color.White;
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLabel,
            this.tsmSeperator,
            this.tsmExit,
            this.tsmRestart,
            this.tsmResetVolume});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.ShowImageMargin = false;
            this.trayContextMenu.Size = new System.Drawing.Size(133, 98);
            // 
            // tsmLabel
            // 
            this.tsmLabel.Enabled = false;
            this.tsmLabel.Name = "tsmLabel";
            this.tsmLabel.Size = new System.Drawing.Size(132, 22);
            this.tsmLabel.Text = "TbVolScroll v1.3";
            // 
            // tsmSeperator
            // 
            this.tsmSeperator.Name = "tsmSeperator";
            this.tsmSeperator.Size = new System.Drawing.Size(129, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(132, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmRestart
            // 
            this.tsmRestart.Name = "tsmRestart";
            this.tsmRestart.Size = new System.Drawing.Size(132, 22);
            this.tsmRestart.Text = "Restart";
            this.tsmRestart.Click += new System.EventHandler(this.tsmRestart_Click);
            // 
            // tsmResetVolume
            // 
            this.tsmResetVolume.Name = "tsmResetVolume";
            this.tsmResetVolume.Size = new System.Drawing.Size(132, 22);
            this.tsmResetVolume.Text = "Reset Volume";
            this.tsmResetVolume.Click += new System.EventHandler(this.tsmResetVolume_Click);
            // 
            // lblVolumePerc
            // 
            this.lblVolumePerc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVolumePerc.BackColor = System.Drawing.Color.Red;
            this.lblVolumePerc.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumePerc.ForeColor = System.Drawing.Color.Black;
            this.lblVolumePerc.Location = new System.Drawing.Point(2, 2);
            this.lblVolumePerc.Name = "lblVolumePerc";
            this.lblVolumePerc.Size = new System.Drawing.Size(121, 13);
            this.lblVolumePerc.TabIndex = 1;
            this.lblVolumePerc.Text = "0%";
            this.lblVolumePerc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(125, 17);
            this.Controls.Add(this.lblVolumePerc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TbVolScroll";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmRestart;
        private System.Windows.Forms.ToolStripMenuItem tsmLabel;
        private System.Windows.Forms.ToolStripSeparator tsmSeperator;
        private System.Windows.Forms.ToolStripMenuItem tsmResetVolume;
        private System.Windows.Forms.Label lblVolumePerc;
    }
}

