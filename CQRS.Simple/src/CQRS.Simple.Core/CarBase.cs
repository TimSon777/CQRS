using CQRS.Simple.Core.CarComponents;

namespace CQRS.Simple.Core;

public abstract class CarBase
{
    public abstract string Name { get; }
    public abstract IEnumerable<CarCompleteSet> CompleteSets { get; }
    public abstract IEnumerable<CarColor> Colors { get; }
}