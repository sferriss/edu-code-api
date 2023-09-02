using Edu.Code.Application.Commands.Modules;
using Edu.Code.Application.Commands.Modules.Create;
using Edu.Code.Application.Queries.Modules.Common;
using Edu.Code.Application.Queries.Modules.GetAll;
using Edu.Code.Application.Queries.Modules.GetModuleContentById;
using Edu.Code.Domain.Modules.Entities;
using Riok.Mapperly.Abstractions;

namespace Edu.Code.Application.Mappers.Modules;

[Mapper]
public partial class ModuleMapper
{
    public partial Module ModuleToEntity(CreateModuleCommand command);
    
    public partial TopicContent ModuleContentToEntity(ModuleTopicData data);
    
    public partial GetAllModulesPagedQueryResult ModuleToQueryResult(Module entity);

    public partial GetModuleTopicByIdQueryResult ModuleTopicToResult(ModuleTopic entity);
}