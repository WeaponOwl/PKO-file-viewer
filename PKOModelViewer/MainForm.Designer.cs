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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFindFiles = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.glControl1 = new OpenTK.GLControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.treeOfFileslvl1NodeMenu.SuspendLayout();
            this.treeOfFileslvl0NodeMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 27);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(124, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Choose directory";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonSelectFoler_Click);
            // 
            // buttonFindFiles
            // 
            this.buttonFindFiles.Location = new System.Drawing.Point(142, 27);
            this.buttonFindFiles.Name = "buttonFindFiles";
            this.buttonFindFiles.Size = new System.Drawing.Size(123, 23);
            this.buttonFindFiles.TabIndex = 2;
            this.buttonFindFiles.Text = "Open directory";
            this.buttonFindFiles.UseVisualStyleBackColor = true;
            this.buttonFindFiles.Click += new System.EventHandler(this.buttonFindFiles_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 20);
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
            this.glControl1.Size = new System.Drawing.Size(438, 351);
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
            this.richTextBox1.Location = new System.Drawing.Point(715, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(205, 402);
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
            this.trackBar1.Location = new System.Drawing.Point(406, 384);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(303, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(271, 384);
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
            this.numericUpDown1.Location = new System.Drawing.Point(322, 398);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(873, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // treeOfFiles
            // 
            this.treeOfFiles.FullRowSelect = true;
            this.treeOfFiles.HideSelection = false;
            this.treeOfFiles.Location = new System.Drawing.Point(12, 82);
            this.treeOfFiles.Name = "treeOfFiles";
            this.treeOfFiles.Size = new System.Drawing.Size(253, 347);
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
            this.treeOfFileslvl1NodeMenu.Size = new System.Drawing.Size(221, 48);
            // 
            // pushThisToExportListToolStripMenuItem
            // 
            this.pushThisToExportListToolStripMenuItem.Name = "pushThisToExportListToolStripMenuItem";
            this.pushThisToExportListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.pushThisToExportListToolStripMenuItem.Text = "Push this to export list";
            this.pushThisToExportListToolStripMenuItem.Click += new System.EventHandler(this.pushThisToExportListToolStripMenuItem_Click);
            // 
            // pushAllThisLvlToExportListToolStripMenuItem
            // 
            this.pushAllThisLvlToExportListToolStripMenuItem.Name = "pushAllThisLvlToExportListToolStripMenuItem";
            this.pushAllThisLvlToExportListToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.pushAllThisLvlToExportListToolStripMenuItem.Text = "Push all this lvl to export list";
            this.pushAllThisLvlToExportListToolStripMenuItem.Click += new System.EventHandler(this.pushAllThisLvlToExportListToolStripMenuItem_Click);
            // 
            // treeOfFileslvl0NodeMenu
            // 
            this.treeOfFileslvl0NodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pushAllChildrentToExportListToolStripMenuItem});
            this.treeOfFileslvl0NodeMenu.Name = "treeOfFileslvl0NodeMenu";
            this.treeOfFileslvl0NodeMenu.Size = new System.Drawing.Size(234, 26);
            // 
            // pushAllChildrentToExportListToolStripMenuItem
            // 
            this.pushAllChildrentToExportListToolStripMenuItem.Name = "pushAllChildrentToExportListToolStripMenuItem";
            this.pushAllChildrentToExportListToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.pushAllChildrentToExportListToolStripMenuItem.Text = "Push all childrent to export list";
            this.pushAllChildrentToExportListToolStripMenuItem.Click += new System.EventHandler(this.pushAllChildrentToExportListToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseDirectoryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // chooseDirectoryToolStripMenuItem
            // 
            this.chooseDirectoryToolStripMenuItem.Name = "chooseDirectoryToolStripMenuItem";
            this.chooseDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.chooseDirectoryToolStripMenuItem.Text = "Choose directory";
            this.chooseDirectoryToolStripMenuItem.Click += new System.EventHandler(this.buttonSelectFoler_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportListToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // exportListToolStripMenuItem
            // 
            this.exportListToolStripMenuItem.Name = "exportListToolStripMenuItem";
            this.exportListToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exportListToolStripMenuItem.Text = "Export list";
            this.exportListToolStripMenuItem.Click += new System.EventHandler(this.exportListToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aboutProgramToolStripMenuItem.Text = "About program";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 441);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeOfFiles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonFindFiles);
            this.Controls.Add(this.buttonLoad);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PKO Model viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.treeOfFileslvl1NodeMenu.ResumeLayout(false);
            this.treeOfFileslvl0NodeMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        public System.Windows.Forms.TextBox textBox1;
    }
}

