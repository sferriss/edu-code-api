using Edu.Code.Application.Commands.Questions;
using FluentValidation;

namespace Edu.Code.Application.Commands.Common.Validators;

public class QuestionDataValidator : AbstractValidator<QuestionData>
{
    public QuestionDataValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();
        
        RuleFor(x => x.Description)
            .NotEmpty();
        
        RuleFor(x => x.Difficulty)
            .IsInEnum();
        
        When(_ => _.Examples is not null && _.Examples.Any(), () =>
        {
            RuleForEach(x => x.Examples)
                .SetValidator(new ExampleDataValidator());
        });
    }
}