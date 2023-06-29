using Edu.Code.Database.Abstractions;
using Edu.Code.Database.Contexts;
using Edu.Code.Domain.Questions.Entities;
using Edu.Code.Domain.Questions.Repositories;

namespace Edu.Code.Database.Repositories.Questions;

public class QuestionListRepository : RepositoryBase<QuestionList>, IQuestionListRepository
{
    public QuestionListRepository(EduCodeDbContext context) : base(context)
    {
    }
}