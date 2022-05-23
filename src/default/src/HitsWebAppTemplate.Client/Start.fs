module HitsWebAppTemplate.Client.Start


open Feliz
open Router
open Elmish
open SharedView
open Feliz
open Feliz.Router
open Feliz.DaisyUI
open Browser


type Msg =
    | UrlChanged of Page

type State = {
    Page : Page
}


let init () =
    let nextPage = Router.currentPath() |> Page.parseFromUrlSegments
    { Page = nextPage }, Cmd.navigatePage nextPage


let update (msg:Msg) (state:State) : State * Cmd<Msg> =
    match msg with
    | UrlChanged page -> { state with Page = page }, Cmd.none


// Routes to different Pages
[<ReactComponent>]
let AppView (state:State) (dispatch:Msg -> unit) =
    
    let navigation =
        Html.div [
            Html.a("Home", Page.Home)
            Html.span " | "
            Html.a("Page1", Page.Page1)
            Html.span " | "
            Html.a("Page2", Page.Page2)
        ]

    let render =
        match state.Page with
        | Page.Home -> Pages.Home.HomeView ()
        | Page.Page1 -> Pages.Page1.Page1View ()
        | Page.Page2 -> Pages.Page2.Page2View ()


    React.router [
        router.pathMode
        router.onUrlChanged (Page.parseFromUrlSegments >> UrlChanged >> dispatch)
        router.children [ navigation; render ]
    ]



    