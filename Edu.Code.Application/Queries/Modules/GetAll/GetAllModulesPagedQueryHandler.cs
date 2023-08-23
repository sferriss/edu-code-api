using Edu.Code.Application.Mappers.Modules;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Modules.Repositories;
using MediatR;

namespace Edu.Code.Application.Queries.Modules.GetAll;

public class GetAllModulesPagedQueryHandler : IRequestHandler<GetAllModulesPagedQuery, PaginatedResult<GetAllModulesPagedQueryResult>>
{
    private readonly IModuleRepository _moduleRepository;
    private readonly ModuleMapper _moduleMapper;

    public GetAllModulesPagedQueryHandler(IModuleRepository moduleRepository, ModuleMapper moduleMapper)
    {
        _moduleRepository = moduleRepository;
        _moduleMapper = moduleMapper;
    }

    public async Task<PaginatedResult<GetAllModulesPagedQueryResult>> Handle(GetAllModulesPagedQuery request, CancellationToken cancellationToken)
    {
        var result = await _moduleRepository.GetAllPagedWithContentAsync(request.PageNumber, request.PageSize)
            .ConfigureAwait(false);
        
        var mappedResult = result.Items?.Select(x => _moduleMapper.ModuleToQueryResult(x));

        return new PaginatedResult<GetAllModulesPagedQueryResult>
        {
            Items = mappedResult,
            PageSize = result.PageSize,
            Page = result.Page,
            Total = result.Total,
        };
    }
}