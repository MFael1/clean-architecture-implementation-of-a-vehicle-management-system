using MediatR;
using Motors.Domain.Aggregates.VehicleAggregate;

namespace Motors.Application.Features.Vehicles.Queries;

public record GetAllVehiclesQuery() : IRequest<IEnumerable<Vehicle>>;