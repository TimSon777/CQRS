using CQRS.Simple.Components;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

public class GetCarQuery : IQuery<GetCarResult>
{
    public long Id { get; set; }
}