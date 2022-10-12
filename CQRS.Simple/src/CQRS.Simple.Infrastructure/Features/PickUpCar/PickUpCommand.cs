using CQRS.Simple.Components.Command;
using CQRS.Simple.Core.CarComponents;

namespace CQRS.Simple.Infrastructure.Features.PickUpCar;

public class PickUpCommand : ICommand<CommandResultWithClaims>
{
    public decimal MinimalPrice { get; set; }
    public decimal MaximumPrice { get; set; }
    public CarColor CarColor { get; set; }
    public CarBodyType CarBodyType { get; set; }
}