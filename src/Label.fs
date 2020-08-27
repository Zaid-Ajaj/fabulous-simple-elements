[<RequireQualifiedAccess>]
module Label  
    
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type ILabelProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new ILabelProp with 
        member x.name = name 
        member x.value = value }    

// === Label Specific === 
let Text (text: string) = createProp Keys.Text text 
let LineBreakMode (mode: LineBreakMode) = createProp Keys.LineBreakMode mode

let TextColor (color: Color) = createProp Keys.TextColor color 
let FontSize (size: FontSize.Value) = createProp Keys.FontSize size 
let FontAttributes (attributes: FontAttributes) = createProp Keys.FontAttributes attributes
let FontFamily (fontFamily: string) = createProp Keys.FontFamily fontFamily
// === Label Specific ===

// Common attributes
let HorizontalTextAlignment (alignment: TextAlignment) = createProp Keys.HorizontalTextAlignment alignment
let VerticalTextAlignment (alignment: TextAlignment) = createProp Keys.VerticalTextAlignment alignment
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements 
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout (box options)
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout (box options)
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let AnchorY (value: double) = createProp Keys.AnchorY value 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let AnchorX (value: double) = createProp Keys.AnchorY value 
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
let Ref (viewRef: ViewRef<Label>) = createProp Keys.Ref viewRef  
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition 
let FormattedText (element: ViewElement) = createProp Keys.FormattedText element
let TextDecorations (decorations: TextDecorations) = createProp Keys.TextDecoration decorations 
let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value 
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness 
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
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
let Tag (value: obj) = createProp Keys.Tag value
// ===================================

let OnCreated (f: Label -> unit) = createProp Keys.Created f

let inline label (props: ILabelProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.Label(?text = find Keys.Text,
        ?margin = Some (Util.applyMarginSettings attributes),
        ?verticalTextAlignment = find Keys.VerticalTextAlignment,
        ?horizontalTextAlignment = find Keys.HorizontalTextAlignment,
        ?lineBreakMode = find Keys.LineBreakMode,
        ?formattedText = find Keys.FormattedText,
        ?isEnabled = find Keys.IsEnabled,
        ?isVisible = find Keys.IsVisible,
        ?textColor = find Keys.TextColor,
        ?textDecorations=find Keys.TextDecoration,
        ?ref = find Keys.Ref,
        ?created = find Keys.Created,
        ?verticalOptions = find Keys.VerticalLayout,
        ?opacity = find Keys.Opacity,
        ?height = find Keys.Height,
        ?width = find Keys.Width,
        ?anchorX = find Keys.AnchorX, 
        ?anchorY = find Keys.AnchorY, 
        ?scale = find Keys.Scale, 
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?style = find Keys.Style, 
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
        ?fontSize = find Keys.FontSize,
        ?backgroundColor = find Keys.BackgroundColor,
        ?inputTransparent = find Keys.InputTransparent,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?tag = find Keys.Tag)

    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes
    