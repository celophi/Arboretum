namespace Arboretum.Lib
{
    public class RemoteDescriptor
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public readonly string Key;

        /// <summary>
        /// Relative URL to the file.
        /// </summary>
        public readonly string Url;

        /// <summary>
        /// When 'true', indicates the file is encrypted.
        /// </summary>
        public readonly bool IsEncrypted;

        /// <summary>
        /// Folder where lists contain files.
        /// </summary>
        public readonly string Folder;

        public RemoteDescriptor(string key, string url, bool encrypted, string folder = null)
        {
            this.Key = key;
            this.Url = url;
            this.IsEncrypted = encrypted;
            this.Folder = folder;
        }
    }
}
