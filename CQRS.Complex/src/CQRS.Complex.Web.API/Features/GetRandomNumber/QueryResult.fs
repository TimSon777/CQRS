namespace CQRS.Complex.Web.API.Features.GetRandomNumber

type QueryResult =
    
    val Number : int
    
    new(number) =
        { Number = number }