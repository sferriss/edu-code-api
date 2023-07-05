using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Database.Extensions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Repositories.Questions;

public class QuestionListRepository : RepositoryBase<QuestionList>, IQuestionListRepository
{
    public QuestionListRepository(EduCodeDbContext context) : base(context)
    {
    }

    public Task<PaginatedResult<QuestionList>> GetByAllPagedAsync(int pageNumber, int pageSize)
    {
        return
            GetQuery()
                .AsNoTracking()
                .Include(_ => _.Questions)
                .OrderBy(_ => _.CreatedAt)
                .ToPaginateAsync(pageSize, pageNumber);
    }
}