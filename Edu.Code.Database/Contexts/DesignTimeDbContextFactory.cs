using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Edu.Code.Database.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EduCodeDbContext>
{
    public EduCodeDbContext CreateDbContext(string[] args)
    {
        // var configuration = new ConfigurationBuilder()
        //     .AddInMemoryCollection(new Dictionary<string, string>
        //     {
        //         ["ConnectionStrings:EduCode"] = "Host=localhost;Database=edu-code;Username=postgres;Password=postgres;Port=5432",
        //     }!)
        //     .AddEnvironmentVariables("App_")
        //     .Build();
        //
        // var connectionString = configuration.GetConnectionString("EduCode");
        // var builder = new DbContextOptionsBuilder<EduCodeDbContext>();
        // builder.UseNpgsql(connectionString);
        
        
        DotNetEnv.Env.Load("/etc/secrets/.env");

        var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__EDUCODE");

        var builder = new DbContextOptionsBuilder<EduCodeDbContext>();
        builder.UseNpgsql(connectionString);

        return new EduCodeDbContext(builder.Options);
    }
}