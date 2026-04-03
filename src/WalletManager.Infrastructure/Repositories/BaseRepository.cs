using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Infrastructure.Context;

namespace WalletManager.Infrastructure.Repositories
{
    public class BaseRepository<TEntity>(DataContext dataContext) : IBaseRepository<TEntity> where TEntity : class
    {
        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken)
        {
            return await dataContext.Set<TEntity>()
                .Where(filterExpression)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            dataContext.Set<TEntity>().Add(entity);
            await dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            dataContext.Set<TEntity>().Update(entity);
            await dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken)
        {
            return await dataContext.Set<TEntity>()
                .FirstOrDefaultAsync(filterExpression, cancellationToken);
        }

        public async Task<IEnumerable<TEntity?>> GetAllAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken)
        {
            return await dataContext.Set<TEntity>()
                .Where(filterExpression)
                .ToListAsync(cancellationToken);
        }
    }
}
