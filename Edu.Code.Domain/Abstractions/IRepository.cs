namespace Edu.Code.Domain.Abstractions;

public interface IRepository<T> where T : IEntity
{
    Task<T?> GetAsync(Guid id);
    
    Task<List<T>> GetAllAsync();
    
    T Add(T entity);
    
    ICollection<T> AddRange(ICollection<T> entity);
    
    void Remove(T entity);
    
    T Update(T entity);
}