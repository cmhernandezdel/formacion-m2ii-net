namespace Tarradellas.Domain;

public interface IIngredientRepository
{
    void Add(Ingredient ingredient);
    void Remove(Ingredient ingredient);
    void Update(Ingredient ingredient);
    Ingredient Get(Guid id);
}
