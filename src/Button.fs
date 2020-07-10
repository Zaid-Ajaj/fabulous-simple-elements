[<RequireQualifiedAccess>]
module Button

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IButtonProp =
    abstract name : string
    abstract value : obj

let internal createProp name value =
    { new IButtonProp with
        member x.name = name
        member x.value = value }

let Text (text: string) = createProp Keys.Text text

let OnClick (f: unit -> unit) = createProp Keys.Command (box f)
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout (box options)
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout (box options)
let CanExecute (condition: bool) = createProp Keys.CanExecute condition
let BorderColor (color: Color) = createProp Keys.BorderColor color
let BorderWidth (width: double) = createProp Keys.BorderWidth width
let CornerRadius (radius: int) = createProp Keys.CornerRadius radius
let ContentLayout (layout: Xamarin.Forms.Button.ButtonContentLayout) = createProp Keys.ContentLayout layout

// Common attributes
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements

let Margin (value: double) = createProp Keys.Margin (Thickness(value))
let MarginLeft (value: double) = createProp Keys.MarginLeft value
let MarginRight (value: double) = createProp Keys.MarginRight value
let MarginTop (value: double) = createProp Keys.MarginTop value
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness

let FontSize (size: FontSize) = createProp Keys.FontSize size

let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let TextColor (color: Color) = createProp Keys.TextColor color
let FontAttributes (attributes: FontAttributes) = createProp Keys.FontAttributes attributes
let FontFamily (fontFamily: string) = createProp Keys.FontFamily fontFamily
let AnchorY (value: double) = createProp Keys.AnchorY value
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let AnchorX (value: double) = createProp Keys.AnchorX value
let Scale (value: double) = createProp Keys.Scale value
let Rotation (value: double) = createProp Keys.Rotation value
let RotationX (value: double) = createProp Keys.RotationX value
let RotationY (value: double) = createProp Keys.RotationY value
let TranslationX (value: double) = createProp Keys.TranslationX value
let TranslationY (value: double) = createProp Keys.TranslationY value
let Opacity (value: double) = createProp Keys.Opacity value
let Height (value: double) = createProp Keys.Height value
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value
let Width (value: double) = createProp Keys.Width value
let Style (style: Style) = createProp Keys.Style style
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id
let Ref (viewRef: ViewRef<Button>) = createProp Keys.Ref viewRef
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition

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

let Image (source : string) = createProp Keys.Image source
let OnCreated (f: Button -> unit) = createProp Keys.Created f

let inline button (props: IButtonProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList

    let find name = Util.tryFind name attributes

    View.Button(?text = find Keys.Text,
        ?margin = Some (Util.applyMarginSettings attributes),
        ?command = find Keys.Command,
        ?created = find Keys.Created,
        ?commandCanExecute = find Keys.CanExecute,
        ?isEnabled = find Keys.IsEnabled,
        ?fontSize = find Keys.FontSize,
        ?isVisible = find Keys.IsVisible,
        ?ref = find Keys.Ref,
        ?borderColor = find Keys.BorderColor,
        ?borderWidth = find Keys.BorderWidth,
        ?cornerRadius = find Keys.CornerRadius,
        ?textColor = find Keys.TextColor,
        ?verticalOptions = find Keys.VerticalLayout,
        ?opacity = find Keys.Opacity,
        ?height = find Keys.Height,
        ?width = find Keys.Width,
        ?contentLayout = find Keys.ContentLayout,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?scale = find Keys.Scale,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?style = find Keys.Scale,
        ?styleSheets = find Keys.StyleSheets,
        ?styleId = find Keys.StyleId,
        ?gestureRecognizers = find Keys.GestureRecognizers,
        ?fontAttributes = find Keys.FontAttributes,
        ?classId = find Keys.ClassId,
        ?automationId = find Keys.AutomationId,
        ?resources = find Keys.Resources,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?fontFamily = find Keys.FontFamily,
        ?backgroundColor = find Keys.BackgroundColor,
        ?inputTransparent = find Keys.InputTransparent,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?image = find Keys.Image,
        ?tag = find Keys.Tag)
    |> fun element ->  Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes