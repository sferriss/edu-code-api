using Edu.Code.Domain.Abstractions.Pagination;
using MediatR;

namespace Edu.Code.Application.Queries.Questions.GetAll;

public class GetAllPagedQuery : PaginationQueryBase, IRequest<PaginatedResult<GetAllPagedQueryResult>>
{
    internal Guid ListId { get; set; }

    public GetAllPagedQuery WithListId(Guid id)
    {
        ListId = id;

        return this;
    }
}