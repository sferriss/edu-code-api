using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.StudentsDoubts.Enums;

namespace Edu.Code.Domain.StudentsDoubts.Entities;

public class StudentDoubt : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Doubt { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public StudentDoubtType? Type { get; set; }
}