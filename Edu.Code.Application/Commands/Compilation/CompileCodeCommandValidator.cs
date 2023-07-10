using FluentValidation;

namespace Edu.Code.Application.Commands.Compilation;

public class CompileCodeCommandValidator : AbstractValidator<CompileCodeCommand>
{
    public CompileCodeCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty();
        
        RuleFor(x => x.Language)
            .NotEmpty();
    }
}