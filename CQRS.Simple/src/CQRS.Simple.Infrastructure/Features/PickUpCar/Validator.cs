using FluentValidation;

namespace CQRS.Simple.Infrastructure.Features.PickUpCar;

// ReSharper disable once UnusedType.Global
public class Validator : AbstractValidator<PickUpCommand>
{
    public Validator()
    {
        RuleFor(x => x.MinimalPrice)
            .InclusiveBetween(50_000, 100_000_000);

        RuleFor(x => x.MaximumPrice)
            .InclusiveBetween(50_000, 10_000_000);

        RuleFor(x => x)
            .Must(y => y.MaximumPrice - y.MinimalPrice > 0.0001M);
    }
}