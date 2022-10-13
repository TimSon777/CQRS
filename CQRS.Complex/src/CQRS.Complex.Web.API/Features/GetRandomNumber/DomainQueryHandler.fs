namespace CQRS.Complex.Web.API.Features.GetRandomNumber

open System
open CQRS.Complex.Components
open CQRS.Complex.Components.ResultBuilder

type DomainQueryHandler() =
    interface IQueryHandler<Query, QueryResult> with
        member this.Handle query =
            result {
                let randomNumber = Random.Shared.Next(1, 11) + query.Number
                return! Ok (QueryResult(randomNumber))
            }
