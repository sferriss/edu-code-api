using MediatR;

namespace Edu.Code.Application.Commands.Questions.CreateQuestionList;

public class CreateQuestionListCommand : IRequest<CreateQuestionListCommandResult>
{
    public string Title { get; set; } = null!;

    public QuestionData[]? Questions { get; set; }
}