using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Recruitment.Contracts;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Recruitment.IntegrationTests
{
    [TestClass]
    public class RecruitmentAPI_Tests : IntegrationTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Url = "api/command/CalculateHashCommand";
        }

        [TestMethod]
        [DataRow("login", "password")]
        public async Task Api_Hash_Returns_OkRequest(string login, string password)
        {
            var content = PrepareContent(login, password);

            var response = await Client.PostAsync(Url, content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow("", "password")]
        [DataRow("login", "")]
        public async Task Api_Hash_Returns_BadRequest(string login, string password)
        {
            var content = PrepareContent(login, password);

            var response = await Client.PostAsync(Url, content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private StringContent PrepareContent(string login, string password)
        {
            var cmd = new CalculateHashCommand { Login = login, Password = password };
            var dataAsString = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}