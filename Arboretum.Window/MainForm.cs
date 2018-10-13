using Arboretum.Lib;
using Arboretum.Window;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Arboretum
{
    public partial class MainForm : Form
    {
        private PakZip _archive;

        public MainForm()
        {
            InitializeComponent();
            this.ArchiveContentsTreeView.MouseUp += this.On_TreeView_MouseUp;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void changeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = ".pak",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Archive Selector",
                Filter = "PakZip (*.pak) | *.pak",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _archive = new PakZip(dialog.FileName);
                this.tabControl1.SelectedTab = this.ArchiveContentsTab;
                this.toolStripStatusLabel1.Text = dialog.FileName;

                var paths = _archive.PakFiles.Select(x => x.FileName);
                foreach (var path in paths)
                {
                    this.AttachPathToTree(this.ArchiveContentsTreeView, path);
                }
            }
        }

        /// <summary>
        /// Attaches a file path to the tree.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="path"></param>
        private void AttachPathToTree(TreeView tree, string path)
        {
            var key = String.Empty;
            TreeNode last = null;
            var partials = path.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });

            foreach (var partial in partials)
            {
                key += (partial + '/');

                var nodes = tree.Nodes.Find(key, true);
                if (nodes.Length > 0)
                {
                    last = nodes[0];
                    continue;
                }

                var node = new TreeNode(partial);
                node.Name = key;

                // If the key and path are the same, attach the path as metadata.
                // This can be any metadata object.
                if (key.Contains(path))
                {
                    this.AttachDataToEndNode(node, path);
                }

                if (last == null)
                {
                    last = node;
                    tree.Nodes.Add(node);
                    continue;
                }

                last.Nodes.Add(node);
                last = node;
            }
        }

        /// <summary>
        /// Attaches a context menu and metadata to a tree node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        private void AttachDataToEndNode(TreeNode node, string path)
        {
            node.Tag = path;

            var menu = new ContextMenuStrip();
            var menuItem = new ToolStripMenuItem
            {
                Text = "Extract",
                Tag = node
            };
            menu.ItemClicked += new ToolStripItemClickedEventHandler(this.On_ContextMenu_ItemClicked);
            menu.Items.Add(menuItem);

            node.ContextMenuStrip = menu;
        }
        
        /// <summary>
        /// Handler to perform extraction when menu item clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void On_ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item.Text == "Extract")
            {
                var node = this.ArchiveContentsTreeView.SelectedNode;
                var path = (string)node.Tag;
                
                var dlg = new FolderBrowserDialog();
                dlg.ShowNewFolderButton = true;
                dlg.Description = "Extract the selected file to this location.";
                var result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var outputDirectory = dlg.SelectedPath;
                    _archive.Extract(path, outputDirectory);
                }
            }
        }

        /// <summary>
        /// Handler for selecting the clicked node in a tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_TreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var pt = new Point(e.X, e.Y);
            var tree = (TreeView)sender;
            tree.PointToClient(pt);

            var node = tree.GetNodeAt(pt);
            if (node == null)
            {
                return;
            }

            tree.SelectedNode = node;
        }
    }
}
