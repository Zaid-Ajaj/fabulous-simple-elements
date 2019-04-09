[<RequireQualifiedAccess>]
module FlexLayout

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IFlexLayoutProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IFlexLayoutProp with 
        member x.name = name 
        member x.value = value }

let AlignContent (alignment: FlexAlignContent) = createProp "alignContent" alignment
let AlignItems (alignItems: FlexAlignItems) = createProp "alignItems" alignItems
let Direction (direction: FlexDirection) = createProp "direction" direction 
let Position (position: FlexPosition) = createProp "position" position
let Wrap (wrap: FlexWrap) = createProp "wrap" wrap
let JustifyContent (justify: FlexJustify) = createProp "justifyContent" justify
let Children (children: ViewElement list) = createProp "children" children
let IsClippedToBound (cond: bool) = createProp "isClipped" cond

// === AbsoluteLayout definitions ===
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp "absoluteLayoutFlags" flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp "absoluteLayoutBounds" rectabgleBounds
// === AbsoluteLayout definitions === 

// === Padding definitions ===
let Padding (value: double) = createProp "padding" (Thickness(value)) 
let PaddingLeft (value: double) = createProp "paddingLeft" value 
let PaddingRight (value: double) = createProp "paddingRight" value 
let PaddingTop (value: double) = createProp "paddingTop" value 
let PaddingBottom (value: double) = createProp "paddingBottom" value 
let PaddingThickness (thickness: Thickness) = createProp "padding" thickness 
// === Padding definitions ===

// === Margin settings ===
let Margin (value: double) = createProp "margin" (Thickness(value)) 
let MarginLeft (value: double) = createProp "marginLeft" value 
let MarginRight (value: double) = createProp "marginRight" value 
let MarginTop (value: double) = createProp "marginTop" value 
let MarginBottom (value: double) = createProp "marginBottom" value 
let MarginThickness (thickness: Thickness) = createProp "margin" thickness 
// === Margin settings ===

// === Grid definitions ===
let GridRow (n: int) = createProp "gridRow" n 
let GridColumn (n: int) = createProp "gridColumn" n 
let GridRowSpan (n: int) = createProp "gridRowSpan" n
let GridColumnSpan (n: int) = createProp "gridColumnSpan" n
// === Grid definitions ===

// === FlexLayout definitions ===
let FlexOrder (n: int) = createProp "flexOrder" n
let FlexGrow (value: double) = createProp "flexGrow" value
let FlexShrink (value: double) = createProp "flexShrink" value
let FlexAignSelf (value: FlexAlignSelf) = createProp "flexAlignSelf" value
let FlexLayoutDirection (value: FlexDirection) = createProp "flexLayoutDirection" value
let FlexBasis (value: FlexBasis) = createProp "flexBasis" value
// === FlexLayout definitions ===


let VerticalOptions (options: LayoutOptions) = createProp "verticalOptions" options
let HorizontalOptions (options: LayoutOptions) = createProp "horizontalOptions" options

let AnchorX (value: double) = createProp "anchorX" value
let AnchorY (value: double) = createProp "anchorY" value

let BackgroundColor (color: Color) = createProp "backgroundColor" color
let IsEnabled (cond: bool) = createProp "isEnabled" cond
let IsVisible (cond: bool) = createProp "isVisible" cond
let Opacity (value: double) = createProp "opacity" value

let Height (value: double) = createProp "height" value 
let Width (value: double) = createProp "width" value
let MinimumHeight (value: double) = createProp "minHeight" value
let MinimumWidth (value: double) = createProp "minWidth" value 
let Rotation (value: double) = createProp "rotation" value 
let RotationX (value: double) = createProp "rotationX" value 
let RotationY (value: double) = createProp "rotationY" value
let Style (style: Style) = createProp "style" style 
let Styles (styles: Style list) = createProp "styles" styles
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition
let OnCreated (f: FlexLayout -> unit) = createProp "created" f
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements
let StyleClass (value: obj) = createProp "styleClass" value
let IsTabStop (cond: bool) = createProp "isTabStop" cond
let TabIndex (index: int) = createProp "tabIndex" index
let Ref (viewRef: ViewRef<FlexLayout>) = createProp "ref" viewRef
let TranslationX (value: double) = createProp "translationX" value 
let TranslationY (value: double) = createProp "translationY" value
// === Relative Layout Constraints ===
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
// ===================================
let inline flexLayout (props: IFlexLayoutProp list) = 
    let attributes = 
        props  
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.FlexLayout(?alignContent=find"alignContent",
        ?alignItems=find"alignItems",
        ?direction=find"direction",
        ?position=find"position",
        ?wrap=find"wrap",
        ?justifyContent=find"justifyContent",
        ?children=find"children",
        ?isClippedToBounds=find"isClipped",
        ?padding = Some (box (Util.applyPaddingSettings attributes)),
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?horizontalOptions = find "horizontalOptions",
        ?verticalOptions = find "verticalOptions",
        ?gestureRecognizers = find "gestureRecognizers",
        ?anchorX=find "anchorX",
        ?anchorY=find"anchorY",
        ?backgroundColor=find "backgroundColor",
        ?rotation=find"rotation",
        ?rotationX = find "rotationX",
        ?rotationY = find "rotationY",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
        ?heightRequest = find "height",
        ?widthRequest = find "width",
        ?minimumHeightRequest = find "minHeight",
        ?minimumWidthRequest = find "minWidth",
        ?inputTransparent = find "inputTransparent",
        ?scale = find "scale",
        ?style = find "style",
        ?styleClass = find "styleClass",
        ?styleSheets = find "styleSheets",
        ?automationId= find "automationId",
        ?classId = find "classId",
        ?styleId = find "styleId",
        ?isTabStop = find "isTabStop",
        ?tabIndex = find "tabIndex",
        ?ref = find "ref",
        ?created = find "created")

    |> fun element -> Util.applyGridSettings element attributes 
    |> fun element -> Util.applyFlexLayoutSettings element attributes 
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes