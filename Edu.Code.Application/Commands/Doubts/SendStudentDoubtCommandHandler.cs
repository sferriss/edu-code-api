using Edu.Code.Application.Exceptions;
using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using Edu.Code.External.Client;
using Edu.Code.External.Client.Requests.OpenAI;
using Edu.Code.External.Client.Responses.OpenAI;
using MediatR;

namespace Edu.Code.Application.Commands.Doubts;

public class SendStudentDoubtCommandHandler : IRequestHandler<SendStudentDoubtCommand, SendStudentDoubtCommandResult>
{
    private readonly OpenAiApiClient _openAiApi;
    private readonly IQuestionRepository _questionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly bool _isSaveDoubt;

    public SendStudentDoubtCommandHandler(OpenAiApiClient openAiApi, IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
    {
        _openAiApi = openAiApi;
        _questionRepository = questionRepository;
        _unitOfWork = unitOfWork;
        _isSaveDoubt = Convert.ToBoolean(Environment.GetEnvironmentVariable("OPENAI__SAVEDOUBT"));
    }

    public async Task<SendStudentDoubtCommandResult> Handle(SendStudentDoubtCommand command, CancellationToken cancellationToken)
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
                BuildUserMessage(command, question),
            }
        });

        if (result is null)
        {
            throw new InvalidOperationException();
        }

        await SaveDoubtAsync(question, result, command)
            .ConfigureAwait(false);

        return new()
        {
            Message = result.Choices.First().Message.Content
        };
    }

    private async Task SaveDoubtAsync(Question question, GptConversationResponse result, SendStudentDoubtCommand command)
    {
        if (_isSaveDoubt)
        {
            question.AddDoubt(new ()
            {
                Doubt = command.Doubt,
                Code = command.Code,
                Answer = result.Choices.First().Message.Content
            });

            _questionRepository.Update(question);
            
            await _unitOfWork.CommitAsync()
                .ConfigureAwait(false);
        }
    }

    private static RoleContent BuildUserMessage(SendStudentDoubtCommand command, Question question)
    {
        return new ()
        {
            Role = "user",
            Content = $"{FormatInstruction()}\n" +
                      $"{FormatExercise(question.Description)}\n" +
                      $"{FormatDoubt(command)}\n" +
                      $"{FormatCode(command)}\n" 
        };
    }

    private static string FormatDoubt(SendStudentDoubtCommand command)
    {
        return $"Dúvida do aluno: {command.Doubt}";
    }

    private static string FormatExercise(string description)
    {
        return $"Exercício: {description}\n";
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
        return string.IsNullOrEmpty(command.Code) ? string.Empty : $"Código do aluno: ${command.Code}";
    }
    
    private static string FormatLasMessage(string? message)
    {
        return string.IsNullOrEmpty(message) ? string.Empty : $"Última orientação recebida: ${message}";
    }
    
    private static string FormatInstruction()
    {
        return "Como responder: Como tutor de programação Java, com respostas não muito longas e NUNCA envie o código da resposta.";
    }

    private static RoleContent BuildDefaultMessage()
    {
        return new()
        {
            Role = "system",
            Content = "Responda como tutor de programação Java, com respostas não muito longas, e NUNCA envie o código da resposta"
        };
    }
}