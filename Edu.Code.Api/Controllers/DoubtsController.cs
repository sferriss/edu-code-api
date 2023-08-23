using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Commands.Doubts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("doubts")]
public class DoubtsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoubtsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{id:guid:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SendStudentDoubtCommandResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> PostStudentAsync([FromRoute] Guid id, [FromBody] SendStudentDoubtCommand request)
    {
        var result = await _mediator.Send(request.WithQuestionId(id))
            .ConfigureAwait(false);
        
        return Ok(result);
    }
}