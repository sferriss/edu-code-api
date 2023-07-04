namespace Edu.Code.Domain.Abstractions.Pagination;

public class PaginatedResult<T>
{
    public PaginatedResult(int count, IEnumerable<T> items, int page, int pageSize)
    {
        Total = count;
        Items = items;
        Page = page;
        PageSize = pageSize;
    }

    public PaginatedResult()
    {
    }

    public IEnumerable<T>? Items { get; set; }

    public int Page { get; set; }
    
    public int PageSize { get; set; }

    public int Pages => (int)Math.Ceiling(Total / (PageSize == 0 ? 1.0 : PageSize));
    
    public int Total { get; set; }
}