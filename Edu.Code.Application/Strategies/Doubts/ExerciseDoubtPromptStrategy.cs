using Edu.Code.Application.Commands.Doubts;
using Edu.Code.External.Client.Requests.OpenAI;

namespace Edu.Code.Application.Strategies.Doubts;

public class ExerciseDoubtPromptStrategy : IDoubtPromptStrategy
{
    public RoleContent BuildPrompt(SendStudentDoubtCommand command, string description)
    {
        return new ()
        {
            Role = "user",
            Content = $"{FormatExercise(description)}\n" +
                      $"{FormatCode(command)}\n" +
                      $"{FormatDoubt(command)}\n" +
                      $"{FormatInstruction()}\n" 
        };
    }
    
    private static string FormatInstruction()
    {
        return "Como responder: Como tutor de programação Java, com respostas não muito longas e NUNCA envie a resposta diretamente.";
    }
    
    private static string FormatExercise(string description)
    {
        return $"Exercício: {description}\n";
    }
    
    private static string FormatDoubt(SendStudentDoubtCommand command)
    {
        return $"Dúvida do aluno: {command.Doubt}";
    }
    
    private static string FormatCode(SendStudentDoubtCommand command)
    {
        return string.IsNullOrEmpty(command.Code) ? string.Empty : $"Código do aluno: {command.Code}";
    }
}