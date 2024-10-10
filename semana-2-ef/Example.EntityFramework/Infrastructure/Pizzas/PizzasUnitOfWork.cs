using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Domain.Pizzas;
using Example.EntityFramework.Infrastructure.EntityFramework;
using Example.EntityFramework.Infrastructure.Ingredients;

namespace Example.EntityFramework.Infrastructure.Pizzas;

public class CreatePizzasUnitOfWork : UnitOfWork<ApplicationDbContext>, ICreatePizzasUnitOfWork
{
    public ICreatePizzasRepository Repository { get; }
    public IGetIngredientsRepository IngredientsRepository { get; }

    public CreatePizzasUnitOfWork(ApplicationDbContext context) : base(context)
    {
        Repository = new CreatePizzasRepository(context);
        IngredientsRepository = new GetIngredientsRepository(context);
    }
}
