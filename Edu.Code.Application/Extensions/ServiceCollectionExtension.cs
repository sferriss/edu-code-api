using System.Reflection;
using Edu.Code.Application.Commads.Questions.CreateQuestionList;
using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Database.Repositories.Questions;
using Edu.Code.Domain.Questions.Repositories;
using Edu.Code.External.Client.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Edu.Code.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddEduCodeApi(this IServiceCollection services, string connectionString)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CreateQuestionListCommandValidator>();
        services.AddDatabase(connectionString);
        services.AddRepositories();
        services.AddCompilerApi();
    }
    
    private static void AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EduCodeDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddTransient<IUnitOfWork>(ctx => ctx.GetService<EduCodeDbContext>()!);
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IQuestionListRepository, QuestionListRepository>();
        services.AddTransient<IQuestionRepository, QuestionRepository>();
    }
}