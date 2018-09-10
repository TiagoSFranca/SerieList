using System;
using System.Security.Cryptography;
using System.Text;

namespace SerieList.Extras.Util.Crypt
{
    public class MD5Crypt
    {
        const string password = "12345";

        public static string Encrypt(string message)
        {
            byte[] results;
            UTF8Encoding uTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tDESKey = hashProvider.ComputeHash(uTF8.GetBytes(password));
            TripleDESCryptoServiceProvider tDESAlgorithm = new TripleDESCryptoServiceProvider();
            tDESAlgorithm.Key = tDESKey;
            tDESAlgorithm.Mode = CipherMode.ECB;
            tDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] dataToEncrypt = uTF8.GetBytes(message);
            try
            {
                ICryptoTransform encryptor = tDESAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                tDESAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

        public static string Decrypt(string message)
        {
            byte[] results;
            UTF8Encoding uTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tDESKey = hashProvider.ComputeHash(uTF8.GetBytes(password));
            TripleDESCryptoServiceProvider tDESAlgorithm = new TripleDESCryptoServiceProvider();
            tDESAlgorithm.Key = tDESKey;
            tDESAlgorithm.Mode = CipherMode.ECB;
            tDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] dataToDecrypt = Convert.FromBase64String(message);
            try
            {
                ICryptoTransform decryptor = tDESAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                tDESAlgorithm.Clear();
                hashProvider.Clear();
            }
            return uTF8.GetString(results);
        }
    }
}
