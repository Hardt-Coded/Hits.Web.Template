namespace HitsWebAppTemplate.Client.Pages

open Feliz
open Feliz.DaisyUI
open Elmish
open Feliz.UseElmish
open HitsWebAppTemplate.Client.Server


module Home =

    type State = {
        Message : string
    }


    type Msg =
        | AskForMessage of bool
        | MessageReceived of ServerResult<string>


    let init () = { Message = "Click on one of the buttons!" }, Cmd.none


    let update (msg:Msg) (model:State) : State * Cmd<Msg> =
        match msg with
        | AskForMessage success -> model, Cmd.OfAsync.eitherAsResult (fun _ -> (homeService "invalid").GetMessage  success) MessageReceived
        | MessageReceived (Ok msg) -> { model with Message = $"Got success response: {msg}" }, Cmd.none
        | MessageReceived (Error error) -> { model with Message = $"Got server error: {error}" }, Cmd.none


    [<ReactComponent>]
    let HomeView () =
        let state, dispatch = React.useElmish(init, update, [| |])

        React.fragment [
            Html.h1 "Home"
            Html.div state.Message
            Daisy.join [
                Daisy.button.button [
                    button.primary
                    prop.text "Click me for success"
                    prop.onClick (fun _ -> true |> AskForMessage |> dispatch)
                ]
                Daisy.button.button [
                    button.secondary
                    prop.text "Click me for error"
                    prop.onClick (fun _ -> false |> AskForMessage |> dispatch)
                ]
            ]
        ]

