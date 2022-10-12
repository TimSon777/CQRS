using CQRS.Simple.Components.Command;
using CQRS.Simple.Components.Query;
using CQRS.Simple.Infrastructure.Features.GetCar;
using CQRS.Simple.Infrastructure.Features.PickUpCar;
using CQRS.Simple.Web.API.Areas.Car.Data;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Simple.Web.API.Areas.Car.Controllers;

[Area(AreasNaming.Car)]
public class CarsController : ControllerBase
{
    private readonly IQueryHandler<GetCarQuery, GetCarResult> _getCarQueryHandler;
    private readonly ICommandHandler<PickUpCommand, CommandResultWithClaims> _pickUpCommandHandler;

    public CarsController(
        IQueryHandler<GetCarQuery, GetCarResult> getCarQueryHandler, 
        ICommandHandler<PickUpCommand, CommandResultWithClaims> pickUpCommandHandler)
    {
        _getCarQueryHandler = getCarQueryHandler;
        _pickUpCommandHandler = pickUpCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] GetCarQueryItem queryItem)
    {
        return await GetResultAsync(async () =>
        {
            var query = queryItem.ToQuery();
            var result = await _getCarQueryHandler.HandleAsync(query);
            return Ok(result);
        });
    }

    [HttpPost]
    public async Task<IActionResult> PickUpAsync(PickUpCommandItem commandItem)
    {
        return await GetResultAsync(async () =>
        {   
            var command = commandItem.ToCommand();
            var result = await _pickUpCommandHandler.HandleAsync(command);
            return Ok(result);
        });
    }
}