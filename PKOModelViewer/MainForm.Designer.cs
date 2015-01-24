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
            this.treeOfFiles = new System.Windows.Forms.TreeView();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFindFiles = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.glControl1 = new OpenTK.GLControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // treeOfFiles
            // 
            this.treeOfFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeOfFiles.Location = new System.Drawing.Point(12, 96);
            this.treeOfFiles.Name = "treeOfFiles";
            this.treeOfFiles.Size = new System.Drawing.Size(202, 333);
            this.treeOfFiles.TabIndex = 0;
            this.treeOfFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOfFiles_AfterSelect);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(202, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Choose directory";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonSelectFoler_Click);
            // 
            // buttonFindFiles
            // 
            this.buttonFindFiles.Location = new System.Drawing.Point(12, 67);
            this.buttonFindFiles.Name = "buttonFindFiles";
            this.buttonFindFiles.Size = new System.Drawing.Size(202, 23);
            this.buttonFindFiles.TabIndex = 2;
            this.buttonFindFiles.Text = "Open directory";
            this.buttonFindFiles.UseVisualStyleBackColor = true;
            this.buttonFindFiles.Click += new System.EventHandler(this.buttonFindFiles_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "D:\\Games\\TalesOfPirate\\Пиратия Online\\";
            // 
            // glControl1
            // 
            this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(220, 12);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(431, 417);
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
            this.richTextBox1.Location = new System.Drawing.Point(657, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(181, 417);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 441);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonFindFiles);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.treeOfFiles);
            this.Name = "MainForm";
            this.Text = "PKO Model viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeOfFiles;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonFindFiles;
        private System.Windows.Forms.TextBox textBox1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

