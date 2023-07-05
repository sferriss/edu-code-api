using Edu.Code.Domain.Questions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.Questions;

public class QuestionMapping : IEntityTypeConfiguration<Question>
{
    private readonly string _schema;
    
    public QuestionMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder
            .ToTable("question", _schema);
        
        builder
            .HasKey(_ => _.Id);

        builder
            .Property(_ => _.Id)
            .HasColumnName("id")
            .IsRequired()
            .HasDefaultValueSql("uuid_generate_v4()");
        
        builder
            .Property(_ => _.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder
            .Property(_ => _.Description)
            .HasColumnName("description")
            .IsRequired();
        
        builder
            .Property(_ => _.Answer)
            .HasColumnName("answer");
        
        builder
            .Property(_ => _.Example)
            .HasColumnName("example");
        
        builder
            .Property(_ => _.Difficulty)
            .HasColumnName("difficulty")
            .IsRequired();
        
        builder
            .Property(_ => _.ListId)
            .HasColumnName("list_id")
            .IsRequired();

        builder
            .HasOne(_ => _.List)
            .WithMany(_ => _.Questions)
            .HasForeignKey(_ => _.ListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}