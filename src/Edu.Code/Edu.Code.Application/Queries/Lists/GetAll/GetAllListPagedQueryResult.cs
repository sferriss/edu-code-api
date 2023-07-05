namespace Edu.Code.Application.Queries.Lists.GetAll;

public class GetAllListPagedQueryResult
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public int QuestionTotal { get; set; }

    public DateTime CreatedAt { get; set; }
}