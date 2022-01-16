
using tbvolscroll.Classes;

namespace tbvolscroll.Forms
{
    partial class AudioPlaybackDevicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlaybackDevicesForm));
            this.ApplyButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.BorderPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DevicesListView = new tbvolscroll.Classes.DoubleBufferedListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsDefaultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VolumeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MutedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BorderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(222, 201);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(303, 201);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 4);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(533, 30);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.Text = "The active device is marked green. Double-click to apply selected device and clos" +
    "e this window.";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BorderPanel
            // 
            this.BorderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderPanel.Controls.Add(this.CloseButton);
            this.BorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorderPanel.Location = new System.Drawing.Point(0, 0);
            this.BorderPanel.Name = "BorderPanel";
            this.BorderPanel.Size = new System.Drawing.Size(600, 235);
            this.BorderPanel.TabIndex = 4;
            // 
            // CloseButton
            // 
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Location = new System.Drawing.Point(570, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 20);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseForm);
            // 
            // DevicesListView
            // 
            this.DevicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.IsDefaultColumn,
            this.VolumeColumn,
            this.MutedColumn});
            this.DevicesListView.FullRowSelect = true;
            this.DevicesListView.HideSelection = false;
            this.DevicesListView.Location = new System.Drawing.Point(12, 37);
            this.DevicesListView.MultiSelect = false;
            this.DevicesListView.Name = "DevicesListView";
            this.DevicesListView.Size = new System.Drawing.Size(576, 158);
            this.DevicesListView.TabIndex = 1;
            this.DevicesListView.UseCompatibleStateImageBehavior = false;
            this.DevicesListView.View = System.Windows.Forms.View.Details;
            this.DevicesListView.SelectedIndexChanged += new System.EventHandler(this.ToggleApplyButton);
            this.DevicesListView.DoubleClick += new System.EventHandler(this.DevicesListViewDoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 370;
            // 
            // IsDefaultColumn
            // 
            this.IsDefaultColumn.Text = "Default";
            // 
            // VolumeColumn
            // 
            this.VolumeColumn.Text = "Volume";
            // 
            // MutedColumn
            // 
            this.MutedColumn.Text = "Muted";
            // 
            // AudioPlaybackDevicesForm
            // 
            this.AcceptButton = this.ApplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 235);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DevicesListView);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.BorderPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioPlaybackDevicesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Playback Devices";
            this.Deactivate += new System.EventHandler(this.CloseForm);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.BorderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader IsDefaultColumn;
        private System.Windows.Forms.ColumnHeader MutedColumn;
        private System.Windows.Forms.ColumnHeader VolumeColumn;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel BorderPanel;
        private System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.Button RefreshButton;
        private DoubleBufferedListView DevicesListView;
    }
}