namespace Example.EntityFramework.Domain.Ingredients;

public interface IIngredientsRepository : IGetIngredientsRepository, ICreateIngredientsRepository
{

}

public interface IGetIngredientsRepository
{
    Ingredient? Get(Guid id);
}

public interface ICreateIngredientsRepository : IGetIngredientsRepository
{
    void Insert(Ingredient ingredient);
}
