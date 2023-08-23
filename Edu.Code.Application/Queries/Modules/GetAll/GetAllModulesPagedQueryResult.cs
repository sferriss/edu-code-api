using Edu.Code.Application.Queries.Modules.Common;

namespace Edu.Code.Application.Queries.Modules.GetAll;

public class GetAllModulesPagedQueryResult
{
    public Guid Id { get; init; }

    public string Title { get; init; } = null!;
    
    public string? Description { get; init; }

    public ModuleContentResult[]? Contents { get; init; }
}