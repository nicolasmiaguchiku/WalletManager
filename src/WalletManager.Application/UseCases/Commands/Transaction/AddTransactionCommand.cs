using LiteBus.Commands.Abstractions;
using WalletManager.Application.Requests;
using WalletManager.Domain.Base;

namespace WalletManager.Application.UseCases.Commands.Transaction;

public record AddTransactionCommand(AddTransactionRequest Request, Guid WalletId) : ICommand<Result<Guid>>;