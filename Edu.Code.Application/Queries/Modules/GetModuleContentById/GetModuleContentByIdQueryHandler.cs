using Edu.Code.Application.Exceptions;
using Edu.Code.Application.Mappers.Modules;
using Edu.Code.Domain.Modules.Repositories;
using MediatR;

namespace Edu.Code.Application.Queries.Modules.GetModuleContentById;

public class GetModuleContentByIdQueryHandler : IRequestHandler<GetModuleContentByIdQuery, GetModuleContentByIdQueryResult>
{
    private readonly IModuleContentRepository _moduleRepository;
    private readonly ModuleMapper _moduleMapper;

    public GetModuleContentByIdQueryHandler(IModuleContentRepository moduleRepository, ModuleMapper moduleMapper)
    {
        _moduleRepository = moduleRepository;
        _moduleMapper = moduleMapper;
    }

    public async Task<GetModuleContentByIdQueryResult> Handle(GetModuleContentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _moduleRepository.GetByIdAsync(request.Id)
            .ConfigureAwait(false);
        
        if (result is null)
        {
            throw new NotFoundException("Item não encontrado.");
        }

        return _moduleMapper.ModuleContentToQueryByIdResult(result);
    }
}