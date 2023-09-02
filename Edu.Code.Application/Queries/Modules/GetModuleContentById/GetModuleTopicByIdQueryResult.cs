using Edu.Code.Application.Queries.Modules.Common;

namespace Edu.Code.Application.Queries.Modules.GetModuleContentById;


public record GetModuleTopicByIdQueryResult
{
    public Guid Id { get; init; }

    public string Title { get; init; } = null!;

    public string? Description { get; set; }

    public TopicContentResult[]? Contents { get; set; }
}