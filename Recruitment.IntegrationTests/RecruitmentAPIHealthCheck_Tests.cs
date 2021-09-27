using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recruitment.IntegrationTests
{
    [TestClass]
    public class RecruitmentAPIHealthCheck_Tests : IntegrationTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Url = "/api/health";
        }

        [TestMethod]
        public async Task HealthCheck_Head_Returns_200()
        {
            var response = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Head, Url));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task HealthCheck_Get_Returns_200()
        {
            var response = await Client.GetAsync(Url);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}