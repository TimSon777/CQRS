namespace CQRS.Simple.Components.Command.DefaultHandlers;

// ReSharper disable once ClassNeverInstantiated.Global
public class ExceptionsCommandHandler<TCommand, TResult> : ExceptionHandlerBase, ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _decorated;

    public ExceptionsCommandHandler(ICommandHandler<TCommand, TResult> decorated)
    {
        _decorated = decorated;
    }

    public async Task<TResult> HandleAsync(TCommand query)
    {
        return await RewriteExceptionsAsync(() => _decorated.HandleAsync(query));
    }
}