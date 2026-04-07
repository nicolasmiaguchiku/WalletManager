using LiteBus.Commands.Abstractions;
using WalletManager.Domain.Base;
using WalletManager.Domain.ValueObjects;

namespace WalletManager.Application.UseCases.Commands.Customer
{
    public sealed class LoginCommandHandler() : ICommandHandler<LoginCommand, Result<Token>>
    {
        public Task<Result<Token>> HandleAsync(LoginCommand message, CancellationToken cancellationToken = default)
        {
            
        }
    }
}