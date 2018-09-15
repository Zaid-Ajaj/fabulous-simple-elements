// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace LoginFlow

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

module App = 
    
    type Page = Login | Backoffice 
    
    type AppState = { 
        CurrentPage : Page
        LoginState : Login.State
        BackofficeState : Backoffice.State
    }

    type Msg = 
    | LoginMsg of Login.Msg 
    | BackofficeMsg of Backoffice.Msg 

    let init() = 
        let loginInitState, loginInitCmd = Login.init() 
        let backofficeInitState, backofficeInitCmd = Backoffice.init() 
        let initState = { 
            LoginState = loginInitState
            BackofficeState = backofficeInitState
            CurrentPage = Login
        }

        initState, Cmd.batch [ Cmd.map LoginMsg loginInitCmd; Cmd.map BackofficeMsg backofficeInitCmd ]
    
    let update msg (state: AppState) =  
        match msg with 
        | LoginMsg (Login.Msg.LoginSuccess token) -> 
            let nextBackofficeState = { state.BackofficeState with AuthorizationToken = token }
            let nextState = { state with BackofficeState = nextBackofficeState; 
                                         CurrentPage = Backoffice }
            nextState, Cmd.none
        
        | LoginMsg loginMsg -> 
            let currentLoginState = state.LoginState 
            let nextLoginState, nextLoginCmd = Login.update loginMsg currentLoginState 
            let nextState = { state with LoginState = nextLoginState }
            nextState, Cmd.map LoginMsg nextLoginCmd 
        
        | BackofficeMsg Backoffice.Msg.Logout -> 
            init()
        
        | BackofficeMsg backofficeMsg -> 
            let currentBackofficeState = state.BackofficeState 
            let nextBackofficeState, nextBackofficeCmd = Backoffice.update backofficeMsg currentBackofficeState
            let nextState = { state with BackofficeState = nextBackofficeState }
            nextState, Cmd.map BackofficeMsg nextBackofficeCmd

    let view (state: AppState) dispatch =
        match state.CurrentPage with 
        | Login -> Login.render state.LoginState (LoginMsg >> dispatch)
        | Backoffice -> Backoffice.render state.BackofficeState (BackofficeMsg >> dispatch)

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> Program.runWithDynamicView app

#if DEBUG
    // Uncomment this line to enable live update in debug mode. 
    // See https://fsprojects.github.io/Fabulous/tools.html for further  instructions.
    //
    //do runner.EnableLiveUpdate()
#endif    

    // Uncomment this code to save the application state to app.Properties using Newtonsoft.Json
    // See https://fsprojects.github.io/Fabulous/models.html for further  instructions.
#if APPSAVE
    let modelId = "model"
    override __.OnSleep() = 

        let json = Newtonsoft.Json.JsonConvert.SerializeObject(runner.CurrentModel)
        Console.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override __.OnResume() = 
        Console.WriteLine "OnResume: checking for model in app.Properties"
        try 
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) -> 

                Console.WriteLine("OnResume: restoring model from app.Properties, json = {0}", json)
                let model = Newtonsoft.Json.JsonConvert.DeserializeObject<App.Model>(json)

                Console.WriteLine("OnResume: restoring model from app.Properties, model = {0}", (sprintf "%0A" model))
                runner.SetCurrentModel (model, Cmd.none)

            | _ -> ()
        with ex -> 
            App.program.onError("Error while restoring model found in app.Properties", ex)

    override this.OnStart() = 
        Console.WriteLine "OnStart: using same logic as OnResume()"
        this.OnResume()
#endif


