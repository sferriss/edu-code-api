using Edu.Code.Application.Exceptions;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using Edu.Code.External.Client;
using Edu.Code.External.Client.Requests.OpenAI;
using MediatR;

namespace Edu.Code.Application.Commands.Doubts;

public class SendStudentDoubtCommandHandler : IRequestHandler<SendStudentDoubtCommand, SendStudentDoubtCommandResult>
{
    private readonly OpenAiApiClient _openAiApi;
    private readonly IQuestionRepository _questionRepository;

    public SendStudentDoubtCommandHandler(OpenAiApiClient openAiApi, IQuestionRepository questionRepository)
    {
        _openAiApi = openAiApi;
        _questionRepository = questionRepository;
    }

    public async Task<SendStudentDoubtCommandResult> Handle(SendStudentDoubtCommand command,
        CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetByIdWithExampleAsync(command.QuestionId)
            .ConfigureAwait(false);

        if (question is null)
        {
            throw new NotFoundException("Exercício não encontrado.");
        }

        var result = await _openAiApi.OpenAiApi.PostGptConversationAsync(new()
        {
            Messages = new[]
            {
                BuildDefaultMessage(),
                BuildUserMessage(command, question),
            }
        });

        if (result is null)
        {
            throw new InvalidOperationException();
        }

        return new()
        {
            Message = result.Choices.First().Message.Content
        };
    }

    private static RoleContent BuildUserMessage(SendStudentDoubtCommand command, Question question)
    {
        return new ()
        {
            Role = "user",
            Content = $"{FormatExercise(question.Description)}\n" +
                      $"{FormatExamples(question.Examples)}" +
                      $"{FormatDoubt(command)}\n" +
                      $"{FormatCode(command)}"
        };
    }

    private static string FormatDoubt(SendStudentDoubtCommand command)
    {
        return $"{command.Doubt}";
    }

    private static string FormatExercise(string description)
    {
        return $"Exercício: ${description}\n";
    }

    private static string FormatExamples(List<QuestionExample>? examples)
    {
        if (examples is null)
        {
            return "";
        }

        var result = "";

        for (var i = 0; i < examples.Count; i++)
        {
            result += $"Exemplo {i + 1}:\n" +
                      $"Input: {examples[i].Input}\n" +
                      $"Output: {examples[i].Output}\n \n";
        }

        return result;
    }

    private static string FormatCode(SendStudentDoubtCommand command)
    {
        return string.IsNullOrEmpty(command.Code) ? string.Empty : $"Código: ${command.Code}";
    }
    
    private static string FormatLasMessage(string? message)
    {
        return string.IsNullOrEmpty(message) ? string.Empty : $"Última orientação recebida: ${message}";
    }

    private static RoleContent BuildDefaultMessage()
    {
        return new()
        {
            Role = "system",
            Content =
                "Responda como tutor de programação Java, de forma gentil, não muito longa e NÃO forneça a resposta diretamente. " +
                "Se precisar enviar codigo mande somente a parte especifica"
        };
    }
}