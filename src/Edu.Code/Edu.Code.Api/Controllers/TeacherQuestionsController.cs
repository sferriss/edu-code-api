using Edu.Code.Application.Commads.Questions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("teacher/questions")]
public class TeacherQuestionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherQuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateQuestionListCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<CreatedResult> PostCreateQuestionsListAsync([FromBody] CreateQuestionListCommand request)
    {
        var result = await _mediator.Send(request)
            .ConfigureAwait(false);

        return Created(string.Empty, result);
    }
}