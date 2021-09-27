using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruitment.DomainLogic;

namespace Recruitment.Tests
{
    [TestClass]
    public class MD5Encryptor_Tests
    {
        [DataTestMethod]
        [DataRow("", "d41d8cd98f00b204e9800998ecf8427e")]
        [DataRow("a", "0cc175b9c0f1b6a831c399e269772661")]
        [DataRow("abc", "900150983cd24fb0d6963f7d28e17f72")]
        [DataRow("message digest", "f96b697d7cb7938d525a2f31aaf161d0")]
        [DataRow("abcdefghijklmnopqrstuvwxyz", "c3fcd3d76192e4007dfb496cca67e13b")]
        [DataRow("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "d174ab98d277d9f5a5611c2c9f419d9f")]
        [DataRow("12345678901234567890123456789012345678901234567890123456789012345678901234567890", "57edf4a22be3c955ac49da2e2107b67a")]
        public void Check_If_MD5_Hash_Is_Valid(string source, string expected)
        {
            var encryptor = new MD5Encryptor();

            var result = encryptor.Encrypt(source);

            Assert.AreEqual(expected, result);
        }
    }
}
