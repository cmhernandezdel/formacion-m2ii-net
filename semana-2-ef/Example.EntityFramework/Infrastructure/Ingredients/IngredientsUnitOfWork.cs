using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Infrastructure.EntityFramework;

namespace Example.EntityFramework.Infrastructure.Ingredients;

public class CreateIngredientsUnitOfWork : UnitOfWork<ApplicationDbContext>, ICreateIngredientsUnitOfWork
{
    public ICreateIngredientsRepository Repository { get; }

    public CreateIngredientsUnitOfWork(ApplicationDbContext context) : base(context)
    {
        Repository = new CreateIngredientsRepository(context);
    }
}
