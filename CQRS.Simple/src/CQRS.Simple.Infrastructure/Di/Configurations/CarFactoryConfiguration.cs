using CQRS.Simple.Core;
using CQRS.Simple.Core.Factories;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class CarFactoryConfiguration
{
    public static IServiceCollection AddCarFactory(this IServiceCollection services)
    {
        services.AddSingleton<IFactory<UserPreferences, CarBase>, CarFactory>();
        return services;
    }
}