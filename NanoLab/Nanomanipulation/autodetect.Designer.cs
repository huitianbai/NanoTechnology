namespace MultiMode.Nanomanipulation
{
    partial class AutoDetect
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentFigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manulPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nanobitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeRecognitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softStiffThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPictureBox = new System.Windows.Forms.PictureBox();
            this.clearShowPicBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movePictureBox = new System.Windows.Forms.PictureBox();
            this.mouseGetPoint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reselectLastPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.reselect = new System.Windows.Forms.ToolStripMenuItem();
            this.apply = new System.Windows.Forms.ToolStripMenuItem();
            this.abandon = new System.Windows.Forms.ToolStripMenuItem();
            this.runningStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pB = new System.Windows.Forms.ToolStripProgressBar();
            this.pathSavedStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.identify = new System.Windows.Forms.Button();
            this.addNewLine = new System.Windows.Forms.Button();
            this.nanowiresList = new System.Windows.Forms.ListBox();
            this.singleWireMove = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.push = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate = new System.Windows.Forms.ToolStripMenuItem();
            this.properties = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteButton = new System.Windows.Forms.Button();
            this.planPanel = new System.Windows.Forms.Panel();
            this.operationMode = new System.Windows.Forms.TabControl();
            this.identificationTabPage = new System.Windows.Forms.TabPage();
            this.manipulationTabPage = new System.Windows.Forms.TabPage();
            this.orderTextBox = new System.Windows.Forms.TextBox();
            this.simulateContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.simulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTarget = new System.Windows.Forms.Button();
            this.orderLabel = new System.Windows.Forms.Label();
            this.compute = new System.Windows.Forms.Button();
            this.nanowireListLabel = new System.Windows.Forms.Label();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.picturePanel1 = new System.Windows.Forms.Panel();
            this.displayPictureBox = new System.Windows.Forms.PictureBox();
            this.Y0 = new System.Windows.Forms.Label();
            this.MX0 = new System.Windows.Forms.Label();
            this.MXmin = new System.Windows.Forms.Label();
            this.MXmax = new System.Windows.Forms.Label();
            this.Ymin = new System.Windows.Forms.Label();
            this.Ymax = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).BeginInit();
            this.clearShowPicBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movePictureBox)).BeginInit();
            this.mouseGetPoint.SuspendLayout();
            this.runningStatusStrip.SuspendLayout();
            this.singleWireMove.SuspendLayout();
            this.planPanel.SuspendLayout();
            this.operationMode.SuspendLayout();
            this.identificationTabPage.SuspendLayout();
            this.manipulationTabPage.SuspendLayout();
            this.simulateContextMenuStrip.SuspendLayout();
            this.picturePanel.SuspendLayout();
            this.picturePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.experientToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1700, 28);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportPathToolStripMenuItem});
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
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentFigureToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // currentFigureToolStripMenuItem
            // 
            this.currentFigureToolStripMenuItem.Name = "currentFigureToolStripMenuItem";
            this.currentFigureToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.currentFigureToolStripMenuItem.Text = "Current Figure";
            this.currentFigureToolStripMenuItem.Click += new System.EventHandler(this.pictureToolStripMenuItem_Click);
            // 
            // exportPathToolStripMenuItem
            // 
            this.exportPathToolStripMenuItem.Enabled = false;
            this.exportPathToolStripMenuItem.Name = "exportPathToolStripMenuItem";
            this.exportPathToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.exportPathToolStripMenuItem.Text = "Export Path";
            this.exportPathToolStripMenuItem.Click += new System.EventHandler(this.exportPathToolStripMenuItem_Click);
            // 
            // experientToolStripMenuItem
            // 
            this.experientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manulPathToolStripMenuItem,
            this.nanobitmapToolStripMenuItem});
            this.experientToolStripMenuItem.Name = "experientToolStripMenuItem";
            this.experientToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.experientToolStripMenuItem.Text = "Experiment";
            // 
            // manulPathToolStripMenuItem
            // 
            this.manulPathToolStripMenuItem.Name = "manulPathToolStripMenuItem";
            this.manulPathToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.manulPathToolStripMenuItem.Text = "Manual cutting";
            this.manulPathToolStripMenuItem.Click += new System.EventHandler(this.traditionalNanomanToolStripMenuItem_Click);
            // 
            // nanobitmapToolStripMenuItem
            // 
            this.nanobitmapToolStripMenuItem.Name = "nanobitmapToolStripMenuItem";
            this.nanobitmapToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.nanobitmapToolStripMenuItem.Text = "Nanobitmap";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // displayToolStripMenuItem1
            // 
            this.displayToolStripMenuItem1.Name = "displayToolStripMenuItem1";
            this.displayToolStripMenuItem1.Size = new System.Drawing.Size(136, 26);
            this.displayToolStripMenuItem1.Text = "Display";
            this.displayToolStripMenuItem1.Click += new System.EventHandler(this.displayToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeRecognitionToolStripMenuItem,
            this.softStiffThresholdToolStripMenuItem,
            this.parameterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // edgeRecognitionToolStripMenuItem
            // 
            this.edgeRecognitionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobelToolStripMenuItem});
            this.edgeRecognitionToolStripMenuItem.Name = "edgeRecognitionToolStripMenuItem";
            this.edgeRecognitionToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.edgeRecognitionToolStripMenuItem.Text = "Edge Recognition";
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // softStiffThresholdToolStripMenuItem
            // 
            this.softStiffThresholdToolStripMenuItem.Name = "softStiffThresholdToolStripMenuItem";
            this.softStiffThresholdToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.softStiffThresholdToolStripMenuItem.Text = "Soft/Stiff Judgement";
            this.softStiffThresholdToolStripMenuItem.Click += new System.EventHandler(this.softStiffThresholdToolStripMenuItem_Click);
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.parameterToolStripMenuItem.Text = "Parameter";
            this.parameterToolStripMenuItem.Click += new System.EventHandler(this.pathToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showPictureBox
            // 
            this.showPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showPictureBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.showPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showPictureBox.ContextMenuStrip = this.clearShowPicBox;
            this.showPictureBox.Location = new System.Drawing.Point(0, 0);
            this.showPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.showPictureBox.Name = "showPictureBox";
            this.showPictureBox.Size = new System.Drawing.Size(650, 650);
            this.showPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showPictureBox.TabIndex = 1;
            this.showPictureBox.TabStop = false;
            this.showPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.showPictureBox_Paint);
            this.showPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseDown);
            this.showPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseMove);
            this.showPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseUp);
            // 
            // clearShowPicBox
            // 
            this.clearShowPicBox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.clearShowPicBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.clearShowPicBox.Name = "clearShowPicBox";
            this.clearShowPicBox.Size = new System.Drawing.Size(116, 28);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // movePictureBox
            // 
            this.movePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movePictureBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.movePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.movePictureBox.ContextMenuStrip = this.mouseGetPoint;
            this.movePictureBox.Location = new System.Drawing.Point(0, 0);
            this.movePictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.movePictureBox.Name = "movePictureBox";
            this.movePictureBox.Size = new System.Drawing.Size(650, 650);
            this.movePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movePictureBox.TabIndex = 2;
            this.movePictureBox.TabStop = false;
            this.movePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.movePictureBox_Paint);
            this.movePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movePictureBox_MouseDown);
            this.movePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movePictureBox_MouseMove);
            // 
            // mouseGetPoint
            // 
            this.mouseGetPoint.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mouseGetPoint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reselectLastPoint,
            this.reselect,
            this.apply,
            this.abandon});
            this.mouseGetPoint.Name = "AddByHand";
            this.mouseGetPoint.Size = new System.Drawing.Size(241, 100);
            // 
            // reselectLastPoint
            // 
            this.reselectLastPoint.Name = "reselectLastPoint";
            this.reselectLastPoint.Size = new System.Drawing.Size(240, 24);
            this.reselectLastPoint.Text = "Reselect the last point";
            this.reselectLastPoint.Click += new System.EventHandler(this.deleteLastToolStripMenuItem_Click);
            // 
            // reselect
            // 
            this.reselect.Name = "reselect";
            this.reselect.Size = new System.Drawing.Size(240, 24);
            this.reselect.Text = "Reselect";
            this.reselect.Click += new System.EventHandler(this.deleteAll_Click);
            // 
            // apply
            // 
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(240, 24);
            this.apply.Text = "Apply";
            this.apply.Click += new System.EventHandler(this.ready_Click);
            // 
            // abandon
            // 
            this.abandon.Name = "abandon";
            this.abandon.Size = new System.Drawing.Size(240, 24);
            this.abandon.Text = "Abandon";
            this.abandon.Click += new System.EventHandler(this.exit_Click);
            // 
            // runningStatusStrip
            // 
            this.runningStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.runningStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pB,
            this.pathSavedStripStatusLabel});
            this.runningStatusStrip.Location = new System.Drawing.Point(0, 739);
            this.runningStatusStrip.Name = "runningStatusStrip";
            this.runningStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.runningStatusStrip.Size = new System.Drawing.Size(1700, 26);
            this.runningStatusStrip.TabIndex = 3;
            this.runningStatusStrip.Text = "runningStatusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 21);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // pB
            // 
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(133, 20);
            // 
            // pathSavedStripStatusLabel
            // 
            this.pathSavedStripStatusLabel.Name = "pathSavedStripStatusLabel";
            this.pathSavedStripStatusLabel.Size = new System.Drawing.Size(105, 21);
            this.pathSavedStripStatusLabel.Text = "Path saved at";
            // 
            // identify
            // 
            this.identify.Location = new System.Drawing.Point(7, 18);
            this.identify.Margin = new System.Windows.Forms.Padding(4);
            this.identify.Name = "identify";
            this.identify.Size = new System.Drawing.Size(254, 34);
            this.identify.TabIndex = 4;
            this.identify.Text = "Sample Identification";
            this.identify.UseVisualStyleBackColor = true;
            this.identify.Click += new System.EventHandler(this.Identify_Click);
            // 
            // addNewLine
            // 
            this.addNewLine.Location = new System.Drawing.Point(7, 60);
            this.addNewLine.Margin = new System.Windows.Forms.Padding(4);
            this.addNewLine.Name = "addNewLine";
            this.addNewLine.Size = new System.Drawing.Size(131, 34);
            this.addNewLine.TabIndex = 22;
            this.addNewLine.Text = "Manually Add";
            this.addNewLine.UseVisualStyleBackColor = true;
            this.addNewLine.Click += new System.EventHandler(this.AddNewLine_Click);
            // 
            // nanowiresList
            // 
            this.nanowiresList.ContextMenuStrip = this.singleWireMove;
            this.nanowiresList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nanowiresList.FormattingEnabled = true;
            this.nanowiresList.ItemHeight = 15;
            this.nanowiresList.Location = new System.Drawing.Point(7, 196);
            this.nanowiresList.Margin = new System.Windows.Forms.Padding(4);
            this.nanowiresList.Name = "nanowiresList";
            this.nanowiresList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.nanowiresList.Size = new System.Drawing.Size(275, 109);
            this.nanowiresList.TabIndex = 23;
            this.nanowiresList.SelectedIndexChanged += new System.EventHandler(this.NanowiresList_SelectedIndexChanged);
            this.nanowiresList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NanowiresList_MouseDown);
            // 
            // singleWireMove
            // 
            this.singleWireMove.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.singleWireMove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.push,
            this.rotate,
            this.properties});
            this.singleWireMove.Name = "SingleWireMove";
            this.singleWireMove.Size = new System.Drawing.Size(155, 76);
            // 
            // push
            // 
            this.push.Name = "push";
            this.push.Size = new System.Drawing.Size(154, 24);
            this.push.Text = "Push";
            // 
            // rotate
            // 
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(154, 24);
            this.rotate.Text = "Rotate";
            // 
            // properties
            // 
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(154, 24);
            this.properties.Text = "Properties";
            this.properties.Click += new System.EventHandler(this.propertiesMenu);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(145, 60);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(115, 34);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Remove";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // planPanel
            // 
            this.planPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.planPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.planPanel.Controls.Add(this.operationMode);
            this.planPanel.Controls.Add(this.nanowiresList);
            this.planPanel.Controls.Add(this.nanowireListLabel);
            this.planPanel.Location = new System.Drawing.Point(1391, 82);
            this.planPanel.Margin = new System.Windows.Forms.Padding(4);
            this.planPanel.Name = "planPanel";
            this.planPanel.Size = new System.Drawing.Size(296, 325);
            this.planPanel.TabIndex = 28;
            // 
            // operationMode
            // 
            this.operationMode.Controls.Add(this.identificationTabPage);
            this.operationMode.Controls.Add(this.manipulationTabPage);
            this.operationMode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationMode.Location = new System.Drawing.Point(7, 14);
            this.operationMode.Name = "operationMode";
            this.operationMode.SelectedIndex = 0;
            this.operationMode.Size = new System.Drawing.Size(276, 142);
            this.operationMode.TabIndex = 40;
            this.operationMode.SelectedIndexChanged += new System.EventHandler(this.operationMode_SelectedIndexChanged);
            // 
            // identificationTabPage
            // 
            this.identificationTabPage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.identificationTabPage.Controls.Add(this.deleteButton);
            this.identificationTabPage.Controls.Add(this.identify);
            this.identificationTabPage.Controls.Add(this.addNewLine);
            this.identificationTabPage.Location = new System.Drawing.Point(4, 25);
            this.identificationTabPage.Name = "identificationTabPage";
            this.identificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.identificationTabPage.Size = new System.Drawing.Size(268, 113);
            this.identificationTabPage.TabIndex = 0;
            this.identificationTabPage.Text = "Identification";
            // 
            // manipulationTabPage
            // 
            this.manipulationTabPage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.manipulationTabPage.Controls.Add(this.orderTextBox);
            this.manipulationTabPage.Controls.Add(this.setTarget);
            this.manipulationTabPage.Controls.Add(this.orderLabel);
            this.manipulationTabPage.Controls.Add(this.compute);
            this.manipulationTabPage.Location = new System.Drawing.Point(4, 25);
            this.manipulationTabPage.Name = "manipulationTabPage";
            this.manipulationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.manipulationTabPage.Size = new System.Drawing.Size(268, 113);
            this.manipulationTabPage.TabIndex = 1;
            this.manipulationTabPage.Text = "Manipulation";
            // 
            // orderTextBox
            // 
            this.orderTextBox.ContextMenuStrip = this.simulateContextMenuStrip;
            this.orderTextBox.Location = new System.Drawing.Point(123, 68);
            this.orderTextBox.Name = "orderTextBox";
            this.orderTextBox.ReadOnly = true;
            this.orderTextBox.Size = new System.Drawing.Size(134, 25);
            this.orderTextBox.TabIndex = 4;
            // 
            // simulateContextMenuStrip
            // 
            this.simulateContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.simulateContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulateToolStripMenuItem});
            this.simulateContextMenuStrip.Name = "displayContextMenuStrip";
            this.simulateContextMenuStrip.Size = new System.Drawing.Size(142, 28);
            // 
            // simulateToolStripMenuItem
            // 
            this.simulateToolStripMenuItem.Name = "simulateToolStripMenuItem";
            this.simulateToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.simulateToolStripMenuItem.Text = "Simulate";
            this.simulateToolStripMenuItem.Click += new System.EventHandler(this.simulateToolStripMenuItem_Click);
            // 
            // setTarget
            // 
            this.setTarget.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setTarget.Location = new System.Drawing.Point(6, 19);
            this.setTarget.Margin = new System.Windows.Forms.Padding(4);
            this.setTarget.Name = "setTarget";
            this.setTarget.Size = new System.Drawing.Size(105, 34);
            this.setTarget.TabIndex = 1;
            this.setTarget.Text = "Set Target";
            this.setTarget.UseVisualStyleBackColor = true;
            this.setTarget.Click += new System.EventHandler(this.setTarget_Click);
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderLabel.Location = new System.Drawing.Point(6, 72);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(106, 17);
            this.orderLabel.TabIndex = 3;
            this.orderLabel.Text = "Movement Order";
            // 
            // compute
            // 
            this.compute.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compute.Location = new System.Drawing.Point(116, 20);
            this.compute.Margin = new System.Windows.Forms.Padding(4);
            this.compute.Name = "compute";
            this.compute.Size = new System.Drawing.Size(143, 34);
            this.compute.TabIndex = 2;
            this.compute.Text = "Generate Path";
            this.compute.UseVisualStyleBackColor = true;
            this.compute.Click += new System.EventHandler(this.compute_Click);
            // 
            // nanowireListLabel
            // 
            this.nanowireListLabel.AutoSize = true;
            this.nanowireListLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nanowireListLabel.Location = new System.Drawing.Point(8, 178);
            this.nanowireListLabel.Name = "nanowireListLabel";
            this.nanowireListLabel.Size = new System.Drawing.Size(271, 15);
            this.nanowireListLabel.TabIndex = 41;
            this.nanowireListLabel.Text = "Num Dia(nm) Len(nm) L/D  Property";
            // 
            // picturePanel
            // 
            this.picturePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picturePanel.Controls.Add(this.showPictureBox);
            this.picturePanel.Location = new System.Drawing.Point(20, 50);
            this.picturePanel.Margin = new System.Windows.Forms.Padding(4);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(650, 650);
            this.picturePanel.TabIndex = 29;
            // 
            // picturePanel1
            // 
            this.picturePanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picturePanel1.Controls.Add(this.displayPictureBox);
            this.picturePanel1.Controls.Add(this.movePictureBox);
            this.picturePanel1.Location = new System.Drawing.Point(720, 50);
            this.picturePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.picturePanel1.Name = "picturePanel1";
            this.picturePanel1.Size = new System.Drawing.Size(650, 650);
            this.picturePanel1.TabIndex = 30;
            // 
            // displayPictureBox
            // 
            this.displayPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPictureBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.displayPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.displayPictureBox.ContextMenuStrip = this.mouseGetPoint;
            this.displayPictureBox.Location = new System.Drawing.Point(0, 0);
            this.displayPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.displayPictureBox.Name = "displayPictureBox";
            this.displayPictureBox.Size = new System.Drawing.Size(650, 650);
            this.displayPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.displayPictureBox.TabIndex = 3;
            this.displayPictureBox.TabStop = false;
            this.displayPictureBox.Visible = false;
            this.displayPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.displayPictureBox_Paint);
            // 
            // Y0
            // 
            this.Y0.AutoSize = true;
            this.Y0.Location = new System.Drawing.Point(684, 393);
            this.Y0.Name = "Y0";
            this.Y0.Size = new System.Drawing.Size(31, 15);
            this.Y0.TabIndex = 4;
            this.Y0.Text = "0um";
            // 
            // MX0
            // 
            this.MX0.AutoSize = true;
            this.MX0.Location = new System.Drawing.Point(1029, 705);
            this.MX0.Name = "MX0";
            this.MX0.Size = new System.Drawing.Size(31, 15);
            this.MX0.TabIndex = 4;
            this.MX0.Text = "0um";
            // 
            // MXmin
            // 
            this.MXmin.AutoSize = true;
            this.MXmin.Location = new System.Drawing.Point(716, 705);
            this.MXmin.Name = "MXmin";
            this.MXmin.Size = new System.Drawing.Size(0, 15);
            this.MXmin.TabIndex = 36;
            // 
            // MXmax
            // 
            this.MXmax.AutoSize = true;
            this.MXmax.Location = new System.Drawing.Point(1350, 705);
            this.MXmax.Name = "MXmax";
            this.MXmax.Size = new System.Drawing.Size(0, 15);
            this.MXmax.TabIndex = 37;
            // 
            // Ymin
            // 
            this.Ymin.AutoSize = true;
            this.Ymin.Location = new System.Drawing.Point(694, 685);
            this.Ymin.Name = "Ymin";
            this.Ymin.Size = new System.Drawing.Size(0, 15);
            this.Ymin.TabIndex = 38;
            // 
            // Ymax
            // 
            this.Ymax.AutoSize = true;
            this.Ymax.Location = new System.Drawing.Point(694, 64);
            this.Ymax.Name = "Ymax";
            this.Ymax.Size = new System.Drawing.Size(0, 15);
            this.Ymax.TabIndex = 39;
            // 
            // AutoDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1700, 765);
            this.Controls.Add(this.Ymax);
            this.Controls.Add(this.Ymin);
            this.Controls.Add(this.MXmax);
            this.Controls.Add(this.MXmin);
            this.Controls.Add(this.MX0);
            this.Controls.Add(this.Y0);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.planPanel);
            this.Controls.Add(this.runningStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.picturePanel1);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoDetect";
            this.Text = "AutoDetect";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).EndInit();
            this.clearShowPicBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.movePictureBox)).EndInit();
            this.mouseGetPoint.ResumeLayout(false);
            this.runningStatusStrip.ResumeLayout(false);
            this.runningStatusStrip.PerformLayout();
            this.singleWireMove.ResumeLayout(false);
            this.planPanel.ResumeLayout(false);
            this.planPanel.PerformLayout();
            this.operationMode.ResumeLayout(false);
            this.identificationTabPage.ResumeLayout(false);
            this.manipulationTabPage.ResumeLayout(false);
            this.manipulationTabPage.PerformLayout();
            this.simulateContextMenuStrip.ResumeLayout(false);
            this.picturePanel.ResumeLayout(false);
            this.picturePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.displayPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentFigureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox showPictureBox;
        private System.Windows.Forms.PictureBox movePictureBox;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.StatusStrip runningStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar pB;
        private System.Windows.Forms.Button identify;
        private System.Windows.Forms.ToolStripMenuItem edgeRecognitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.Button addNewLine;
        private System.Windows.Forms.ToolStripMenuItem softStiffThresholdToolStripMenuItem;
        private System.Windows.Forms.ListBox nanowiresList;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ContextMenuStrip mouseGetPoint;
        private System.Windows.Forms.ToolStripMenuItem reselectLastPoint;
        private System.Windows.Forms.ToolStripMenuItem reselect;
        private System.Windows.Forms.ToolStripMenuItem apply;
        private System.Windows.Forms.ContextMenuStrip singleWireMove;
        private System.Windows.Forms.ToolStripMenuItem properties;
        private System.Windows.Forms.ToolStripMenuItem push;
        private System.Windows.Forms.ToolStripMenuItem rotate;
        private System.Windows.Forms.Panel planPanel;
        private System.Windows.Forms.ToolStripMenuItem abandon;
        private System.Windows.Forms.Button setTarget;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Panel picturePanel1;
        private System.Windows.Forms.ContextMenuStrip clearShowPicBox;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Button compute;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.TextBox orderTextBox;
        private System.Windows.Forms.PictureBox displayPictureBox;
        private System.Windows.Forms.ContextMenuStrip simulateContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem simulateToolStripMenuItem;
        private System.Windows.Forms.Label Y0;
        private System.Windows.Forms.Label MX0;
        private System.Windows.Forms.Label MXmin;
        private System.Windows.Forms.Label MXmax;
        private System.Windows.Forms.Label Ymin;
        private System.Windows.Forms.Label Ymax;
        private System.Windows.Forms.ToolStripMenuItem parameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem experientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manulPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nanobitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel pathSavedStripStatusLabel;
        private System.Windows.Forms.TabControl operationMode;
        private System.Windows.Forms.TabPage identificationTabPage;
        private System.Windows.Forms.TabPage manipulationTabPage;
        private System.Windows.Forms.Label nanowireListLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem1;
    }
}

