using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Commands.Questions.CreateQuestionList;

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
        
        return new (list.Id);
    }

    private static Question MapQuestionToEntity(QuestionData questionData)
    {
        var question = new Question
        {
            Title = questionData.Title,
            Description = questionData.Description,
            Difficulty = questionData.Difficulty,
        };

        if (questionData.Examples != null && questionData.Examples.Any())
        {
            question.AddExample(questionData.Examples.Select(MapExampleToEntity));
        }

        return question;
    }

    private static QuestionExample MapExampleToEntity(ExampleData example)
    {
        return new()
        {
            Input = example.Input,
            Output = example.Output
        };
    }
}