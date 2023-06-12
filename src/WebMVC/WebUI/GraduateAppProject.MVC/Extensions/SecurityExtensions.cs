using System.Security.Cryptography;
using System.Text;

namespace GraduateAppProject.MVC.Extensions
{
    public static class SecurityExtensions
    {
        public static string EncryptWithHash(this string citizenNumber, IConfiguration configuration)
        {
            var key = configuration["EncryptKey:RandomKey"];
            byte[] data = UTF8Encoding.UTF8.GetBytes(citizenNumber);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (var tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        public static string DecryptWithHash(this string hashedCitizenNumber, IConfiguration configuration)
        {
            var key = configuration["EncryptKey:RandomKey"];

            byte[] data = Convert.FromBase64String(hashedCitizenNumber);
            var returnVal = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    returnVal = UTF8Encoding.UTF8.GetString(results);
                }
            }

            return returnVal;
        }
    }
}
