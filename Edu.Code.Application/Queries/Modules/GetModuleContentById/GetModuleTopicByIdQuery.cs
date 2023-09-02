using MediatR;

namespace Edu.Code.Application.Queries.Modules.GetModuleContentById;

public class GetModuleTopicByIdQuery : IRequest<GetModuleTopicByIdQueryResult>
{
    public Guid Id { get; set; }
};