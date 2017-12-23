namespace MultiMode.Nanomanipulation
{
    partial class ChangeWireProperties
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rotationPivot = new System.Windows.Forms.ComboBox();
            this.position = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SoftOrStiff = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(33, 164);
            this.Confirm.Margin = new System.Windows.Forms.Padding(4);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(100, 29);
            this.Confirm.TabIndex = 8;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(155, 164);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(100, 29);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rotationPivot);
            this.groupBox1.Controls.Add(this.position);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SoftOrStiff);
            this.groupBox1.Controls.Add(this.textBox);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 141);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // rotationPivot
            // 
            this.rotationPivot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.rotationPivot.FormattingEnabled = true;
            this.rotationPivot.Items.AddRange(new object[] {
            "0",
            "0.5",
            "1"});
            this.rotationPivot.Location = new System.Drawing.Point(144, 104);
            this.rotationPivot.Margin = new System.Windows.Forms.Padding(4);
            this.rotationPivot.Name = "rotationPivot";
            this.rotationPivot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rotationPivot.Size = new System.Drawing.Size(77, 23);
            this.rotationPivot.TabIndex = 12;
            this.rotationPivot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rotationPivot_KeyPress);
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Location = new System.Drawing.Point(11, 105);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(119, 15);
            this.position.TabIndex = 11;
            this.position.Text = "Rotation pivot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Diameter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Soft or Stiff";
            // 
            // SoftOrStiff
            // 
            this.SoftOrStiff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SoftOrStiff.FormattingEnabled = true;
            this.SoftOrStiff.Items.AddRange(new object[] {
            "soft",
            "stiff"});
            this.SoftOrStiff.Location = new System.Drawing.Point(144, 35);
            this.SoftOrStiff.Margin = new System.Windows.Forms.Padding(4);
            this.SoftOrStiff.Name = "SoftOrStiff";
            this.SoftOrStiff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SoftOrStiff.Size = new System.Drawing.Size(77, 23);
            this.SoftOrStiff.TabIndex = 11;
            this.SoftOrStiff.SelectedIndexChanged += new System.EventHandler(this.SoftOrStiff_SelectedIndexChanged);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(144, 68);
            this.textBox.Margin = new System.Windows.Forms.Padding(4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(77, 25);
            this.textBox.TabIndex = 9;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // ChangeWireProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 215);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangeWireProperties";
            this.Text = "ChangeWireProperties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.TextBox textBox;
        public System.Windows.Forms.ComboBox SoftOrStiff;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox rotationPivot;
        public System.Windows.Forms.Label position;
    }
}