namespace Example.EntityFramework.Domain.Pizzas;

public interface IPizzasRepository : IGetPizzasRepository, ICreatePizzasRepository
{

}

public interface IGetPizzasRepository
{
    Pizza? Get(Guid id);
}

public interface ICreatePizzasRepository : IGetPizzasRepository
{
    void Insert(Pizza pizza);
}
