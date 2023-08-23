using MediatR;

namespace Edu.Code.Application.Commands.Modules.Create;

public record CreateModuleCommand : IRequest<CreateModuleCommandResult>
{
    public string Title { get; init; } = null!;
    
    public string? Description { get; init; }

    public ModuleContentData[]? Contents { get; init; }
}