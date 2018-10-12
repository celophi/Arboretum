using Arboretum.Lib;
using Arboretum.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arboretum
{
    public partial class MainForm : Form
    {
        private PakZip _archive;

        public MainForm()
        {
            InitializeComponent();
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
                this.PopulateArchiveTree();
            }
        }

        /// <summary>
        /// Populates the archive view tree.
        /// </summary>
        private void PopulateArchiveTree()
        {
            TreeNode lastNode = null;
            string subPathAgg;

            // TODO: Find a better path separator.
            char pathSeparator = '/';

            this.ArchiveContentsTreeView.Nodes.Clear();
            var paths = _archive.PakFiles.Select(x => x.FileName);
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = this.ArchiveContentsTreeView.Nodes.Find(subPathAgg, true);

                    if (nodes.Length > 0)
                    {
                        lastNode = nodes[0];
                        continue;
                    }

                    if (lastNode == null)
                    {
                        lastNode = this.ArchiveContentsTreeView.Nodes.Add(subPathAgg, subPath);
                        continue;
                    }

                    lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                }

                lastNode = null;
            }
        }
    }
}
