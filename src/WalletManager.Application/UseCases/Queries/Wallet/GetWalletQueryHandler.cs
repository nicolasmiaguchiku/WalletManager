using LiteBus.Queries.Abstractions;
using WalletManager.Application.Mappers;
using WalletManager.Application.Responses;
using WalletManager.Domain.Base;
using WalletManager.Domain.Interfaces.Repositories;

namespace WalletManager.Application.UseCases.Queries.Wallet
{
    public class GetWalletQueryHandler(
        IWalletRepository walletRepository,
        ITransactionRepository transactionRepository) : IQueryHandler<GetWalletQuery, Result<WalletResponse>>
    {
        public async Task<Result<WalletResponse>> HandleAsync(GetWalletQuery message, CancellationToken cancellationToken = default)
        {
            var walletEntity = await walletRepository.GetAsync(x => x.CustomerId == message.Id, cancellationToken);

            var transactions = await transactionRepository.GetAllAsync(x => x.WalletId == walletEntity!.Id, cancellationToken);

            var wallet = walletEntity!.ToResponse(transactions);

            return Result<WalletResponse>.Success(wallet);
        }
    }
}