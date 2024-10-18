using Example.EntityFramework.Application.Core;
using Example.EntityFramework.Domain.Ingredients;

namespace Example.EntityFramework.Application.Ingredients;

public class CreateIngredientUseCase
{
    public readonly record struct CreateIngredientRequest(string Name, double Price) : IRequest;
    public readonly record struct CreateIngredientResponse(Guid Id, string Name, double Price) : IResponse;

    public class Handler(ICreateIngredientsUnitOfWork uow) : IHandler<CreateIngredientRequest, CreateIngredientResponse>
    {
        public CreateIngredientResponse Handle(CreateIngredientRequest request)
        {
            var entity = Ingredient.Create(request.Name, request.Price);
            var outboxEvent = new AddIngredientEvent(Guid.NewGuid(), entity.Id, entity);
            uow.Repository.Insert(entity);
            uow.EventRepository.Add(outboxEvent);
            uow.Commit();
            return new CreateIngredientResponse(entity.Id, entity.Name, entity.Price);
        }
    }
}
