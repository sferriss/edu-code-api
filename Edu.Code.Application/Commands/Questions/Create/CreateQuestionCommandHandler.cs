using Edu.Code.Application.Exceptions;
using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Commands.Questions.Create;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionCommandResult>
{
    private readonly IQuestionListRepository _questionListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuestionCommandHandler(IQuestionListRepository questionListRepository, IUnitOfWork unitOfWork)
    {
        _questionListRepository = questionListRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateQuestionCommandResult> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var list = await _questionListRepository.GetAsync(request.ListId)
            .ConfigureAwait(false);

        if (list is null)
        {
            throw new NotFoundException("Lista não encontrada.");
        }

        var questions = request.Questions.Select(MapToEntity).ToList();
        list.AddQuestion(questions);

        await _unitOfWork.CommitAsync()
            .ConfigureAwait(false);


        return new(questions.Select(x => x.Id).ToArray());
    }

    private static Question MapToEntity(QuestionData questionData)
    {
        var question =  new Question
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