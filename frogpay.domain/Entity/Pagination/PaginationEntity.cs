using System;
using System.Collections.Generic;

namespace frogpay.domain.Entity.Pagination;

public class PaginationEntity<TEntity>
{
    public List<TEntity> Items { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}