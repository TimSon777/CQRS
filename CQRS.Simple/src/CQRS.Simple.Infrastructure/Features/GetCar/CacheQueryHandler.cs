using CQRS.Simple.Components;
using EasyCaching.Core;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

// ReSharper disable once ClassNeverInstantiated.Global
public class QueryHandler : IQueryHandler<GetCarQuery, GetCarResult>
{
    private readonly IRedisCachingProvider _cachingProvider;
    
    public QueryHandler(IEasyCachingProviderFactory cachingProviderFactory)
    {
        _cachingProvider = cachingProviderFactory.GetRedisProvider("default");

    }
    public async Task<GetCarResult> HandleAsync(GetCarQuery getCarQuery)
    {
        var id = getCarQuery.Id.ToString();
        var carName = await _cachingProvider.StringGetAsync(id);
        
        return new GetCarResult
        {
            Name = carName
        };
    }
}