using System.Reflection;
using FluentValidation;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class FluentValidationsConfigurations
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Singleton);
        return services;
    }
}