using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using frogpay.domain.Entity.Pagination;

namespace frogpay.application.Interface.PaginationService;

public interface IPaginationAppService
{
    Task<PaginationEntity<TEntity>> GetPaginatedData<TEntity>(int pageSize, int pageNumber, 
        Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : class;
}