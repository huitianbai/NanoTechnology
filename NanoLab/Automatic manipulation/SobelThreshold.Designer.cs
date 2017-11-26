namespace NanoExperiment.Automanipulation
{
    partial class SobelThreshold
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
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.Threshold = new System.Windows.Forms.TextBox();
            this.tvalue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(47, 100);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 5;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(142, 100);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(24, 38);
            this.trackBar.Maximum = 200;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(222, 45);
            this.trackBar.TabIndex = 7;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // Threshold
            // 
            this.Threshold.BackColor = System.Drawing.SystemColors.Control;
            this.Threshold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Threshold.Location = new System.Drawing.Point(12, 18);
            this.Threshold.Name = "Threshold";
            this.Threshold.ReadOnly = true;
            this.Threshold.Size = new System.Drawing.Size(73, 14);
            this.Threshold.TabIndex = 8;
            this.Threshold.Text = "Threshold";
            // 
            // tvalue
            // 
            this.tvalue.BackColor = System.Drawing.SystemColors.Control;
            this.tvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvalue.Location = new System.Drawing.Point(199, 18);
            this.tvalue.Name = "tvalue";
            this.tvalue.Size = new System.Drawing.Size(73, 14);
            this.tvalue.TabIndex = 9;
            // 
            // SobelThreshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 143);
            this.Controls.Add(this.tvalue);
            this.Controls.Add(this.Threshold);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Name = "SobelThreshold";
            this.Text = "SobelThreshold";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TextBox Threshold;
        public System.Windows.Forms.TextBox tvalue;
    }
}