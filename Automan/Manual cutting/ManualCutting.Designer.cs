namespace NanoExperiment.Cutting
{
    partial class ManualCutting
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
            this.showPictureBox = new System.Windows.Forms.PictureBox();
            this.manualCuttingContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutomanipulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualCuttingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nanodrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nanobitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.Xmin = new System.Windows.Forms.Label();
            this.X0 = new System.Windows.Forms.Label();
            this.Xmax = new System.Windows.Forms.Label();
            this.Ymin = new System.Windows.Forms.Label();
            this.Y0 = new System.Windows.Forms.Label();
            this.Ymax = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pathSavedStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).BeginInit();
            this.manualCuttingContextMenuStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.picturePanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showPictureBox
            // 
            this.showPictureBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.showPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showPictureBox.ContextMenuStrip = this.manualCuttingContextMenuStrip;
            this.showPictureBox.Location = new System.Drawing.Point(0, -1);
            this.showPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.showPictureBox.Name = "showPictureBox";
            this.showPictureBox.Size = new System.Drawing.Size(650, 650);
            this.showPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPictureBox.TabIndex = 4;
            this.showPictureBox.TabStop = false;
            this.showPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.showPictureBox_Paint);
            this.showPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseDown);
            this.showPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseMove);
            // 
            // manualCuttingContextMenuStrip
            // 
            this.manualCuttingContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.manualCuttingContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPathToolStripMenuItem,
            this.deleteLastToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.manualCuttingContextMenuStrip.Name = "ContextMenuStrip";
            this.manualCuttingContextMenuStrip.Size = new System.Drawing.Size(156, 100);
            // 
            // addPathToolStripMenuItem
            // 
            this.addPathToolStripMenuItem.Name = "addPathToolStripMenuItem";
            this.addPathToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.addPathToolStripMenuItem.Text = "Add Path";
            this.addPathToolStripMenuItem.Click += new System.EventHandler(this.addPathToolStripMenuItem_Click);
            // 
            // deleteLastToolStripMenuItem
            // 
            this.deleteLastToolStripMenuItem.Name = "deleteLastToolStripMenuItem";
            this.deleteLastToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.deleteLastToolStripMenuItem.Text = "Delete last";
            this.deleteLastToolStripMenuItem.Click += new System.EventHandler(this.deleteLastToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.deleteAllToolStripMenuItem.Text = "Delete all";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.experimentToolStripMenuItem,
            this.parameterToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(797, 28);
            this.mainMenu.TabIndex = 5;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.savePathToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // pictureToolStripMenuItem
            // 
            this.pictureToolStripMenuItem.Name = "pictureToolStripMenuItem";
            this.pictureToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.pictureToolStripMenuItem.Text = "Picture";
            this.pictureToolStripMenuItem.Click += new System.EventHandler(this.pictureToolStripMenuItem_Click);
            // 
            // savePathToolStripMenuItem
            // 
            this.savePathToolStripMenuItem.Name = "savePathToolStripMenuItem";
            this.savePathToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.savePathToolStripMenuItem.Text = "Export Path";
            this.savePathToolStripMenuItem.Click += new System.EventHandler(this.savePathToolStripMenuItem_Click);
            // 
            // experimentToolStripMenuItem
            // 
            this.experimentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutomanipulationToolStripMenuItem,
            this.manualCuttingToolStripMenuItem,
            this.nanodrawToolStripMenuItem,
            this.nanobitmapToolStripMenuItem});
            this.experimentToolStripMenuItem.Name = "experimentToolStripMenuItem";
            this.experimentToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.experimentToolStripMenuItem.Text = "Experiment";
            // 
            // AutomanipulationToolStripMenuItem
            // 
            this.AutomanipulationToolStripMenuItem.Name = "AutomanipulationToolStripMenuItem";
            this.AutomanipulationToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.AutomanipulationToolStripMenuItem.Text = "Automatic manipulation";
            this.AutomanipulationToolStripMenuItem.Click += new System.EventHandler(this.AutomanipulationToolStripMenuItem_Click);
            // 
            // manualCuttingToolStripMenuItem
            // 
            this.manualCuttingToolStripMenuItem.Name = "manualCuttingToolStripMenuItem";
            this.manualCuttingToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.manualCuttingToolStripMenuItem.Text = "Manual Cutting";
            this.manualCuttingToolStripMenuItem.Click += new System.EventHandler(this.manualCuttingToolStripMenuItem_Click);
            // 
            // nanodrawToolStripMenuItem
            // 
            this.nanodrawToolStripMenuItem.Name = "nanodrawToolStripMenuItem";
            this.nanodrawToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.nanodrawToolStripMenuItem.Text = "Nanodraw";
            this.nanodrawToolStripMenuItem.Click += new System.EventHandler(this.nanodrawToolStripMenuItem_Click);
            // 
            // nanobitmapToolStripMenuItem
            // 
            this.nanobitmapToolStripMenuItem.Name = "nanobitmapToolStripMenuItem";
            this.nanobitmapToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.nanobitmapToolStripMenuItem.Text = "Nanobitmap";
            this.nanobitmapToolStripMenuItem.Click += new System.EventHandler(this.nanobitmapToolStripMenuItem_Click);
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathToolStripMenuItem});
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.parameterToolStripMenuItem.Text = "Parameter";
            // 
            // pathToolStripMenuItem
            // 
            this.pathToolStripMenuItem.Name = "pathToolStripMenuItem";
            this.pathToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.pathToolStripMenuItem.Text = "Path";
            this.pathToolStripMenuItem.Click += new System.EventHandler(this.pathToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // picturePanel
            // 
            this.picturePanel.BackColor = System.Drawing.SystemColors.GrayText;
            this.picturePanel.Controls.Add(this.showPictureBox);
            this.picturePanel.Location = new System.Drawing.Point(53, 46);
            this.picturePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(650, 650);
            this.picturePanel.TabIndex = 6;
            // 
            // Xmin
            // 
            this.Xmin.AutoSize = true;
            this.Xmin.Location = new System.Drawing.Point(51, 675);
            this.Xmin.Name = "Xmin";
            this.Xmin.Size = new System.Drawing.Size(0, 15);
            this.Xmin.TabIndex = 7;
            // 
            // X0
            // 
            this.X0.AutoSize = true;
            this.X0.Location = new System.Drawing.Point(364, 698);
            this.X0.Name = "X0";
            this.X0.Size = new System.Drawing.Size(31, 15);
            this.X0.TabIndex = 8;
            this.X0.Text = "0um";
            // 
            // Xmax
            // 
            this.Xmax.AutoSize = true;
            this.Xmax.Location = new System.Drawing.Point(693, 675);
            this.Xmax.Name = "Xmax";
            this.Xmax.Size = new System.Drawing.Size(0, 15);
            this.Xmax.TabIndex = 9;
            // 
            // Ymin
            // 
            this.Ymin.AutoSize = true;
            this.Ymin.Location = new System.Drawing.Point(11, 651);
            this.Ymin.Name = "Ymin";
            this.Ymin.Size = new System.Drawing.Size(0, 15);
            this.Ymin.TabIndex = 10;
            // 
            // Y0
            // 
            this.Y0.AutoSize = true;
            this.Y0.Location = new System.Drawing.Point(20, 348);
            this.Y0.Name = "Y0";
            this.Y0.Size = new System.Drawing.Size(31, 15);
            this.Y0.TabIndex = 11;
            this.Y0.Text = "0um";
            // 
            // Ymax
            // 
            this.Ymax.AutoSize = true;
            this.Ymax.Location = new System.Drawing.Point(15, 46);
            this.Ymax.Name = "Ymax";
            this.Ymax.Size = new System.Drawing.Size(0, 15);
            this.Ymax.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathSavedStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 743);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(797, 25);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pathSavedStripStatusLabel
            // 
            this.pathSavedStripStatusLabel.Name = "pathSavedStripStatusLabel";
            this.pathSavedStripStatusLabel.Size = new System.Drawing.Size(109, 20);
            this.pathSavedStripStatusLabel.Text = "Path saved at ";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // ManualCutting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 768);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Ymax);
            this.Controls.Add(this.Y0);
            this.Controls.Add(this.Ymin);
            this.Controls.Add(this.Xmax);
            this.Controls.Add(this.X0);
            this.Controls.Add(this.Xmin);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManualCutting";
            this.Text = "Nanoman";
            this.Load += new System.EventHandler(this.ManualCutting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).EndInit();
            this.manualCuttingContextMenuStrip.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.picturePanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox showPictureBox;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem experimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutomanipulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nanobitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Label Xmin;
        private System.Windows.Forms.Label X0;
        private System.Windows.Forms.Label Xmax;
        private System.Windows.Forms.Label Ymin;
        private System.Windows.Forms.Label Y0;
        private System.Windows.Forms.Label Ymax;
        private System.Windows.Forms.ContextMenuStrip manualCuttingContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel pathSavedStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem nanodrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualCuttingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
    }
}