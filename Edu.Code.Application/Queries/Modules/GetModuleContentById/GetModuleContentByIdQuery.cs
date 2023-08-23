using MediatR;

namespace Edu.Code.Application.Queries.Modules.GetModuleContentById;

public class GetModuleContentByIdQuery : IRequest<GetModuleContentByIdQueryResult>
{
    public Guid Id { get; set; }
};