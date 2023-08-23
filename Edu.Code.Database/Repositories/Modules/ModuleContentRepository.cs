using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Domain.Modules.Entities;
using Edu.Code.Domain.Modules.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Repositories.Modules;

public class ModuleContentRepository : RepositoryBase<ModuleContent>, IModuleContentRepository
{
    public ModuleContentRepository(EduCodeDbContext context) : base(context)
    {
    }

    public Task<ModuleContent?> GetByIdAsync(Guid id)
    {
        return GetQuery()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}