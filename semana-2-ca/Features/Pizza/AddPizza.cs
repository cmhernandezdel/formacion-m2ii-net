using Tarradellas.Domain;
using Tarradellas.Infrastructure;
using PizzaEntity = Tarradellas.Domain.Pizza;

namespace Tarradellas.Features.Pizza;

public sealed class AddPizza
{
    public readonly record struct Request(string Name, string Description, Uri Url, IEnumerable<Ingredient> Ingredients);
    public readonly record struct Response(Guid Id, string Name, string Description, Uri Url, double Price, IEnumerable<Ingredient> Ingredients);

    public interface IController {
        Response Handle(Request request);
    }

    public interface IHandler {
        Response Handle(Request request);
    }

    public class Controller(IHandler handler) : IController
    {
        public Response Handle(Request request)
        {
            return handler.Handle(request);
        }

        // setup DI
        public static IController Create() {
            var repository = new PizzaRepository();
            var handler = new Handler(repository);
            return new Controller(handler);
        }
    }

    private class Handler(IAddPizza repository) : IHandler
    {
        public Response Handle(Request request)
        {
            var pizza = PizzaEntity.Create(request.Name, request.Description, request.Url, request.Ingredients.ToHashSet());
            repository.Add(pizza);
            return new Response(pizza.Id, pizza.Name, pizza.Description, pizza.Url, pizza.GetPrice(), pizza.Ingredients);
        }
    }
}
