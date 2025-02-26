// src/Motors/Motors.Contract/Events/VehicleCreatedIntegrationEvent.cs
namespace Motors.Contract.Events;

public record VehicleCreatedIntegrationEvent
{
    public int VehicleId { get; init; }
    public string Brand { get; init; } = null!;
    public string? Model { get; init; }
    public DateOnly? ManufactureDate { get; init; }
    public DateTimeOffset OccurredOn { get; init; }
}