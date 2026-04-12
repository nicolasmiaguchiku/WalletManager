using LiteBus.Commands.Abstractions;
using WalletManager.Application.Mappers;
using WalletManager.Domain.Base;
using WalletManager.Domain.Interfaces.Services;
using WalletManager.Domain.ValueObjects;

namespace WalletManager.Application.UseCases.Commands.Customer
{
    public sealed class LoginCommandHandler(IAuthenticationService authenticationService) : ICommandHandler<LoginCommand, Result<Token>>
    {
        public async Task<Result<Token>> HandleAsync(LoginCommand message, CancellationToken cancellationToken = default)
        {
            var authenticationResult = await authenticationService.Authenticate(message.Request.ToUser(), cancellationToken);

            if (authenticationResult.IsFaiulure)
            {
                return Result<Token>.Failure(authenticationResult.Error);
            }

            return Result<Token>.Success(authenticationResult.Data);
        }
    }
}