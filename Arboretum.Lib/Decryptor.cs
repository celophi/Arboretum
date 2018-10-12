using Arboretum.Libraries;
using System;
using System.IO;

namespace Arboretum.Lib
{
    public class Decryptor
    {
        /// <summary>
        /// Used for decrypting main client files.
        /// </summary>
        private readonly Blowfish _cryptor;

        public Decryptor()
        {
            // For some reason IMC decided to use a custom schedule here of all 0x5F bytes :thinkingface:
            var schedule = new uint[1042];
            for (var i = 0; i < schedule.Length; i++)
            {
                schedule[i] = 0x5F5F5F5F;
            }

            _cryptor = new Blowfish(schedule);
        }

        /// <summary>
        /// Decrypts a file using the custom schedule and writes all bytes.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="outputFile"></param>
        public void Decrypt(string sourceFile, string outputFile)
        {
            // TODO: Use BSR and remove magic numbers.

            var raw = File.ReadAllBytes(sourceFile);

            var unencryptedSize = BitConverter.ToInt32(raw, 0);
            var encryptedSize = BitConverter.ToInt32(raw, 4);

            _cryptor.Decipher(raw, 8, encryptedSize);

            var buffer = new byte[unencryptedSize];
            Buffer.BlockCopy(raw, 8, buffer, 0, buffer.Length);
            File.WriteAllBytes(outputFile, buffer);
        }
    }
}
