using System;
using System.Linq;
using System.Linq.Expressions;

namespace frogpay.application.AppService.PaginationService;

public static class QueryExtensions
{
    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Expression<Func<T, bool>> filter)
    {
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return query;
    }

    public static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> query, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    {
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        return query;
    }
}