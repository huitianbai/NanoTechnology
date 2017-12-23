namespace autodetect
{
    partial class CannyParameters
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
            this.highThreshold = new System.Windows.Forms.TextBox();
            this.lowThreshold = new System.Windows.Forms.TextBox();
            this.Sigma = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.TH = new System.Windows.Forms.TextBox();
            this.TL = new System.Windows.Forms.TextBox();
            this.Sig = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // highThreshold
            // 
            this.highThreshold.BackColor = System.Drawing.SystemColors.Menu;
            this.highThreshold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.highThreshold.Location = new System.Drawing.Point(45, 26);
            this.highThreshold.Name = "highThreshold";
            this.highThreshold.ReadOnly = true;
            this.highThreshold.Size = new System.Drawing.Size(100, 14);
            this.highThreshold.TabIndex = 0;
            this.highThreshold.Text = "High Threshold :";
            // 
            // lowThreshold
            // 
            this.lowThreshold.BackColor = System.Drawing.SystemColors.Menu;
            this.lowThreshold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lowThreshold.Location = new System.Drawing.Point(41, 54);
            this.lowThreshold.Name = "lowThreshold";
            this.lowThreshold.ReadOnly = true;
            this.lowThreshold.Size = new System.Drawing.Size(100, 14);
            this.lowThreshold.TabIndex = 1;
            this.lowThreshold.Text = "Low Threshold :";
            this.lowThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Sigma
            // 
            this.Sigma.BackColor = System.Drawing.SystemColors.Menu;
            this.Sigma.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Sigma.Location = new System.Drawing.Point(41, 82);
            this.Sigma.Name = "Sigma";
            this.Sigma.ReadOnly = true;
            this.Sigma.Size = new System.Drawing.Size(100, 14);
            this.Sigma.TabIndex = 3;
            this.Sigma.Text = "Sigma :";
            this.Sigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(47, 113);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 4;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(146, 113);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // TH
            // 
            this.TH.Location = new System.Drawing.Point(156, 23);
            this.TH.Name = "TH";
            this.TH.Size = new System.Drawing.Size(60, 21);
            this.TH.TabIndex = 6;
            // 
            // TL
            // 
            this.TL.Location = new System.Drawing.Point(156, 50);
            this.TL.Name = "TL";
            this.TL.Size = new System.Drawing.Size(60, 21);
            this.TL.TabIndex = 7;
            // 
            // Sig
            // 
            this.Sig.Location = new System.Drawing.Point(156, 79);
            this.Sig.Name = "Sig";
            this.Sig.Size = new System.Drawing.Size(60, 21);
            this.Sig.TabIndex = 9;
            // 
            // CannyParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 173);
            this.Controls.Add(this.Sig);
            this.Controls.Add(this.TL);
            this.Controls.Add(this.TH);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Sigma);
            this.Controls.Add(this.lowThreshold);
            this.Controls.Add(this.highThreshold);
            this.Name = "CannyParameters";
            this.Text = "CannyParameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox highThreshold;
        private System.Windows.Forms.TextBox lowThreshold;
        private System.Windows.Forms.TextBox Sigma;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox TH;
        private System.Windows.Forms.TextBox TL;
        private System.Windows.Forms.TextBox Sig;
    }
}