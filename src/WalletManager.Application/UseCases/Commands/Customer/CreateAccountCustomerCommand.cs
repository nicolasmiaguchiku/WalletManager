using LiteBus.Commands.Abstractions;
using WalletManager.Domain.Base;

namespace WalletManager.Application.UseCases.Commands.Customer;

public record CreateAccountCustomerCommand() : ICommand<Result<Guid>>;