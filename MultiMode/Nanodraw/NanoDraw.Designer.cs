namespace MultiMode.Nanodraw
{
    partial class NanoDraw
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
            this.line = new System.Windows.Forms.Button();
            this.arc = new System.Windows.Forms.Button();
            this.lineWidth = new System.Windows.Forms.Label();
            this.lineWidthinput = new System.Windows.Forms.TextBox();
            this.click = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(50, 34);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(76, 23);
            this.line.TabIndex = 0;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // arc
            // 
            this.arc.Location = new System.Drawing.Point(50, 72);
            this.arc.Name = "arc";
            this.arc.Size = new System.Drawing.Size(76, 27);
            this.arc.TabIndex = 1;
            this.arc.Text = "Arc";
            this.arc.UseVisualStyleBackColor = true;
            this.arc.Click += new System.EventHandler(this.arc_Click);
            // 
            // lineWidth
            // 
            this.lineWidth.AutoSize = true;
            this.lineWidth.Location = new System.Drawing.Point(53, 163);
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(65, 12);
            this.lineWidth.TabIndex = 2;
            this.lineWidth.Text = "Line Width";
            // 
            // lineWidthinput
            // 
            this.lineWidthinput.Location = new System.Drawing.Point(138, 160);
            this.lineWidthinput.Name = "lineWidthinput";
            this.lineWidthinput.Size = new System.Drawing.Size(76, 21);
            this.lineWidthinput.TabIndex = 3;
            // 
            // click
            // 
            this.click.Location = new System.Drawing.Point(50, 115);
            this.click.Name = "click";
            this.click.Size = new System.Drawing.Size(75, 23);
            this.click.TabIndex = 4;
            this.click.Text = "Circle";
            this.click.UseVisualStyleBackColor = true;
            this.click.Click += new System.EventHandler(this.circle_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(271, 34);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(212, 169);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // NanoDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 408);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.click);
            this.Controls.Add(this.lineWidthinput);
            this.Controls.Add(this.lineWidth);
            this.Controls.Add(this.arc);
            this.Controls.Add(this.line);
            this.Name = "NanoDraw";
            this.Text = "NanoDraw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button arc;
        private System.Windows.Forms.Label lineWidth;
        private System.Windows.Forms.TextBox lineWidthinput;
        private System.Windows.Forms.Button click;
        private System.Windows.Forms.TreeView treeView1;
    }
}