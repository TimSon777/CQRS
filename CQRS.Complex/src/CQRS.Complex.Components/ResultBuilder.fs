module CQRS.Complex.Components.ResultBuilder

type ResultBuilder() =

    member this.Bind(x, f) =
        match x with
        | Error er -> Error er
        | Ok ok -> f ok

    member this.Return x =
        Ok x
    
    member this.ReturnFrom x = x
        
    member this.Delay(f) =
        f()

let result = ResultBuilder()