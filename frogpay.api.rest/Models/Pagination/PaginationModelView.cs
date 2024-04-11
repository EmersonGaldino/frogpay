using System;
using System.Collections.Generic;

namespace frogpay.api.rest.Models.Pagination;

public class PaginationModelView<TEntity>
{
    public List<TEntity> Items { get; set; }
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
}