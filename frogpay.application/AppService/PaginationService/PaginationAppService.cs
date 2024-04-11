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

        query = query.ApplyFilter(filter)
            .ApplyOrderBy(orderBy);
        
        return new PaginationEntity<TEntity>
        {
            Items = await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(),
            TotalItems = await query.CountAsync(),
            PageSize = pageSize,
            PageNumber = pageNumber
        };
    }
    

}