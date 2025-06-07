module HitsWebAppTemplate.Client.App

open Elmish
open Elmish.React

#if DEBUG
open Elmish.HMR
#endif

Program.mkProgram Start.init Start.update Start.AppView
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "hits-app"
|> Program.run


// or
// ReactDOM.createRoot(Browser.Dom.document.getElementById("hits-app")).render(Start.AppView())