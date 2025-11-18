namespace Lab13Web_NadiaTorres.Application.Interfaces;

public interface IRepository<T> where T : class
{
    void AddEntity(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    
}