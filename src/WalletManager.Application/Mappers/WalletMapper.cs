using WalletManager.Application.Responses;
using WalletManager.Domain.Enities;

namespace WalletManager.Application.Mappers
{
    public static class WalletMapper
    {
        public static WalletResponse ToResponse(this WalletEntity walletEntity)
        {
            return new WalletResponse(
                walletEntity.Balance,
                walletEntity.Transactions.ToResponse());
        }
    }
}
