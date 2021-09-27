using Flurl.Http;
using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recruitment.Client;
using Recruitment.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recruitment.Tests
{
    [TestClass]
    public class ApiClient_Tests
    {
        private ApiClient _apiClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _apiClient = new ApiClient("http://localhost/");
        }

        [TestMethod]
        public async Task ApiClient_Returns_200_Status()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("hashcode", 200);

                await _apiClient.CalculateHashCommandAsync(It.IsAny<CalculateHashCommand>());

                httpTest.ShouldHaveCalled("http://localhost/api/command/CalculateHashCommand").WithVerb(HttpMethod.Post).WithHeader("content-type", "application/json");
            }
        }

        [TestMethod]
        [DataRow(400)]
        [DataRow(500)]
        public async Task ApiClient_Throws_FlurlHttpException_With_Expected_Status(int statuscode)
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("hashcode", statuscode);

                var ex = await Assert.ThrowsExceptionAsync<FlurlHttpException>(async () => _ = await _apiClient.CalculateHashCommandAsync(new CalculateHashCommand()));
                Assert.AreEqual(ex.StatusCode, statuscode);
            }
        }

        [TestMethod]
        public void ApiClient_ApiConfiguration_Constructor_Throws_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ApiClient(null));
        }
    }
}
