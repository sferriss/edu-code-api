using Edu.Code.Domain.Questions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.Questions;

public class QuestionExampleMapping : IEntityTypeConfiguration<QuestionExample>
{
    private readonly string _schema;
    
    public QuestionExampleMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<QuestionExample> builder)
    {
        builder
            .ToTable("question_example", _schema);
        
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
            .Property(_ => _.Input)
            .HasColumnName("input")
            .IsRequired();
        
        builder
            .Property(_ => _.Output)
            .HasColumnName("output")
            .IsRequired();
        
        builder
            .Property(_ => _.QuestionId)
            .HasColumnName("question_id")
            .IsRequired();

        builder
            .HasOne(_ => _.Question)
            .WithMany(_ => _.Examples)
            .HasForeignKey(_ => _.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}