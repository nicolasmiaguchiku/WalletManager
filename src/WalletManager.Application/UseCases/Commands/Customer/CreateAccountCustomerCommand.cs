using LiteBus.Commands.Abstractions;
using WalletManager.Application.Requests;
using WalletManager.Domain.Base;

namespace WalletManager.Application.UseCases.Commands.Customer;

public record CreateAccountCustomerCommand(CreateAccountCustomerRequest Request) : ICommand<Result<Guid>>;