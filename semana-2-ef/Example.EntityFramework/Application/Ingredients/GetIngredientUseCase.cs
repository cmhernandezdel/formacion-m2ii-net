using Example.EntityFramework.Application.Core;
using Example.EntityFramework.Domain.Ingredients;

namespace Example.EntityFramework.Application.Ingredients;

public class GetIngredientUseCase
{
    public record GetIngredientRequest(Guid Id) : IRequest;
    public record GetIngredientResponse(Guid Id, string Name, double Price) : IResponse;

    public class Handler : IHandler<GetIngredientRequest, GetIngredientResponse?>
    {
        private readonly ICreateIngredientsRepository _repository;

        public Handler(ICreateIngredientsRepository repository)
        {
            _repository = repository;
        }

        public GetIngredientResponse? Handle(GetIngredientRequest request)
        {
            var entity = _repository.Get(request.Id);
            if (entity is null) return null;
            var response = new GetIngredientResponse(entity.Id, entity.Name, entity.Price);
            return response;
        }
    }
}
