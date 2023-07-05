using Edu.Code.Application.Commads.Common.Validators;
using FluentValidation;

namespace Edu.Code.Application.Commads.Questions.Create;

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