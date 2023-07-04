using Edu.Code.Application.Exceptions;
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
        var result =await _questionRepository.GetAsync(request.Id).ConfigureAwait(false);

        if (result is null)
        {
            throw new NotFoundException("Item não encontrado.");
        }

        return new()
        {
            Description = result.Description,
            Difficult = result.Difficulty,
            Example = result.Example,
        };
    }
}