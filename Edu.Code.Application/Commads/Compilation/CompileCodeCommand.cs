using MediatR;

namespace Edu.Code.Application.Commads.Compilation;

public sealed class CompileCodeCommand : IRequest<CompileCodeCommandResult>
{
    public string Code { get; set; } = null!;
    
    public string Language { get; set; } = null!;
}