using Edu.Code.Application.Commands.Doubts;
using Edu.Code.External.Client.Requests.OpenAI;

namespace Edu.Code.Application.Strategies.Doubts;

public class SystemPromptStrategy : IDoubtPromptStrategy
{
    public RoleContent BuildPrompt(SendStudentDoubtCommand? command = null, string? description = null)
    {
        return new ()
        {
            Role = "system",
            Content = $"{FormatInstruction()}\n"
        };
    }
    
    private static string FormatInstruction()
    {
        return "Você é tutor de programação Java, ofereça dicas sem fornecer solução completa e só responda perguntas relacionadas ao exercício";
    }
}