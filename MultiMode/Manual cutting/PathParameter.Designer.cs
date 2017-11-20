namespace MultiMode.Nanoman
{
    partial class PathParameter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pushSpeedTextBox = new System.Windows.Forms.TextBox();
            this.hangSpeedTextBox = new System.Windows.Forms.TextBox();
            this.zStepTextBox = new System.Windows.Forms.TextBox();
            this.pushSpeedLabel = new System.Windows.Forms.Label();
            this.hangSpeedLabel = new System.Windows.Forms.Label();
            this.zStepLabel = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pushSpeedTextBox);
            this.groupBox1.Controls.Add(this.hangSpeedTextBox);
            this.groupBox1.Controls.Add(this.zStepTextBox);
            this.groupBox1.Controls.Add(this.pushSpeedLabel);
            this.groupBox1.Controls.Add(this.hangSpeedLabel);
            this.groupBox1.Controls.Add(this.zStepLabel);
            this.groupBox1.Location = new System.Drawing.Point(49, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 176);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Path Paremeters";
            // 
            // pushSpeedTextBox
            // 
            this.pushSpeedTextBox.Location = new System.Drawing.Point(156, 39);
            this.pushSpeedTextBox.Name = "pushSpeedTextBox";
            this.pushSpeedTextBox.Size = new System.Drawing.Size(100, 25);
            this.pushSpeedTextBox.TabIndex = 16;
            this.pushSpeedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pushSpeedTextBox_KeyPress);
            // 
            // hangSpeedTextBox
            // 
            this.hangSpeedTextBox.Location = new System.Drawing.Point(156, 84);
            this.hangSpeedTextBox.Name = "hangSpeedTextBox";
            this.hangSpeedTextBox.Size = new System.Drawing.Size(100, 25);
            this.hangSpeedTextBox.TabIndex = 15;
            this.hangSpeedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hangSpeedTextBox_KeyPress);
            // 
            // zStepTextBox
            // 
            this.zStepTextBox.Location = new System.Drawing.Point(156, 128);
            this.zStepTextBox.Name = "zStepTextBox";
            this.zStepTextBox.Size = new System.Drawing.Size(100, 25);
            this.zStepTextBox.TabIndex = 12;
            this.zStepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zStepTextBox_KeyPress);
            // 
            // pushSpeedLabel
            // 
            this.pushSpeedLabel.AutoSize = true;
            this.pushSpeedLabel.Location = new System.Drawing.Point(44, 42);
            this.pushSpeedLabel.Name = "pushSpeedLabel";
            this.pushSpeedLabel.Size = new System.Drawing.Size(87, 15);
            this.pushSpeedLabel.TabIndex = 3;
            this.pushSpeedLabel.Text = "push speed";
            // 
            // hangSpeedLabel
            // 
            this.hangSpeedLabel.AutoSize = true;
            this.hangSpeedLabel.Location = new System.Drawing.Point(45, 89);
            this.hangSpeedLabel.Name = "hangSpeedLabel";
            this.hangSpeedLabel.Size = new System.Drawing.Size(87, 15);
            this.hangSpeedLabel.TabIndex = 2;
            this.hangSpeedLabel.Text = "hang speed";
            // 
            // zStepLabel
            // 
            this.zStepLabel.AutoSize = true;
            this.zStepLabel.Location = new System.Drawing.Point(77, 132);
            this.zStepLabel.Name = "zStepLabel";
            this.zStepLabel.Size = new System.Drawing.Size(55, 15);
            this.zStepLabel.TabIndex = 5;
            this.zStepLabel.Text = "z step";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(71, 232);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(90, 28);
            this.confirm.TabIndex = 12;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(230, 232);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 28);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // PathParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 285);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "PathParameter";
            this.Text = "PathParameter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox pushSpeedTextBox;
        private System.Windows.Forms.TextBox hangSpeedTextBox;
        private System.Windows.Forms.TextBox zStepTextBox;
        private System.Windows.Forms.Label pushSpeedLabel;
        private System.Windows.Forms.Label hangSpeedLabel;
        private System.Windows.Forms.Label zStepLabel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}