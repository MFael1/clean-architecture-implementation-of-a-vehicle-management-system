using Maintenance.Domain.Aggregates.MaintenanceSchedule.AggregateRoot;
using Maintenance.Domain.Repositories;
using Maintenance.Infrastructure.Persistence.Contexts;

namespace Maintenance.Infrastructure.Persistence.Repositories;

public class MaintenanceScheduleRepository : Repository<MaintenanceSchedule>, IMaintenanceScheduleRepository
{
    protected MaintenanceScheduleRepository(AppDbContext context) : base(context)
    {
        
    }
}