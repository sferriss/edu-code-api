using Edu.Code.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.Modules;

public class ModuleTopicMapping : IEntityTypeConfiguration<ModuleTopic>
{
    private readonly string _schema;
    
    public ModuleTopicMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<ModuleTopic> builder)
    {
        builder
            .ToTable("module_topic", _schema);
        
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
            .HasColumnName("title");
        
        builder
            .Property(m => m.Description)
            .HasColumnName("description");
        
        builder
            .Property(m => m.ModuleId)
            .HasColumnName("module_id")
            .IsRequired();

        builder
            .HasOne(m => m.Module)
            .WithMany(m => m.Topics)
            .HasForeignKey(m => m.ModuleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}