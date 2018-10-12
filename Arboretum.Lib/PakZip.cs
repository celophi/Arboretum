using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Arboretum.Lib
{
    public class PakZip
    {
        /// <summary>
        /// Path to the archive.
        /// </summary>
        public readonly string ArchivePath;

        /// <summary>
        /// List of files contained within the PAK archive.
        /// </summary>
        public List<PakFile> PakFiles;

        public PakZip(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Error. The file was not found.", path);
            }

            this.ArchivePath = path;
            this.PakFiles = new List<PakFile>();

            using (var reader = new BinaryReader(File.Open(this.ArchivePath, FileMode.Open)))
            {
                var total = reader.BaseStream.Length;
                while (reader.BaseStream.Position < total)
                {
                    var pak = new PakFile(reader);
                    this.PakFiles.Add(pak);
                }
            }
        }

        /// <summary>
        /// Extracts a single file inside of a PAK archive to a destination directory.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="outputDirectory"></param>
        public void Extract(string filename, string outputDirectory)
        {
            var pak = this.PakFiles.FirstOrDefault(x => x.FileName == filename);
            if (pak == null)
            {
                throw new FileNotFoundException($"Error. Could not find file inside the archive.", filename);
            }

            var buffer = new byte[pak.UncompressedSize];
            var outputFile = Path.GetFullPath(Path.Combine(outputDirectory, filename));
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            using (var ms = new MemoryStream(pak.Zipped))
            using (var writer = File.Create(outputFile))
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    ds.CopyTo(writer);
                }
            }
        }
    }
}