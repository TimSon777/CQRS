using System.Security;
using CQRS.Simple.Components.Query;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

// ReSharper disable once ClassNeverInstantiated.Global
public class SecurityQueryHandler : IQueryHandler<GetCarQuery, GetCarResult>
{
    private readonly IQueryHandler<GetCarQuery, GetCarResult> _decorated;

    public SecurityQueryHandler(IQueryHandler<GetCarQuery, GetCarResult> decorated)
    {
        _decorated = decorated;
    }

    public async Task<GetCarResult> HandleAsync(GetCarQuery query)
    {
        if (query.Id == Guid.Empty)
        {
            throw new SecurityException("You can't access this car");
        }

        return await _decorated.HandleAsync(query);
    }
}