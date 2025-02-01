namespace Motors.Domain.Repositories;

public interface IRepository<T> where T : class
{
    // Create
    Task AddAsync(T entity);
    
    // Read
    Task<T?> GetByIdAsync(int id);
    
    Task<IReadOnlyList<T>> GetAllAsync();
    
    // Update
    Task UpdateAsync(T entity);
    
    // Delete
    Task DeleteAsync(T entity);
}