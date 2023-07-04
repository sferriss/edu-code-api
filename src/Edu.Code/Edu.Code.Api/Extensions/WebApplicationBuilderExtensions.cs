using Edu.Code.Api.ExceptionHandlers;
using Edu.Code.Api.ExceptionHandlers.Factories;
using Edu.Code.Application.Extensions;

namespace Edu.Code.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEduCodeApi(builder.Configuration.GetConnectionString("EduCode")!);
        RegisterExceptionHandlers(builder.Services);
    }
    
    public static ExceptionHandlerFactory AddExceptionHandlers(this IServiceCollection services)
    {
        var factory = new ExceptionHandlerFactory();

        services.AddSingleton(factory);

        return factory;
    }

    private static void RegisterExceptionHandlers(IServiceCollection services)
    {
        services.AddTransient<BusinessValidationExceptionHandler>();
        services.AddTransient<NotFoundExceptionHandler>();
    }
}