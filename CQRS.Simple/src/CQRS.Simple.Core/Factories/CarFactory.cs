using System.Reflection;

namespace CQRS.Simple.Core.Factories;

public class CarFactory : IFactory<UserPreferences, CarBase>
{
    private static readonly IEnumerable<CarBase> Cars;

    static CarFactory()
    {
        var carType = typeof(CarBase);
        var cars = Assembly.GetAssembly(carType)!
            .GetTypes()
            .Where(x => !x.IsAbstract && x.IsSubclassOf(carType));

        Cars = cars.Select(x => (CarBase) Activator.CreateInstance(x)!);
    }
    
    public Task<CarBase?> CreateAsync(UserPreferences preferences)
    {
        var car = Cars
            .FirstOrDefault(x => x.CompleteSets
                                     .Any(y => y.Price <= preferences.MaximumPrice 
                                               && y.Price >= preferences.MinimalPrice
                                               && y.BodyType == preferences.CarBodyType) 
                                 && x.Colors
                                     .Any(y => y == preferences.CarColor));

        return Task.FromResult(car);
    }
}