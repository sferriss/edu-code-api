using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;

namespace Edu.Code.Domain.Questions.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    public Task<PaginatedResult<Question>> GetAllPagedAsync(int pageNumber, int pageSize);
}