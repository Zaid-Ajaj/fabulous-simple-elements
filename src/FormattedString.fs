[<RequireQualifiedAccess>]
module FormattedString
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IFormattedStringProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new IFormattedStringProp with
        member x.name = name
        member x.value = value }
    
let Spans (value: ViewElement list) = createProp Keys.Spans value
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<FormattedString>) = createProp Keys.Ref viewRef

let OnCreated (f: FormattedString -> unit) = createProp Keys.Created f

let formattedString (props: IFormattedStringProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes

    View.FormattedString(
        ?spans = find Keys.Spans,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref
    )