using Edu.Code.Application.Commands.Common.Validators;
using FluentValidation;

namespace Edu.Code.Application.Commands.Questions.Create;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        When(_ => _.Questions is not null && _.Questions.Any(), () =>
        {
            RuleForEach(x => x.Questions)
                .SetValidator(new QuestionDataValidator());
        });
    }
}