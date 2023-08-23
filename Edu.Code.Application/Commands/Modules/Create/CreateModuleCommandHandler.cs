using Edu.Code.Application.Mappers.Modules;
using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Modules.Repositories;
using MediatR;

namespace Edu.Code.Application.Commands.Modules.Create;

public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, CreateModuleCommandResult>
{
    private readonly IModuleRepository _moduleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ModuleMapper _mapper;

    public CreateModuleCommandHandler(IModuleRepository moduleRepository, IUnitOfWork unitOfWork, ModuleMapper mapper)
    {
        _moduleRepository = moduleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateModuleCommandResult> Handle(CreateModuleCommand command, CancellationToken cancellationToken)
    {
        var module = _mapper.ModuleToEntity(command);
        
        _moduleRepository.Add(module);
        await _unitOfWork.CommitAsync()
            .ConfigureAwait(false);

        return new (module.Id);
    }
}