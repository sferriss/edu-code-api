using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Modules.Entities;

public class ModuleTopic : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    
    public Guid ModuleId { get; set; }

    public Module Module { get; set; } = null!;
    
    public List<TopicContent> Contents { get; } = new();
    
    public void AddContent(IEnumerable<TopicContent>? contents)
    {
        if (contents != null) Contents.AddRange(contents);
    }
    
    public void AddContent(TopicContent? content)
    {
        if (content != null) Contents.Add(content);
    }
}