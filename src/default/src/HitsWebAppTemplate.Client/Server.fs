module HitsWebAppTemplate.Client.Server

open Fable.Core
open Fable.Remoting.Client
open HitsWebAppTemplate.Shared.API
open Fable.SimpleJson
open HitsWebAppTemplate.Shared.Errors

[<Emit("config.baseUrl")>]
let baseUrl : string = jsNative

[<Emit("config.clientUrl")>]
let clientUrl : string = jsNative

let private exnToError (e:exn) : ServerError =
    match e with
    | :? ProxyRequestException as ex ->
        try
            let serverError = Json.parseAs<{| error: ServerError |}>(ex.Response.ResponseBody)
            serverError.error
        with _ -> ServerError.Exception(e.Message)
    | _ -> ServerError.Exception(e.Message)

type ServerResult<'a> = Result<'a,ServerError>

module Cmd =
    open Elmish

    module OfAsync =
        let eitherAsResult fn resultMsg =
            Cmd.OfAsync.either fn () (Result.Ok >> resultMsg) (exnToError >> Result.Error >> resultMsg)

let homeService token =
    Remoting.createApi()
    |> Remoting.withBaseUrl baseUrl
    |> Remoting.withAuthorizationHeader $"Bearer {token}"
    |> Remoting.withRouteBuilder Service.HomeRouteBuilder
    |> Remoting.buildProxy<Service>


let page1Service token =
    Remoting.createApi()
    |> Remoting.withBaseUrl baseUrl
    |> Remoting.withAuthorizationHeader $"Bearer {token}"
    |> Remoting.withRouteBuilder Service.Page1RouteBuilder
    |> Remoting.buildProxy<Service>


let page2Service token =
    Remoting.createApi()
    |> Remoting.withBaseUrl baseUrl
    |> Remoting.withAuthorizationHeader $"Bearer {token}"
    |> Remoting.withRouteBuilder Service.Page2RouteBuilder
    |> Remoting.buildProxy<Service>