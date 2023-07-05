using Edu.Code.Application.Commads.Questions;
using FluentValidation;

namespace Edu.Code.Application.Commads.Common.Validators;

public class QuestionDataValidator : AbstractValidator<QuestionData>
{
    public QuestionDataValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty();
        
        RuleFor(x => x.Difficulty)
            .IsInEnum();
    }
}