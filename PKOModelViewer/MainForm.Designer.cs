namespace PKOModelViewer
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("How use Model viewer");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1, Choose client folder");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("2. Load client content");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("3. Select client content for preview");
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.glControl1 = new OpenTK.GLControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.treeOfFiles = new System.Windows.Forms.TreeView();
            this.treeOfFileslvl1NodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pushThisToExportListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pushAllThisLvlToExportListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeOfFileslvl0NodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pushAllChildrentToExportListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toObjConvertorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromObjConvertorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFindFiles = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderSelectDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.treeOfFileslvl1NodeMenu.SuspendLayout();
            this.treeOfFileslvl0NodeMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "D:\\Games\\TalesOfPirate\\Пиратия Online\\";
            // 
            // glControl1
            // 
            this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(271, 27);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(548, 394);
            this.glControl1.TabIndex = 4;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(825, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(205, 445);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(406, 427);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(413, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(271, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(322, 441);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // treeOfFiles
            // 
            this.treeOfFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeOfFiles.FullRowSelect = true;
            this.treeOfFiles.HideSelection = false;
            this.treeOfFiles.Location = new System.Drawing.Point(6, 45);
            this.treeOfFiles.Name = "treeOfFiles";
            treeNode1.Name = "Node3";
            treeNode1.Text = "How use Model viewer";
            treeNode2.Name = "Node0";
            treeNode2.Text = "1, Choose client folder";
            treeNode3.Name = "Node1";
            treeNode3.Text = "2. Load client content";
            treeNode4.Name = "Node2";
            treeNode4.Text = "3. Select client content for preview";
            this.treeOfFiles.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeOfFiles.Size = new System.Drawing.Size(241, 314);
            this.treeOfFiles.TabIndex = 10;
            this.treeOfFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOfFiles_AfterSelect);
            this.treeOfFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeOfFiles_MouseClick);
            // 
            // treeOfFileslvl1NodeMenu
            // 
            this.treeOfFileslvl1NodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pushThisToExportListToolStripMenuItem,
            this.pushAllThisLvlToExportListToolStripMenuItem});
            this.treeOfFileslvl1NodeMenu.Name = "treeOfFileslvl1NodeMenu";
            this.treeOfFileslvl1NodeMenu.Size = new System.Drawing.Size(222, 48);
            // 
            // pushThisToExportListToolStripMenuItem
            // 
            this.pushThisToExportListToolStripMenuItem.Name = "pushThisToExportListToolStripMenuItem";
            this.pushThisToExportListToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.pushThisToExportListToolStripMenuItem.Text = "Push this to export list";
            this.pushThisToExportListToolStripMenuItem.Click += new System.EventHandler(this.pushThisToExportListToolStripMenuItem_Click);
            // 
            // pushAllThisLvlToExportListToolStripMenuItem
            // 
            this.pushAllThisLvlToExportListToolStripMenuItem.Name = "pushAllThisLvlToExportListToolStripMenuItem";
            this.pushAllThisLvlToExportListToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.pushAllThisLvlToExportListToolStripMenuItem.Text = "Push all this lvl to export list";
            this.pushAllThisLvlToExportListToolStripMenuItem.Click += new System.EventHandler(this.pushAllThisLvlToExportListToolStripMenuItem_Click);
            // 
            // treeOfFileslvl0NodeMenu
            // 
            this.treeOfFileslvl0NodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pushAllChildrentToExportListToolStripMenuItem});
            this.treeOfFileslvl0NodeMenu.Name = "treeOfFileslvl0NodeMenu";
            this.treeOfFileslvl0NodeMenu.Size = new System.Drawing.Size(235, 26);
            // 
            // pushAllChildrentToExportListToolStripMenuItem
            // 
            this.pushAllChildrentToExportListToolStripMenuItem.Name = "pushAllChildrentToExportListToolStripMenuItem";
            this.pushAllChildrentToExportListToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.pushAllChildrentToExportListToolStripMenuItem.Text = "Push all childrent to export list";
            this.pushAllChildrentToExportListToolStripMenuItem.Click += new System.EventHandler(this.pushAllChildrentToExportListToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toObjConvertorToolStripMenuItem,
            this.fromObjConvertorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1042, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseDirectoryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "App";
            // 
            // chooseDirectoryToolStripMenuItem
            // 
            this.chooseDirectoryToolStripMenuItem.Name = "chooseDirectoryToolStripMenuItem";
            this.chooseDirectoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chooseDirectoryToolStripMenuItem.Text = "Choose client folder";
            this.chooseDirectoryToolStripMenuItem.Click += new System.EventHandler(this.buttonSelectFoler_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Image = global::PKOModelViewer.Properties.Resources.ukraine;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 20);
            this.toolStripMenuItem1.Text = "Support Ukraine";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toObjConvertorToolStripMenuItem
            // 
            this.toObjConvertorToolStripMenuItem.Image = global::PKOModelViewer.Properties.Resources.Export;
            this.toObjConvertorToolStripMenuItem.Name = "toObjConvertorToolStripMenuItem";
            this.toObjConvertorToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.toObjConvertorToolStripMenuItem.Text = "To Obj Convertor";
            this.toObjConvertorToolStripMenuItem.Click += new System.EventHandler(this.exportListToolStripMenuItem_Click);
            // 
            // fromObjConvertorToolStripMenuItem
            // 
            this.fromObjConvertorToolStripMenuItem.Image = global::PKOModelViewer.Properties.Resources.Import;
            this.fromObjConvertorToolStripMenuItem.Name = "fromObjConvertorToolStripMenuItem";
            this.fromObjConvertorToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.fromObjConvertorToolStripMenuItem.Text = "From Obj Convertor";
            this.fromObjConvertorToolStripMenuItem.Click += new System.EventHandler(this.importListToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 19);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(192, 20);
            this.textBoxSearch.TabIndex = 12;
            this.textBoxSearch.Text = "01010004.lgo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.buttonFindFiles);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 77);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client folder";
            // 
            // buttonFindFiles
            // 
            this.buttonFindFiles.Image = global::PKOModelViewer.Properties.Resources.OpenFolder;
            this.buttonFindFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFindFiles.Location = new System.Drawing.Point(6, 45);
            this.buttonFindFiles.Name = "buttonFindFiles";
            this.buttonFindFiles.Size = new System.Drawing.Size(241, 23);
            this.buttonFindFiles.TabIndex = 2;
            this.buttonFindFiles.Text = "Load client content";
            this.buttonFindFiles.UseVisualStyleBackColor = true;
            this.buttonFindFiles.Click += new System.EventHandler(this.buttonFindFiles_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = global::PKOModelViewer.Properties.Resources.SearchFolderOpened;
            this.buttonLoad.Location = new System.Drawing.Point(204, 17);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(43, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonSelectFoler_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.textBoxSearch);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.treeOfFiles);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 362);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client content";
            // 
            // button2
            // 
            this.button2.Image = global::PKOModelViewer.Properties.Resources.Search;
            this.button2.Location = new System.Drawing.Point(204, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderSelectDialogToolStripMenuItem,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(207, 32);
            // 
            // openFolderSelectDialogToolStripMenuItem
            // 
            this.openFolderSelectDialogToolStripMenuItem.Name = "openFolderSelectDialogToolStripMenuItem";
            this.openFolderSelectDialogToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openFolderSelectDialogToolStripMenuItem.Text = "Open folder select dialog";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(983, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 484);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.glControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PKO/TOP Model viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.treeOfFileslvl1NodeMenu.ResumeLayout(false);
            this.treeOfFileslvl0NodeMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonFindFiles;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeOfFiles;
        private System.Windows.Forms.ContextMenuStrip treeOfFileslvl1NodeMenu;
        private System.Windows.Forms.ContextMenuStrip treeOfFileslvl0NodeMenu;
        private System.Windows.Forms.ToolStripMenuItem pushThisToExportListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pushAllThisLvlToExportListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pushAllChildrentToExportListToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFolderSelectDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toObjConvertorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromObjConvertorToolStripMenuItem;
    }
}

