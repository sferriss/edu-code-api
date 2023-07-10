using Edu.Code.Application.Exceptions;
using Edu.Code.Domain.Questions.Repositories;
using Edu.Code.External.Client;
using Edu.Code.External.Client.Requests.OpenAI;
using MediatR;

namespace Edu.Code.Application.Commads.Doubts;

public class SendStudentDoubtCommandHandler : IRequestHandler<SendStudentDoubtCommand, SendStudentDoubtCommandResult>
{
    private readonly OpenAiApiClient _openAiApi;
    private readonly IQuestionRepository _questionRepository;

    public SendStudentDoubtCommandHandler(OpenAiApiClient openAiApi, IQuestionRepository questionRepository)
    {
        _openAiApi = openAiApi;
        _questionRepository = questionRepository;
    }

    public async Task<SendStudentDoubtCommandResult> Handle(SendStudentDoubtCommand command, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetAsync(command.QuestionId)
            .ConfigureAwait(false);

        if (question is null)
        {
            throw new NotFoundException("Exercício não encontrado.");
        }
        
        var result = await _openAiApi.OpenAiApi.PostGptConversationAsync(new()
        {
            Messages = new []
            {
                BuildDefaultMessage(),
                BuildUserMessage(command, question.Description),
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

    private static RoleContent BuildUserMessage(SendStudentDoubtCommand command, string description)
    {
        return new()
        {
            Role = "user",
            Content = $"{FormatExercise(description)}\n" +
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
        return $"Exercício: ${description}";
    }
    
    private static string FormatCode(SendStudentDoubtCommand command)
    {
        return string.IsNullOrEmpty(command.Code) ? string.Empty : $"Código: ${command.Code}";
    }
    
    private static RoleContent BuildDefaultMessage()
    {
        return new()
        {
            Role = "system",
            Content = "Responda como tutor de programação, de forma gentil, não muito longa e NÃO forneça a resposta diretamente. " +
                      "Se precisar enviar codigo mande somente a parte especifica"
        };
    }
}