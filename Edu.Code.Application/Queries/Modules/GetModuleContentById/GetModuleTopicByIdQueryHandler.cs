using Edu.Code.Application.Exceptions;
using Edu.Code.Application.Mappers.Modules;
using Edu.Code.Domain.Modules.Repositories;
using MediatR;

namespace Edu.Code.Application.Queries.Modules.GetModuleContentById;

public class GetModuleTopicByIdQueryHandler : IRequestHandler<GetModuleTopicByIdQuery, GetModuleTopicByIdQueryResult>
{
    private readonly IModuleTopicRepository _moduleTopicRepository;
    private readonly ModuleMapper _moduleMapper;

    public GetModuleTopicByIdQueryHandler(IModuleTopicRepository moduleTopicRepository, ModuleMapper moduleMapper)
    {
        _moduleTopicRepository = moduleTopicRepository;
        _moduleMapper = moduleMapper;
    }

    public async Task<GetModuleTopicByIdQueryResult> Handle(GetModuleTopicByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _moduleTopicRepository.GetByIdAsync(request.Id)
            .ConfigureAwait(false);
        
        if (result is null)
        {
            throw new NotFoundException("Item não encontrado.");
        }

        return _moduleMapper.ModuleTopicToResult(result);
    }
}