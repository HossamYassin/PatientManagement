using System.Security.Cryptography;
using System.Text;

namespace PatientManagement.Infrastructure.Helpers;
public static class EncryptionHelper
{
    // better to store in azure key vault
    private static readonly string EncryptionKey = "wU9FqX67C7n5bsZf/q4Fz2tK1YYMgA1fFQ5kl8jYYxY=";  // Replace with your key
    private static readonly string IV = "3XJjC5Fi2tmAswD9g5/m9A==";  // Replace with your IV

    public static string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return null;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(EncryptionKey);
            aes.IV = Convert.FromBase64String(IV);

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            return null;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(EncryptionKey);
            aes.IV = Convert.FromBase64String(IV);

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
