// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public abstract class QueryConfigurator
{
    public abstract IServiceCollection AddQuery(IServiceCollection services);
}