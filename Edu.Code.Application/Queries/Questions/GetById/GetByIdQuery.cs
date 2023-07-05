using MediatR;

namespace Edu.Code.Application.Queries.Questions.GetById;

public class GetByIdQuery : IRequest<GetByIdQueryResult>
{
    public Guid Id { get; set; }
}