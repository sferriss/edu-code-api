
using Edu.Code.Application.Queries.Questions.Common;
using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Queries.Questions.GetById;

public class GetByIdQueryResult
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public ExampleResult[]? Examples { get; set; }
    
    public QuestionDifficulty Difficult { get; set; }
}