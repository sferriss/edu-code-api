using Edu.Code.Domain.Abstractions;

namespace Edu.Code.Domain.Questions.Entities;

public class QuestionList : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Title { get; set; } = null!;

    public ICollection<Question> Questions  { get; } = new List<Question>();

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }
}