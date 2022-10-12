using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Simple.Components.Command;

public abstract class CommandConfigurator
{
    public abstract IServiceCollection AddCommand(IServiceCollection services);
}