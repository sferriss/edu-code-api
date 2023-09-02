using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Domain.Modules.Entities;
using Edu.Code.Domain.Modules.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Repositories.Modules;

public class ModuleTopicRepository : RepositoryBase<ModuleTopic>, IModuleTopicRepository
{
    public ModuleTopicRepository(EduCodeDbContext context) : base(context)
    {
    }

    public Task<ModuleTopic?> GetByIdAsync(Guid id)
    {
        return GetQuery()
            .Include(x => x.Contents)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}