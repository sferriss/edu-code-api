using Edu.Code.Domain.StudentsDoubts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edu.Code.Database.Mappings.StudentsDoubts;

public class StudentDoubtMapping : IEntityTypeConfiguration<StudentDoubt>
{
    private readonly string _schema;
    
    public StudentDoubtMapping(string schema) =>
        _schema = schema;
    
    public void Configure(EntityTypeBuilder<StudentDoubt> builder)
    {
        builder
            .ToTable("student_doubt", _schema);
        
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
            .Property(_ => _.Doubt)
            .HasColumnName("doubt")
            .IsRequired();
        
        builder
            .Property(_ => _.Code)
            .HasColumnName("code");
        
        builder
            .Property(_ => _.Answer)
            .HasColumnName("answer")
            .IsRequired();
        
        builder
            .Property(_ => _.QuestionId)
            .HasColumnName("question_id");
        
        builder
            .HasOne(_ => _.Question)
            .WithMany(_ => _.Doubts)
            .HasForeignKey(_ => _.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}