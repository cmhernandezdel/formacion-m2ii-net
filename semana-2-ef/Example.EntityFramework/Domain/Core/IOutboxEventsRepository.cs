namespace Example.EntityFramework.Domain.Core;

public interface IGetOutboxEventRepository
{
    OutboxEvent? Get(Guid id);
}

public interface IGetAllOutboxEventsRepository : IGetOutboxEventRepository
{
    IEnumerable<OutboxEvent> Get();
}

public interface ICreateOutboxEventRepository : IGetOutboxEventRepository
{
    void Add(OutboxEvent outboxEvent);
}

public interface IUpdateOutboxEventRepository : IGetOutboxEventRepository
{
    void Update(OutboxEvent outboxEvent);
}

public interface IRemoveOutboxEventRepository : IGetOutboxEventRepository
{
    void Remove(OutboxEvent outboxEvent);
}
