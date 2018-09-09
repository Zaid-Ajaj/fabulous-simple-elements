// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace FifteenPuzzle

open System.Diagnostics
open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

module App = 
    
    type Position = { X: int; Y: int }

    type Slot = Position * string

    type AppState = { Slots : Slot list;  FreePos : Position }

    type Msg = 
    | StartNewGame
    | SelectSlot of Slot

    let random = System.Random()

    let initialState() : AppState = 
        let randomTags = List.sortBy (fun _ -> random.Next()) [1 .. 16]
        // generate slot positions
        [ for x in 0 .. 3 do 
          for y in 0 .. 3 do 
          yield { X = x; Y = y }  ]
        // give each position a random tag, making it a slot
        |> List.mapi (fun i pos -> pos, string (List.item i randomTags))
        |> fun slots -> 
            // find the free slot, it has tag "16"
            let (pos, _) = Seq.find (fun (p, tag) -> tag = "16") slots
            // return initial state
            { Slots = slots; FreePos = pos }

    let update appMessage (state: AppState) = 
        match appMessage with
        | StartNewGame -> initialState()
        | SelectSlot selectedSlot ->
            let (selectedPos, selectedTag) = selectedSlot
            let freePos = state.FreePos
            let dx = abs (freePos.X - selectedPos.X)
            let dy = abs (freePos.Y - selectedPos.Y)
            // check whether or not the selected slot can be replaced with the free slot
            // let canMove (dx = 1 && dy <> 1) || (dx <> 1 && dy = 1) 
            let cantMove = dx + dy > 1
            if cantMove then state 
            else 
            let slots = 
                state.Slots  
                |> List.map (fun (pos, tag) -> 
                    if pos = freePos then pos, selectedTag
                    else (pos, tag))
            { Slots = slots; FreePos = selectedPos } 
    
    let correctSlotsOrder = 
      [ for x in [0 .. 3] do
        for y in [0 .. 3] do
        yield { X = x; Y = y } ]
      |> Seq.mapi (fun i pos -> pos, string (i + 1))

    let inCorrectPosition slot = 
      let (slotPos, slotTag) = slot
      correctSlotsOrder
      |> Seq.find (fun (pos, tag) -> pos = slotPos)
      |> fun (pos, tag) -> tag = slotTag

    let (|GameCleared|StillPlaying|) (state: AppState) = 
       state.Slots
       |> List.filter (fun (pos, tag) -> pos <> state.FreePos)
       |> List.forall inCorrectPosition 
       |> function 
            | true -> GameCleared 
            | false -> StillPlaying 

    let renderSlot (slot: Slot) freePos dispatch = 
      let (slotPos, slotTag) = slot
      if freePos = slotPos then 
        Button.button [ 
            Button.GridRow slotPos.X
            Button.GridColumn slotPos.Y
            Button.CanExecute false
            Button.BackgroundColor Color.Transparent 
        ] 
      elif inCorrectPosition slot then
        Button.button [
            Button.GridRow slotPos.X
            Button.GridColumn slotPos.Y
            Button.Text slotTag 
            Button.BackgroundColor Color.LightGreen
            Button.OnClick (fun _ -> dispatch (SelectSlot slot))
        ] 
      else
        Button.button [
            Button.GridRow slotPos.X
            Button.GridColumn slotPos.Y
            Button.Text slotTag 
            Button.BackgroundColor Color.LightBlue
            Button.OnClick (fun _ -> dispatch (SelectSlot slot))
        ] 

    let render (state: AppState) dispatch =
        let freePos = state.FreePos
        let appLayout = 
            match state with 
            | GameCleared -> 
                StackLayout.stackLayout [
                    StackLayout.Padding 20.0 
                    StackLayout.VerticalLayout LayoutOptions.Center
                    StackLayout.Children [ 
                        Label.label [ 
                            Label.Text "Congrats, you have won!"; 
                            Label.HorizontalTextAlignment TextAlignment.Center
                            Label.MarginLeft 30.0
                            Label.MarginRight 30.0
                            Label.FontSize FontSize.Large 
                        ]
                        Button.button [ 
                            Button.Text "Play Again"
                            Button.OnClick (fun _ -> dispatch StartNewGame) 
                        ]
                    ]
                ]
            
            | StillPlaying -> 
                StackLayout.stackLayout [
                    StackLayout.VerticalLayout LayoutOptions.Center
                    StackLayout.Children [
                        Label.label [ 
                            Label.Text "Fabulous Fifteen Puzzle"
                            Label.HorizontalTextAlignment TextAlignment.Center
                            Label.FontSize FontSize.Large
                            Label.MarginThickness (Thickness(0.0, 10.0, 10.0, 10.0))
                        ]   
                        Grid.grid [
                            Grid.Rows [ for i in 1 .. 4 -> Grid.RowDef Grid.Auto ]
                            Grid.Columns [ for i in 1 .. 4 -> Grid.ColumnDef Grid.Auto ]
                            Grid.MarginLeft 20.0
                            Grid.MarginRight 20.0
                            Grid.Children [ 
                                for slot in state.Slots -> 
                                    renderSlot slot freePos dispatch 
                            ]
                        ]
                        Button.button [ 
                            Button.Text "Start New Game"
                            Button.MarginLeft 30.0
                            Button.MarginRight 30.0
                            Button.MarginTop 10.0
                            Button.OnClick (fun _ -> dispatch StartNewGame) 
                        ]
                    ]
                ]

        View.ContentPage(appLayout)
            
    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkSimple initialState update render

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


