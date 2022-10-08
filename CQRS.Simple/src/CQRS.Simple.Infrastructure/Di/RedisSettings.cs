using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public class RedisSettings
{
    public const string Position = "REDIS_SETTINGS";

    [ConfigurationKeyName("HOST")] 
    public string Host { get; set; } = "";

    [ConfigurationKeyName("PORT")]
    public int Port { get; set; }
}