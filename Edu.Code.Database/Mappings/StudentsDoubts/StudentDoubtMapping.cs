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
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .HasDefaultValueSql("uuid_generate_v4()");
        
        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder
            .Property(x => x.Doubt)
            .HasColumnName("doubt")
            .IsRequired();
        
        builder
            .Property(x => x.Answer)
            .HasColumnName("answer")
            .IsRequired();
        
        builder
            .Property(x => x.Type)
            .HasColumnName("type");
    }
}