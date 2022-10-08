using Microsoft.AspNetCore.Mvc;

namespace CQRS.Simple.Web.API;

[ApiController]
[Route("api/[controller]")]
public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{ }