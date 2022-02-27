
namespace tb_vol_scroll.Forms
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
            this.ViewReleasesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.CurrentVersionValueLabel = new System.Windows.Forms.Label();
            this.CurrentVersionLabel = new System.Windows.Forms.Label();
            this.LatestVersionLabel = new System.Windows.Forms.Label();
            this.LatestVersionValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ViewReleasesLinkLabel
            // 
            this.ViewReleasesLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.ViewReleasesLinkLabel.AutoSize = true;
            this.ViewReleasesLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ViewReleasesLinkLabel.LinkColor = System.Drawing.SystemColors.Highlight;
            this.ViewReleasesLinkLabel.Location = new System.Drawing.Point(104, 124);
            this.ViewReleasesLinkLabel.Name = "ViewReleasesLinkLabel";
            this.ViewReleasesLinkLabel.Size = new System.Drawing.Size(76, 13);
            this.ViewReleasesLinkLabel.TabIndex = 14;
            this.ViewReleasesLinkLabel.TabStop = true;
            this.ViewReleasesLinkLabel.Text = "View releases";
            this.ViewReleasesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewReleasesLinkLabel_LinkClicked);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(39, 82);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(202, 25);
            this.DownloadButton.TabIndex = 12;
            this.DownloadButton.Text = "Download && Install";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // CurrentVersionValueLabel
            // 
            this.CurrentVersionValueLabel.Location = new System.Drawing.Point(156, 23);
            this.CurrentVersionValueLabel.Name = "CurrentVersionValueLabel";
            this.CurrentVersionValueLabel.Size = new System.Drawing.Size(67, 16);
            this.CurrentVersionValueLabel.TabIndex = 15;
            this.CurrentVersionValueLabel.Text = "0.0.0";
            this.CurrentVersionValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentVersionLabel
            // 
            this.CurrentVersionLabel.AutoSize = true;
            this.CurrentVersionLabel.Location = new System.Drawing.Point(61, 25);
            this.CurrentVersionLabel.Name = "CurrentVersionLabel";
            this.CurrentVersionLabel.Size = new System.Drawing.Size(89, 13);
            this.CurrentVersionLabel.TabIndex = 16;
            this.CurrentVersionLabel.Text = "Current version:";
            // 
            // LatestVersionLabel
            // 
            this.LatestVersionLabel.AutoSize = true;
            this.LatestVersionLabel.Location = new System.Drawing.Point(70, 44);
            this.LatestVersionLabel.Name = "LatestVersionLabel";
            this.LatestVersionLabel.Size = new System.Drawing.Size(80, 13);
            this.LatestVersionLabel.TabIndex = 17;
            this.LatestVersionLabel.Text = "Latest version:";
            // 
            // LatestVersionValueLabel
            // 
            this.LatestVersionValueLabel.Image = global::tb_vol_scroll.Properties.Resources.spinner;
            this.LatestVersionValueLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LatestVersionValueLabel.Location = new System.Drawing.Point(156, 42);
            this.LatestVersionValueLabel.Name = "LatestVersionValueLabel";
            this.LatestVersionValueLabel.Size = new System.Drawing.Size(67, 16);
            this.LatestVersionValueLabel.TabIndex = 18;
            this.LatestVersionValueLabel.Text = ". . .";
            this.LatestVersionValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.LatestVersionValueLabel);
            this.Controls.Add(this.LatestVersionLabel);
            this.Controls.Add(this.CurrentVersionLabel);
            this.Controls.Add(this.CurrentVersionValueLabel);
            this.Controls.Add(this.ViewReleasesLinkLabel);
            this.Controls.Add(this.DownloadButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update (tb-vol-scroll)";
            this.Deactivate += new System.EventHandler(this.UpdateForm_Deactivate);
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel ViewReleasesLinkLabel;
        public System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Label CurrentVersionValueLabel;
        private System.Windows.Forms.Label CurrentVersionLabel;
        private System.Windows.Forms.Label LatestVersionLabel;
        private System.Windows.Forms.Label LatestVersionValueLabel;
    }
}