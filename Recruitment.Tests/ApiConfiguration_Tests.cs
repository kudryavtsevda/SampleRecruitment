using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruitment.Client;
using System;

namespace Recruitment.Tests
{
    [TestClass]
    public class ApiConfiguration_Tests
    {
        [TestMethod]
        [DataRow("SomeValue")]
        public void ApiConfiguration_BaseUrl_Set_NotEmpty(string expected)
        {
            var config = new ApiConfiguration();

            config.BaseUrl = expected;

            Assert.AreEqual(expected, config.BaseUrl);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void ApiConfiguration_BaseUrl_Throws_ArgumentNullException(string value)
        {
            var config = new ApiConfiguration();

            Assert.ThrowsException<ArgumentException>(() => config.BaseUrl = value);
        }
    }
}
