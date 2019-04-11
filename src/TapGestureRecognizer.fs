[<RequireQualifiedAccess>]
module TapGestureRecognizer

open Fabulous.DynamicViews
open Xamarin.Forms 
open Xamarin.Forms

type ITapGestureRecognizerProp = 
    abstract Name : string 
    abstract Value : obj 

let createProp name value = 
    { new ITapGestureRecognizerProp with
        member x.Name = name
        member x.Value = value }

let OnTapped (handler: unit -> unit) = createProp Keys.OnTapped handler
let TapsRequired (taps: int) = createProp Keys.NumberOfTapsRequired taps
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Created (handler: TapGestureRecognizer -> unit) = createProp Keys.Created handler
let Ref (ref: ViewRef<TapGestureRecognizer>) = createProp Keys.Ref ref 

let inline tapGestureRecognizer (props: ITapGestureRecognizerProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.TapGestureRecognizer(?command = find Keys.OnTapped,
        ?numberOfTapsRequired = find Keys.NumberOfTapsRequired,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId, 
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref)