using FluentValidation;

namespace CQRS.Simple.Infrastructure.Features.GetCar;

// ReSharper disable once UnusedType.Global
public class Validator : AbstractValidator<GetCarQuery>
{
    public Validator()
    {
        RuleFor(x => x.Id)
            .ExclusiveBetween(0, 4294967296);
    }
}