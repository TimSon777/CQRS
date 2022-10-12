// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseHttpRequestExceptionsHandler(this IApplicationBuilder app)
    {
        //app.UseMiddleware<HttpRequestExceptionMiddleware>();
        return app;
    }
}

public class HttpRequestExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public HttpRequestExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HttpRequestException ex)
        {
            httpContext.Response.Clear();
            httpContext.Response.ContentType = "application/json";

            if (!ex.StatusCode.HasValue)
            {
                httpContext.Response.StatusCode = 500;
                return;
            }

            var statusCode = (int) ex.StatusCode;

            if (statusCode == 400 && ex.InnerException is not null)
            {
                await httpContext.Response.WriteAsJsonAsync(ex.InnerException.Message);
            }
            
            httpContext.Response.StatusCode = (int) ex.StatusCode;
        }
    }
}