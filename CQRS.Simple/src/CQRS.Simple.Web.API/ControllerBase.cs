using Microsoft.AspNetCore.Mvc;

namespace CQRS.Simple.Web.API;

[ApiController]
[Route("api/[area]/[controller]")]
public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected async Task<IActionResult> GetResultAsync(Func<Task<IActionResult>> action)
    {
        try
        {
            return await action();
        }
        catch (HttpRequestException ex)
        {
            var result = new ObjectResult(ex.Message);
            
            var statusCode = ex.StatusCode.HasValue
                ? (int) ex.StatusCode
                : 500;

            result.StatusCode = statusCode;
            return result;
        }
    }
}