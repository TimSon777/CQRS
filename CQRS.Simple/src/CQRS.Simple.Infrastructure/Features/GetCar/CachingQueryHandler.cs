using System.Net;
using CQRS.Simple.Components.Query;
using EasyCaching.Core;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

// ReSharper disable once ClassNeverInstantiated.Global
public class CachingQueryHandler : IQueryHandler<GetCarQuery, GetCarResult>
{
    private readonly IRedisCachingProvider _cachingProvider;
    
    public CachingQueryHandler(IEasyCachingProviderFactory cachingProviderFactory)
    {
        _cachingProvider = cachingProviderFactory.GetRedisProvider("default");

    }
    public async Task<GetCarResult> HandleAsync(GetCarQuery getCarQuery)
    {
        var id = getCarQuery.Id.ToString();
        var carName = await _cachingProvider.StringGetAsync(id);

        if (carName is null)
        {
            throw new HttpRequestException("Entity was not found", null, HttpStatusCode.UnprocessableEntity);
        }
        
        return new GetCarResult
        {
            Name = carName
        };
    }
}