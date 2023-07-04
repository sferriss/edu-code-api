using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Database.Extensions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Repositories.Questions;

public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
{
    public QuestionRepository(EduCodeDbContext context) : base(context)
    {
    }

    public Task<PaginatedResult<Question>> GetByListIdPagedAsync(Guid listId, int pageNumber, int pageSize)
    {
        return GetQuery()
            .AsNoTracking()
            .Include(_ => _.List)
            .Where(_ => _.ListId == listId)
            .ToPaginateAsync(pageSize, pageNumber);
    }
}