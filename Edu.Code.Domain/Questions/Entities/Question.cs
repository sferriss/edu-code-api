using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Domain.Questions.Entities;

public class Question : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Description { get; set; } = null!;

    public string? Answer { get; set; }
    
    public string? Example { get; set; }

    public QuestionDifficulty Difficulty { get; set; }

    public Guid ListId { get; set; }

    public QuestionList List { get; set; } = null!;
}