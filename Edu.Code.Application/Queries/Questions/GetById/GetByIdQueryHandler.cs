using Edu.Code.Application.Exceptions;
using Edu.Code.Application.Queries.Questions.Common;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Queries.Questions.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdQueryResult>
{
    private readonly IQuestionRepository _questionRepository;

    public GetByIdQueryHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<GetByIdQueryResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _questionRepository.GetByIdWithExampleAsync(request.Id)
            .ConfigureAwait(false);

        if (result is null)
        {
            throw new NotFoundException("Item não encontrado.");
        }

        return new()
        {
            Id = result.Id,
            Title = result.Title,
            Description = result.Description,
            Difficult = result.Difficulty,
            Examples = result.Examples.Any() ? result.Examples.Select(MapExampleToEntity).ToArray() : null
        };
    }
    
    private static ExampleResult MapExampleToEntity(QuestionExample example)
    {
        return new()
        {
            Id = example.Id,
            Input = example.Input,
            Output = example.Output
        };
    }
}