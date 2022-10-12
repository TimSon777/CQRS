using CQRS.Simple.Components.Query;
using CQRS.Simple.Components.Query.DefaultHandlers;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class QueryBuilderExtensions
{
    public static QueryBuilder<TQuery, TResult> AddQueryExceptionsHandler<TQuery, TResult>(
        this QueryBuilder<TQuery, TResult> builder)
        where TQuery : IQuery<TResult>
    {
        builder.AddQuery<ExceptionsQueryHandler<TQuery, TResult>>();
        return builder;
    }
    
    public static QueryBuilder<TQuery, TResult> AddQueryValidator<TQuery, TResult>(
        this QueryBuilder<TQuery, TResult> builder)
        where TQuery : IQuery<TResult>
    {
        builder.AddQuery<ValidatorQueryHandler<TQuery, TResult>>();
        return builder;
    }
}