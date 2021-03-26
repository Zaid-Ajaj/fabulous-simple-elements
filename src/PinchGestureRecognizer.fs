[<RequireQualifiedAccess>]
module PinchGestureRecognizer

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IPinchGestureRecognizerProp =
    abstract Name : string
    abstract Value : obj

let createProp name value =
    { new IPinchGestureRecognizerProp with
        member x.Name = name
        member x.Value = value }

let PinchUpdated (handler: PinchGestureUpdatedEventArgs -> unit) = createProp Keys.PinchUpdated handler
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Created (handler: PinchGestureRecognizer -> unit) = createProp Keys.Created handler
let Ref (ref: ViewRef<PinchGestureRecognizer>) = createProp Keys.Ref ref

let inline pinchGestureRecognizer (props: IPinchGestureRecognizerProp list) =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)
        |> Map.ofList

    let find name = Util.tryFind name attributes

    View.PinchGestureRecognizer(?pinchUpdated = find Keys.PinchUpdated,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref)