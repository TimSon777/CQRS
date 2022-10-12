using CQRS.Simple.Components.Command;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Simple.Infrastructure.Features.PickUpCar;

public class Configurator : CommandConfigurator
{
    public override IServiceCollection AddCommand(IServiceCollection services)
    {
        CommandBuilder<PickUpCommand, CommandResultWithClaims>
            .Create(services)
            .AddCommand<DomainCommandHandler>()
            .AddCommandValidator()
            .AddQueryExceptionsHandler()
            .Build();

        return services;
    }
}