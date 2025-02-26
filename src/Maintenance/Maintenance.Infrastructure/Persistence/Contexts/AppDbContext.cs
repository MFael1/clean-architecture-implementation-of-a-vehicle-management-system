using Maintenance.Domain.Aggregates.MaintenanceSchedule.AggregateRoot;
using Maintenance.Domain.Common.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Maintenance.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{

    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var timestampEntries  = ChangeTracker
            .Entries<Entity>()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .ToList();
        
        foreach (var entityEntry in timestampEntries )
        {
            (entityEntry.Entity).UpdateModifiedDate();

            if (entityEntry.State == EntityState.Added)
            {
                (entityEntry.Entity).SetCreatedDate();
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);
        
        var domainEventEntries  = ChangeTracker
            .Entries<AggregateRoot>()
            .Where(e => e.Entity.DomainEvents.Count != 0)
            .ToList();

        var domainEvents = domainEventEntries 
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();
       
        domainEventEntries .ToList().ForEach(e => e.Entity.ClearDomainEvents());

        foreach (var @event in domainEvents)
        {
            await _mediator.Publish(@event, cancellationToken);
        }
        return result;
    }
}