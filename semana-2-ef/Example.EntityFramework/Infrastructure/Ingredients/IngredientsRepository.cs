using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Infrastructure.EntityFramework;

namespace Example.EntityFramework.Infrastructure.Ingredients;

public class GetIngredientsRepository : IGetIngredientsRepository
{
    private readonly ApplicationDbContext _context;

    public GetIngredientsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Ingredient? Get(Guid id)
    {
        return _context.Ingredients.FirstOrDefault(e => e.Id == id);
    }
}

public sealed class CreateIngredientsRepository : GetIngredientsRepository, ICreateIngredientsRepository
{
    private readonly ApplicationDbContext _context;

    public CreateIngredientsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Insert(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
    }
}
