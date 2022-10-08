using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class CommandAndQueriesConfiguration
{
    public static IServiceCollection AddQueries(this IServiceCollection services, params Assembly[] assembly)
    {
        var configurators = assembly
            .SelectMany(x => x
                .GetTypes()
                .Where(y => !y.IsAbstract && y.IsSubclassOf(typeof(QueryConfigurator)))
                .Select(Activator.CreateInstance)
                .Select(y => (QueryConfigurator) y!));

        foreach (var configurator in configurators)
        {
            configurator.AddQuery(services);
        }

        return services;
    }
}