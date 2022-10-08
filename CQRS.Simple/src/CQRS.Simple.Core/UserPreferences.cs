using CQRS.Simple.Core.CarComponents;

namespace CQRS.Simple.Core;

public class UserPreferences
{
    public decimal MinimalPrice { get; set; }
    public decimal MaximumPrice { get; set; }
    public CarColor CarColor { get; set; }
    public CarBodyType CarBodyType { get; set; }
}