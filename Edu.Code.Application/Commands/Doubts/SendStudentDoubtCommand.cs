using Edu.Code.Application.Commands.Doubts.Enums;
using MediatR;

namespace Edu.Code.Application.Commands.Doubts;

public class SendStudentDoubtCommand : IRequest<SendStudentDoubtCommandResult>
{
    internal Guid Id { get; private set; }
    
    public string? Code { get; set; }

    public string Doubt { get; set; } = null!;
    
    public string? OutPut { get; set; }

    public DoubtType Type { get; set; }

    public SendStudentDoubtCommand WithQuestionId(Guid id)
    {
        Id = id;

        return this;
    }
}