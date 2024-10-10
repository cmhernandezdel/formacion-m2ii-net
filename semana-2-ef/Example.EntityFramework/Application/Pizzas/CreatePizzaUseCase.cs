using Example.EntityFramework.Application.Core;
using Example.EntityFramework.Domain.Ingredients;
using Example.EntityFramework.Domain.Pizzas;

namespace Example.EntityFramework.Application.Pizzas;

public class CreatePizzaUseCase
{
    public record CreatePizzaRequest(string Name, string Description, Uri Url, IEnumerable<Guid> IngredientIds) : IRequest;
    public record CreatePizzaResponse(Guid Id, string Name, string Description, Uri Url, IEnumerable<Guid> IngredientIds) : IResponse;

    public class Handler(ICreatePizzasUnitOfWork uow) : IHandler<CreatePizzaRequest, CreatePizzaResponse?>
    {
        public CreatePizzaResponse? Handle(CreatePizzaRequest request)
        {
            List<Ingredient> ingredients = [];
            foreach (var ingredientId in request.IngredientIds)
            {
                var ingredient = uow.IngredientsRepository.Get(ingredientId);
                if (ingredient is null)
                {
                    return null;
                }
                ingredients.Add(ingredient);
            }

            var entity = Pizza.Create(request.Name, request.Description, request.Url, [.. ingredients]);
            uow.Repository.Insert(entity);
            uow.Commit();
            return new CreatePizzaResponse(entity.Id, entity.Name, entity.Description, entity.Url, entity.Ingredients.Select(i => i.Id));
        }
    }
}
