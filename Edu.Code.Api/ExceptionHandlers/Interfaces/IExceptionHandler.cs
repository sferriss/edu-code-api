using Edu.Code.Api.ExceptionHandlers.Responses;

namespace Edu.Code.Api.ExceptionHandlers.Interfaces;

public interface IExceptionHandler
{
    ExceptionResponse HandleException(Exception ex, string traceId);
}