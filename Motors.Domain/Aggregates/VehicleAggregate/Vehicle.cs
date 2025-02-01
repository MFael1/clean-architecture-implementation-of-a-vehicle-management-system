using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Motors.Domain.Aggregates.VehicleAggregate.Events;
using Motors.Domain.Common.Base;

namespace Motors.Domain.Aggregates.VehicleAggregate;

public class Vehicle : AggregateRoot
{
    public string Brand { get; private set; } = null!;

    public string? Model { get; private set; }
    
    public DateOnly? Date { get; private set; }

    private Vehicle()
    {
    }
    
    private Vehicle(string brand, string? model, DateOnly? date)
    {
        Brand = brand;
        Model = model;
        Date = date;

        AddDomainEvent(new VehicleCreatedEvent(Id, brand));
    }

    public static Vehicle Create(string brand, string? model, DateOnly? date)
    {
        if(string.IsNullOrWhiteSpace(brand))
            throw new ArgumentNullException(nameof(brand));
        return new Vehicle(brand, model, date);
    }
}