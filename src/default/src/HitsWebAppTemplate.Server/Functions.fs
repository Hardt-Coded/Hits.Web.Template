namespace HitsWebAppTemplate.Server

open Fable.Remoting.Server
open Fable.Remoting.AzureFunctions.Worker
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Extensions.Logging
open HitsWebAppTemplate.Shared.API
open HitsWebAppTemplate.Shared.Errors
open System.Security.Claims
open System.Net.Http
open System.Net.Http.Headers
open System.IdentityModel.Tokens.Jwt



type Functions(log:ILogger<Functions>) =

    let homeService (ctx: FunctionContext) (req:HttpRequestData) = {
        GetMessage = fun success ->
            task {
                let serviceName = "HomeService"
                if success then return $"Hi {serviceName} from Azure Functions!"
                else return ServerError.failwith (ServerError.Exception $"OMG {serviceName}, something terrible happened")
            }
            |> Async.AwaitTask
    }


    let page1Service (ctx: FunctionContext) (req:HttpRequestData) = {
        GetMessage = fun success ->
            task {
                let serviceName = "Page1Service"
                if success then return $"Hi {serviceName} from Azure Functions!"
                else return ServerError.failwith (ServerError.Exception $"OMG {serviceName}, something terrible happened")
            }
            |> Async.AwaitTask
    }


    let page2Service (ctx: FunctionContext) (req:HttpRequestData) = {
        GetMessage = fun success ->
            task {
                let serviceName = "Page2Service"
                if success then return $"Hi {serviceName} from Azure Functions!"
                else return ServerError.failwith (ServerError.Exception $"OMG {serviceName}, something terrible happened")
            }
            |> Async.AwaitTask
    }



    [<Function("HomeService")>]
    member _.Index ([<HttpTrigger(AuthorizationLevel.Anonymous, Route = "home/{*any}")>] req: HttpRequestData, ctx: FunctionContext) =
        Remoting.createApi()
        |> Remoting.withRouteBuilder Service.HomeRouteBuilder
        |> Remoting.fromValue (homeService ctx req)
        |> Remoting.withErrorHandler (Remoting.errorHandler log)
        |> Remoting.buildRequestHandler
        |> HttpResponseData.fromRequestHandler req





    [<Function("Page1Service")>]
    member _.Page1Service ([<HttpTrigger(AuthorizationLevel.Anonymous, Route = "page1/{*any}")>] req: HttpRequestData, ctx: FunctionContext) =
        Remoting.createApi()
        |> Remoting.withRouteBuilder Service.Page1RouteBuilder
        |> Remoting.fromValue (page1Service ctx req)
        |> Remoting.withErrorHandler (Remoting.errorHandler log)
        |> Remoting.buildRequestHandler
        |> HttpResponseData.fromRequestHandler req




    [<Function("Page2Service")>]
    member _.Page2Service ([<HttpTrigger(AuthorizationLevel.Anonymous, Route = "page2/{*any}")>] req: HttpRequestData, ctx: FunctionContext) =
        Remoting.createApi()
        |> Remoting.withRouteBuilder Service.Page2RouteBuilder
        |> Remoting.fromValue (page2Service ctx req)
        |> Remoting.withErrorHandler (Remoting.errorHandler log)
        |> Remoting.buildRequestHandler
        |> HttpResponseData.fromRequestHandler req