[<RequireQualifiedAccess>]
module Button 

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open Xamarin.Forms
    
type IButtonProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new IButtonProp with 
        member x.name = name 
        member x.value = value }

let Text (text: string) = createProp "text" (box text)

let OnClick (f: unit -> unit) = createProp "command" (box f)
let HorizontalLayout (options: LayoutOptions) = createProp "horizontalOptions" (box options)
let VerticalLayout (options: LayoutOptions) = createProp "verticalOptions" (box options)
let CanExecute (condition: bool) = createProp "canExecute" condition
let BorderColor (color: Color) = createProp "borderColor" color 
let BorderWidth (width: double) = createProp "borderWidth" width
let CornerRadius (radius: int) = createProp "cornerRadius" radius 
let ContentLayout (layout: Xamarin.Forms.Button.ButtonContentLayout) = createProp "contentLayout" layout

// Common attributes 
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements 
let Margin (value: double) = createProp "margin" (Thickness(value)) 
let MarginLeft (value: double) = createProp "marginLeft" value 
let MarginRight (value: double) = createProp "marginRight" value 
let MarginTop (value: double) = createProp "marginTop" value 
let MarginBottom (value: double) = createProp "marginBottom" value
let MarginThickness (thickness: Thickness) = createProp "margin" thickness 
let FontSize ((FontSize.FontSize size): FontSize.IFontSize) = createProp "fontSize" size 
let FontSizeInPixels (fontSize: double) = createProp "fontSize" fontSize

let IsEnabled (condition: bool) = createProp "isEnabled" condition
let IsVisible (condition: bool) = createProp "isVisible" condition
let TextColor (color: Color) = createProp "textColor" color 
let FontAttributes (attributes: FontAttributes) = createProp "fontAttributes" attributes
let FontFamily (fontFamily: string) = createProp "fontFamily" fontFamily
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
let MinimumHeight (value: double) = createProp "minimumHeightRequest" value 
let MinimumWidth (value: double) = createProp "minimumWidthRequest" value 
let Width (value: double) = createProp "widthRequest" value
let Style (style: Style) = createProp "style" style 
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let Ref (viewRef: ViewRef<Button>) = createProp "ref" viewRef 
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition 

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

let OnCreated (f: Button -> unit) = createProp "created" f

let inline button (props: IButtonProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.Button(?text = find "text",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?command = find "command", 
        ?created = find "created",
        ?canExecute = find "canExecute",
        ?isEnabled = find "isEnabled",
        ?fontSize = find "fontSize",
        ?isVisible = find "isVisible",
        ?ref = find "ref",
        ?borderColor = find "borderColor", 
        ?borderWidth = find "borderWidth",
        ?cornerRadius = find "cornerRadius",
        ?textColor = find "textColor",
        ?verticalOptions = find "verticalOptions",
        ?opacity = find "opacity",
        ?heightRequest = find "heightRequest",
        ?widthRequest = find "widthRequest",
        ?contentLayout = find "contentLayout",
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
        ?fontAttributes = find "fontAttributes",
        ?classId = find "classId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeightRequest = find "minimumHeightRequest",
        ?minimumWidthRequest = find "minimumHeightRequest",
        ?fontFamily = find "fontFamily",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent",
        ?horizontalOptions = find "horizontalOptions")
    |> fun element ->  Util.applyGridSettings element attributes  
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes 