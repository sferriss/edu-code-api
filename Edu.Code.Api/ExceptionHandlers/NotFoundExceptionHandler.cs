using Edu.Code.Api.ExceptionHandlers.Interfaces;
using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Exceptions;

namespace Edu.Code.Api.ExceptionHandlers;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public ExceptionResponse HandleException(Exception ex, string traceId)
    {
        var exception = ex as NotFoundException;
            
        return new ExceptionResponse()
        {
            Type = "Recurso não encontrado",
            Title = exception?.Message,
            Status = StatusCodes.Status404NotFound,
            TraceId = traceId
        };
    }
}