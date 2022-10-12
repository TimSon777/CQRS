using CQRS.Simple.Core;

namespace CQRS.Simple.Infrastructure.Features.PickUpCar;

public static class Mapping
{
    public static UserPreferences Map(this PickUpCommand command)
    {
        return new UserPreferences
        {
            CarColor = command.CarColor,
            MaximumPrice = command.MaximumPrice,
            MinimalPrice = command.MinimalPrice,
            CarBodyType = command.CarBodyType
        };
    }
}