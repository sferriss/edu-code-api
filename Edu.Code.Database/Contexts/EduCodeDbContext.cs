using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Mappings.Modules;
using Edu.Code.Database.Mappings.Questions;
using Edu.Code.Database.Mappings.StudentsDoubts;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Contexts;

public class EduCodeDbContext : DbContext, IUnitOfWork
{
    public EduCodeDbContext(DbContextOptions<EduCodeDbContext> options)
        : base(options)
    {
    }
    
    public Task<int> CommitAsync() =>
        SaveChangesAsync();
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
        base.OnConfiguring(builder);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        const string defaultSchema = "edu-code";

        modelBuilder.HasPostgresExtension("uuid-ossp");
        
        modelBuilder.ApplyConfiguration(new QuestionListMapping(defaultSchema));
        modelBuilder.ApplyConfiguration(new QuestionMapping(defaultSchema));
        modelBuilder.ApplyConfiguration(new QuestionExampleMapping(defaultSchema));
        modelBuilder.ApplyConfiguration(new StudentDoubtMapping(defaultSchema));
        modelBuilder.ApplyConfiguration(new ModuleMapping(defaultSchema));
        modelBuilder.ApplyConfiguration(new TopicContentMapping(defaultSchema));
        modelBuilder.ApplyConfiguration(new ModuleTopicMapping(defaultSchema));
    }
}