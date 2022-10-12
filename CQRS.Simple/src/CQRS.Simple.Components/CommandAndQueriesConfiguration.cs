using System.Reflection;
using CQRS.Simple.Components.Command;
using CQRS.Simple.Components.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class CommandAndQueriesConfiguration
{
    public static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assembly)
    {
        var configurators = assembly
            .SelectMany(x => x
                .GetTypes()
                .GetInheritors<QueryConfigurator>()
                .Select(Activator.CreateInstance)
                .Select(y => (QueryConfigurator) y!));

        foreach (var configurator in configurators)
        {
            configurator.AddQuery(services);
        }

        return services;
    }
    
    public static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assembly)
    {
        var configurators = assembly
            .SelectMany(x => x
                .GetTypes()
                .GetInheritors<CommandConfigurator>()
                .Select(Activator.CreateInstance)
                .Select(y => (CommandConfigurator) y!));

        foreach (var configurator in configurators)
        {
            configurator.AddCommand(services);
        }

        return services;
    }
}