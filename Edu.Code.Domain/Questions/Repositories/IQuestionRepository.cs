﻿using Edu.Code.Domain.Abstractions;
using Edu.Code.Domain.Abstractions.Pagination;
using Edu.Code.Domain.Questions.Entities;

namespace Edu.Code.Domain.Questions.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    public Task<Question?> GetByIdWithExampleAsync(Guid id);
    
    public Task<PaginatedResult<Question>> GetByListIdPagedAsync(Guid listId, int pageNumber, int pageSize);
}