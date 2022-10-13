namespace CQRS.Complex.Web.API

#nowarn "20"

open CQRS.Complex.Components
open CQRS.Complex.Web.API.Features.GetRandomNumber
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        (fun _ -> DomainQueryHandler()
                  |> ValidationQueryHandler :> IQueryHandler<Query, QueryResult>)
        |> builder.Services.AddScoped<IQueryHandler<Query, QueryResult>>
        
        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()
        
        let app = builder.Build()

        app.UseHttpsRedirection()
        
        app.UseSwagger()
        app.UseSwaggerUI()
        
        app.MapControllers()

        app.Run()

        exitCode