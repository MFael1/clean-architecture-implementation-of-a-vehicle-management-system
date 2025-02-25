using Motors.Domain.Events;

namespace Motors.Domain.Aggregates.VehicleAggregate.Events;

public class VehicleCreatedEvent : DomainEvent
{
    public int Id { get;}
    public string Brand { get;}

    public VehicleCreatedEvent(int id, string brand)
    {
        Brand = brand;
        Id = id;
    }
}