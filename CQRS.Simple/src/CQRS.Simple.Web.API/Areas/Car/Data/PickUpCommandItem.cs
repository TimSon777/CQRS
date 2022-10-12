using CQRS.Simple.Core.CarComponents;

namespace CQRS.Simple.Web.API.Areas.Car.Data;

public class PickUpCommandItem
{
    public decimal MinimalPrice { get; set; }
    public decimal MaximumPrice { get; set; }
    public CarColor CarColor { get; set; }
    public CarBodyType CarBodyType { get; set; }
}