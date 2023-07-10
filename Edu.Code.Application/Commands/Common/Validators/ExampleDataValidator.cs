using Edu.Code.Application.Commands.Questions;
using FluentValidation;

namespace Edu.Code.Application.Commands.Common.Validators;

public class ExampleDataValidator : AbstractValidator<ExampleData>
{
    public ExampleDataValidator()
    {
        RuleFor(x => x.Input)
            .NotEmpty();
        
        RuleFor(x => x.Output)
            .NotEmpty();
    }
}