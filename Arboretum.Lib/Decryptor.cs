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
        /// Decrypts an encrypted TOS file and returns a byte array for the result.
        /// </summary>
        /// <param name="data"></param>
        public byte[] Decrypt(byte[] data)
        {
            // TODO: Use BSR and remove magic numbers.
            
            var unencryptedSize = BitConverter.ToInt32(data, 0);
            var encryptedSize = BitConverter.ToInt32(data, 4);

            _cryptor.Decipher(data, 8, encryptedSize);

            var buffer = new byte[unencryptedSize];
            Buffer.BlockCopy(data, 8, buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
