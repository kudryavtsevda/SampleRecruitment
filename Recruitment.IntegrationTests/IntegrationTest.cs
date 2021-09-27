using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Recruitment.Api;
using System.Net.Http;

namespace Recruitment.IntegrationTests
{
    public abstract class IntegrationTest
    {
        private readonly TestServer _server;

        protected IntegrationTest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        protected string Url { get; set; }
        protected HttpClient Client { get; private set; }
    }
}
