using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Queries.Questions.GetAll;

public class GetAllPagedQueryResult
{
    public string Description { get; set; } = null!;
    
    public string? Example { get; set; }
    
    public QuestionDifficulty Difficult { get; set; }
}