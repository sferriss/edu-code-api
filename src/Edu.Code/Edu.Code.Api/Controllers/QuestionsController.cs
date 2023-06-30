using Edu.Code.Application.Commads.Questions;
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

    [HttpPost]
    public async Task<CreatedResult> PostCreateQuestionsListAsync([FromBody] CreateQuestionListCommand request)
    {
        var result = await _mediator.Send(request)
            .ConfigureAwait(false);

        return Created(string.Empty, result);
    }
}