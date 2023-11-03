using Edu.Code.Application.Commands.Doubts;
using Edu.Code.External.Client.Requests.OpenAI;

namespace Edu.Code.Application.Strategies.Doubts;

public class ContentDoubtPromptStrategy : IDoubtPromptStrategy
{
    public RoleContent BuildPrompt(SendStudentDoubtCommand? command, string? description)
    {
        return new ()
        {
            Role = "user",
            Content = $"{FormatInstruction()}\n" +
                      $"{FormatContent(description!)}\n" +
                      $"{FormatDoubt(command!)}\n"
        };
    }
    
    private static string FormatInstruction()
    {
        return "Como responder: Você é um tutor de programação ajudando um aluno, responda a dúvida baseado no conteúdo de referência. Só responda perguntas relacionadas ao conteúdo.";
    }
    
    private static string FormatContent(string description)
    {
        return $"Conteúdo de referência: {description}\n";
    }
    
    private static string FormatDoubt(SendStudentDoubtCommand command)
    {
        return $"Dúvida: {command.Doubt}";
    }
}