using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Modules.Entities;

public class ModuleContent : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;

    public string? Title { get; set; }
    
    public string? Description { get; set; }

    public Guid ModuleId { get; set; }

    public Module Module { get; set; } = null!;
}