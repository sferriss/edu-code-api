using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Queries.Lists.GetAll;
using Edu.Code.Application.Queries.Questions.GetAll;
using Edu.Code.Application.Queries.Questions.GetById;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.External.Client;
using Edu.Code.External.Client.Requests.OpenAI;
using Edu.Code.External.Client.Settings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edu.Code.Api.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly CompilerApiClient _compilerApi;
    private readonly OpenAiApiClient _openAiApi;

    public StudentsController(IMediator mediator, CompilerApiClient compilerApi, OpenAiApiClient openAiApi)
    {
        _mediator = mediator;
        _compilerApi = compilerApi;
        _openAiApi = openAiApi;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllListPagedQueryResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> GetAllListsAsync([FromQuery] GetAllListPagedQuery query)
    {
        var result = await _mediator.Send(query)
            .ConfigureAwait(false);

        return Ok(result);
    }
    
    [HttpPost("teste")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllListPagedQueryResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> PostTesteAsync()
    {
        var result = await _compilerApi.CompilerApi.PostExecuteAsync(new()
        {
            Language = "java",
            Script = "public class HelloWorld {\n    public static void main(String[] args) {\n        System.out.println(\"Hello, World!\")\n    }\n}",
        });
        return Ok(result);
    }
    
    [HttpPost("teste2")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllListPagedQueryResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionResponse))]
    public async Task<IActionResult> PostTeste2Async()
    {
        var result = await _openAiApi.OpenAiApi.PostGptConversationAsync(new()
        {
            Messages = new []
            {
                new RoleContent
                {
                    Role = "system",
                    Content = "Você é um tutor de programação que tem como objetivo auxiliar os alunos nas duvidas, seja gentil e não forneça a resposta diretamente"
                },
                new RoleContent ()
                {
                    Role = "user",
                    Content = "Olá, quem é voce?"
                },
            }
        });
        return Ok(result);
    }
}