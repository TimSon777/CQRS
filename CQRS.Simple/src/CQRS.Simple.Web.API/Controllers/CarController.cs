using CQRS.Simple.Components;
using CQRS.Simple.Core;
using CQRS.Simple.Infrastructure.Features.GetCar;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Simple.Web.API.Controllers;

public class CarController : ControllerBase
{
    private readonly IQueryHandler<GetCarQuery, GetCarResult> _queryHandler;

    public CarController(IQueryHandler<GetCarQuery, GetCarResult> queryHandler)
    {
        _queryHandler = queryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetCarQuery query)
    {
        var result = await _queryHandler.HandleAsync(query);
        return Ok(result);
    }

    [HttpPost]
    public Task<IActionResult> PickUpAsync(UserPreferences preferences)
    {
        throw new NotImplementedException();
    }
}