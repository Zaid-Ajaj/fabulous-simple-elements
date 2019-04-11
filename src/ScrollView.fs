[<RequireQualifiedAccess>]
module ScrollView 

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

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

let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness 

let Content (elem: ViewElement) = createProp "content" elem 
let BackgroundImage (value: string) = createProp "backgroundImage" value
let Padding (value: double) = createProp Keys.Padding (Thickness(value)) 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 
let Ref (viewRef : ViewRef<ScrollView>) = createProp "ref" viewRef 
let Icon (name: string) = createProp "icon" name 
// === Grid definitions ===
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
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
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
        margin = box (Util.applyMarginSettings attributes),
        ?horizontalScrollBarVisibility = find "horizontalScrollBarVisibility",
        ?verticalScrollBarVisibility = find "verticalScrollBarVisibility",
        ?ref = find "ref",  
        ?gestureRecognizers = find "gestureRecognizers",
        ?created = find "created", 
        padding = box (Util.applyPaddingSettings attributes),
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