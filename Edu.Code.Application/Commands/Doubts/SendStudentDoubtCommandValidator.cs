using FluentValidation;

namespace Edu.Code.Application.Commands.Doubts;

public class SendStudentDoubtCommandValidator : AbstractValidator<SendStudentDoubtCommand>
{
    public SendStudentDoubtCommandValidator()
    {
        RuleFor(x => x.Doubt)
            .NotEmpty()
            .MaximumLength(200);
    }
}