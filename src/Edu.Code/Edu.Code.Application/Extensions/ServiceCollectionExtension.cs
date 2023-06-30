﻿using System.Reflection;
using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Database.Repositories.Questions;
using Edu.Code.Domain.Questions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Edu.Code.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddEduCodeApi(this IServiceCollection services, string connectionString)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddDatabase(connectionString);
        services.AddRepositories();
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