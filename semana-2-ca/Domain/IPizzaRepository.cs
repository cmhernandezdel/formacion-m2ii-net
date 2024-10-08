namespace Tarradellas.Domain;

public interface IPizzaRepository
{
    void Add(Pizza pizza);
    void Remove(Pizza pizza);
    void Update(Pizza pizza);
    Pizza Get(Guid id);
}
