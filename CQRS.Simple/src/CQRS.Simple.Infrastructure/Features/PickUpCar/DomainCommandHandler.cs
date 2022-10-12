using System.Net;
using CQRS.Simple.Components.Command;
using CQRS.Simple.Core;
using CQRS.Simple.Core.Factories;
using EasyCaching.Core;

namespace CQRS.Simple.Infrastructure.Features.PickUpCar;

// ReSharper disable once ClassNeverInstantiated.Global
public class DomainCommandHandler : ICommandHandler<PickUpCommand, CommandResultWithClaims>
{
    private readonly IFactory<UserPreferences, CarBase> _factory;
    private readonly IRedisCachingProvider _cachingProvider;

    public DomainCommandHandler(IFactory<UserPreferences, CarBase> factory, IEasyCachingProviderFactory cachingProviderFactory)
    {
        _cachingProvider = cachingProviderFactory.GetRedisProvider("default");
        _factory = factory;
    }

    public async Task<CommandResultWithClaims> HandleAsync(PickUpCommand command)
    {
        var userPreferences = command.Map();
        var car = await _factory.CreateAsync(userPreferences);
        var result = new CommandResultWithClaims();
        
        if (car is null)
        {
            result.Claims["Message"] = "We can't pick up car. Change your preferences";
            return result;
        }

        var guid = Guid
            .NewGuid()
            .ToString();

        var isOk = await _cachingProvider.StringSetAsync(guid, car.Name);

        if (!isOk)
        {
            throw new HttpRequestException(null, null, HttpStatusCode.InternalServerError);
        }

        result.Claims["Id"] = guid;

        return result;
    }
}