using Microsoft.EntityFrameworkCore;
using Motors.Domain.Repositories;
using Motors.Infrastructure.Persistence.Contexts;

namespace Motors.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    protected Repository(AppDbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}