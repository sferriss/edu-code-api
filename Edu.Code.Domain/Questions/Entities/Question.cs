using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Questions.Enums;
using Edu.Code.Domain.StudentsDoubts.Entities;

namespace Edu.Code.Domain.Questions.Entities;

public class Question : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public QuestionDifficulty Difficulty { get; set; }

    public Guid ListId { get; set; }

    public QuestionList List { get; set; } = null!;
    
    public List<QuestionExample> Examples = new();
    
    public List<StudentDoubt> Doubts = new();

    public void AddExample(IEnumerable<QuestionExample> examples)
    {
        Examples.AddRange(examples);
    }
    
    public void AddDoubt(StudentDoubt doubt)
    {
        Doubts.Add(doubt);
    }
}