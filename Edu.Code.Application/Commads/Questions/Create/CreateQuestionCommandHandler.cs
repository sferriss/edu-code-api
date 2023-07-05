using Edu.Code.Application.Exceptions;
using Edu.Code.Database.Abstractions;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Commads.Questions.Create;

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


        return new ()
        {
            Ids = questions.Select(_ => _.Id).ToArray()
        };
    }

    private static Question MapToEntity(QuestionData question)
    {
        return new()
        {
            Answer = question.Answer,
            Description = question.Description,
            Difficulty = question.Difficulty,
            Example = question.Example,
        };
    }
}