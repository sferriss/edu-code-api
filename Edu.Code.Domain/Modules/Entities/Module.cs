using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Modules.Entities;

public class Module : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    
    public List<ModuleTopic> Topics { get; } = new();
    
    public void AddContent(IEnumerable<ModuleTopic>? topics)
    {
        if (topics != null) Topics.AddRange(topics);
    }
    
    public void AddContent(ModuleTopic? topic)
    {
        if (topic != null) Topics.Add(topic);
    }
}