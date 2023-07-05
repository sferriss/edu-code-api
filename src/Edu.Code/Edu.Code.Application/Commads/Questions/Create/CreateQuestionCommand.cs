using MediatR;

namespace Edu.Code.Application.Commads.Questions.Create;

public class CreateQuestionCommand : IRequest<CreateQuestionCommandResult>
{
    internal Guid ListId { get; set; }

    public QuestionData[] Questions { get; set; } = null!;

    public CreateQuestionCommand WithListId(Guid id)
    {
        ListId = id;

        return this;
    }
}