using Edu.Code.Application.Commands.Doubts.Enums;

namespace Edu.Code.Application.Strategies.Doubts;

public static class HandlerDoubtPromptStrategy
{
    public static IDoubtPromptStrategy GetStrategy(DoubtType type)
    {
        return type switch
        {
            DoubtType.Exercise => new ExerciseDoubtPromptStrategy(),
            DoubtType.Content => new ContentDoubtPromptStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Operação inválida")
        };
    }
}