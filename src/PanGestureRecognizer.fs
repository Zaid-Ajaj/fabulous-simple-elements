[<RequireQualifiedAccess>]
module PanGestureRecognizer

open Xamarin.Forms
open Fabulous.DynamicViews

type IPanGestureRecognizerProp = 
    abstract Name : string 
    abstract Value : obj 
    
let internal createProp name value = 
    { new IPanGestureRecognizerProp with 
        member x.Name = name 
        member x.Value = value }    

let TouchPoints (value: int) = createProp Keys.TouchPoints value
let PanUpdated (handler: PanUpdatedEventArgs -> unit) = createProp Keys.PanUpdated handler
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Created (handler: PanGestureRecognizer -> unit) = createProp Keys.Created handler
let Ref (ref: ViewRef<PanGestureRecognizer>) = createProp Keys.Ref ref 

let inline panGestureRecognizer (props: IPanGestureRecognizerProp list) =
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    View.PanGestureRecognizer(?touchPoints = find Keys.TouchPoints,
        ?panUpdated = find Keys.PanUpdated,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId, 
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref)