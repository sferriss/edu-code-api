using Edu.Code.Database.Contexts;
using Edu.Code.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Edu.Code.Database.Abstractions;

public class RepositoryBase<T> : IRepository<T> where T : class, IEntity
{
    private readonly EduCodeDbContext _context;

    public RepositoryBase(EduCodeDbContext context)
    {
        _context = context;
    }

    public Task<T?> GetAsync(Guid id) =>
        GetQuery()
            .FirstOrDefaultAsync(t => t.Id == id);

    public ICollection<T> AddRange(ICollection<T> entity)
    {
        _context.AddRange(entity);
        return entity;
    }

    public T Add(T entity)
    {
        _context.Add(entity);
        return entity;
    }

    public void Remove(T entity) =>
        _context.Remove(entity);

    public virtual Task<List<T>> GetAllAsync() =>
        GetQuery().ToListAsync();

    protected IQueryable<T> GetQuery() =>
        _context.Set<T>();

    public T Update(T entity)
    {
        _context.Update(entity);
        return entity;
    }
}