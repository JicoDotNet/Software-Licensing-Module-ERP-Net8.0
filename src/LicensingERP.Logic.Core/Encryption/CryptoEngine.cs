using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace LicensingERP.Logic.Encryption
{
    public class CryptoEngine : ICryptoEngine
    {
        private string encryptionKey;
        public CryptoEngine(string _Key)
        {
            if (_Key.Length != 32)
            {
                throw new Exception("Key Should be 32 digit chars");
            }
            else
            {
                this.encryptionKey = _Key;
            }
        }
        public string Encrypt(string inputText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
            // Ensure the key is 32 bytes (256-bit encryption)
            if (keyBytes.Length != 32)
            {
                Array.Resize(ref keyBytes, 32);
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.GenerateIV(); // Generate a random IV
                byte[] iv = aes.IV;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(iv, 0, iv.Length); // Write the IV at the beginning of the stream
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(inputText);
                            }
                        }

                        byte[] encrypted = ms.ToArray();
                        return Convert.ToBase64String(encrypted);
                    }
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
            // Ensure the key is 32 bytes (256-bit encryption)
            if (keyBytes.Length != 32)
            {
                Array.Resize(ref keyBytes, 32);
            }

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;

                byte[] iv = new byte[16];
                Array.Copy(encryptedBytes, 0, iv, 0, iv.Length);
                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream(encryptedBytes, 16, encryptedBytes.Length - 16))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}