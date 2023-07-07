using MediatR;

namespace Edu.Code.Application.Commads.Doubts;

public class SendStudentDoubtCommand : IRequest<SendStudentDoubtCommandResult>
{
    internal Guid QuestionId { get; set; }
    
    public string? Code { get; set; }

    public string Doubt { get; set; } = null!;

    public string? LastMessage { get; set; }

    public SendStudentDoubtCommand WithQuestionId(Guid id)
    {
        QuestionId = id;

        return this;
    }
}