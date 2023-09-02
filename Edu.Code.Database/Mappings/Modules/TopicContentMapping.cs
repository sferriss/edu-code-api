using Edu.Code.Domain.Modules.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.Modules;

public class TopicContentMapping : IEntityTypeConfiguration<TopicContent>
{
    private readonly string _schema;
    
    public TopicContentMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<TopicContent> builder)
    {
        builder
            .ToTable("topic_content", _schema);
        
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
            .Property(m => m.Description)
            .HasColumnName("description");
        
        builder
            .Property(m => m.TopicId)
            .HasColumnName("topic_id")
            .IsRequired();

        builder
            .HasOne(m => m.Topic)
            .WithMany(m => m.Contents)
            .HasForeignKey(m => m.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}