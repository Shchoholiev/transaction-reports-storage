using System.Linq.Expressions;
using TransactionReportsStorage.App.Paging;
using TransactionReportsStorage.Core.Common;

namespace TransactionReportsStorage.App.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters,
                                              params Expression<Func<TEntity, object>>[] includeProperties);

        Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters,
                                              Expression<Func<TEntity, bool>> predicate,
                                              params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
