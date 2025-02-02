// Motors.Application/Features/Vehicles/EventHandlers/VehicleCreatedEventHandler.cs
using MediatR;
using Microsoft.Extensions.Logging;
using Motors.Domain.Aggregates.VehicleAggregate.Events;

namespace Motors.Application.Features.Vehicles.EventHandlers;

public class VehicleCreatedEventHandler : INotificationHandler<VehicleCreatedEvent>
{
    private readonly ILogger<VehicleCreatedEventHandler> _logger;

    public VehicleCreatedEventHandler(ILogger<VehicleCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(VehicleCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Here you can:
        // 1. Send emails
        // 2. Update other aggregates
        // 3. Send notifications
        // 4. Trigger external systems
        // 5. etc.

        _logger.LogInformation(
            "Vehicle created: {VehicleId} - Brand: {Brand} at {OccurredOn}", 
            notification.Id, 
            notification.Brand,
            notification.OccurredOn);

        return Task.CompletedTask;
    }
}