using System.Net;
using System.Security;
using FluentValidation;

namespace CQRS.Simple.Components;

public class ExceptionHandlerBase
{
    protected async Task<T> RewriteExceptionsAsync<T>(Func<Task<T>> handler)
    {
        try
        {
            return await handler();
        }
        catch (ValidationException ex)
        {
            throw new HttpRequestException(ex.Message, null, HttpStatusCode.BadRequest);
        }
        catch (SecurityException ex)
        {
            throw new HttpRequestException(ex.Message, null, HttpStatusCode.Forbidden);
        }
    }
}