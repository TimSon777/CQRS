using System.Reflection;

namespace CQRS.Simple.Core.Factories;

public class CarFactory : IFactory<UserPreferences, CarBase>
{
    private static readonly IEnumerable<CarBase> Cars;

    static CarFactory()
    {
        var carType = typeof(CarBase);
        Cars = Assembly.GetAssembly(carType)!
            .GetTypes()
            .Where(x => !x.IsAbstract && x.IsSubclassOf(carType))
            // ReSharper disable once SuspiciousTypeConversion.Global
            .Cast<CarBase>();
    }
    
    public Task<CarBase?> CreateAsync(UserPreferences preferences)
    {
        var car = Cars
            .Where(x => x.Colors
                .Contains(preferences.CarColor))
            .FirstOrDefault(x => x.CompleteSets
                .Any(y => y.Price <= preferences.MaximumPrice 
                          && y.Price >= preferences.MinimalPrice
                          && y.BodyType == preferences.CarBodyType));

        return Task.FromResult(car);
    }
}