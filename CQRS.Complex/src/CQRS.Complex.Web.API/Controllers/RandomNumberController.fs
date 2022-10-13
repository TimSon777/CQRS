namespace CQRS.Complex.Web.API.Controllers

open CQRS.Complex.Components
open Microsoft.AspNetCore.Mvc
open CQRS.Complex.Web.API.Features.GetRandomNumber

type RandomNumberController(queryHandler: IQueryHandler<Query, QueryResult>) =
    inherit Controller()
    
    [<HttpGet("number")>]
    member this.Get(number: int) =
        let result = number |> Query |> queryHandler.Handle
        match result with
        | Error e when e = "Wtf"-> e |> this.BadRequest :> IActionResult
        | Ok ok -> ok |> this.Ok :> IActionResult
        | Error e -> e |> failwith