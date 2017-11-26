namespace NanoExperiment.Automanipulation
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
            this.eLabel = new System.Windows.Forms.Label();
            this.qLabel = new System.Windows.Forms.Label();
            this.hangVelocityLabel = new System.Windows.Forms.Label();
            this.xyVelocityLabel = new System.Windows.Forms.Label();
            this.pushStepLabel = new System.Windows.Forms.Label();
            this.zStepLabel = new System.Windows.Forms.Label();
            this.tLabel = new System.Windows.Forms.Label();
            this.tipRadiusLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tTextBox = new System.Windows.Forms.TextBox();
            this.qTextBox = new System.Windows.Forms.TextBox();
            this.tipRadiusTextBox = new System.Windows.Forms.TextBox();
            this.pushSpeedTextBox = new System.Windows.Forms.TextBox();
            this.hangSpeedTextBox = new System.Windows.Forms.TextBox();
            this.pushStepTextBox = new System.Windows.Forms.TextBox();
            this.zStepTextBox = new System.Windows.Forms.TextBox();
            this.eTextBox = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.zvelocity = new System.Windows.Forms.Label();
            this.zVelocityTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eLabel
            // 
            this.eLabel.AutoSize = true;
            this.eLabel.Location = new System.Drawing.Point(40, 40);
            this.eLabel.Name = "eLabel";
            this.eLabel.Size = new System.Drawing.Size(127, 15);
            this.eLabel.TabIndex = 0;
            this.eLabel.Text = "elastic modulus";
            // 
            // qLabel
            // 
            this.qLabel.AutoSize = true;
            this.qLabel.Location = new System.Drawing.Point(290, 40);
            this.qLabel.Name = "qLabel";
            this.qLabel.Size = new System.Drawing.Size(263, 15);
            this.qLabel.TabIndex = 1;
            this.qLabel.Text = "dynamic friction per unit length";
            // 
            // hangVelocityLabel
            // 
            this.hangVelocityLabel.AutoSize = true;
            this.hangVelocityLabel.Location = new System.Drawing.Point(385, 93);
            this.hangVelocityLabel.Name = "hangVelocityLabel";
            this.hangVelocityLabel.Size = new System.Drawing.Size(167, 15);
            this.hangVelocityLabel.TabIndex = 2;
            this.hangVelocityLabel.Text = "tip hanging velocity";
            // 
            // xyVelocityLabel
            // 
            this.xyVelocityLabel.AutoSize = true;
            this.xyVelocityLabel.Location = new System.Drawing.Point(72, 91);
            this.xyVelocityLabel.Name = "xyVelocityLabel";
            this.xyVelocityLabel.Size = new System.Drawing.Size(95, 15);
            this.xyVelocityLabel.TabIndex = 3;
            this.xyVelocityLabel.Text = "XY velocity";
            // 
            // pushStepLabel
            // 
            this.pushStepLabel.AutoSize = true;
            this.pushStepLabel.Location = new System.Drawing.Point(474, 143);
            this.pushStepLabel.Name = "pushStepLabel";
            this.pushStepLabel.Size = new System.Drawing.Size(79, 15);
            this.pushStepLabel.TabIndex = 4;
            this.pushStepLabel.Text = "push step";
            // 
            // zStepLabel
            // 
            this.zStepLabel.AutoSize = true;
            this.zStepLabel.Location = new System.Drawing.Point(112, 143);
            this.zStepLabel.Name = "zStepLabel";
            this.zStepLabel.Size = new System.Drawing.Size(55, 15);
            this.zStepLabel.TabIndex = 5;
            this.zStepLabel.Text = "z step";
            // 
            // tLabel
            // 
            this.tLabel.AutoSize = true;
            this.tLabel.Location = new System.Drawing.Point(16, 194);
            this.tLabel.Name = "tLabel";
            this.tLabel.Size = new System.Drawing.Size(151, 15);
            this.tLabel.TabIndex = 6;
            this.tLabel.Text = "recession distance";
            // 
            // tipRadiusLabel
            // 
            this.tipRadiusLabel.AutoSize = true;
            this.tipRadiusLabel.Location = new System.Drawing.Point(466, 194);
            this.tipRadiusLabel.Name = "tipRadiusLabel";
            this.tipRadiusLabel.Size = new System.Drawing.Size(87, 15);
            this.tipRadiusLabel.TabIndex = 9;
            this.tipRadiusLabel.Text = "tip radius";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zVelocityTextBox);
            this.groupBox1.Controls.Add(this.zvelocity);
            this.groupBox1.Controls.Add(this.tTextBox);
            this.groupBox1.Controls.Add(this.qTextBox);
            this.groupBox1.Controls.Add(this.tipRadiusTextBox);
            this.groupBox1.Controls.Add(this.pushSpeedTextBox);
            this.groupBox1.Controls.Add(this.hangSpeedTextBox);
            this.groupBox1.Controls.Add(this.pushStepTextBox);
            this.groupBox1.Controls.Add(this.zStepTextBox);
            this.groupBox1.Controls.Add(this.eTextBox);
            this.groupBox1.Controls.Add(this.tipRadiusLabel);
            this.groupBox1.Controls.Add(this.eLabel);
            this.groupBox1.Controls.Add(this.qLabel);
            this.groupBox1.Controls.Add(this.tLabel);
            this.groupBox1.Controls.Add(this.xyVelocityLabel);
            this.groupBox1.Controls.Add(this.hangVelocityLabel);
            this.groupBox1.Controls.Add(this.pushStepLabel);
            this.groupBox1.Controls.Add(this.zStepLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 294);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Path Paremeters";
            // 
            // tTextBox
            // 
            this.tTextBox.Location = new System.Drawing.Point(173, 191);
            this.tTextBox.Name = "tTextBox";
            this.tTextBox.Size = new System.Drawing.Size(100, 25);
            this.tTextBox.TabIndex = 20;
            this.tTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tTextBox_KeyPress);
            // 
            // qTextBox
            // 
            this.qTextBox.Location = new System.Drawing.Point(559, 37);
            this.qTextBox.Name = "qTextBox";
            this.qTextBox.Size = new System.Drawing.Size(100, 25);
            this.qTextBox.TabIndex = 19;
            this.qTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qTextBox_KeyPress);
            // 
            // tipRadiusTextBox
            // 
            this.tipRadiusTextBox.Location = new System.Drawing.Point(559, 191);
            this.tipRadiusTextBox.Name = "tipRadiusTextBox";
            this.tipRadiusTextBox.Size = new System.Drawing.Size(100, 25);
            this.tipRadiusTextBox.TabIndex = 18;
            this.tipRadiusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.probeRadiusTextBox_KeyPress);
            // 
            // pushSpeedTextBox
            // 
            this.pushSpeedTextBox.Location = new System.Drawing.Point(173, 88);
            this.pushSpeedTextBox.Name = "pushSpeedTextBox";
            this.pushSpeedTextBox.Size = new System.Drawing.Size(100, 25);
            this.pushSpeedTextBox.TabIndex = 16;
            this.pushSpeedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pushSpeedTextBox_KeyPress);
            // 
            // hangSpeedTextBox
            // 
            this.hangSpeedTextBox.Location = new System.Drawing.Point(559, 88);
            this.hangSpeedTextBox.Name = "hangSpeedTextBox";
            this.hangSpeedTextBox.Size = new System.Drawing.Size(100, 25);
            this.hangSpeedTextBox.TabIndex = 15;
            this.hangSpeedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hangSpeedTextBox_KeyPress);
            // 
            // pushStepTextBox
            // 
            this.pushStepTextBox.Location = new System.Drawing.Point(559, 140);
            this.pushStepTextBox.Name = "pushStepTextBox";
            this.pushStepTextBox.Size = new System.Drawing.Size(100, 25);
            this.pushStepTextBox.TabIndex = 13;
            this.pushStepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pushStepTextBox_KeyPress);
            // 
            // zStepTextBox
            // 
            this.zStepTextBox.Location = new System.Drawing.Point(173, 140);
            this.zStepTextBox.Name = "zStepTextBox";
            this.zStepTextBox.Size = new System.Drawing.Size(100, 25);
            this.zStepTextBox.TabIndex = 12;
            this.zStepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zStepTextBox_KeyPress);
            // 
            // eTextBox
            // 
            this.eTextBox.Location = new System.Drawing.Point(173, 37);
            this.eTextBox.Name = "eTextBox";
            this.eTextBox.Size = new System.Drawing.Size(100, 25);
            this.eTextBox.TabIndex = 10;
            this.eTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eTextBox_KeyPress);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(183, 335);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(90, 28);
            this.confirm.TabIndex = 11;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(440, 334);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 28);
            this.cancel.TabIndex = 12;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // zvelocity
            // 
            this.zvelocity.AutoSize = true;
            this.zvelocity.Location = new System.Drawing.Point(80, 246);
            this.zvelocity.Name = "zvelocity";
            this.zvelocity.Size = new System.Drawing.Size(87, 15);
            this.zvelocity.TabIndex = 21;
            this.zvelocity.Text = "Z velocity";
            // 
            // zVelocityTextBox
            // 
            this.zVelocityTextBox.Location = new System.Drawing.Point(173, 241);
            this.zVelocityTextBox.Name = "zVelocityTextBox";
            this.zVelocityTextBox.Size = new System.Drawing.Size(100, 25);
            this.zVelocityTextBox.TabIndex = 22;
            this.zVelocityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zVelocitytextBox_KeyPress);
            // 
            // PathParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 384);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "PathParameter";
            this.Text = "PathParameter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label eLabel;
        private System.Windows.Forms.Label qLabel;
        private System.Windows.Forms.Label hangVelocityLabel;
        private System.Windows.Forms.Label xyVelocityLabel;
        private System.Windows.Forms.Label pushStepLabel;
        private System.Windows.Forms.Label zStepLabel;
        private System.Windows.Forms.Label tLabel;
        private System.Windows.Forms.Label tipRadiusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox eTextBox;
        private System.Windows.Forms.TextBox tTextBox;
        private System.Windows.Forms.TextBox qTextBox;
        private System.Windows.Forms.TextBox tipRadiusTextBox;
        private System.Windows.Forms.TextBox pushSpeedTextBox;
        private System.Windows.Forms.TextBox hangSpeedTextBox;
        private System.Windows.Forms.TextBox pushStepTextBox;
        private System.Windows.Forms.TextBox zStepTextBox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label zvelocity;
        private System.Windows.Forms.TextBox zVelocityTextBox;
    }
}