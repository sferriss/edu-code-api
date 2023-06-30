using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Commads.Questions;

public class CreateQuestionListCommandHandler : IRequestHandler<CreateQuestionListCommand, CreateQuestionListCommandResult>
{
    private readonly IQuestionListRepository _questionListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuestionListCommandHandler(IUnitOfWork unitOfWork, IQuestionListRepository questionListRepository)
    {
        _unitOfWork = unitOfWork;
        _questionListRepository = questionListRepository;
    }

    public async Task<CreateQuestionListCommandResult> Handle(CreateQuestionListCommand request, CancellationToken cancellationToken)
    {
        var list = new QuestionList
        {
            Title = request.Title
        };

        if (request.Questions != null && request.Questions.Any())
        {
            var questions = request.Questions.Select(MapQuestionToEntity).ToList();

            list.AddQuestion(questions);
        }

        _questionListRepository.Add(list);
        await _unitOfWork.CommitAsync()
            .ConfigureAwait(false);
        
        return new () { Id = list.Id};
    }

    private static Question MapQuestionToEntity(QuestionData questionData)
    {
        return new()
        {
            Answer = questionData.Answer,
            Description = questionData.Description,
            Difficulty = questionData.Difficulty,
            Example = questionData.Example
        };
    }
}