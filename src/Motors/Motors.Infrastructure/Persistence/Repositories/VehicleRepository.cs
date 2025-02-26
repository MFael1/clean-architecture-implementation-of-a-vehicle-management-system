using Motors.Domain.Aggregates.VehicleAggregate;
using Motors.Domain.Repositories;
using Motors.Infrastructure.Persistence.Contexts;

namespace Motors.Infrastructure.Persistence.Repositories;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context)
    {
        
    }
}