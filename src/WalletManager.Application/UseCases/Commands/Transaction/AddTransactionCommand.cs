using LiteBus.Commands.Abstractions;
using WalletManager.Application.Requests;
using WalletManager.Domain.Base;

namespace WalletManager.Application.UseCases.Commands.Transaction;

public record AddTransactionCommand(AddTransactionRequest Request) : ICommand<Result<Guid>>;