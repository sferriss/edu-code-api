namespace Edu.Code.Domain.Abstractions.Pagination;

public class PaginatedResult<T>
{
    public PaginatedResult(int count, IEnumerable<T> items)
    {
        TotalCount = count;
        Items = items;
    }

    public PaginatedResult()
    {
    }

    public IEnumerable<T>? Items { get; set; }
    
    public int TotalCount { get; set; }
}