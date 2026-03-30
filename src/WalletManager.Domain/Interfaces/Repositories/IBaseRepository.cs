using System.Linq.Expressions;

namespace WalletManager.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(Expression<Func<TEntity, bool>> filterExpression,
            TEntity entity, CancellationToken cancellationToken);

        Task<long> DeleteAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);
    }
}