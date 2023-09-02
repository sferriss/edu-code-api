namespace Edu.Code.Application.Commands.Modules;

public record ModuleTopicData
{
    public string Title { get; init; } = null!;

    public string? Description { get; set; }

    public TopicContentData[]? Contents { get; set; }
}