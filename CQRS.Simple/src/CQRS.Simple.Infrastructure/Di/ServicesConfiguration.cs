using System.Reflection;
using CQRS.Simple.Components;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        Assembly[] assemblies =
        {
            Assembly.GetAssembly(typeof(IQuery<>))!,
            Assembly.GetAssembly(typeof(RedisSettings))! 
        };
        
        services
            .AddCarFactory()
            .AddValidators()
            .AddQueries(assemblies)
            .AddRedis(configuration);
        
        return services;
    }
}