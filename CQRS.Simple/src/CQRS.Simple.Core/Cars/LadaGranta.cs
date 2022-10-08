using CQRS.Simple.Core.CarComponents;

namespace CQRS.Simple.Core.Cars;

public class LadaGranta : LadaBase
{
    public override string Name => "Lada Granta";

    public override IEnumerable<CarCompleteSet> CompleteSets => new CarCompleteSet[]
    {
        new(CarBodyType.Sedan, 680_000)
    };

    public override IEnumerable<CarColor> Colors => new[]
    {
        CarColor.All
    };
}