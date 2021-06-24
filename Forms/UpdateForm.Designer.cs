
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
            this.SuspendLayout();
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(58, 51);
            this.DownloadButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(178, 34);
            this.DownloadButton.TabIndex = 2;
            this.DownloadButton.Text = "Download and install";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DoUpdate);
            // 
            // CheckingForUpdatesLabel
            // 
            this.CheckingForUpdatesLabel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.CheckingForUpdatesLabel.FlatAppearance.BorderSize = 0;
            this.CheckingForUpdatesLabel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.CheckingForUpdatesLabel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.CheckingForUpdatesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckingForUpdatesLabel.Image = global::tbvolscroll.Properties.Resources.spinner;
            this.CheckingForUpdatesLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckingForUpdatesLabel.Location = new System.Drawing.Point(15, 15);
            this.CheckingForUpdatesLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckingForUpdatesLabel.Name = "CheckingForUpdatesLabel";
            this.CheckingForUpdatesLabel.Size = new System.Drawing.Size(262, 29);
            this.CheckingForUpdatesLabel.TabIndex = 3;
            this.CheckingForUpdatesLabel.Text = "Checking for updates...";
            this.CheckingForUpdatesLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CheckingForUpdatesLabel.UseVisualStyleBackColor = true;
            this.CheckingForUpdatesLabel.Click += new System.EventHandler(this.DoUpdateCheck);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(292, 100);
            this.Controls.Add(this.CheckingForUpdatesLabel);
            this.Controls.Add(this.DownloadButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update";
            this.Shown += new System.EventHandler(this.DoUpdateCheck);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button CheckingForUpdatesLabel;
    }
}