[<RequireQualifiedAccess>]
module ShellContent


open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IShellContentProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new IShellContentProp with
        member x.name = name
        member x.value = value }
    
let Content (item: ViewElement) = createProp Keys.Content item
let MenuItems (items: seq<ViewElement>) = createProp Keys.MenuItems items
let FlyoutIcon (icon: obj) = createProp Keys.FlyoutIcon icon
let Icon (value: InputTypes.Image) = createProp Keys.Icon value
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsTabStop (condition: bool) = createProp Keys.IsTabStop condition
let Route (value: string) = createProp Keys.Route value
let TabIndex (index: int) = createProp Keys.TabIndex index
let Title (value: string) = createProp Keys.Title value
let Style (style: Style) = createProp Keys.Style style
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<ShellContent>) = createProp Keys.Ref viewRef

let OnCreated (f: ShellContent -> unit) = createProp Keys.Created f

let shellContent (props: IShellContentProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes

    View.ShellContent(
        ?content = find Keys.Content,
        ?menuItems = find Keys.MenuItems,
        ?flyoutIcon = find Keys.FlyoutIcon,
        ?icon = find Keys.Icon,
        ?isEnabled = find Keys.IsEnabled,
        ?isTabStop = find Keys.IsTabStop,
        ?route = find Keys.Route,
        ?tabIndex = find Keys.TabIndex,
        ?title = find Keys.Title,
        ?style = find Keys.Style,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref
    )