using EasyCaching.Core.Configurations;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class CachingConfiguration
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        const string serviceName = "default";
        services.AddEasyCaching(options =>
        {
            options.UseRedis(configurator =>
            {
                var redisSettings = configuration.Get<RedisSettings>(RedisSettings.Position);

                var redisEndpoint = new ServerEndPoint
                {
                    Host = redisSettings.Host,
                    Port = redisSettings.Port
                };

                configurator
                    .DBConfig
                    .Endpoints
                    .Add(redisEndpoint);
                
                configurator.SerializerName = serviceName;
            }, serviceName)
                .WithMessagePack(serviceName);
        });

        return services;
    }
}