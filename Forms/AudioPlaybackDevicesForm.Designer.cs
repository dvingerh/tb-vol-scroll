

using System.Windows.Forms;
using tb_vol_scroll.Classes.ControlsExt;

namespace tb_vol_scroll.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioPlaybackDevicesForm));
            this.RefreshButton = new System.Windows.Forms.Button();
            this.MakeDefaultButton = new System.Windows.Forms.Button();
            this.DevicesListViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.DevicesListView = new tb_vol_scroll.Classes.ControlsExt.ListViewExt();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VolumeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsDefaultColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MutedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(270, 174);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(100, 25);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MakeDefaultButton
            // 
            this.MakeDefaultButton.Enabled = false;
            this.MakeDefaultButton.Location = new System.Drawing.Point(164, 174);
            this.MakeDefaultButton.Name = "MakeDefaultButton";
            this.MakeDefaultButton.Size = new System.Drawing.Size(100, 25);
            this.MakeDefaultButton.TabIndex = 3;
            this.MakeDefaultButton.Text = "Make default";
            this.MakeDefaultButton.UseVisualStyleBackColor = true;
            this.MakeDefaultButton.Click += new System.EventHandler(this.SetDefaultButton_Click);
            // 
            // DevicesListViewImageList
            // 
            this.DevicesListViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.DevicesListViewImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.DevicesListViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DevicesListView
            // 
            this.DevicesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DevicesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DevicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.VolumeColumn,
            this.IsDefaultColumn,
            this.MutedColumn});
            this.DevicesListView.FullRowSelect = true;
            this.DevicesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.DevicesListView.HideSelection = false;
            this.DevicesListView.Location = new System.Drawing.Point(12, 12);
            this.DevicesListView.MultiSelect = false;
            this.DevicesListView.Name = "DevicesListView";
            this.DevicesListView.Size = new System.Drawing.Size(510, 156);
            this.DevicesListView.SmallImageList = this.DevicesListViewImageList;
            this.DevicesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.DevicesListView.TabIndex = 4;
            this.DevicesListView.UseCompatibleStateImageBehavior = false;
            this.DevicesListView.View = System.Windows.Forms.View.Details;
            this.DevicesListView.SelectedIndexChanged += new System.EventHandler(this.DevicesListView_SelectedIndexChanged);
            this.DevicesListView.DoubleClick += new System.EventHandler(this.DevicesListView_DoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 300;
            // 
            // VolumeColumn
            // 
            this.VolumeColumn.Text = "Volume";
            // 
            // IsDefaultColumn
            // 
            this.IsDefaultColumn.Text = "Default";
            // 
            // MutedColumn
            // 
            this.MutedColumn.Text = "Muted";
            // 
            // AudioPlaybackDevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 211);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DevicesListView);
            this.Controls.Add(this.MakeDefaultButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioPlaybackDevicesForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Playback Devices (tb-vol-scroll)";
            this.Deactivate += new System.EventHandler(this.AudioPlaybackDevicesForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioPlaybackDevicesForm_FormClosing);
            this.Shown += new System.EventHandler(this.AudioPlaybackDevicesForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button RefreshButton;
        private ListViewExt DevicesListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader IsDefaultColumn;
        private System.Windows.Forms.ColumnHeader VolumeColumn;
        private System.Windows.Forms.ColumnHeader MutedColumn;
        private System.Windows.Forms.Button MakeDefaultButton;
        private System.Windows.Forms.ImageList DevicesListViewImageList;
    }
}