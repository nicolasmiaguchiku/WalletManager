using LiteBus.Commands.Abstractions;
using WalletManager.Application.Mappers;
using WalletManager.Domain.Base;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Domain.Interfaces.Services;
using WalletManager.Domain.ValueObjects;

namespace WalletManager.Application.UseCases.Commands.Customer
{
    public sealed class LoginCommandHandler(
        ICustomerRepository customerRepository,
        IAuthenticationService authenticationService) : ICommandHandler<LoginCommand, Result<Token>>
    {
        public async Task<Result<Token>> HandleAsync(LoginCommand message, CancellationToken cancellationToken = default)
        {
            var customer = await customerRepository.GetAsync(x => x.Email == message.Request.Email, cancellationToken);

            if(customer is null)
            {
                return Result<Token>.Failure(customer);
            }

            var authenticationResult = authenticationService.Authenticate(customer.ToUser());
        }
    }
}