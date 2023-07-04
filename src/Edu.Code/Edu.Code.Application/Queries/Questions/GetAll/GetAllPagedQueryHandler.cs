using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Queries.Questions.GetAll;

public class GetAllPagedQueryHandler : IRequestHandler<GetAllPagedQuery, PaginatedResult<GetAllPagedQueryResult>>
{
    private readonly IQuestionRepository _questionRepository;

    public GetAllPagedQueryHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<PaginatedResult<GetAllPagedQueryResult>> Handle(GetAllPagedQuery request, CancellationToken cancellationToken)
    {
        var result = await _questionRepository.GetByListIdPagedAsync(request.ListId, request.PageNumber, request.PageSize)
            .ConfigureAwait(false);

        return new PaginatedResult<GetAllPagedQueryResult>
        {
            Items = result.Items?.Select(MapToResult),
            PageSize = result.PageSize,
            Page = result.Page,
            Total = result.Total,
        };
    }

    private static GetAllPagedQueryResult MapToResult(Question question)
    {
        return new()
        {
            Id = question.Id,
            Description = question.Description,
            Example = question.Example,
            Difficult = question.Difficulty
        };
    }
}