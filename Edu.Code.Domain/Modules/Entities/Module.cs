using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Modules.Entities;

public class Module : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
    
    public List<ModuleContent> Contents { get; } = new();
    
    public void AddContent(IEnumerable<ModuleContent>? contents)
    {
        if (contents != null) Contents.AddRange(contents);
    }
    
    public void AddContent(ModuleContent? content)
    {
        if (content != null) Contents.Add(content);
    }
}