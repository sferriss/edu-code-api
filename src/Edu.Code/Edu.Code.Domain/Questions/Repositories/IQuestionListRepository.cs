using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;

namespace Edu.Code.Domain.Questions.Repositories;

public interface IQuestionListRepository : IRepository<QuestionList>
{
    public Task<PaginatedResult<QuestionList>> GetByAllPagedAsync(int pageNumber, int pageSize);
}