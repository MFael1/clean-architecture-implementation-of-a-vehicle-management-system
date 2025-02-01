namespace Motors.Domain.Events;

public abstract class DomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredOn { get; }
    public Guid EventId { get; }

    protected DomainEvent()
    {
        EventId = Guid.NewGuid();
        OccurredOn = DateTimeOffset.UtcNow;
    }
}