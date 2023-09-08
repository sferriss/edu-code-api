using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Domain.StudentsDoubts.Repositories;

namespace Edu.Code.Database.Repositories.StudentDoubt;

public class StudentDoubtRepository : RepositoryBase<Domain.StudentsDoubts.Entities.StudentDoubt>, IStudentDoubtRepository
{
    public StudentDoubtRepository(EduCodeDbContext context) : base(context)
    {
    }
}