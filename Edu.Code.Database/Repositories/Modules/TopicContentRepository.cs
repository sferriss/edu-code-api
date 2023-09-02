using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Domain.Modules.Entities;
using Edu.Code.Domain.Modules.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Repositories.Modules;

public class TopicContentRepository : RepositoryBase<TopicContent>, ITopicContentRepository
{
    public TopicContentRepository(EduCodeDbContext context) : base(context)
    {
    }

    public Task<TopicContent?> GetByIdAsync(Guid id)
    {
        return GetQuery()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}