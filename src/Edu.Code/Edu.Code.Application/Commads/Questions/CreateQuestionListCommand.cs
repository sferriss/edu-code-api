using MediatR;

namespace Edu.Code.Application.Commads.Questions;

public class CreateQuestionListCommand : IRequest<CreateQuestionListCommandResult>
{
    public string Title { get; set; } = null!;

    public QuestionData[]? Questions { get; set; }
}