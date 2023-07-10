using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Commands.Questions;

public class QuestionData
{
    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;

    public ExampleData[]? Examples { get; set; }

    public QuestionDifficulty Difficulty { get; set; }
}