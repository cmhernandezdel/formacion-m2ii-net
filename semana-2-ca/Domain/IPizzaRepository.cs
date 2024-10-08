namespace Tarradellas.Domain;

public interface IReadPizza
{
    Pizza Get(Guid id);
}

public interface IAddPizza 
{
    void Add(Pizza pizza);
}

public interface IUpdatePizza : IReadPizza {
    void Update(Pizza pizza);
}

public interface IPizzaRepository : IAddPizza, IUpdatePizza
{
    void Remove(Pizza pizza);
}
