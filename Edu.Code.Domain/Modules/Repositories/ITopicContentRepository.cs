using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Modules.Entities;

namespace Edu.Code.Domain.Modules.Repositories;

public interface ITopicContentRepository : IRepository<TopicContent>
{
    Task<TopicContent?> GetByIdAsync(Guid id);
}