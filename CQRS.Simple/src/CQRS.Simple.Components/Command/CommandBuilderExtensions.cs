using CQRS.Simple.Components.Command;
using CQRS.Simple.Components.Command.DefaultHandlers;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class CommandBuilderExtensions
{
    public static CommandBuilder<TCommand, TResult> AddQueryExceptionsHandler<TCommand, TResult>(
        this CommandBuilder<TCommand, TResult> builder)
        where TCommand : ICommand<TResult>
    {
        builder.AddCommand<ExceptionsCommandHandler<TCommand, TResult>>();
        return builder;
    }
    
    public static CommandBuilder<TCommand, TResult> AddCommandValidator<TCommand, TResult>(
        this CommandBuilder<TCommand, TResult> builder)
        where TCommand : ICommand<TResult>
    {
        builder.AddCommand<ValidatorCommandHandler<TCommand, TResult>>();
        return builder;
    }
}