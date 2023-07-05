using Edu.Code.Domain.Questions.Enums;

namespace Edu.Code.Application.Commads.Questions;

public class QuestionData
{
    public string Description { get; set; } = null!;
    
    public string? Answer { get; set; }
    
    public string? Example { get; set; }

    public QuestionDifficulty Difficulty { get; set; }
}