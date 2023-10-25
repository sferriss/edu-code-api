using System.ComponentModel;
using Edu.Code.Application.Commands.Doubts.Enums;
using Edu.Code.Application.Exceptions;
using Edu.Code.Application.Strategies.Doubts;
using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Modules.Entities;
using Edu.Code.Domain.Modules.Repositories;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using Edu.Code.Domain.StudentsDoubts.Entities;
using Edu.Code.Domain.StudentsDoubts.Enums;
using Edu.Code.Domain.StudentsDoubts.Repositories;
using Edu.Code.External.Client;
using Edu.Code.External.Client.Requests.OpenAI;
using Edu.Code.External.Client.Responses.OpenAI;
using MediatR;

namespace Edu.Code.Application.Commands.Doubts;

public class SendStudentDoubtCommandHandler : IRequestHandler<SendStudentDoubtCommand, SendStudentDoubtCommandResult>
{
    private readonly OpenAiApiClient _openAiApi;
    private readonly IQuestionRepository _questionRepository;
    private readonly ITopicContentRepository _contentRepository;
    private readonly IStudentDoubtRepository _studentDoubtRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly bool _isSaveDoubt;

    public SendStudentDoubtCommandHandler(
        OpenAiApiClient openAiApi,
        IQuestionRepository questionRepository,
        IUnitOfWork unitOfWork,
        ITopicContentRepository contentRepository,
        IStudentDoubtRepository studentDoubtRepository)
    {
        _openAiApi = openAiApi;
        _questionRepository = questionRepository;
        _unitOfWork = unitOfWork;
        _contentRepository = contentRepository;
        _studentDoubtRepository = studentDoubtRepository;
        _isSaveDoubt = Convert.ToBoolean(Environment.GetEnvironmentVariable("OPENAI__SAVEDOUBT"));
    }

    public async Task<SendStudentDoubtCommandResult> Handle(SendStudentDoubtCommand command, CancellationToken cancellationToken)
    {
        var messages = await HandlerMessageAsync(command).ConfigureAwait(false);

        var result = await _openAiApi.OpenAiApi.PostGptConversationAsync(new()
        {
            Messages = messages
        });

        if (result is null)
        {
            throw new InvalidOperationException();
        }

        await SaveDoubtAsync(result, command, messages.Last())
            .ConfigureAwait(false);

        return new()
        {
            Message = result.Choices.First().Message.Content
        };
    }

    private async Task<RoleContent[]> HandlerMessageAsync(SendStudentDoubtCommand command)
    {
        var handlerDoubtPrompt = HandlerDoubtPromptStrategy.GetStrategy(command.Type);

        if (command.Type is DoubtType.Exercise)
        {
            var handlerSystemPrompt = HandlerDoubtPromptStrategy.GetStrategy(DoubtType.System);
            var systemMessage = handlerSystemPrompt.BuildPrompt();
            
            var question = await GetQuestionAsync(command).ConfigureAwait(false);
            var exerciseMessage = handlerDoubtPrompt.BuildPrompt(command, question.Description);
            
            return new[]
            {
                systemMessage,
                exerciseMessage,
            };
        }
        
        var content = await GetContentAsync(command).ConfigureAwait(false);
        var message = handlerDoubtPrompt.BuildPrompt(command, content.Description!);

        return new[]
        {
            message,
        };
    }

    private async Task<Question> GetQuestionAsync(SendStudentDoubtCommand command)
    {
        var question = await _questionRepository.GetByIdWithExampleAsync(command.Id)
            .ConfigureAwait(false);

        if (question is null)
        {
            throw new NotFoundException("Exercício não encontrado.");
        }

        return question;
    }
    
    private async Task<TopicContent> GetContentAsync(SendStudentDoubtCommand command)
    {
        var content = await _contentRepository.GetByIdAsync(command.Id)
            .ConfigureAwait(false);

        if (content is null)
        {
            throw new NotFoundException("Conteúdo não encontrado.");
        }

        return content;
    }

    private async Task SaveDoubtAsync(GptConversationResponse result, SendStudentDoubtCommand command, RoleContent message)
    {
        if (_isSaveDoubt)
        {
            var doubt = new StudentDoubt 
            {
                Doubt = message.Content,
                Answer = result.Choices.First().Message.Content,
                Type = Converter(command.Type)
            };

            _studentDoubtRepository.Add(doubt);
            
            await _unitOfWork.CommitAsync()
                .ConfigureAwait(false);
        }
    }

    private static StudentDoubtType Converter(DoubtType type) => type switch
    {
        DoubtType.Content => StudentDoubtType.Content,
        DoubtType.Exercise => StudentDoubtType.Exercise,
    };
}