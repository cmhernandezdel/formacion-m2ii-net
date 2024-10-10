using Example.EntityFramework.Application.Core;
using Example.EntityFramework.Application.Pizzas;
using Microsoft.AspNetCore.Mvc;

namespace Example.EntityFramework.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzasController : ControllerBase
{
    private readonly IHandler<CreatePizzaUseCase.CreatePizzaRequest, CreatePizzaUseCase.CreatePizzaResponse> _postHandler;

    public PizzasController(IHandler<CreatePizzaUseCase.CreatePizzaRequest, CreatePizzaUseCase.CreatePizzaResponse> postHandler)
    {
        _postHandler = postHandler;
    }

    [HttpPost]
    public ActionResult<IResponse> Create(CreatePizzaUseCase.CreatePizzaRequest request)
    {
        var result = _postHandler.Handle(request);
        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}