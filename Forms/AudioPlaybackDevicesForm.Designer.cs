
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.DevicesListView = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsDefaultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MutedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VolumeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(189, 151);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // DevicesListView
            // 
            this.DevicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.IsDefaultColumn,
            this.MutedColumn,
            this.VolumeColumn});
            this.DevicesListView.FullRowSelect = true;
            this.DevicesListView.HideSelection = false;
            this.DevicesListView.Location = new System.Drawing.Point(12, 12);
            this.DevicesListView.MultiSelect = false;
            this.DevicesListView.Name = "DevicesListView";
            this.DevicesListView.Size = new System.Drawing.Size(510, 133);
            this.DevicesListView.TabIndex = 1;
            this.DevicesListView.UseCompatibleStateImageBehavior = false;
            this.DevicesListView.View = System.Windows.Forms.View.Details;
            this.DevicesListView.SelectedIndexChanged += new System.EventHandler(this.ToggleSaveButton);
            this.DevicesListView.DoubleClick += new System.EventHandler(this.DevicesListViewDoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 300;
            // 
            // IsDefaultColumn
            // 
            this.IsDefaultColumn.Text = "Default";
            this.IsDefaultColumn.Width = 75;
            // 
            // MutedColumn
            // 
            this.MutedColumn.DisplayIndex = 3;
            this.MutedColumn.Text = "Muted";
            this.MutedColumn.Width = 50;
            // 
            // VolumeColumn
            // 
            this.VolumeColumn.DisplayIndex = 2;
            this.VolumeColumn.Text = "Volume";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(270, 151);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // AudioPlaybackDevicesForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(534, 186);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DevicesListView);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioPlaybackDevicesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Playback Devices";
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ListView DevicesListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader IsDefaultColumn;
        private System.Windows.Forms.ColumnHeader MutedColumn;
        private System.Windows.Forms.ColumnHeader VolumeColumn;
        private System.Windows.Forms.Button RefreshButton;
    }
}