﻿using MediatR;

namespace Edu.Code.Application.Commands.Compilation;

public sealed class CompileCodeCommand : IRequest<CompileCodeCommandResult>
{
    public string Code { get; set; } = null!;
    
    public string? Input { get; set; }
    
    public string Language { get; set; } = null!;
}