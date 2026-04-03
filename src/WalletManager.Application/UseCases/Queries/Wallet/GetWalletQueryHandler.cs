using LiteBus.Queries.Abstractions;
using WalletManager.Application.Mappers;
using WalletManager.Application.Responses;
using WalletManager.Domain.Base;
using WalletManager.Domain.Interfaces.Repositories;

namespace WalletManager.Application.UseCases.Queries.Wallet
{
    public class GetWalletQueryHandler(IWalletRepository walletRepository) : IQueryHandler<GetWalletQuery, Result<WalletResponse>>
    {
        public async Task<Result<WalletResponse>> HandleAsync(GetWalletQuery message, CancellationToken cancellationToken = default)
        {
            var walletEntity = await walletRepository.GetAsync(x => x.CustomerId == message.Id, cancellationToken);

            var wallet = walletEntity!.ToResponse();

            return Result<WalletResponse>.Success(wallet);
        }
    }
}