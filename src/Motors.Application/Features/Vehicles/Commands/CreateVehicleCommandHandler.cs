using MediatR;
using Motors.Domain.Aggregates.VehicleAggregate;
using Motors.Domain.Repositories;

namespace Motors.Application.Features.Vehicles.Commands;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand,int>
{
    private readonly IVehicleRepository _vehicleRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        if(request.Brand is null)
            throw new ApplicationException("Brand should not be null");
        
        var vehicle = Vehicle.Create(request.Brand!, request.Model, request.Date);
        
        await _vehicleRepository.AddAsync(vehicle);
        
        await _unitOfWork.CommitAsync();
        
        return vehicle.Id; 
    }
}