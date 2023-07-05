using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using MediatR;

namespace Edu.Code.Application.Queries.Lists.GetAll;

public class GetAllListPagedQueryHandler : IRequestHandler<GetAllListPagedQuery, PaginatedResult<GetAllListPagedQueryResult>>
{
    private readonly IQuestionListRepository _questionListRepository;

    public GetAllListPagedQueryHandler(IQuestionListRepository questionListRepository)
    {
        _questionListRepository = questionListRepository;
    }

    public async Task<PaginatedResult<GetAllListPagedQueryResult>> Handle(GetAllListPagedQuery request, CancellationToken cancellationToken)
    {
        var result = await _questionListRepository.GetByAllPagedAsync(request.PageNumber, request.PageSize)
            .ConfigureAwait(false);

        return new PaginatedResult<GetAllListPagedQueryResult>
        {
            Items = result.Items?.Select(MapToResult),
            PageSize = result.PageSize,
            Page = result.Page,
            Total = result.Total,
        };
    }
    
    private static GetAllListPagedQueryResult MapToResult(QuestionList list)
    {
        return new()
        {
            Id = list.Id,
            Title = list.Title,
            QuestionTotal = list.Questions.Count,
            CreatedAt = list.CreatedAt
        };
    }
}