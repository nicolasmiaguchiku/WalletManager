using LiteBus.Commands.Abstractions;
using WalletManager.Application.Mappers;
using WalletManager.Domain.Base;
using WalletManager.Domain.Enities;
using WalletManager.Domain.Errors;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Domain.Interfaces.Services;

namespace WalletManager.Application.UseCases.Commands.Customer
{
    public sealed class CreateAccountCustomerCommandHandler(
        ICustomerRepository customerRepository,
        IPasswordHashService passwordHashService,
        IWalletRepository walletRepository) : ICommandHandler<CreateAccountCustomerCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> HandleAsync(CreateAccountCustomerCommand message, CancellationToken cancellationToken = default)
        {
            var existingCustomer = await customerRepository.GetAsync(x => x.Email == message.Request.Email, cancellationToken);

            if (existingCustomer is not null)
            {
                return Result<Guid>.Failure(CustomerErrors.EmailAlreadyRegisteredError);
            }

            var password = passwordHashService.ComparePassword(message.Request.Password, message.Request.ConfirmPassword);

            if (!password)
            {
                return Result<Guid>.Failure(CustomerErrors.PasswordsDoNotMatchError);
            }

            var passswordHash = passwordHashService.EncryptPassword(message.Request.Password);

            var customerEntity = message.Request.ToEntity(passswordHash);

            await customerRepository.InsertAsync(customerEntity, cancellationToken);

            var walletEntity = new WalletEntity.Builder()
                .SetId(Guid.NewGuid())
                .SetCustomerId(customerEntity.Id)
                .SetBalance(0)
                .Build();

            await walletRepository.InsertAsync(walletEntity, cancellationToken);

            return Result<Guid>.Success(customerEntity.Id);
        }
    }
}