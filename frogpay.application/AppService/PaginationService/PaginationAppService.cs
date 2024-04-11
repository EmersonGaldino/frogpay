using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using frogpay.application.Interface.PaginationService;
using frogpay.domain.Entity.Pagination;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.application.AppService.PaginationService;

public class PaginationAppService : IPaginationAppService
{
    private readonly ContextDb context;
    public PaginationAppService(ContextDb context)
    {
        this.context = context;
    }
    public async Task<PaginationEntity<TEntity>> GetPaginatedData<TEntity>(
        int pageSize, 
        int pageNumber, 
        Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : class
    {
        IQueryable<TEntity> query = context.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        var data = await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pagedResult = new PaginationEntity<TEntity>
        {
            Items = data,
            TotalItems = totalItems,
            PageSize = pageSize,
            PageNumber = pageNumber
        };

        return pagedResult;
    }
}