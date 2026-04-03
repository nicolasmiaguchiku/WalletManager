using LiteBus.Queries.Abstractions;
using WalletManager.Application.Responses;
using WalletManager.Domain.Base;

namespace WalletManager.Application.UseCases.Queries.Wallet;

public record GetWalletQuery(Guid Id) : IQuery<Result<WalletResponse>>;