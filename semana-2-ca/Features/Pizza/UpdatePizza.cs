using Tarradellas.Domain;
using Tarradellas.Infrastructure;

namespace Tarradellas.Features.Pizza;

public sealed class UpdatePizza
{
    public readonly record struct Request(Guid Id, string Name, string Description, Uri Url);
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
            var repository = new UpdatePizzaRepository();
            var handler = new Handler(repository);
            return new Controller(handler);
        }
    }

    private class Handler(IUpdatePizza repository) : IHandler
    {
        public Response Handle(Request request)
        {
            var pizza = repository.Get(request.Id);
            pizza.Update(request.Name, request.Description, request.Url);
            repository.Update(pizza);
            return new Response(pizza.Id, pizza.Name, pizza.Description, pizza.Url, pizza.GetPrice(), pizza.Ingredients);
        }
    }
}
