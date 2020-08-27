[<RequireQualifiedAccess>]
module MenuItem
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IMenuItemProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new IMenuItemProp with
        member x.name = name
        member x.value = value }
    
let Text (text: string) = createProp Keys.Text text
let Command (f: unit -> unit) = createProp Keys.Command f
let Icon (value: InputTypes.Image.Value) = createProp Keys.Icon value
let Accelerator (value: string) = createProp Keys.Accelerator value
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<MenuItem>) = createProp Keys.Ref viewRef
let Tag (tag: obj) = createProp Keys.Tag tag

let OnCreated (f: MenuItem -> unit) = createProp Keys.Created f

let inline menuItem (props: IMenuItemProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes
    
    View.MenuItem(
        ?text = find Keys.Text,
        ?command = find Keys.Command,
        ?icon = find Keys.Icon,
        ?accelerator = find Keys.Accelerator,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref,
        ?tag = find Keys.Tag
    )