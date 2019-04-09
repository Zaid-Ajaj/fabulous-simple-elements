[<RequireQualifiedAccess>]
module ScrollView 

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open Xamarin.Forms
open Xamarin.Forms
open Util

type IScrollViewProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new IScrollViewProp with 
        member x.name = name 
        member x.value = value }   

let Orientation (orientation: ScrollOrientation) = createProp "orientation" orientation
let HorizontalScrollBarVisibility (visibility: ScrollBarVisibility) = createProp "horizontalScrollBarVisibility" visibility 
let VerticalScrollBarVisibility (visibility: ScrollBarVisibility) = createProp "verticalScrollBarVisibility" visibility 

let Margin (value: double) = createProp "margin" (Thickness(value)) 
let MarginLeft (value: double) = createProp "marginLeft" value 
let MarginRight (value: double) = createProp "marginRight" value 
let MarginTop (value: double) = createProp "marginTop" value 
let MarginBottom (value: double) = createProp "marginBottom" value
let MarginThickness (thickness: Thickness) = createProp "margin" thickness 

let Content (elem: ViewElement) = createProp "content" elem 
let BackgroundImage (value: string) = createProp "backgroundImage" value
let Padding (value: double) = createProp "padding" value 
let PaddingLeft (value: double) = createProp "paddingLeft" value 
let PaddingRight (value: double) = createProp "paddingRight" value 
let PaddingTop (value: double) = createProp "paddingTop" value 
let PaddingBottom (value: double) = createProp "paddingBottom" value 
let PaddingThickness (thickness: Thickness) = createProp "padding" thickness 
let Ref (viewRef : ViewRef<ScrollView>) = createProp "ref" viewRef 
let Icon (name: string) = createProp "icon" name 
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

let IsEnabled (condition: bool) = createProp "isEnabled" condition
let IsVisible (condition: bool) = createProp "isVisible" condition
let AnchorY (value: double) = createProp "anchorY" value 
let BackgroundColor (color: Color) = createProp "backgroundColor" color
let AnchorX (value: double) = createProp "anchorX" value 
let Scale (value: double) = createProp "scale" value 
let Rotation (value: double) = createProp "rotation" value 
let RotationX (value: double) = createProp "rotationX" value 
let RotationY (value: double) = createProp "rotationY" value 
let TranslationX (value: double) = createProp "translationX" value 
let TranslationY (value: double) = createProp "translationY" value
let Opacity (value: double) = createProp "opacity" value
let Height (value: double) = createProp "heightRequest" value 
let IsClippedToBounds (condition: bool) = createProp "isClippedToBounds" condition
let MinimumHeight (value: double) = createProp "minimumHeightRequest" value 
let MinimumWidth (value: double) = createProp "minimumWidthRequest" value 
let Width (value: double) = createProp "widthRequest" value
let Style (style: Style) = createProp "style" style 
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition 
let OnCreated (f: ScrollView -> unit) = createProp "created" f
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements
// === AbsoluteLayout definitions ===
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp "absoluteLayoutFlags" flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp "absoluteLayoutBounds" rectabgleBounds
// === AbsoluteLayout definitions === 

// === Relative Layout Constraints ===
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
// ===================================

let inline scrollView (props: IScrollViewProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    View.ScrollView(?content = find "content", 
        ?orientation = find "orientation",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?horizontalScrollBarVisibility = find "horizontalScrollBarVisibility",
        ?verticalScrollBarVisibility = find "verticalScrollBarVisibility",
        ?ref = find "ref",  
        ?gestureRecognizers = find "gestureRecognizers",
        ?created = find "created", 
        ?padding = Some (box (Util.applyPaddingSettings attributes)),
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
        ?classId = find "classId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeightRequest = find "minimumHeightRequest",
        ?minimumWidthRequest = find "minimumHeightRequest",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent"
    )
    
    |> fun elem -> Util.applyGridSettings elem attributes
    |> fun elem -> Util.applyAbsoluteLayoutSettings elem attributes
    |> fun elem -> Util.applyFlexLayoutSettings elem attributes
    |> fun elem -> Util.applyRelativeLayoutConstraints elem attributes