using Edu.Code.Api.ExceptionHandlers;
using Edu.Code.Api.ExceptionHandlers.Factories;
using Edu.Code.Application.Extensions;
using Edu.Code.Database.Contexts;
using Edu.Code.External.Client.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var pathEnv = builder.Configuration.GetValue<string>("AppOptions:PathEnv");
        DotNetEnv.Env.Load(pathEnv);
        builder.Services.AddEduCodeApi(Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__EDUCODE")!);
        
        RegisterExceptionHandlers(builder.Services);
        
        builder.Services.AddOpenAiApi();
    }
    
    public static ExceptionHandlerFactory AddExceptionHandlers(this IServiceCollection services)
    {
        var factory = new ExceptionHandlerFactory();

        services.AddSingleton(factory);

        return factory;
    }
    
    public static void MigrationInitialisation(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var serviceDb  = serviceScope.ServiceProvider
            .GetService<EduCodeDbContext>();
                             
        serviceDb!.Database.Migrate();
    }

    private static void RegisterExceptionHandlers(IServiceCollection services)
    {
        services.AddTransient<BusinessValidationExceptionHandler>();
        services.AddTransient<NotFoundExceptionHandler>();
    }
}