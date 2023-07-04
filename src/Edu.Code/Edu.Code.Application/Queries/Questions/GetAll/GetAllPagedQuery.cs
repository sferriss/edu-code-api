using Edu.Code.Domain.Abstractions.Pagination;
using MediatR;

namespace Edu.Code.Application.Queries.Questions.GetAll;

public class GetAllPagedQuery : PaginationQueryBase, IRequest<PaginatedResult<GetAllPagedQueryResult>>
{
}