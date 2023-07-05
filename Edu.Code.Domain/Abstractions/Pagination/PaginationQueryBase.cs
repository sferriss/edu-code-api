namespace Edu.Code.Domain.Abstractions.Pagination;

public class PaginationQueryBase
{
    public int PageNumber { get; set; } = 0;

    public int PageSize { get; set; } = 20;
}