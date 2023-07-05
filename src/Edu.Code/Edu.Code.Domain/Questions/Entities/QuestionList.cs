using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Questions.Entities;

public class QuestionList : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Title { get; set; } = null!;

    public List<Question> Questions  { get; } = new();

    public void AddQuestion(IEnumerable<Question> question)
    {
        Questions.AddRange(question);
    }
}