using Example.EntityFramework.Domain.Pizzas;
using Example.EntityFramework.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Example.EntityFramework.Infrastructure.Pizzas;

public class GetPizzasRepository : IGetPizzasRepository
{
    private readonly ApplicationDbContext _context;

    public GetPizzasRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Pizza? Get(Guid id)
    {
        return _context.Pizzas.AsNoTracking().FirstOrDefault(e => e.Id == id);
    }
}

public sealed class CreatePizzasRepository : GetPizzasRepository, ICreatePizzasRepository
{
    private readonly ApplicationDbContext _context;

    public CreatePizzasRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Insert(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
    }
}
