namespace CQRS.Simple.Components.Command;

public class CommandResultWithClaims 
    : ICommand<CommandResultWithClaims> 
{
    // ReSharper disable once UnusedMember.Global
    public Dictionary<string, string> Claims { get; set; } = new();
}