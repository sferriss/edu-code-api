using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Questions.Entities;

namespace Edu.Code.Domain.StudentsDoubts.Entities;

public class StudentDoubt : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Doubt { get; set; } = null!;

    public string? Code { get; set; }

    public string Answer { get; set; } = null!;

    public Guid QuestionId { get; set; }

    public Question Question { get; set; } = null!;
}