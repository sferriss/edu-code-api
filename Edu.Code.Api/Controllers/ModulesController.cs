using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Queries.Modules.GetAll;
using Edu.Code.Application.Queries.Modules.GetModuleContentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("modules")]
public class ModulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ModulesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllModulesPagedQueryResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> GetAllModulesAsync([FromQuery] GetAllModulesPagedQuery request)
    {
        var result = await _mediator.Send(request)
            .ConfigureAwait(false);
        
        return Ok(result);
    }
    
    [HttpGet("topic/{id:guid:required}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetModuleTopicByIdQueryResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> GetTopicByIdAsync([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetModuleTopicByIdQuery
            {
                Id = id,
            }).ConfigureAwait(false);
        
        return Ok(result);
    }
}