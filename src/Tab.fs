[<RequireQualifiedAccess>]
module Tab

open Fabulous.DynamicViews
open Xamarin.Forms

type ITabProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new ITabProp with
        member x.name = name
        member x.value = value }
    
let CurrentItem (item: ViewElement) = createProp Keys.CurrentItem item
let Items (items: seq<ViewElement>) = createProp Keys.Items items
let FlyoutDisplayOptions (option: FlyoutDisplayOptions) = createProp Keys.FlyoutDisplayOptions option
let FlyoutIcon (icon: obj) = createProp Keys.FlyoutIcon icon
let Icon (value: string) = createProp Keys.Icon value
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsTabStop (condition: bool) = createProp Keys.IsTabStop condition
let Route (value: string) = createProp Keys.Route value
let TabIndex (index: int) = createProp Keys.TabIndex index
let Title (value: string) = createProp Keys.Title value
let IsChecked (condition: bool) = createProp Keys.IsChecked condition
let Style (style: Style) = createProp Keys.Style style
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<Tab>) = createProp Keys.Ref viewRef

let GridRow (n: int) = createProp Keys.GridRow n
let GridColumn (n: int) = createProp Keys.GridColumn n
let GridRowSpan (n: int) = createProp Keys.GridRowSpan n
let GridColumnSpan (n: int) = createProp Keys.GridColumnSpan n
let FlexOrder (n: int) = createProp Keys.FlexOrder n
let FlexGrow (value: double) = createProp Keys.FlexGrow value
let FlexShrink (value: double) = createProp Keys.FlexShrink value
let FlexAignSelf (value: FlexAlignSelf) = createProp Keys.FlexAlignSelf value
let FlexLayoutDirection (value: FlexDirection) = createProp Keys.FlexLayoutDirection value
let FlexBasis (value: FlexBasis) = createProp Keys.FlexBasis value
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value
let XConstraint (value: Constraint) = createProp Keys.XConstraint value
let YConstraint (value: Constraint) = createProp Keys.YConstraint value

let OnCreated (f: Tab -> unit) = createProp Keys.Created f

let tab (props: ITabProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes

    View.Tab(
        ?currentItem = find Keys.CurrentItem,
        ?items = find Keys.Items,
        ?flyoutDisplayOptions = find Keys.FlyoutDisplayOptions,
        ?flyoutIcon = find Keys.FlyoutIcon,
        ?icon = find Keys.Icon,
        ?isEnabled = find Keys.IsEnabled,
        ?isTabStop = find Keys.IsTabStop,
        ?route = find Keys.Route,
        ?tabIndex = find Keys.TabIndex,
        ?title = find Keys.Title,
        ?isChecked = find Keys.IsChecked,
        ?style = find Keys.Style,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref
    )
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes 