using MediatR;

namespace Maintenance.Domain.Events;

public interface IDomainEvent : INotification
{
    DateTimeOffset OccurredOn { get; }
    Guid EventId { get; }
}
