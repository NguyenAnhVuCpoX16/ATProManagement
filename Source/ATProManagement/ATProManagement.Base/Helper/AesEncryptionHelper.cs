using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ATProManagement.Base
{
    public class AesEncryptionHelper
    {
        private const string SECRET_KEY = "ATPRO_SECRET_KEY_2026";
        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(SECRET_KEY));
            aes.GenerateIV();
            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            var result = aes.IV.Concat(encryptedBytes).ToArray();
            return Convert.ToBase64String(result);
        }
        public static string Decrypt(string cipherText)
        {
            var fullBytes = Convert.FromBase64String(cipherText);
            using Aes aes = Aes.Create();
            aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(SECRET_KEY));
            var iv = fullBytes.Take(16).ToArray();
            var cipher = fullBytes.Skip(16).ToArray();
            aes.IV = iv;
            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var decryptedBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
