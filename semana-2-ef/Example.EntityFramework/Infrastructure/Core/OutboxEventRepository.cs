using Example.EntityFramework.Domain.Core;
using Example.EntityFramework.Infrastructure.EntityFramework;

namespace Example.EntityFramework.Infrastructure.Core;

public class GetOutboxEventRepository(ApplicationDbContext context) : IGetOutboxEventRepository
{
    public OutboxEvent? Get(Guid id)
    {
        return context.OutboxEvents.FirstOrDefault(e => e.Id == id);
    }
}

public class CreateOutboxEventRepository : GetOutboxEventRepository, ICreateOutboxEventRepository
{
    private readonly ApplicationDbContext _context;

    public CreateOutboxEventRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Add(OutboxEvent outboxEvent)
    {
        _context.OutboxEvents.Add(outboxEvent);
    }
}
