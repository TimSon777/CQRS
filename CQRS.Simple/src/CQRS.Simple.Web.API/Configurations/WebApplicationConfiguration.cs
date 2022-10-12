// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationConfiguration
{
    public static WebApplication Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app
            .UseHttpsRedirection()
            .UseHttpRequestExceptionsHandler();

        app.MapControllers();

        return app;
    }
}