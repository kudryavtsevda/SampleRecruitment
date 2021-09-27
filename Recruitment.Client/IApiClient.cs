using Recruitment.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Client
{
    public interface IApiClient
    {
        Task<string> CalculateHashCommandAsync(CalculateHashCommand cmd);
        Task<string> CalculateHashCommandAsync(CalculateHashCommand cmd, CancellationToken cancellationToken);
    }
}
