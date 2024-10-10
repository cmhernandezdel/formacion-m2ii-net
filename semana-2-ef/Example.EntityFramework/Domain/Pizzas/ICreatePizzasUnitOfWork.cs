using Example.EntityFramework.Domain.Core;
using Example.EntityFramework.Domain.Ingredients;

namespace Example.EntityFramework.Domain.Pizzas;

public interface ICreatePizzasUnitOfWork : IUnitOfWork
{
    public ICreatePizzasRepository Repository { get; }
    public IGetIngredientsRepository IngredientsRepository { get; }
}
