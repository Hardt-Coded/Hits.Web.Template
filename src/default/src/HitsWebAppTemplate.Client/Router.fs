module HitsWebAppTemplate.Client.Router

open Browser.Types
open Feliz.Router
open Fable.Core.JsInterop

type Page =
    | Home
    | Page1
    | Page2
    

[<RequireQualifiedAccess>]
module Page =
    let defaultPage = Page.Home

    let parseFromUrlSegments = function
        | [ "page1" ] -> Page.Page1
        | [ "page2" ] -> Page.Page2
        | [ ] -> Page.Home
        | _ -> defaultPage

    let noQueryString segments : string list * (string * string) list = segments, []

    let toUrlSegments = function
        | Page.Home ->  [ ]         |> noQueryString
        | Page.Page1 -> [ "page1" ] |> noQueryString
        | Page.Page2 -> [ "page2" ] |> noQueryString


[<RequireQualifiedAccess>]
module Router =
    let goToUrl (e:MouseEvent) =
        e.preventDefault()
        let href : string = !!e.currentTarget?attributes?href?value
        Router.navigatePath href

    let navigatePage (p:Page) = p |> Page.toUrlSegments |> Router.navigatePath


// Helper to trigger a goto  page
[<RequireQualifiedAccess>]
module Cmd =
    let navigatePage (p:Page) = p |> Page.toUrlSegments |> Cmd.navigatePath