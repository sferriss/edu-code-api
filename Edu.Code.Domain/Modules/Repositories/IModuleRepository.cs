using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Modules.Entities;

namespace Edu.Code.Domain.Modules.Repositories;

public interface IModuleRepository : IRepository<Module>
{
    Task<PaginatedResult<Module>> GetAllPagedWithContentAsync(int pageNumber, int pageSize);
}