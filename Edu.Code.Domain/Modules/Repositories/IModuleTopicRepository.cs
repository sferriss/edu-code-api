using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Modules.Entities;

namespace Edu.Code.Domain.Modules.Repositories;

public interface IModuleTopicRepository : IRepository<ModuleTopic>
{
    Task<ModuleTopic?> GetByIdAsync(Guid id);
}