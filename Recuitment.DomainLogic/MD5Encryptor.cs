using System;
using System.Security.Cryptography;
using System.Text;

namespace Recruitment.DomainLogic
{
    public class MD5Encryptor : IEncryptor
    {
        public string Encrypt(string source)
        {
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).ToLower().Replace("-", string.Empty);
            }
        }
    }
}