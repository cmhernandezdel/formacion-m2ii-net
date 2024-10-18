namespace Example.EntityFramework.Domain.Core;

public class OutboxEvent
{
    public Guid Id { get; set; }

    public Guid EntityId { get; set; }

    public OutboxEventType Type { get; set; }

    public DateTime TimestampUtc { get; set; }

    public object? Data { get; set; }

    public OutboxEvent(Guid id, Guid entityId, OutboxEventType type, object? data)
    {
        Id = id;
        EntityId = entityId;
        Type = type;
        TimestampUtc = DateTime.UtcNow;
        Data = data;
    }
}
