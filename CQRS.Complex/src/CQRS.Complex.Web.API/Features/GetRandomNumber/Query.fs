namespace CQRS.Complex.Web.API.Features.GetRandomNumber

open CQRS.Complex.Components

type Query =
    
    val Number : int
    
    new(number) =
        { Number = number }
        
    interface IQuery<QueryResult>