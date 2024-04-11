using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using frogpay.domain.Entity.Pagination;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.Pagination;

public class Pagination
{
    public async Task<PaginationEntity<TEntity>> GetPaginatedData<TEntity>(
        DbContext context,
        int pageSize, 
        int pageNumber,
        Expression<Func<TEntity,bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
    ) where TEntity  : class
    {
        IQueryable<TEntity> query = context.Set<TEntity>();
        
        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);
        
        var totalItems = await query.CountAsync();
        // var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        
        var data = await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PaginationEntity<TEntity>
        {
            Items = data,
            TotalItems = totalItems,
            PageSize = pageSize,
            PageNumber = pageNumber
        };
    }
}