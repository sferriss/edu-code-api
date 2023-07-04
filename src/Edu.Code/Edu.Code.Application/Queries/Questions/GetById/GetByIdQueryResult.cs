using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Queries.Questions.GetById;

public class GetByIdQueryResult
{
    public string Description { get; set; } = null!;
    
    public string? Example { get; set; }
    
    public QuestionDifficulty Difficult { get; set; }
}