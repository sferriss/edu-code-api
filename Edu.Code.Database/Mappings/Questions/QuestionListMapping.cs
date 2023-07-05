using Edu.Code.Domain.Questions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.Questions;

public class QuestionListMapping : IEntityTypeConfiguration<QuestionList>
{
    private readonly string _schema;
    public QuestionListMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<QuestionList> builder)
    {
        builder
            .ToTable("question_list", _schema);
        
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
            .Property(_ => _.Title)
            .HasColumnName("title")
            .IsRequired();
    }
}