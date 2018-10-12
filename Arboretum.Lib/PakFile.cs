using System.IO;
using System.Text;

namespace Arboretum.Lib
{
    /// <summary>
    /// Represents a compressed file insize of a PakZip archive.
    /// </summary>
    public class PakFile
    {
        /// <summary>
        /// Length of the file name.
        /// </summary>
        public readonly ushort FileNameLength;

        /// <summary>
        /// CRC checksum.
        /// </summary>
        public readonly int Checksum;

        /// <summary>
        /// Compressed size of the file in bytes.
        /// </summary>
        public readonly uint CompressedSize;

        /// <summary>
        /// Size of the file after inflate in bytes.
        /// </summary>
        public readonly uint UncompressedSize;

        /// <summary>
        /// Name of the file.
        /// </summary>
        public readonly string FileName;

        /// <summary>
        /// Compressed file data.
        /// </summary>
        public readonly byte[] Zipped;

        public PakFile(BinaryReader reader)
        {
            this.FileNameLength = reader.ReadUInt16();
            this.Checksum = reader.ReadInt32();
            this.CompressedSize = reader.ReadUInt32();
            this.UncompressedSize = reader.ReadUInt32();

            var bytes = reader.ReadBytes(this.FileNameLength);
            this.FileName = Encoding.UTF8.GetString(bytes);

            this.Zipped = reader.ReadBytes((int)this.CompressedSize);
        }
    }
}