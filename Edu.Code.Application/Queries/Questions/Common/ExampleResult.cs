namespace Edu.Code.Application.Queries.Questions.Common;

public record ExampleResult
{
    public Guid Id { get; init; }

    public string Input { get; init; } = null!;
    
    public string Output { get; init; } = null!;
}