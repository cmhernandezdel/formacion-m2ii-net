namespace Tarradellas.Domain;

public interface IAddPizza 
{
    void Add(Pizza pizza);
}

public interface IPizzaRepository : IAddPizza
{
    void Remove(Pizza pizza);
    void Update(Pizza pizza);
    Pizza Get(Guid id);
}
