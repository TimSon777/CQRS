using CQRS.Simple.Core.CarComponents;

namespace CQRS.Simple.Core.Cars;

public class LadaPriora : LadaBase
{
    public override string Name => "Lada priora";

    public override IEnumerable<CarCompleteSet> CompleteSets => new CarCompleteSet[]
    {
        new(CarBodyType.Hatchback, 300_000),
        new(CarBodyType.Sedan, 250_000),
        new(CarBodyType.StationWagons, 320_000)
    };

    public override IEnumerable<CarColor> Colors { get; } = new[]
    {
        CarColor.White,
        CarColor.Black
    };
}