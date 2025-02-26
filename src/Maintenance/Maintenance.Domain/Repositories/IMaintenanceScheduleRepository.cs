using Maintenance.Domain.Aggregates.MaintenanceSchedule.AggregateRoot;

namespace Maintenance.Domain.Repositories;

public interface IMaintenanceScheduleRepository : IRepository<MaintenanceSchedule>
{
    
}