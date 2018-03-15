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
            this.pnlColor = new System.Windows.Forms.Panel();
            this.lblVolumePerc = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlColor.SuspendLayout();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.Red;
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Controls.Add(this.lblVolumePerc);
            this.pnlColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColor.Location = new System.Drawing.Point(0, 0);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(100, 16);
            this.pnlColor.TabIndex = 0;
            // 
            // lblVolumePerc
            // 
            this.lblVolumePerc.BackColor = System.Drawing.Color.Transparent;
            this.lblVolumePerc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVolumePerc.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumePerc.ForeColor = System.Drawing.Color.Black;
            this.lblVolumePerc.Location = new System.Drawing.Point(0, 0);
            this.lblVolumePerc.Name = "lblVolumePerc";
            this.lblVolumePerc.Size = new System.Drawing.Size(98, 14);
            this.lblVolumePerc.TabIndex = 0;
            this.lblVolumePerc.Text = "0%";
            this.lblVolumePerc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVolumePerc.Visible = false;
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
            this.tsmExit,
            this.tsmRestart});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.ShowImageMargin = false;
            this.trayContextMenu.Size = new System.Drawing.Size(86, 48);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(85, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmRestart
            // 
            this.tsmRestart.Name = "tsmRestart";
            this.tsmRestart.Size = new System.Drawing.Size(85, 22);
            this.tsmRestart.Text = "Restart";
            this.tsmRestart.Click += new System.EventHandler(this.tsmRestart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(100, 16);
            this.Controls.Add(this.pnlColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TbVolScroll";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.pnlColor.ResumeLayout(false);
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label lblVolumePerc;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmRestart;
    }
}

