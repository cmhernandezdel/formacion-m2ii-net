using Tarradellas.Domain;
using PizzaEntity = Tarradellas.Domain.Pizza;

namespace Tarradellas.Features.Pizza;

public sealed class AddPizza
{
    public readonly record struct Request(string Name, string Description, Uri Url, IEnumerable<Ingredient> Ingredients);
    public readonly record struct Response(Guid Id, string Name, string Description, Uri Url, double Price, IEnumerable<Ingredient> Ingredients);

    public class Controller 
    {

    }

    private class Handler(IAddPizza repository)
    {
        public Response Handle(Request request)
        {
            var pizza = PizzaEntity.Create(request.Name, request.Description, request.Url, request.Ingredients.ToHashSet());
            repository.Add(pizza);
            return new Response(pizza.Id, pizza.Name, pizza.Description, pizza.Url, pizza.GetPrice(), pizza.Ingredients);
        }
    }
}
