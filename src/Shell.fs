[<RequireQualifiedAccess>]
module Shell

open Fabulous.CustomControls
open System
open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IShellProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new IShellProp with
        member x.name = name
        member x.value = value }
    
let Items (items: seq<ViewElement>) = createProp Keys.Items items
let CurrentItem (item: ViewElement) = createProp Keys.CurrentItem item
let FlyoutBackgroundColor (color: Color) = createProp Keys.FlyoutBackgroundColor color
let FlyoutBehavior (behaviour: FlyoutBehavior) = createProp Keys.FlyoutBehaviour behaviour
let FlyoutHeader (header: obj) = createProp Keys.FlyoutHeader header
let FlyoutHeaderBehavior (behaviour: FlyoutHeaderBehavior) = createProp Keys.FlyoutHeaderBehaviour behaviour
let FlyoutIcon (icon: obj) = createProp Keys.FlyoutIcon icon
let FlyoutIsPresented (condition: bool) = createProp Keys.FlyoutIsPresented condition
let Navigated (f: ShellNavigatedEventArgs -> unit) = createProp Keys.Navigated f
let Navigating (f: ShellNavigatingEventArgs -> unit) = createProp Keys.Navigating f
let GoToAsync (value: (ShellNavigationState * AnimationKind)) = createProp Keys.GoToAsync value
let Title (value: string) = createProp Keys.Title value
let BackgroundImage (value: string) = createProp Keys.BackgroundImage value
let Icon (value: string) = createProp Keys.Icon value
let IsBusy (condition: bool) = createProp Keys.IsBusy condition
let Padding (value: double) = createProp Keys.Padding (Thickness(value))
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness
let ToolbarItems (items: ViewElement list) = createProp Keys.ToolbarItems items
let UseSafeArea (condition: bool) = createProp Keys.UseSafeArea condition
let Appearing (f: unit -> unit) = createProp Keys.Appearing f
let Disappearing (f: unit -> unit) = createProp Keys.Disappearing f
let LayoutChanged (f: unit -> unit) = createProp Keys.LayoutChanged f
let BackgroundImageSource (source: obj) = createProp Keys.BackgroundImageSource source
let IconImageSource (source: obj) = createProp Keys.IconImageSource source
let AnchorX (value: double) = createProp Keys.AnchorX value
let AnchorY (value: double) = createProp Keys.AnchorY value
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let HeightRequest (value: double) = createProp Keys.HeightRequest value
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let MinimumHeightRequest (value: double) = createProp Keys.MinimumHeightRequest value
let MinimumWidthRequest (value: double) = createProp Keys.MinimumWidthRequest value
let Opacity (value: double) = createProp Keys.Opacity value
let Rotation (value: double) = createProp Keys.Rotation value
let RotationX (value: double) = createProp Keys.RotationX value
let RotationY (value: double) = createProp Keys.RotationY value
let Scale (value: double) = createProp Keys.Scale value
let TranslationX (value: double) = createProp Keys.TranslationX value
let TranslationY (value: double) = createProp Keys.TranslationY value
let WidthRequest (value: double) = createProp Keys.WidthRequest value
let Resources (values: (string * obj) list) = createProp Keys.Resources values
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let IsTabStop (condition: bool) = createProp Keys.IsTabStop condition
let ScaleX (value: double) = createProp Keys.ScaleX value
let ScaleY (value: double) = createProp Keys.ScaleY value
let TabIndex (index: int) = createProp Keys.TabIndex index
let ChildrenReordered (f: EventArgs -> unit) = createProp Keys.ChildrenReordered f
let MeasureInvalidated (f: EventArgs -> unit) = createProp Keys.MeasureInvalidated f
let Focused (f: FocusEventArgs -> unit) = createProp Keys.Focused f
let SizeChanged (f: SizeChangedEventArgs -> unit) = createProp Keys.SizeChanged f
let Unfocused (f: FocusEventArgs -> unit) = createProp Keys.Unfocused f
let Style (style: Style) = createProp Keys.Style style
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<Shell>) = createProp Keys.Ref viewRef

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

let OnCreated (f: Shell -> unit) = createProp Keys.Created f
        
let inline shell (props: IShellProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes
    
    View.Shell(
        ?items = find Keys.Items,
        ?currentItem = find Keys.CurrentItem,
        ?flyoutBackgroundColor = find Keys.FlyoutBackgroundColor,
        ?flyoutBehavior = find Keys.FlyoutBehaviour,
        ?flyoutHeader = find Keys.FlyoutHeader,
        ?flyoutHeaderBehavior = find Keys.FlyoutHeaderBehaviour,
        ?flyoutIcon = find Keys.FlyoutIcon,
        ?flyoutIsPresented = find Keys.FlyoutIsPresented,
        ?navigated = find Keys.Navigated,
        ?navigating = find Keys.Navigating,
        ?goToAsync = find Keys.GoToAsync,
        ?title = find Keys.Title,
        ?backgroundImage = find Keys.BackgroundImage,
        ?icon = find Keys.Icon,
        ?isBusy = find Keys.IsBusy,
        ?padding = Some (box (Util.applyPaddingSettings attributes)),
        ?toolbarItems = find Keys.ToolbarItems,
        ?useSafeArea = find Keys.UseSafeArea,
        ?appearing = find Keys.Appearing,
        ?disappearing = find Keys.Disappearing,
        ?layoutChanged = find Keys.LayoutChanged,
        ?backgroundImageSource = find Keys.BackgroundImageSource,
        ?iconImageSource = find Keys.IconImageSource,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor,
        ?heightRequest = find Keys.HeightRequest,
        ?inputTransparent = find Keys.InputTransparent,
        ?isEnabled = find Keys.IsEnabled,
        ?isVisible = find Keys.IsVisible,
        ?minimumHeightRequest = find Keys.MinimumHeightRequest,
        ?minimumWidthRequest = find Keys.MinimumWidthRequest,
        ?opacity = find Keys.Opacity,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?scale = find Keys.Scale,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?widthRequest = find Keys.WidthRequest,
        ?resources = find Keys.Resources,
        ?styleSheets = find Keys.StyleSheets,
        ?isTabStop = find Keys.IsTabStop,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
        ?tabIndex = find Keys.TabIndex,
        ?childrenReordered = find Keys.ChildrenReordered,
        ?measureInvalidated = find Keys.MeasureInvalidated,
        ?focused = find Keys.Focused,
        ?sizeChanged = find Keys.SizeChanged,
        ?unfocused = find Keys.Unfocused,
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