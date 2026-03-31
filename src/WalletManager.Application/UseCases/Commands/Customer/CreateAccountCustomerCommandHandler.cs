using LiteBus.Commands.Abstractions;
using WalletManager.Domain.Base;
using WalletManager.Domain.Errors;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Domain.Interfaces.Services;

namespace WalletManager.Application.UseCases.Commands.Customer
{
    public sealed class CreateAccountCustomerCommandHandler(
        ICustomerRepository customerRepository,
        IPasswordHashService passwordHashService)
        : ICommandHandler<CreateAccountCustomerCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> HandleAsync(CreateAccountCustomerCommand message, CancellationToken cancellationToken = default)
        {
            var existingCustomer = await customerRepository.GetAsync(x => x.Email == message.Request.Email, cancellationToken);

            if (existingCustomer is not null)
            {
                return Result<Guid>.Failure(CustomerErrors.EmailAlreadyRegisteredError);
            }

            var password = passwordHashService.ComparePassword(message.Request.Password, message.Request.ConfirmPassword);

            if(!password)
            {
                return Result<Guid>.Failure(CustomerErrors.);
            }
        }
    }
}