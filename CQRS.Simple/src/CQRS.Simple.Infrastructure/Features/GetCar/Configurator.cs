﻿using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

// ReSharper disable once UnusedType.Global
public class Configurator : QueryConfigurator
{
    public override IServiceCollection AddQuery(IServiceCollection services)
    {
        QueryBuilder<GetCarQuery, GetCarResult>
            .Create(services)
            .AddQuery<QueryHandler>()
            .AddQueryValidator()
            .Build();
        
        return services;
    }
}