using WalletManager.Application.Responses;
using WalletManager.Domain.Enities;

namespace WalletManager.Application.Mappers
{
    public static class TransactionMapper
    {
        public static IEnumerable<TransactionResponse> ToResponse(this IEnumerable<TransactionEntity> transactionEntities)
        {
            return transactionEntities.Select(x => new TransactionResponse(
                x.Id,
                x.Amount,
                x.Description,
                x.Type.ToString(),
                x.CreatedAt));
        }
    }
}