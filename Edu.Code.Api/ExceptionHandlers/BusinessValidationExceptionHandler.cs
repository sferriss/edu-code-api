using Edu.Code.Api.ExceptionHandlers.Interfaces;
using Edu.Code.Api.ExceptionHandlers.Responses;
using Edu.Code.Application.Exceptions;

namespace Edu.Code.Api.ExceptionHandlers;

public class BusinessValidationExceptionHandler : IExceptionHandler
{
    public ExceptionResponse HandleException(Exception ex, string traceId)
    {
        var exception = ex as BusinessValidationException;
            
        return new ExceptionResponse()
        {
            Type = "Validação de regra de negócios",
            Title = exception?.Message,
            Status = StatusCodes.Status400BadRequest,
            TraceId = traceId
        };
    }
}