[<RequireQualifiedAccess>]
module BoxView 

open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open Fabulous
open Fabulous.XamarinForms

type IBoxViewProp = 
    abstract Name : string 
    abstract Value : obj

let createProp name value = 
    { new IBoxViewProp with    
        member x.Name = name
        member x.Value = value }

let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value 
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness 
let GridRow (n: int) = createProp Keys.GridRow n 
let GridColumn (n: int) = createProp Keys.GridColumn n 
let GridRowSpan (n: int) = createProp Keys.GridRowSpan n
let GridColumnSpan (n: int) = createProp Keys.GridColumnSpan n
let FlexOrder (n: int) = createProp Keys.FlexOrder n
let FlexGrow (value: double) = createProp Keys.FlexGrow value
let FlexShrink (value: double) = createProp Keys.FlexShrink value
let FlexAlignSelf (value: FlexAlignSelf) = createProp Keys.FlexAlignSelf value
let FlexLayoutDirection (value: FlexDirection) = createProp Keys.FlexLayoutDirection value
let FlexBasis (value: FlexBasis) = createProp Keys.FlexBasis value
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags 
let AbsoluteLayoutBounds (rectangleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectangleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
let Color (color: Color) = createProp Keys.Color color
let CornerRadius (radius: CornerRadius) = createProp Keys.CornerRadius radius 
let GestureRecognizers (recognizers: ViewElement list) = createProp Keys.GestureRecognizers recognizers
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let AnchorY (value: double) = createProp Keys.AnchorY value 
let AnchorX (value: double) = createProp Keys.AnchorX value 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let Scale (value: double) = createProp Keys.Scale value 
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value 
let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value
let Opacity (value: double) = createProp Keys.Opacity value
let Height (value: double) = createProp Keys.HeightRequest value
let Width (value: double) = createProp Keys.WidthRequest value 
let MinimumHeight (value: double) = createProp Keys.MinimumHeightRequest value 
let MinimumWidth (value: double) = createProp Keys.MinimumWidthRequest value 
let Style (style: Style) = createProp Keys.Style style 
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition 
let OnCreated (f: BoxView -> unit) = createProp Keys.Created f
let IsTabStop (tabStop: bool) = createProp Keys.IsTabStop tabStop
let TabIndex (tabIndex: int) = createProp Keys.TabIndex tabIndex
let OnFocused (focused: FocusEventArgs -> unit) = createProp Keys.Focused focused
let OnUnfocused (unfocused: FocusEventArgs -> unit) = createProp Keys.Unfocused unfocused
let Ref(ref: ViewRef<BoxView> -> unit) = createProp Keys.Ref ref

let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout options
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout options 

let inline boxView (props: IBoxViewProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.BoxView(?color = find Keys.Color, 
        ?cornerRadius = find Keys.CornerRadius,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        margin = Util.applyMarginSettings attributes, 
        ?ref = find Keys.Ref,
        ?created = find Keys.Created,
        ?isEnabled = find Keys.IsEnabled, 
        ?isVisible = find Keys.IsVisible,
        ?opacity = find Keys.Opacity,
        ?heightRequest = find Keys.HeightRequest, 
        ?widthRequest = find Keys.WidthRequest,
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
        ?classId = find Keys.ClassId,
        ?automationId = find Keys.AutomationId,
        ?resources = find Keys.Resources,
        ?minimumHeightRequest = find Keys.MinimumHeightRequest,
        ?minimumWidthRequest = find Keys.MinimumWidthRequest,
        ?backgroundColor = find Keys.BackgroundColor,
        ?inputTransparent = find Keys.InputTransparent,
        ?tabIndex = find Keys.TabIndex)