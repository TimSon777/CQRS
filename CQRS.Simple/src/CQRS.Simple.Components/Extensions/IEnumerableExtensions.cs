namespace CQRS.Simple.Components.Extensions;

// ReSharper disable once InconsistentNaming
public static class IEnumerableExtensions
{
    public static IEnumerable<Type> GetInheritors<T>(this IEnumerable<Type> src)
    {
        return src.Where(y => !y.IsAbstract 
                              && y.IsSubclassOf(typeof(T)));
    }
}