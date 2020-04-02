[<RequireQualifiedAccess>]
module FlexLayout

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IFlexLayoutProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IFlexLayoutProp with 
        member x.name = name 
        member x.value = value }

let AlignContent (alignment: FlexAlignContent) = createProp Keys.AlignContent alignment
let AlignItems (alignItems: FlexAlignItems) = createProp Keys.AlignItems alignItems
let Direction (direction: FlexDirection) = createProp Keys.Direction direction 
let Position (position: FlexPosition) = createProp Keys.Position position
let Wrap (wrap: FlexWrap) = createProp Keys.Wrap wrap
let JustifyContent (justify: FlexJustify) = createProp Keys.JustifyContent justify
let Children (children: ViewElement list) = createProp Keys.Children children
let IsClippedToBound (cond: bool) = createProp Keys.IsClippedToBounds cond

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
let Padding (value: double) = createProp Keys.Padding (Thickness(value)) 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 

let VerticalOptions (options: LayoutOptions) = createProp Keys.VerticalLayout options
let HorizontalOptions (options: LayoutOptions) = createProp Keys.HorizontalLayout options

let AnchorX (value: double) = createProp Keys.AnchorX value
let AnchorY (value: double) = createProp Keys.AnchorY value

let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let IsEnabled (cond: bool) = createProp Keys.IsEnabled cond
let IsVisible (cond: bool) = createProp Keys.IsVisible cond
let Opacity (value: double) = createProp Keys.Opacity value

let Height (value: double) = createProp Keys.Height value 
let Width (value: double) = createProp Keys.Width value
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value 
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value
let Style (style: Style) = createProp Keys.Style style 
let Styles (styles: Style list) = createProp Keys.Styles styles
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let OnCreated (f: FlexLayout -> unit) = createProp Keys.Created f
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements
let StyleClass (value: obj) = createProp Keys.StyleClass value
let IsTabStop (cond: bool) = createProp Keys.IsTabStop cond
let TabIndex (index: int) = createProp Keys.TabIndex index
let Ref (viewRef: ViewRef<FlexLayout>) = createProp Keys.Ref viewRef
let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value

let inline flexLayout (props: IFlexLayoutProp list) = 
    let attributes = 
        props  
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.FlexLayout(?alignContent=find Keys.AlignContent,
        ?alignItems=find Keys.AlignItems,
        ?direction=find Keys.Direction,
        ?position=find Keys.Position,
        ?wrap=find Keys.Wrap,
        ?justifyContent=find Keys.JustifyContent,
        ?children=find Keys.Children,
        ?isClippedToBounds=find Keys.IsClippedToBounds,
        ?padding = Some (Util.applyPaddingSettings attributes),
        ?margin = Some (Util.applyMarginSettings attributes),
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        ?gestureRecognizers = find Keys.GestureRecognizers,
        ?anchorX=find Keys.AnchorX,
        ?anchorY=find Keys.AnchorY,
        ?backgroundColor=find Keys.BackgroundColor,
        ?rotation=find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?isEnabled = find Keys.IsEnabled,
        ?isVisible = find Keys.IsVisible,
        ?height = find Keys.Height,
        ?width = find Keys.Width,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?inputTransparent = find Keys.InputTransparent,
        ?scale = find Keys.Scale,
        ?style = find Keys.Style,
        ?styleClasses = find Keys.StyleClass,
        ?styleSheets = find Keys.StyleSheets,
        ?automationId= find Keys.AutomationId,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?isTabStop = find Keys.IsTabStop,
        ?tabIndex = find Keys.TabIndex,
        ?ref = find Keys.Ref,
        ?created = find Keys.Created)

    |> fun element -> Util.applyGridSettings element attributes 
    |> fun element -> Util.applyFlexLayoutSettings element attributes 
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes