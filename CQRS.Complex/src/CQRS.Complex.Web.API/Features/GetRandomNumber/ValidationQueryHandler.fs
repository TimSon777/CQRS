namespace CQRS.Complex.Web.API.Features.GetRandomNumber

open CQRS.Complex.Components
open CQRS.Complex.Components.ResultBuilder

type ValidationQueryHandler(decorated: IQueryHandler<Query, QueryResult>) =
    interface IQueryHandler<Query, QueryResult> with
        member this.Handle query =
            result {
                return!
                    match query.Number with
                    | 5 -> Error "Wtf"
                    | _ ->
                        query |> decorated.Handle
            }
