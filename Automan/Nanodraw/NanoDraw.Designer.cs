namespace NanoExperiment.Nanodraw
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Line");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Arc");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Cirle");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Path", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.line = new System.Windows.Forms.Button();
            this.arc = new System.Windows.Forms.Button();
            this.lineWidth = new System.Windows.Forms.Label();
            this.lineWidthinput = new System.Windows.Forms.TextBox();
            this.click = new System.Windows.Forms.Button();
            this.pathTree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deteleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(67, 42);
            this.line.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(101, 29);
            this.line.TabIndex = 0;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // arc
            // 
            this.arc.Location = new System.Drawing.Point(67, 90);
            this.arc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.arc.Name = "arc";
            this.arc.Size = new System.Drawing.Size(101, 34);
            this.arc.TabIndex = 1;
            this.arc.Text = "Arc";
            this.arc.UseVisualStyleBackColor = true;
            this.arc.Click += new System.EventHandler(this.arc_Click);
            // 
            // lineWidth
            // 
            this.lineWidth.AutoSize = true;
            this.lineWidth.Location = new System.Drawing.Point(71, 204);
            this.lineWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(87, 15);
            this.lineWidth.TabIndex = 2;
            this.lineWidth.Text = "Line Width";
            // 
            // lineWidthinput
            // 
            this.lineWidthinput.Location = new System.Drawing.Point(184, 200);
            this.lineWidthinput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lineWidthinput.Name = "lineWidthinput";
            this.lineWidthinput.Size = new System.Drawing.Size(100, 25);
            this.lineWidthinput.TabIndex = 3;
            this.lineWidthinput.TextChanged += new System.EventHandler(this.lineWidthinput_TextChanged);
            // 
            // click
            // 
            this.click.Location = new System.Drawing.Point(67, 144);
            this.click.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.click.Name = "click";
            this.click.Size = new System.Drawing.Size(100, 29);
            this.click.TabIndex = 4;
            this.click.Text = "Circle";
            this.click.UseVisualStyleBackColor = true;
            this.click.Click += new System.EventHandler(this.circle_Click);
            // 
            // pathTree
            // 
            this.pathTree.Location = new System.Drawing.Point(361, 42);
            this.pathTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pathTree.Name = "pathTree";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode1.Checked = true;
            treeNode1.Name = "Line";
            treeNode1.Text = "Line";
            treeNode2.Checked = true;
            treeNode2.Name = "Arc";
            treeNode2.Text = "Arc";
            treeNode3.Checked = true;
            treeNode3.Name = "Circle";
            treeNode3.Text = "Cirle";
            treeNode4.BackColor = System.Drawing.Color.Silver;
            treeNode4.Checked = true;
            treeNode4.Name = "Path";
            treeNode4.Text = "Path";
            this.pathTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.pathTree.Size = new System.Drawing.Size(305, 452);
            this.pathTree.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deteleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 28);
            this.contextMenuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip1_MouseDown);
            // 
            // deteleToolStripMenuItem
            // 
            this.deteleToolStripMenuItem.Name = "deteleToolStripMenuItem";
            this.deteleToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.deteleToolStripMenuItem.Text = "Detele";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pixel";
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(97, 314);
            this.Generate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(100, 29);
            this.Generate.TabIndex = 8;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // NanoDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 510);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTree);
            this.Controls.Add(this.click);
            this.Controls.Add(this.lineWidthinput);
            this.Controls.Add(this.lineWidth);
            this.Controls.Add(this.arc);
            this.Controls.Add(this.line);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NanoDraw";
            this.Text = "NanoDraw";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NanoDraw_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button arc;
        private System.Windows.Forms.Label lineWidth;
        private System.Windows.Forms.TextBox lineWidthinput;
        private System.Windows.Forms.Button click;
        private System.Windows.Forms.TreeView pathTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deteleToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Generate;
    }
}