using CQRS.Simple.Components.Command;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public class CommandBuilder<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    private readonly IServiceCollection _services;
    private readonly List<Action> _commands = new();
    private bool _isFirstDecorator = true;

    private CommandBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public static CommandBuilder<TCommand, TResult> Create(IServiceCollection services)
    {
        return new CommandBuilder<TCommand, TResult>(services);
    }

    public CommandBuilder<TCommand, TResult> AddCommand<TCommandHandler>()
        where TCommandHandler : class, ICommandHandler<TCommand, TResult>
    {
        _commands.Add(Register<TCommandHandler>);
        
        return this;
    }

    public IServiceCollection Build()
    {
        foreach (var command in _commands)
        {
            command();
        }

        return _services;
    }

    private void Register<TCommandHandler>() 
        where TCommandHandler : class, ICommandHandler<TCommand, TResult>
    {
        if (_isFirstDecorator)
        {
            _isFirstDecorator = false;
            _services.AddScoped<ICommandHandler<TCommand, TResult>, TCommandHandler>();
        }
        else
        {
            _services.Decorate<ICommandHandler<TCommand, TResult>, TCommandHandler>();
        }
    }
}