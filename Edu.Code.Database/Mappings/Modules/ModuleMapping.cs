using Edu.Code.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.Modules;

public class ModuleMapping : IEntityTypeConfiguration<Module>
{
    private readonly string _schema;
    
    public ModuleMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder
            .ToTable("module", _schema);
        
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .HasColumnName("id")
            .IsRequired()
            .HasDefaultValueSql("uuid_generate_v4()");
        
        builder
            .Property(m => m.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder
            .Property(m => m.Title)
            .HasColumnName("title")
            .IsRequired();
        
        builder
            .Property(m => m.Description)
            .HasColumnName("description");
    }
}