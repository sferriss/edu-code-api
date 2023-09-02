using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Modules.Entities;

public class TopicContent : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;
    
    public string? Description { get; set; }
    
    public Guid TopicId { get; set; }

    public ModuleTopic Topic { get; set; } = null!;
}