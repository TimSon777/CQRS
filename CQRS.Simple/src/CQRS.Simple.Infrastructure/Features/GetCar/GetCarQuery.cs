using CQRS.Simple.Components.Query;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

public class GetCarQuery : IQuery<GetCarResult>
{
    public Guid Id { get; set; }
}