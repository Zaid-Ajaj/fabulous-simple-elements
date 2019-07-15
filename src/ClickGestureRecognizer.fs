[<RequireQualifiedAccess>]
module ClickGestureRecognizer

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms 

type IClickGestureRecognizerProp = 
    abstract Name : string 
    abstract Value : obj 

let createProp name value = 
    { new IClickGestureRecognizerProp with
        member x.Name = name
        member x.Value = value } 

let OnClicked (handler: unit -> unit) = createProp Keys.OnClicked handler
let ClicksRequired (clicks: int) = createProp Keys.ClicksRequired clicks 
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Created (handler: ClickGestureRecognizer -> unit) = createProp Keys.Created handler
let Ref (ref: ViewRef<ClickGestureRecognizer>) = createProp Keys.Ref ref 
let Buttons (buttonsMask : ButtonsMask) = createProp Keys.ButtonsMask buttonsMask

let inline clickGestureRecognizer (props: IClickGestureRecognizerProp list) =   
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.ClickGestureRecognizer(?command = find Keys.IsPinching,
        ?numberOfClicksRequired = find Keys.ClicksRequired,
        ?buttons = find Keys.ButtonsMask,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId, 
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref)