[<RequireQualifiedAccess>]
module SwipeGestureRecognizer

open Fabulous.DynamicViews
open Xamarin.Forms 

type ISwipeGestureRecognizerProp = 
    abstract Name : string 
    abstract Value : obj 

let createProp name value = 
    { new ISwipeGestureRecognizerProp with
        member x.Name = name
        member x.Value = value }

let OnSwiped (handler: unit -> unit) = createProp Keys.OnSwiped handler
let SwipeDirection (direction: SwipeDirection ) = createProp Keys.SwipeDirection direction
let Threshold (threshold: uint32) = createProp Keys.Threshold threshold 
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Created (handler: SwipeGestureRecognizer -> unit) = createProp Keys.Created handler
let Ref (ref: ViewRef<SwipeGestureRecognizer>) = createProp Keys.Ref ref 

let internal swipeGestureRecognizer (props: ISwipeGestureRecognizerProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.SwipeGestureRecognizer(?command = find Keys.OnSwiped,
        ?direction = find Keys.SwipeDirection,
        ?threshold = find Keys.Threshold, 
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId, 
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref)