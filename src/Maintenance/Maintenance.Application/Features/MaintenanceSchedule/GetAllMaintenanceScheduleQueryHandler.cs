using Maintenance.Application.Features.MaintenanceSchedule.Queries;
using Maintenance.Domain.Repositories;
using MediatR;

namespace Maintenance.Application.Features.MaintenanceSchedule;

public class GetAllMaintenanceScheduleQueryHandler : IRequestHandler<GetAllMaintenanceScheduleQuery, IEnumerable<Domain.Aggregates.MaintenanceSchedule.AggregateRoot.MaintenanceSchedule>>
{
    private readonly IMaintenanceScheduleRepository _repository;

    public GetAllMaintenanceScheduleQueryHandler(IMaintenanceScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Domain.Aggregates.MaintenanceSchedule.AggregateRoot.MaintenanceSchedule>> Handle(GetAllMaintenanceScheduleQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}