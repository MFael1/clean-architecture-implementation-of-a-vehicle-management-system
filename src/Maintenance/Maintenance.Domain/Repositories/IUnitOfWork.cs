namespace Maintenance.Domain.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    Task<int> CommitAsync();
}