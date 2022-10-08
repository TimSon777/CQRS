using CQRS.Simple.Components;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public class QueryBuilder<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IServiceCollection _services;
    private readonly List<Action> _queries = new();
    private bool _isFirstDecorator = true;

    private QueryBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public static QueryBuilder<TQuery, TResult> Create(IServiceCollection services)
    {
        return new QueryBuilder<TQuery, TResult>(services);
    }

    public QueryBuilder<TQuery, TResult> AddQuery<TQueryHandler>()
        where TQueryHandler : class, IQueryHandler<TQuery, TResult>
    {
        _queries.Add(Register<TQueryHandler>);
        
        return this;
    }

    public QueryBuilder<TQuery, TResult> AddQueryValidator()
    {
        _queries.Add(Register<QueryValidator<TQuery, TResult>>);
        return this;
    }

    public IServiceCollection Build()
    {
        foreach (var query in _queries)
        {
            query();
        }

        return _services;
    }

    private void Register<TQueryHandler>() 
        where TQueryHandler : class, IQueryHandler<TQuery, TResult>
    {
        if (_isFirstDecorator)
        {
            _isFirstDecorator = false;
            _services.AddSingleton<IQueryHandler<TQuery, TResult>, TQueryHandler>();
        }
        else
        {
            _services.Decorate<IQueryHandler<TQuery, TResult>, TQueryHandler>();
        }
    }
}