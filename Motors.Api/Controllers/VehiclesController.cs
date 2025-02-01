using MediatR;
using Microsoft.AspNetCore.Mvc;
using Motors.Application.Features.Vehicles.Commands;
using Motors.Application.Features.Vehicles.Queries;
using Motors.Domain.Aggregates.VehicleAggregate;

namespace Motors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateVehicleCommand command)
    {
        var vehicleId = await _mediator.Send(command);
        return Ok(vehicleId);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
    {
        var vehicles = await _mediator.Send(new GetAllVehiclesQuery());
        return Ok(vehicles);
    }
}