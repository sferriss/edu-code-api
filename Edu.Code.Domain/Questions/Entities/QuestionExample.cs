using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Questions.Entities;

public class QuestionExample : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Input { get; set; } = null!;

    public string Output { get; set; } = null!;

    public Guid QuestionId { get; set; }

    public Question Question { get; set; } = null!;
}