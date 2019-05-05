[<RequireQualifiedAccess>]
module Picker

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IPickerProp =
    abstract name : string
    abstract value : obj

let internal createProp name value =
    { new IPickerProp with
        member x.name = name
        member x.value = value }

let ItemsSource (items: seq<'T>) = createProp Keys.ItemsSource items
let SelectedIndex (index: int) = createProp Keys.SelectedIndex index
let Title (value: string) = createProp Keys.Title value
let TextColor (color: Color)= createProp Keys.TextColor color
let OnIndexChanged (f: (int * 'T option) -> unit) = createProp Keys.SelectedIndexChanged f
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout options
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout options
let Margin (value: double) = createProp Keys.Margin (Thickness(value))
let MarginLeft (value: double) = createProp Keys.MarginLeft value
let MarginRight (value: double) = createProp Keys.MarginRight value
let MarginTop (value: double) = createProp Keys.MarginTop value
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements
let AnchorX (value: double) = createProp Keys.AnchorX value
let AnchorY (value: double) = createProp Keys.AnchorY value
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let HeightRequest (value: double) = createProp Keys.HeightRequest value
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let MinimumHeight (value: double) = createProp Keys.MinimumHeightRequest value
let MinimumWidth (value: double) = createProp Keys.MinimumWidthRequest value
let Opacity (value: double) = createProp Keys.Opacity value
let Rotation (value: double) = createProp Keys.Rotation value
let RotationX (value: double) = createProp Keys.RotationX value
let RotationY (value: double) = createProp Keys.RotationY value
let Scale (value: double) = createProp Keys.Scale value
let Style (style: Style) = createProp Keys.Style style
let TranslationX (value: double) = createProp Keys.TranslationX value
let TranslationY (value: double) = createProp Keys.TranslationY value
let WidthRequest (value: double) = createProp Keys.WidthRequest value
let Resources (values: (string * obj) list) = createProp Keys.Resources values
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let ScaleX (value: double) = createProp Keys.ScaleX value
let ScaleY (value: double) = createProp Keys.ScaleY value
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<Picker>) = createProp Keys.Ref viewRef
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

let OnCreated (f: Picker -> unit) = createProp Keys.Created f

let inline picker (props: IPickerProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList

    let find name = Util.tryFind name attributes

    View.Picker(
        ?itemsSource = find Keys.ItemsSource,
        ?selectedIndex = find Keys.SelectedIndex,
        ?title = find Keys.Title,
        ?textColor = find Keys.TextColor,
        ?selectedIndexChanged = find Keys.SelectedIndexChanged,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?gestureRecognizers = find Keys.GestureRecognizers,
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
        ?style = find Keys.Style,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?widthRequest = find Keys.WidthRequest,
        ?resources = find Keys.Resources,
        ?styleSheets = find Keys.StyleSheets,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
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