using System.Linq.Expressions;

namespace WalletManager.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity?>> GetAllAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);
    }
}