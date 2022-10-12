using FluentValidation;

namespace CQRS.Simple.Components.Command.DefaultHandlers;

// ReSharper disable once ClassNeverInstantiated.Global
public class ValidatorCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly IValidator<TCommand> _validator;
    private readonly ICommandHandler<TCommand, TResult> _decorated;

    public ValidatorCommandHandler(IValidator<TCommand> validator, ICommandHandler<TCommand, TResult> decorated)
    {
        _validator = validator;
        _decorated = decorated;
    }

    public async Task<TResult> HandleAsync(TCommand query)
    {
        await _validator.ValidateAndThrowAsync(query);
        return await _decorated.HandleAsync(query);
    }
}