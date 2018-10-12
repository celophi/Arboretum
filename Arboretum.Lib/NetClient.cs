using System;
using System.Net;

namespace Arboretum.Lib
{
    public class NetClient
    {
        /// <summary>
        /// Base URL for hosted files.
        /// </summary>
        public string ContentUrl { get; set; }

        /// <summary>
        /// Fetches bytes from a URL.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] FetchData(string path)
        {
            using (var client = new WebClient())
            {
                var baseUri = new Uri(this.ContentUrl);
                var fullPath = new Uri(baseUri, path);

                return client.DownloadData(fullPath);
            }
        }
    }
}
