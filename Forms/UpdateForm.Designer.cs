
namespace tbvolscroll.Forms
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.DownloadButton = new System.Windows.Forms.Button();
            this.CheckingForUpdatesLabel = new System.Windows.Forms.Button();
            this.ViewReleasesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(46, 41);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(142, 27);
            this.DownloadButton.TabIndex = 2;
            this.DownloadButton.Text = "Download and install";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.StartUpdateDownload);
            // 
            // CheckingForUpdatesLabel
            // 
            this.CheckingForUpdatesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckingForUpdatesLabel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.CheckingForUpdatesLabel.FlatAppearance.BorderSize = 0;
            this.CheckingForUpdatesLabel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.CheckingForUpdatesLabel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.CheckingForUpdatesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckingForUpdatesLabel.Image = global::tbvolscroll.Properties.Resources.spinner;
            this.CheckingForUpdatesLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckingForUpdatesLabel.Location = new System.Drawing.Point(12, 12);
            this.CheckingForUpdatesLabel.Name = "CheckingForUpdatesLabel";
            this.CheckingForUpdatesLabel.Size = new System.Drawing.Size(210, 23);
            this.CheckingForUpdatesLabel.TabIndex = 3;
            this.CheckingForUpdatesLabel.Text = "Checking for updates...";
            this.CheckingForUpdatesLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CheckingForUpdatesLabel.UseVisualStyleBackColor = true;
            this.CheckingForUpdatesLabel.Click += new System.EventHandler(this.DoUpdateCheck);
            // 
            // ViewReleasesLinkLabel
            // 
            this.ViewReleasesLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.ViewReleasesLinkLabel.AutoSize = true;
            this.ViewReleasesLinkLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewReleasesLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ViewReleasesLinkLabel.LinkColor = System.Drawing.SystemColors.Highlight;
            this.ViewReleasesLinkLabel.Location = new System.Drawing.Point(146, 74);
            this.ViewReleasesLinkLabel.Name = "ViewReleasesLinkLabel";
            this.ViewReleasesLinkLabel.Size = new System.Drawing.Size(76, 13);
            this.ViewReleasesLinkLabel.TabIndex = 4;
            this.ViewReleasesLinkLabel.TabStop = true;
            this.ViewReleasesLinkLabel.Text = "View releases";
            this.ViewReleasesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewReleasesLinkClicked);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(234, 96);
            this.Controls.Add(this.ViewReleasesLinkLabel);
            this.Controls.Add(this.CheckingForUpdatesLabel);
            this.Controls.Add(this.DownloadButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DontCloseOnUpdate);
            this.Shown += new System.EventHandler(this.DoUpdateCheck);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button CheckingForUpdatesLabel;
        public System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.LinkLabel ViewReleasesLinkLabel;
    }
}