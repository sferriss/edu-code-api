using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Queries.Lists.Common;

public class QuestionResult
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;

    public QuestionDifficulty Difficulty { get; set; }
}