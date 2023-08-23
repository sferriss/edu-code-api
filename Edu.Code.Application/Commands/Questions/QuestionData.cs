using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Commands.Questions;

public record QuestionData
{
    public string Title { get; init; } = null!;
    
    public string Description { get; init; } = null!;

    public ExampleData[]? Examples { get; init; }

    public QuestionDifficulty Difficulty { get; init; }
}