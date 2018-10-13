using Arboretum.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arboretum.Window
{
    public class RemoteTree
    {
        private readonly List<RemoteDescriptor> _remoteDecriptors = new List<RemoteDescriptor>
        {
            new RemoteDescriptor("ServerList", "toslive/patch/serverlist.xml", false),
            new RemoteDescriptor("StaticConfig", "toslive/patch/static__Config.txt", false),
            new RemoteDescriptor("DataFileList", "toslive/patch/full/data.file.list.txt", true, "toslive/patch/full/data"),
            new RemoteDescriptor("DataRevisions", "toslive/patch/full/data.revision.txt", true),
            new RemoteDescriptor("DataReleaseRevisions", "toslive/patch/full/release.revision.txt", true),
            new RemoteDescriptor("PatcherVersion", "toslive/patch/updater/patcher.version.txt", true),
            new RemoteDescriptor("UpdaterList", "toslive/patch/updater/updater.list.txt", false),
            new RemoteDescriptor("UpdaterDownloader", "toslive/patch/updater/Updater_Downloader.exe", true),
            new RemoteDescriptor("PartialDataRevisions", "toslive/patch/partial/data.revision.txt", true, "toslive/patch/partial/data"),
            new RemoteDescriptor("PartialPreRevisions", "toslive/patch/partial/pre.revision.txt", true),
            new RemoteDescriptor("PartialReleaseRevisions", "toslive/patch/partial/release.revision.txt", true, "toslive/patch/partial/release"),
        };

        public void Thing(TreeView tree)
        {
            var urls = _remoteDecriptors.Select(x => x.Url);
            foreach (var url in urls)
            {
                this.AttachPathToTree(tree, url);
            }

            // Read file lists.
            var cls = new NetClient(Properties.Settings.Default.DefaultUrl);

            // TODO: Maybe let each have a delegate method for how to parse the list.

            // DataFileList
            var descriptor = _remoteDecriptors.FirstOrDefault(x => x.Key == "DataFileList");
            var list = cls.GetArchiveList(descriptor.Url);
            foreach (var line in list)
            {
                var path = $"{descriptor.Folder}/{line}.ipf";
                this.AttachPathToTree(tree, path);
            }

            // PartialDataRevisions
            descriptor = _remoteDecriptors.FirstOrDefault(x => x.Key == "PartialDataRevisions");
            list = cls.GetArchiveList(descriptor.Url);
            foreach (var line in list)
            {
                var main = line.Split(' ')[0];
                var sub = Convert.ToInt32(line.Split(' ')[1]).ToString("D3");
                var path = $"{descriptor.Folder}/{main}_{sub}{sub}.ipf";
                this.AttachPathToTree(tree, path);
            }

            // PartialReleaseRevisions
            descriptor = _remoteDecriptors.FirstOrDefault(x => x.Key == "PartialReleaseRevisions");
            list = cls.GetArchiveList(descriptor.Url);
            foreach (var line in list)
            {
                var main = line.Split(' ')[0];
                var sub = Convert.ToInt32(line.Split(' ')[1]).ToString("D3");
                var path = $"{descriptor.Url}/{main}_{sub}{sub}.pak";
                this.AttachPathToTree(tree, path);
            }
        }

        /// <summary>
        /// Attaches a file path to the tree.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="path"></param>
        private void AttachPathToTree(TreeView tree, string path)
        {
            // TODO: combine this with other method instead of duplicating.

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
    }
}
