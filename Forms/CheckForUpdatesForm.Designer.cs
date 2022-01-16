
namespace tbvolscroll.Forms
{
    partial class CheckForUpdatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForUpdatesForm));
            this.ViewReleasesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CheckingForUpdatesLabel = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.RefreshUpdateToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CurrentVersionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ViewReleasesLinkLabel
            // 
            this.ViewReleasesLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.ViewReleasesLinkLabel.AutoSize = true;
            this.ViewReleasesLinkLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewReleasesLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ViewReleasesLinkLabel.LinkColor = System.Drawing.SystemColors.Highlight;
            this.ViewReleasesLinkLabel.Location = new System.Drawing.Point(150, 89);
            this.ViewReleasesLinkLabel.Name = "ViewReleasesLinkLabel";
            this.ViewReleasesLinkLabel.Size = new System.Drawing.Size(76, 13);
            this.ViewReleasesLinkLabel.TabIndex = 10;
            this.ViewReleasesLinkLabel.TabStop = true;
            this.ViewReleasesLinkLabel.Text = "View releases";
            this.ViewReleasesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewReleasesLinkClicked);
            // 
            // CheckingForUpdatesLabel
            // 
            this.CheckingForUpdatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckingForUpdatesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckingForUpdatesLabel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.CheckingForUpdatesLabel.FlatAppearance.BorderSize = 0;
            this.CheckingForUpdatesLabel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.CheckingForUpdatesLabel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.CheckingForUpdatesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckingForUpdatesLabel.Image = global::tbvolscroll.Properties.Resources.spinner;
            this.CheckingForUpdatesLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.CheckingForUpdatesLabel.Location = new System.Drawing.Point(12, 13);
            this.CheckingForUpdatesLabel.Name = "CheckingForUpdatesLabel";
            this.CheckingForUpdatesLabel.Size = new System.Drawing.Size(209, 26);
            this.CheckingForUpdatesLabel.TabIndex = 9;
            this.CheckingForUpdatesLabel.Text = "  Checking for updates...";
            this.CheckingForUpdatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckingForUpdatesLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RefreshUpdateToolTip.SetToolTip(this.CheckingForUpdatesLabel, "Click to check for updates");
            this.CheckingForUpdatesLabel.UseVisualStyleBackColor = true;
            this.CheckingForUpdatesLabel.Click += new System.EventHandler(this.DoUpdateCheck);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(11, 45);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(211, 25);
            this.DownloadButton.TabIndex = 8;
            this.DownloadButton.Text = "Download && Install";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.StartUpdateDownload);
            // 
            // RefreshUpdateToolTip
            // 
            this.RefreshUpdateToolTip.AutomaticDelay = 100;
            this.RefreshUpdateToolTip.BackColor = System.Drawing.Color.White;
            // 
            // CurrentVersionLabel
            // 
            this.CurrentVersionLabel.AutoSize = true;
            this.CurrentVersionLabel.Location = new System.Drawing.Point(8, 89);
            this.CurrentVersionLabel.Name = "CurrentVersionLabel";
            this.CurrentVersionLabel.Size = new System.Drawing.Size(31, 13);
            this.CurrentVersionLabel.TabIndex = 11;
            this.CurrentVersionLabel.Text = "0.0.0";
            // 
            // CheckForUpdatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.CurrentVersionLabel);
            this.Controls.Add(this.ViewReleasesLinkLabel);
            this.Controls.Add(this.CheckingForUpdatesLabel);
            this.Controls.Add(this.DownloadButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckForUpdatesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check for Updates";
            this.Deactivate += new System.EventHandler(this.CloseFormOnDeacivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DontCloseOnUpdate);
            this.Shown += new System.EventHandler(this.DoUpdateCheck);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ViewReleasesLinkLabel;
        public System.Windows.Forms.Button CheckingForUpdatesLabel;
        public System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.ToolTip RefreshUpdateToolTip;
        private System.Windows.Forms.Label CurrentVersionLabel;
    }
}