using FluentValidation;

namespace CQRS.Simple.Components;

// ReSharper disable once ClassNeverInstantiated.Global
public class QueryValidator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    private readonly IValidator<TQuery> _validator;
    private readonly IQueryHandler<TQuery, TResult> _decorated;

    public QueryValidator(IValidator<TQuery> validator, IQueryHandler<TQuery, TResult> decorated)
    {
        _validator = validator;
        _decorated = decorated;
    }

    public async Task<TResult> HandleAsync(TQuery query)
    {
        await _validator.ValidateAndThrowAsync(query);
        return await _decorated.HandleAsync(query);
    }
}