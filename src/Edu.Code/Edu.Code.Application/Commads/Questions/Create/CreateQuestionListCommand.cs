using MediatR;

namespace Edu.Code.Application.Commads.Questions.Create;

public class CreateQuestionListCommand : IRequest<CreateQuestionListCommandResult>
{
    public string Title { get; set; } = null!;

    public QuestionData[]? Questions { get; set; }
}