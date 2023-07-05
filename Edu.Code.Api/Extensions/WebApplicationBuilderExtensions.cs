using Edu.Code.Api.ExceptionHandlers;
using Edu.Code.Api.ExceptionHandlers.Factories;
using Edu.Code.Application.Extensions;
using Edu.Code.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        DotNetEnv.Env.Load("/etc/secrets/.env");
        builder.Services.AddEduCodeApi(Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__EDUCODE")!);
        RegisterExceptionHandlers(builder.Services);
    }
    
    public static ExceptionHandlerFactory AddExceptionHandlers(this IServiceCollection services)
    {
        var factory = new ExceptionHandlerFactory();

        services.AddSingleton(factory);

        return factory;
    }
    
    public static void MigrationInitialisation(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var serviceDb  = serviceScope.ServiceProvider
                .GetService<EduCodeDbContext>();
                             
            serviceDb!.Database.Migrate();
        }
    }

    private static void RegisterExceptionHandlers(IServiceCollection services)
    {
        services.AddTransient<BusinessValidationExceptionHandler>();
        services.AddTransient<NotFoundExceptionHandler>();
    }
}