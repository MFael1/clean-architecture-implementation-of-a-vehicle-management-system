using MediatR;
using Motors.Domain.Aggregates.VehicleAggregate;
using Motors.Domain.Repositories;

namespace Motors.Application.Features.Vehicles.Queries;

public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<Vehicle>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleRepository.GetAllAsync();
    }
}