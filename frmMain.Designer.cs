namespace TbVolScroll_Reloaded
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
            this.lblVolumeText = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmTitleLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResetVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiSetVolumeStep = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSetPreciseScollThreshold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVolumeText
            // 
            this.lblVolumeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVolumeText.BackColor = System.Drawing.Color.White;
            this.lblVolumeText.Location = new System.Drawing.Point(1, 1);
            this.lblVolumeText.Name = "lblVolumeText";
            this.lblVolumeText.Size = new System.Drawing.Size(123, 18);
            this.lblVolumeText.TabIndex = 0;
            this.lblVolumeText.Text = "Loading . . .";
            this.lblVolumeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Tag = "TbVolScroll";
            this.trayIcon.Text = "TbVolScroll - Loading";
            this.trayIcon.Visible = true;
            this.trayIcon.Click += new System.EventHandler(this.ShowTrayMenuOnClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.BackColor = System.Drawing.Color.White;
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTitleLabel,
            this.tsmSeperator,
            this.tsmOptions,
            this.tsmExit});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.trayContextMenu.ShowCheckMargin = true;
            this.trayContextMenu.ShowImageMargin = false;
            this.trayContextMenu.Size = new System.Drawing.Size(181, 98);
            // 
            // tsmTitleLabel
            // 
            this.tsmTitleLabel.Enabled = false;
            this.tsmTitleLabel.Name = "tsmTitleLabel";
            this.tsmTitleLabel.Size = new System.Drawing.Size(180, 22);
            this.tsmTitleLabel.Text = "TbVolScroll v1.6";
            // 
            // tsmSeperator
            // 
            this.tsmSeperator.Name = "tsmSeperator";
            this.tsmSeperator.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmOptions
            // 
            this.tsmOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmResetVolume,
            this.tsmRestart,
            this.tsmSeperator2,
            this.tmiSetVolumeStep,
            this.tmiSetPreciseScollThreshold});
            this.tsmOptions.Name = "tsmOptions";
            this.tsmOptions.Size = new System.Drawing.Size(180, 22);
            this.tsmOptions.Text = "Options";
            // 
            // tsmResetVolume
            // 
            this.tsmResetVolume.Name = "tsmResetVolume";
            this.tsmResetVolume.Size = new System.Drawing.Size(223, 22);
            this.tsmResetVolume.Text = "Reset volume";
            this.tsmResetVolume.Click += new System.EventHandler(this.ResetVolume);
            // 
            // tsmRestart
            // 
            this.tsmRestart.Name = "tsmRestart";
            this.tsmRestart.Size = new System.Drawing.Size(223, 22);
            this.tsmRestart.Text = "Restart";
            this.tsmRestart.Click += new System.EventHandler(this.RestartApplication);
            // 
            // tsmSeperator2
            // 
            this.tsmSeperator2.Name = "tsmSeperator2";
            this.tsmSeperator2.Size = new System.Drawing.Size(220, 6);
            // 
            // tmiSetVolumeStep
            // 
            this.tmiSetVolumeStep.Name = "tmiSetVolumeStep";
            this.tmiSetVolumeStep.Size = new System.Drawing.Size(223, 22);
            this.tmiSetVolumeStep.Text = "Set volume scroll step...";
            this.tmiSetVolumeStep.Click += new System.EventHandler(this.OpenSetVolumeStepDialog);
            // 
            // tmiSetPreciseScollThreshold
            // 
            this.tmiSetPreciseScollThreshold.Name = "tmiSetPreciseScollThreshold";
            this.tmiSetPreciseScollThreshold.Size = new System.Drawing.Size(223, 22);
            this.tmiSetPreciseScollThreshold.Text = "Set precise scroll threshold...";
            this.tmiSetPreciseScollThreshold.Click += new System.EventHandler(this.OpenSetPreciseScrollThreshold);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(180, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.ExitApplication);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(125, 23);
            this.ControlBox = false;
            this.Controls.Add(this.lblVolumeText);
            this.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(125, 200);
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.SetupProgramVars);
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVolumeText;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmTitleLabel;
        private System.Windows.Forms.ToolStripSeparator tsmSeperator;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmResetVolume;
        private System.Windows.Forms.ToolStripMenuItem tsmRestart;
        private System.Windows.Forms.ToolStripSeparator tsmSeperator2;
        private System.Windows.Forms.ToolStripMenuItem tmiSetVolumeStep;
        private System.Windows.Forms.ToolStripMenuItem tmiSetPreciseScollThreshold;
    }
}

