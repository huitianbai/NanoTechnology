namespace NanoExperiment.Automanipulation
{
    partial class PictureMode
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
            this.pictureComboBox = new System.Windows.Forms.ComboBox();
            this.pictureColorType = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pictureComboBox
            // 
            this.pictureComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.pictureComboBox.FormattingEnabled = true;
            this.pictureComboBox.Items.AddRange(new object[] {
            "Grey",
            "Iron",
            "Rainbow"});
            this.pictureComboBox.Location = new System.Drawing.Point(113, 18);
            this.pictureComboBox.Name = "pictureComboBox";
            this.pictureComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pictureComboBox.Size = new System.Drawing.Size(94, 20);
            this.pictureComboBox.TabIndex = 0;
            this.pictureComboBox.SelectedIndexChanged += new System.EventHandler(this.pictureComboBox_SelectedIndexChanged);
            // 
            // pictureColorType
            // 
            this.pictureColorType.BackColor = System.Drawing.SystemColors.Control;
            this.pictureColorType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pictureColorType.Location = new System.Drawing.Point(36, 21);
            this.pictureColorType.Name = "pictureColorType";
            this.pictureColorType.Size = new System.Drawing.Size(73, 14);
            this.pictureColorType.TabIndex = 1;
            this.pictureColorType.Text = "Color Type";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(33, 51);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(66, 22);
            this.Confirm.TabIndex = 2;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(123, 51);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(74, 22);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PictureMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 87);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.pictureColorType);
            this.Controls.Add(this.pictureComboBox);
            this.Name = "PictureMode";
            this.Text = "PictureMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pictureComboBox;
        private System.Windows.Forms.TextBox pictureColorType;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
    }
}