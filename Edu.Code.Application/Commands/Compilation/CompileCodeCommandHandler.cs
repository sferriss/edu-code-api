using Edu.Code.External.Client;
using MediatR;

namespace Edu.Code.Application.Commands.Compilation;

public class CompileCodeCommandHandler : IRequestHandler<CompileCodeCommand, CompileCodeCommandResult>
{
    private readonly CompilerApiClient _compilerApi;

    public CompileCodeCommandHandler(CompilerApiClient compilerApi)
    {
        _compilerApi = compilerApi;
    }

    public async Task<CompileCodeCommandResult> Handle(CompileCodeCommand request, CancellationToken cancellationToken)
    {
        var result = await _compilerApi.CompilerApi.PostExecuteAsync(new()
        {
            Language = request.Language,
            Script = request.Code,
            Stdin = request.Input,
        });

        return new()
        {
            Output = result.Output
        };
    }
}