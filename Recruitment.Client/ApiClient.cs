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
        private readonly string _baseUrl;
        // <summary>
        /// Initializes a new client using only one parameter.
        /// If there were more input parameters then it would be used ApiConfiguration class to pass into constructor many params.
        /// </summary>
        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public Task<string> CalculateHashCommandAsync(CalculateHashCommand cmd)
        {
            return CalculateHashCommandAsync(cmd, CancellationToken.None);
        }

        public async Task<string> CalculateHashCommandAsync(CalculateHashCommand cmd, CancellationToken cancellationToken)
        {
            var response = await _baseUrl.AppendPathSegment("api/command/CalculateHashCommand")
                                        .WithHeaders(new { Accept = "*/*", Content_Type = "application/json" })
                                        .PostJsonAsync(cmd, cancellationToken);

            return await response.GetStringAsync();
        }
    }
}