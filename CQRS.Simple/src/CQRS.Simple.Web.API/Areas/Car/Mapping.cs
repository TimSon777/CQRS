using CQRS.Simple.Infrastructure.Features.GetCar;
using CQRS.Simple.Infrastructure.Features.PickUpCar;
using CQRS.Simple.Web.API.Areas.Car.Data;

namespace CQRS.Simple.Web.API.Areas.Car;

public static class Mapping
{
    public static GetCarQuery ToQuery(this GetCarQueryItem item)
    {
        return new GetCarQuery
        {
            Id = item.Id
        };
    }

    public static PickUpCommand ToCommand(this PickUpCommandItem item)
    {
        return new PickUpCommand
        {
            CarColor = item.CarColor,
            MaximumPrice = item.MaximumPrice,
            MinimalPrice = item.MinimalPrice,
            CarBodyType = item.CarBodyType
        };
    }
}