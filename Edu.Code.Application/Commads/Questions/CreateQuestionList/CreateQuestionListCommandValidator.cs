using Edu.Code.Application.Commads.Common.Validators;
using FluentValidation;

namespace Edu.Code.Application.Commads.Questions.CreateQuestionList;

public class CreateQuestionListCommandValidator : AbstractValidator<CreateQuestionListCommand>
{
    public CreateQuestionListCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        When(_ => _.Questions is not null && _.Questions.Any(), () =>
        {
            RuleForEach(x => x.Questions)
                .SetValidator(new QuestionDataValidator());
        });
    }
}