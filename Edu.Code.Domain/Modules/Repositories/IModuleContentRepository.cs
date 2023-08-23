using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Modules.Entities;

namespace Edu.Code.Domain.Modules.Repositories;

public interface IModuleContentRepository : IRepository<ModuleContent>
{
    Task<ModuleContent?> GetByIdAsync(Guid id);
}