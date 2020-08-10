[<RequireQualifiedAccess>]
module Picker

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IPickerProp =
    abstract name : string
    abstract value : obj

let internal createProp name value =
    { new IPickerProp with
        member x.name = name
        member x.value = value }

let Items (items: string list) = createProp Keys.Items items
let SelectedIndex (index: int) = createProp Keys.SelectedIndex index
let Title (value: string) = createProp Keys.Title value
let TextColor (color: Color)= createProp Keys.TextColor color
let OnIndexChanged (f: (int * string option) -> unit) = createProp Keys.SelectedIndexChanged f
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
let HeightRequest (value: double) = createProp Keys.Height value
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value
let Opacity (value: double) = createProp Keys.Opacity value
let Rotation (value: double) = createProp Keys.Rotation value
let RotationX (value: double) = createProp Keys.RotationX value
let RotationY (value: double) = createProp Keys.RotationY value
let Scale (value: double) = createProp Keys.Scale value
let Style (style: Style) = createProp Keys.Style style
let TranslationX (value: double) = createProp Keys.TranslationX value
let TranslationY (value: double) = createProp Keys.TranslationY value
let WidthRequest (value: double) = createProp Keys.Width value
let Resources (values: (string * obj) list) = createProp Keys.Resources values
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let ScaleX (value: double) = createProp Keys.ScaleX value
let ScaleY (value: double) = createProp Keys.ScaleY value
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<Picker>) = createProp Keys.Ref viewRef
let Row (n: int) = createProp Keys.Row n
let Column (n: int) = createProp Keys.Column n
let RowSpan (n: int) = createProp Keys.RowSpan n
let ColumnSpan (n: int) = createProp Keys.ColumnSpan n
let Order (n: int) = createProp Keys.Order n
let Grow (value: double) = createProp Keys.Grow value
let Shrink (value: single) = createProp Keys.Shrink value
let AlignSelf (value: FlexAlignSelf) = createProp Keys.AlignSelf value
let FlexLayoutDirection (value: FlexDirection) = createProp Keys.FlexLayoutDirection value
let Basis (value: FlexBasis) = createProp Keys.Basis value
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags
let AbsoluteLayoutBounds (rectangleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectangleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value
let XConstraint (value: Constraint) = createProp Keys.XConstraint value
let YConstraint (value: Constraint) = createProp Keys.YConstraint value
let Tag (value: obj) = createProp Keys.Tag value

let OnCreated (f: Picker -> unit) = createProp Keys.Created f
let Unfocused (value: FocusEventArgs -> unit) = createProp Keys.Unfocused value

let inline picker (props: IPickerProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList

    let find name = Util.tryFind name attributes

    View.Picker(
        ?items = find Keys.Items,
        ?selectedIndex = find Keys.SelectedIndex,
        ?title = find Keys.Title,
        ?textColor = find Keys.TextColor,
        ?selectedIndexChanged = find Keys.SelectedIndexChanged,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        ?margin = Some (Util.applyMarginSettings attributes),
        ?gestureRecognizers = find Keys.GestureRecognizers,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor,
        ?height = find Keys.Height,
        ?inputTransparent = find Keys.InputTransparent,
        ?isEnabled = find Keys.IsEnabled,
        ?isVisible = find Keys.IsVisible,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?opacity = find Keys.Opacity,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?scale = find Keys.Scale,
        ?style = find Keys.Style,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?width = find Keys.Width,
        ?resources = find Keys.Resources,
        ?styleSheets = find Keys.StyleSheets,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref,
        ?unfocused = find Keys.Unfocused,
        ?tag = find Keys.Tag
    )
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes 