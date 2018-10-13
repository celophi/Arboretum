namespace Arboretum
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RemoteTreeTab = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.RemoteFileTree = new System.Windows.Forms.TreeView();
            this.ArchiveContentsTab = new System.Windows.Forms.TabPage();
            this.ArchiveContentsTreeView = new System.Windows.Forms.TreeView();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.RemoteTreeTab.SuspendLayout();
            this.ArchiveContentsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(870, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeURLToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.settingsToolStripMenuItem_DropDownItemClicked);
            // 
            // changeURLToolStripMenuItem
            // 
            this.changeURLToolStripMenuItem.Name = "changeURLToolStripMenuItem";
            this.changeURLToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.changeURLToolStripMenuItem.Text = "Change URL";
            this.changeURLToolStripMenuItem.Click += new System.EventHandler(this.changeURLToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.RemoteTreeTab);
            this.tabControl1.Controls.Add(this.ArchiveContentsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 431);
            this.tabControl1.TabIndex = 6;
            // 
            // RemoteTreeTab
            // 
            this.RemoteTreeTab.BackColor = System.Drawing.Color.White;
            this.RemoteTreeTab.Controls.Add(this.listView1);
            this.RemoteTreeTab.Controls.Add(this.splitter1);
            this.RemoteTreeTab.Controls.Add(this.RemoteFileTree);
            this.RemoteTreeTab.Location = new System.Drawing.Point(4, 22);
            this.RemoteTreeTab.Name = "RemoteTreeTab";
            this.RemoteTreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.RemoteTreeTab.Size = new System.Drawing.Size(838, 405);
            this.RemoteTreeTab.TabIndex = 0;
            this.RemoteTreeTab.Text = "Remote Tree";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(299, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(536, 399);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(296, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 399);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // RemoteFileTree
            // 
            this.RemoteFileTree.BackColor = System.Drawing.SystemColors.Window;
            this.RemoteFileTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.RemoteFileTree.Location = new System.Drawing.Point(3, 3);
            this.RemoteFileTree.Name = "RemoteFileTree";
            this.RemoteFileTree.Size = new System.Drawing.Size(293, 399);
            this.RemoteFileTree.TabIndex = 0;
            // 
            // ArchiveContentsTab
            // 
            this.ArchiveContentsTab.Controls.Add(this.ArchiveContentsTreeView);
            this.ArchiveContentsTab.Location = new System.Drawing.Point(4, 22);
            this.ArchiveContentsTab.Name = "ArchiveContentsTab";
            this.ArchiveContentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ArchiveContentsTab.Size = new System.Drawing.Size(838, 405);
            this.ArchiveContentsTab.TabIndex = 1;
            this.ArchiveContentsTab.Text = "Archive Contents";
            this.ArchiveContentsTab.UseVisualStyleBackColor = true;
            // 
            // ArchiveContentsTreeView
            // 
            this.ArchiveContentsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveContentsTreeView.Location = new System.Drawing.Point(3, 3);
            this.ArchiveContentsTreeView.Name = "ArchiveContentsTreeView";
            this.ArchiveContentsTreeView.Size = new System.Drawing.Size(832, 399);
            this.ArchiveContentsTreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 487);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Arboretum";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.RemoteTreeTab.ResumeLayout(false);
            this.ArchiveContentsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ArchiveContentsTab;
        private System.Windows.Forms.TabPage RemoteTreeTab;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TreeView RemoteFileTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView ArchiveContentsTreeView;
    }
}
