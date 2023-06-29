namespace Edu.Code.Database.Abstractions;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}