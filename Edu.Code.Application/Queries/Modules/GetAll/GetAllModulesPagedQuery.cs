using Edu.Code.Domain.Abstractions.Pagination;
using MediatR;

namespace Edu.Code.Application.Queries.Modules.GetAll;

public class GetAllModulesPagedQuery : PaginationQueryBase, IRequest<PaginatedResult<GetAllModulesPagedQueryResult>>
{
}