using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arboretum.Lib
{
    public class NetClient
    {
        public readonly Uri RootUrl;
        private Decryptor _decryptor;
        
        public NetClient(string rootPath)
        {
            this.RootUrl = new Uri(rootPath);
            _decryptor = new Decryptor();
        }

        /// <summary>
        /// Fetches an archive list and returns the lines in a list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> GetArchiveList(string path)
        {
            var lines = new List<string>();
            var data = this.DownloadEncryptedFile(path);

            using (var ms = new MemoryStream(data))
            using (var reader = new StreamReader(ms))
            {
                while (reader.Peek() > 0)
                {
                    lines.Add(reader.ReadLine());
                }
            }

            return lines;
        }

        /// <summary>
        /// Downloads an encrypted file and returns the payload decrypted.
        /// </summary>
        /// <param name="path">Relative URL.</param>
        /// <returns></returns>
        public byte[] DownloadEncryptedFile(string path)
        {
            try
            {
                var url = new Uri(this.RootUrl, path).ToString();
                
                using (var client = new WebClient())
                {
                    var encrypted = client.DownloadData(url);
                    return _decryptor.Decrypt(encrypted);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}