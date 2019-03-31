module RelativeLayout 

open Xamarin.Forms
open Fabulous.DynamicViews

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open Fabulous.CustomControls
open System.Data
open Util

type IRelativeLayoutProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new IRelativeLayoutProp with 
        member x.name = name 
        member x.value = value }    

let IsClippedToBounds (condition: bool) = createProp "isClippedToBounds" condition
let VerticalLayout (options: LayoutOptions) = createProp "verticalOptions" options 
let HorizontalLayout (options: LayoutOptions) = createProp "horizontalOptions" options
let Children (children: ViewElement list) = createProp "children" children
let IsEnabled (condition: bool) = createProp "isEnabled" condition
let IsVisible (condition: bool) = createProp "isVisible" condition
let AnchorY (value: double) = createProp "anchorY" value 
let AnchorX (value: double) = createProp "anchorX" value 
let BackgroundColor (color: Color) = createProp "backgroundColor" color
let Scale (value: double) = createProp "scale" value 
let Rotation (value: double) = createProp "rotation" value 
let RotationX (value: double) = createProp "rotationX" value 
let RotationY (value: double) = createProp "rotationY" value 
let TranslationX (value: double) = createProp "translationX" value 
let TranslationY (value: double) = createProp "translationY" value
let Opacity (value: double) = createProp "opacity" value
let Height (value: double) = createProp "heightRequest" value
let Width (value: double) = createProp "widthRequest" value 
let MinimumHeight (value: double) = createProp "minimumHeightRequest" value 
let MinimumWidth (value: double) = createProp "minimumWidthRequest" value 
let Style (style: Style) = createProp "style" style 
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition 
let OnCreated (f: NavigationPage -> unit) = createProp "created" f
let IsTabStop (tabStop: bool) = createProp "isTabStop" tabStop
let TabIndex (tabIndex: int) = createProp "tabIndex" tabIndex
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements
let OnFocused (focused: FocusEventArgs -> unit) = createProp "focused" focused
let OnUnfocused (unfocused: FocusEventArgs -> unit) = createProp "unfocused" unfocused
let OnChildrenReordered (reordered: System.EventArgs -> unit) = createProp "childrenReordered" reordered
let OnMeasureInvalidated (measureInvalidated: System.EventArgs -> unit) = createProp "measureInvalidated" measureInvalidated
let OnSizeChanged (sizeChanged: SizeChangedEventArgs -> unit) = createProp "sizeChanged" sizeChanged
let Ref(ref: ViewRef<RelativeLayout> -> unit) = createProp "ref" ref
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

// === Relative Layout Constraints ===
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
// ===================================

let relativeLayout (props: IRelativeLayoutProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.RelativeLayout(?children = find "children",
        ?padding = Some (box (Util.applyPaddingSettings attributes)), 
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?ref = find "ref",
        ?created = find "created",
        ?verticalOptions = find "verticalOptions",
        ?isClippedToBounds = find "isClippedToBounds",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
        ?opacity = find "opacity",
        ?heightRequest = find "heightRequest",
        ?widthRequest = find "widthRequest",
        ?anchorX = find "anchorX", 
        ?anchorY = find "anchorY", 
        ?scale = find "scale", 
        ?rotation = find "rotation",
        ?rotationX = find "rotationX",
        ?rotationY = find "rotationY",
        ?translationX = find "translationX",
        ?translationY = find "translationY",
        ?style = find "style", 
        ?styleSheets = find "styleSheets",
        ?styleId = find "styleId",
        ?gestureRecognizers = find "gestureRecognizers",
        ?classId = find "classId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeightRequest = find "minimumHeightRequest",
        ?minimumWidthRequest = find "minimumHeightRequest",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent",
        ?horizontalOptions = find "horizontalOptions")
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes