using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Commads.Questions.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("teacher-management")]
public class TeacherManagementController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherManagementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create-list")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateQuestionListCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> PostCreateQuestionsListAsync([FromBody] CreateQuestionListCommand request)
    {
        var result = await _mediator.Send(request)
            .ConfigureAwait(false);

        return Created(string.Empty, result);
    }
}