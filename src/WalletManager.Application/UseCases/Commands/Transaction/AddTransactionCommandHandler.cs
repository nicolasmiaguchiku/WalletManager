using LiteBus.Commands.Abstractions;
using WalletManager.Domain.Base;
using WalletManager.Domain.Enities;
using WalletManager.Domain.Interfaces.Repositories;

namespace WalletManager.Application.UseCases.Commands.Transaction
{
    public sealed class AddTransactionCommandHandler(
        ITransactionRepository transactionRepository,
        IWalletRepository walletRepository) :
        ICommandHandler<AddTransactionCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> HandleAsync(AddTransactionCommand message, CancellationToken cancellationToken = default)
        {
            var wallet = await walletRepository.GetAsync(x => x.Id == message.WalletId, cancellationToken);

            var transaction = new TransactionEntity.Builder()
                .SetId(Guid.NewGuid())
                .SetWalletId(message.WalletId)
                .SetAmount(message.Request.Amount)
                .SetDescription(message.Request.Description ?? "")
                .SetType(message.Request.Type)
                .SetCreatedAt(DateTime.UtcNow)
                .Build();

            wallet.SetTransaction(transaction);

            await walletRepository.UpdateAsync(wallet, cancellationToken);

            await transactionRepository.InsertAsync(transaction, cancellationToken);

            return Result<Guid>.Success(transaction.Id);
        }
    }
}
