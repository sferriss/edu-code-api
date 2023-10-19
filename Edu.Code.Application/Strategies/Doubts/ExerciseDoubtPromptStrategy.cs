﻿using Edu.Code.Application.Commands.Doubts;
using Edu.Code.External.Client.Requests.OpenAI;

namespace Edu.Code.Application.Strategies.Doubts;

public class ExerciseDoubtPromptStrategy : IDoubtPromptStrategy
{
    public RoleContent BuildPrompt(SendStudentDoubtCommand command, string description)
    {
        return new ()
        {
            Role = "user",
            Content = $"{FormatInstruction()}\n" + 
                      $"{FormatExercise(description)}\n" +
                      $"{FormatDoubt(command)}\n" +
                      $"{FormatCode(command)}\n"
        };
    }
    
    private static string FormatInstruction()
    {
        return "COMO RESPONDER: Você é tutor de programação Java, ofereça dicas para ajudar o aluno. NUNCA envie código que responda completamente a questão e só responda perguntas relacionadas ao exercício";
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