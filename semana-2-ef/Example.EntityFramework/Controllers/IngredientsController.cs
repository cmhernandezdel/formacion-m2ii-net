using Example.EntityFramework.Application.Core;
using Example.EntityFramework.Application.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace Example.EntityFramework.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IHandler<GetIngredientUseCase.GetIngredientRequest, GetIngredientUseCase.GetIngredientResponse> _getHandler;
    private readonly IHandler<CreateIngredientUseCase.CreateIngredientRequest, CreateIngredientUseCase.CreateIngredientResponse> _postHandler;

    public IngredientsController(
        IHandler<GetIngredientUseCase.GetIngredientRequest, GetIngredientUseCase.GetIngredientResponse> getHandler,
        IHandler<CreateIngredientUseCase.CreateIngredientRequest, CreateIngredientUseCase.CreateIngredientResponse> postHandler)
    {
        _getHandler = getHandler;
        _postHandler = postHandler;
    }

    [HttpGet("{id}")]
    public ActionResult<IResponse> Get(Guid id)
    {
        var request = new GetIngredientUseCase.GetIngredientRequest(id);
        var result = _getHandler.Handle(request);
        if (result is null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<IResponse> Create(CreateIngredientUseCase.CreateIngredientRequest request)
    {
        var result = _postHandler.Handle(request);
        return Ok(result);
    }
}
