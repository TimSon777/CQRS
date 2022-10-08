namespace CQRS.Simple.Core.CarComponents;

public class CarCompleteSet
{
    public CarBodyType BodyType { get; }
    public decimal Price { get; }

    public CarCompleteSet(CarBodyType bodyType, decimal price)
    {
        BodyType = bodyType;
        Price = price;
    }
}