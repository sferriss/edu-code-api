using System.Linq.Expressions;
using Edu.Code.Domain.Abstractions.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Extensions;

public static class QueryExtension
{
    public static async Task<PaginatedResult<T>> ToPaginateAsync<T>(this IQueryable<T> query, int pageSize, int pageNumber)
        where T : class
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var paginated = query.Skip(pageSize * pageNumber)
            .Take(pageSize);

        var count = await query.CountAsync()
            .ConfigureAwait(false);
        
        var items = await paginated.ToArrayAsync()
            .ConfigureAwait(false);

        return new PaginatedResult<T>(count, items, pageNumber, pageSize);
    }
    
    public static IQueryable<T> ConditionalFilter<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression, bool condition)
    {
        return condition ? query.Where(expression) : query;
    }
}