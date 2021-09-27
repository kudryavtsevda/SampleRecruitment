using CommandQuery;
using Recruitment.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Recruitment.DomainLogic;
using System;

namespace Recruitment.CommandHandlers
{
    public class CalculateHashCommandHandler : ICommandHandler<CalculateHashCommand, string>
    {
        private readonly IEncryptor _encryptor;
        public CalculateHashCommandHandler(IEncryptor encryptor)
        {
            _encryptor = encryptor ?? throw new System.ArgumentNullException(nameof(encryptor));
        }

        public Task<string> HandleAsync(CalculateHashCommand command, CancellationToken cancellationToken)
        {
            _ = command ?? throw new ArgumentNullException(nameof(command));

            return Task.FromResult(_encryptor.Encrypt($"{command.Login}{command.Password}"));
        }
    }
}