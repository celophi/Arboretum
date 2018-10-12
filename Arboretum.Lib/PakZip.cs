using System.IO;
using System.IO.Compression;
using System.Text;

namespace Arboretum.Lib
{
    public class PakZip
    {
        public readonly string Archive;

        public PakZip(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Error. The file {path} was not found.");
            }

            this.Archive = path;
        }

        /// <summary>
        /// Extracts a PakZip file to a directory.
        /// </summary>
        /// <param name="outputDirectory"></param>
        public void Extract(string outputDirectory)
        {
            using (var reader = new BinaryReader(File.Open(this.Archive, FileMode.Open)))
            {
                var total = reader.BaseStream.Length;

                while (reader.BaseStream.Position < total)
                {
                    var filenameLength = reader.ReadInt16();
                    var crc = reader.ReadInt32();
                    var compressedSize = reader.ReadUInt32();
                    var uncompressedSize = reader.ReadUInt32();
                    var filenameBytes = reader.ReadBytes(filenameLength);
                    var zipped = reader.ReadBytes((int)compressedSize);

                    var filename = Encoding.UTF8.GetString(filenameBytes);
                    var buffer = new byte[uncompressedSize];

                    var outputFile = Path.GetFullPath(Path.Combine(outputDirectory, filename));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                    using (var ms = new MemoryStream(zipped))
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
    }
}