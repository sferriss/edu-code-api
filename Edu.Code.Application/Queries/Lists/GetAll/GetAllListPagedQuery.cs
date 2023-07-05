using Edu.Code.Domain.Abstractions.Pagination;
using MediatR;

namespace Edu.Code.Application.Queries.Lists.GetAll;

public class GetAllListPagedQuery : PaginationQueryBase, IRequest<PaginatedResult<GetAllListPagedQueryResult>>
{
    
}