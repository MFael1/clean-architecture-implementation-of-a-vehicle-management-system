using Maintenance.Application.Features.MaintenanceSchedule.Queries;
using Maintenance.Domain.Aggregates.MaintenanceSchedule.AggregateRoot;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Maintenance.Api.Controllers.Maintenance;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceController
{
    private readonly IMediator _mediator;

    public MaintenanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaintenanceSchedule>>> GetAll()
    {
        var maintenanceSchedules = await _mediator.Send(new GetAllMaintenanceScheduleQuery());
        return maintenanceSchedules;
    }
}