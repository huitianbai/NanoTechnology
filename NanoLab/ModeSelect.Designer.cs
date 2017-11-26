namespace NanoExperiment
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
            this.manualCutting = new System.Windows.Forms.RadioButton();
            this.automanipulation = new System.Windows.Forms.RadioButton();
            this.load = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.nanodraw = new System.Windows.Forms.RadioButton();
            this.modeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // modeGroupBox
            // 
            this.modeGroupBox.Controls.Add(this.nanodraw);
            this.modeGroupBox.Controls.Add(this.nanobitmap);
            this.modeGroupBox.Controls.Add(this.manualCutting);
            this.modeGroupBox.Controls.Add(this.automanipulation);
            this.modeGroupBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modeGroupBox.Location = new System.Drawing.Point(12, 11);
            this.modeGroupBox.Name = "modeGroupBox";
            this.modeGroupBox.Size = new System.Drawing.Size(270, 180);
            this.modeGroupBox.TabIndex = 0;
            this.modeGroupBox.TabStop = false;
            this.modeGroupBox.Text = "Select experiment";
            // 
            // nanobitmap
            // 
            this.nanobitmap.AutoSize = true;
            this.nanobitmap.Location = new System.Drawing.Point(42, 142);
            this.nanobitmap.Name = "nanobitmap";
            this.nanobitmap.Size = new System.Drawing.Size(116, 19);
            this.nanobitmap.TabIndex = 2;
            this.nanobitmap.TabStop = true;
            this.nanobitmap.Text = "Nano-bitmap";
            this.nanobitmap.UseVisualStyleBackColor = true;
            // 
            // manualCutting
            // 
            this.manualCutting.AutoSize = true;
            this.manualCutting.Location = new System.Drawing.Point(42, 69);
            this.manualCutting.Name = "manualCutting";
            this.manualCutting.Size = new System.Drawing.Size(140, 19);
            this.manualCutting.TabIndex = 1;
            this.manualCutting.TabStop = true;
            this.manualCutting.Text = "Manual cutting";
            this.manualCutting.UseVisualStyleBackColor = true;
            // 
            // automanipulation
            // 
            this.automanipulation.AutoSize = true;
            this.automanipulation.Location = new System.Drawing.Point(42, 31);
            this.automanipulation.Name = "automanipulation";
            this.automanipulation.Size = new System.Drawing.Size(204, 19);
            this.automanipulation.TabIndex = 0;
            this.automanipulation.TabStop = true;
            this.automanipulation.Text = "Automatic manipulation";
            this.automanipulation.UseVisualStyleBackColor = true;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(41, 209);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 35);
            this.load.TabIndex = 1;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(173, 208);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 35);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // nanodraw
            // 
            this.nanodraw.AutoSize = true;
            this.nanodraw.Location = new System.Drawing.Point(42, 105);
            this.nanodraw.Name = "nanodraw";
            this.nanodraw.Size = new System.Drawing.Size(92, 19);
            this.nanodraw.TabIndex = 3;
            this.nanodraw.TabStop = true;
            this.nanodraw.Text = "Nanodraw";
            this.nanodraw.UseVisualStyleBackColor = true;
            // 
            // ModeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 275);
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
        private System.Windows.Forms.RadioButton manualCutting;
        private System.Windows.Forms.RadioButton automanipulation;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.RadioButton nanodraw;
    }
}

