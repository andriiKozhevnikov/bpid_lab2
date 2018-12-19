using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Lab2.Services
{
    public class RSAService
    {
        public RSAParameters rsaParams { get; set; }

        public RSAService()
        {
            using (var provider = new RSACryptoServiceProvider(512))
            {
                rsaParams = provider.ExportParameters(true);
            }
        }

        public byte[] Encrypt(byte[] dataToEncrypt)
        {
            byte[] encryptedData;

            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.ImportParameters(rsaParams);

                encryptedData = rsaCryptoServiceProvider.Encrypt(dataToEncrypt, false);
            }

            return encryptedData;
        }

        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            byte[] decryptedData;

            using (var rsaCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rsaCryptoServiceProvider.ImportParameters(rsaParams);

                decryptedData = rsaCryptoServiceProvider.Decrypt(dataToDecrypt, false);
            }

            return decryptedData;
        }
    }
}
