using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Database.Extensions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Modules.Entities;
using Edu.Code.Domain.Modules.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Repositories.Modules;

public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
{
    public ModuleRepository(EduCodeDbContext context) : base(context)
    {
    }

    public Task<PaginatedResult<Module>> GetAllPagedWithContentAsync(int pageNumber, int pageSize)
    {
        return
            GetQuery()
                .AsNoTracking()
                .Include(x => x.Contents)
                .OrderBy(x => x.CreatedAt)
                .ToPaginateAsync(pageSize, pageNumber);
    }
}