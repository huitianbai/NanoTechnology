namespace MultiMode
{
    partial class ModeSelect
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
            this.modeGroupBox = new System.Windows.Forms.GroupBox();
            this.nanobitmap = new System.Windows.Forms.RadioButton();
            this.nanoman = new System.Windows.Forms.RadioButton();
            this.nanomanipulation = new System.Windows.Forms.RadioButton();
            this.load = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.modeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // modeGroupBox
            // 
            this.modeGroupBox.Controls.Add(this.nanobitmap);
            this.modeGroupBox.Controls.Add(this.nanoman);
            this.modeGroupBox.Controls.Add(this.nanomanipulation);
            this.modeGroupBox.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modeGroupBox.Location = new System.Drawing.Point(12, 11);
            this.modeGroupBox.Name = "modeGroupBox";
            this.modeGroupBox.Size = new System.Drawing.Size(270, 146);
            this.modeGroupBox.TabIndex = 0;
            this.modeGroupBox.TabStop = false;
            this.modeGroupBox.Text = "Select experiment";
            // 
            // nanobitmap
            // 
            this.nanobitmap.AutoSize = true;
            this.nanobitmap.Location = new System.Drawing.Point(42, 108);
            this.nanobitmap.Name = "nanobitmap";
            this.nanobitmap.Size = new System.Drawing.Size(116, 19);
            this.nanobitmap.TabIndex = 2;
            this.nanobitmap.TabStop = true;
            this.nanobitmap.Text = "Nano-bitmap";
            this.nanobitmap.UseVisualStyleBackColor = true;
            // 
            // nanoman
            // 
            this.nanoman.AutoSize = true;
            this.nanoman.Location = new System.Drawing.Point(42, 69);
            this.nanoman.Name = "nanoman";
            this.nanoman.Size = new System.Drawing.Size(180, 19);
            this.nanoman.TabIndex = 1;
            this.nanoman.TabStop = true;
            this.nanoman.Text = "Traditional Nanoman";
            this.nanoman.UseVisualStyleBackColor = true;
            // 
            // nanomanipulation
            // 
            this.nanomanipulation.AutoSize = true;
            this.nanomanipulation.Location = new System.Drawing.Point(42, 31);
            this.nanomanipulation.Name = "nanomanipulation";
            this.nanomanipulation.Size = new System.Drawing.Size(164, 19);
            this.nanomanipulation.TabIndex = 0;
            this.nanomanipulation.TabStop = true;
            this.nanomanipulation.Text = "Nano-manipulation";
            this.nanomanipulation.UseVisualStyleBackColor = true;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(41, 161);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 35);
            this.load.TabIndex = 1;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(173, 162);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 35);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ModeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 211);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.load);
            this.Controls.Add(this.modeGroupBox);
            this.MaximizeBox = false;
            this.Name = "ModeSelect";
            this.Text = "ModeSelect";
            this.modeGroupBox.ResumeLayout(false);
            this.modeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox modeGroupBox;
        private System.Windows.Forms.RadioButton nanobitmap;
        private System.Windows.Forms.RadioButton nanoman;
        private System.Windows.Forms.RadioButton nanomanipulation;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button cancel;
    }
}

