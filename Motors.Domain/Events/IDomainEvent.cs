using MediatR;

namespace Motors.Domain.Events;

public interface IDomainEvent : INotification
{
    DateTimeOffset OccurredOn { get; }
    Guid EventId { get; }
}
