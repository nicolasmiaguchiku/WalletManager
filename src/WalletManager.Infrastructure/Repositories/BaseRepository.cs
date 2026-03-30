using System.Linq.Expressions;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Infrastructure.Context;

namespace WalletManager.Infrastructure.Repositories
{
    public class BaseRepository<TEntity>(DataContext dataContext) : IBaseRepository<TEntity> where TEntity : class
    {
        public Task<long> DeleteAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Expression<Func<TEntity, bool>> filterExpression, TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
