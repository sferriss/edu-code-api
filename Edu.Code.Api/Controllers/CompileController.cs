using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Commands.Compilation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("compile")]
public class CompileController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompileController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompileCodeCommandResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> PostCompileAsync([FromBody] CompileCodeCommand request)
    {
        var result = await _mediator.Send(request)
            .ConfigureAwait(false);
        
        return Ok(result);
    }
}