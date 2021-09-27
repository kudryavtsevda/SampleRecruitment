using Flurl;
using Flurl.Http;
using Recruitment.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Client
{
    public class ApiClient : IApiClient
    {
        private readonly IApiClientConfiguration _config;

        public ApiClient(string baseUrl)
        {
            _ = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));

            _config = new ApiConfiguration { BaseUrl = baseUrl };
        }

        public ApiClient(IApiClientConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _ = config.BaseUrl ?? throw new ArgumentNullException(nameof(config.BaseUrl));
        }

        public Task<string> CalculateHashCommandAsync(CalculateHashCommand cmd)
        {
            return CalculateHashCommandAsync(cmd, CancellationToken.None);
        }

        public async Task<string> CalculateHashCommandAsync(CalculateHashCommand cmd, CancellationToken cancellationToken)
        {
            var baseUrl = _config.BaseUrl;

            var response = await baseUrl.AppendPathSegment("api/command/CalculateHashCommand")
                                        .WithHeaders(new { Accept = "*/*", Content_Type = "application/json" })
                                        .PostJsonAsync(cmd, cancellationToken);

            return await response.GetStringAsync();
        }

        public IApiClientConfiguration Configuration => _config;
    }
}