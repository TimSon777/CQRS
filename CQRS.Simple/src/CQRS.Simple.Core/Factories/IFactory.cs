namespace CQRS.Simple.Core.Factories;

public interface IFactory<in TIn, TOut>
{
    Task<TOut?> CreateAsync(TIn preferences);
}