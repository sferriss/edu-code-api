using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Queries.Lists.GetAll;
using Edu.Code.Application.Queries.Questions.GetAll;
using Edu.Code.Application.Queries.Questions.GetById;
using Edu.Code.Domain.Abstractions.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("questions")]
public class QuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("questions-all/{listId:guid:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<GetAllPagedQueryResult>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> GetAllQuestionsAsync([FromRoute] Guid listId, [FromQuery] GetAllPagedQuery query)
    {
        var result = await _mediator.Send(query.WithListId(listId))
            .ConfigureAwait(false);

        return Ok(result);
    }
    
    [HttpGet("questions/{id:guid:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByIdQueryResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> GetAllQuestionsAsync([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetByIdQuery { Id = id })
            .ConfigureAwait(false);

        return Ok(result);
    }
    
    [HttpGet("questions/list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<GetAllListPagedQueryResult>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> GetAllListsAsync([FromQuery] GetAllListPagedQuery query)
    {
        var result = await _mediator.Send(query)
            .ConfigureAwait(false);

        return Ok(result);
    }
}