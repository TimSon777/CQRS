namespace CQRS.Simple.Components.Query.DefaultHandlers;

// ReSharper disable once ClassNeverInstantiated.Global
public class ExceptionsQueryHandler<TQuery, TResult> : ExceptionHandlerBase, IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;

    public ExceptionsQueryHandler(IQueryHandler<TQuery, TResult> decorated)
    {
        _decorated = decorated;
    }

    public async Task<TResult> HandleAsync(TQuery query)
    {
        return await RewriteExceptionsAsync(() => _decorated.HandleAsync(query));
    }
}