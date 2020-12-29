namespace TbVolScrollNet5.Forms
{
    partial class SetVolumeStepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetVolumeStepForm));
            this.SetVolumeStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SetVolumeStepLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SetVolumeStepNumericUpDown
            // 
            this.SetVolumeStepNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetVolumeStepNumericUpDown.Location = new System.Drawing.Point(77, 47);
            this.SetVolumeStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SetVolumeStepNumericUpDown.Name = "SetVolumeStepNumericUpDown";
            this.SetVolumeStepNumericUpDown.Size = new System.Drawing.Size(49, 22);
            this.SetVolumeStepNumericUpDown.TabIndex = 0;
            this.SetVolumeStepNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SetVolumeStepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SetVolumeStepLabel
            // 
            this.SetVolumeStepLabel.AutoSize = true;
            this.SetVolumeStepLabel.Location = new System.Drawing.Point(33, 9);
            this.SetVolumeStepLabel.Name = "SetVolumeStepLabel";
            this.SetVolumeStepLabel.Size = new System.Drawing.Size(193, 26);
            this.SetVolumeStepLabel.TabIndex = 1;
            this.SetVolumeStepLabel.Text = "Change the volume step percentage\r\nfor each scroll. Default value is 5.";
            this.SetVolumeStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(132, 47);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(50, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveNewVolumeStep);
            // 
            // SetVolumeStepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(259, 81);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SetVolumeStepLabel);
            this.Controls.Add(this.SetVolumeStepNumericUpDown);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetVolumeStepForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Volume Step";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadCurrentVolumeStep);
            ((System.ComponentModel.ISupportInitialize)(this.SetVolumeStepNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SetVolumeStepNumericUpDown;
        private System.Windows.Forms.Label SetVolumeStepLabel;
        private System.Windows.Forms.Button SaveButton;
    }
}