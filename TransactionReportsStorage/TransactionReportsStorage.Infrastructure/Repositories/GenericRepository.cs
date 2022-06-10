using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TransactionReportsStorage.App.Interfaces.Repositories;
using TransactionReportsStorage.App.Paging;
using TransactionReportsStorage.Core.Common;
using TransactionReportsStorage.Infrastructure.EF;

namespace TransactionReportsStorage.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext _db;

        private readonly DbSet<TEntity> _table;

        public GenericRepository(ApplicationContext context)
        {
            this._db = context;
            this._table = _db.Set<TEntity>();
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, 
                                                     params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this._table
                            .AsNoTracking()
                            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                            .Take(pageParameters.PageSize);
            var entities = await this.Include(query, includeProperties).ToListAsync();
            var totalCount = await this._table.CountAsync();

            return new PagedList<TEntity>(entities, pageParameters, totalCount);
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, 
                                                     Expression<Func<TEntity, bool>> predicate, 
                                                     params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this._table
                            .AsNoTracking()
                            .Where(predicate)
                            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                            .Take(pageParameters.PageSize);
            var entities = await this.Include(query, includeProperties).ToListAsync();
            var totalCount = await this._table.CountAsync(predicate);

            return new PagedList<TEntity>(entities, pageParameters, totalCount);
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, 
                                            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties.Aggregate(query, (current, includeProperty)
                                               => current.Include(includeProperty));
        }

        private async Task SaveAsync()
        {
            await this._db.SaveChangesAsync();
        }
    }
}
