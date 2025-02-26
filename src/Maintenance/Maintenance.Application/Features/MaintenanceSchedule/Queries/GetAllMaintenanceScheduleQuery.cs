using MediatR;

namespace Maintenance.Application.Features.MaintenanceSchedule.Queries;

public class GetAllMaintenanceScheduleQuery :IRequest<List<Domain.Aggregates.MaintenanceSchedule.AggregateRoot.MaintenanceSchedule>>
{
    
}