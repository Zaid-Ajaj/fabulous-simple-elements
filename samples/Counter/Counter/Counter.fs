// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Counter

open System.Diagnostics
open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

module App = 
    type State = { Count : int }

    type Msg = 
        | Increment 
        | Decrement 
        | IncrementDelayed 
        | Reset 

    let initModel = { Count = 0 }

    let init () = initModel, Cmd.none

    let timeout n msg = 
        async { 
            do! Async.Sleep n
            return msg
        }

    let update msg state =
        match msg with
        | Increment -> { state with Count = state.Count + 1 }, Cmd.none
        | Decrement -> { state with Count = state.Count - 1 }, Cmd.none
        | IncrementDelayed -> state, Cmd.ofAsyncMsg (timeout 1000 Increment)
        | Reset -> init ()

    let view (model: State) dispatch =
        let createButton text msg = 
            Button.button [
                Button.Text text 
                Button.OnClick (fun _ -> dispatch msg)
            ]
        
        let layout = StackLayout.stackLayout [
            StackLayout.Padding 20.0
            StackLayout.VerticalLayout LayoutOptions.Center
            StackLayout.Children [
                Label.label [ 
                    Label.Text (sprintf "%d" model.Count)
                    Label.FontSize FontSize.Large  
                    Label.HorizontalLayout LayoutOptions.Center
                ]
                createButton "Increment" Increment 
                createButton "Increment Delayed" IncrementDelayed
                createButton "Reset" Reset 
            ]
        ]

        ContentPage.contentPage [ ContentPage.Content layout ]

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
        |> Program.withConsoleTrace
        |> Program.runWithDynamicView app