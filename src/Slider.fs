[<RequireQualifiedAccess>]
module Slider 
  
open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type ISliderProp = 
     abstract name : string 
     abstract value : obj 
     
let internal createProp name value = 
    { new ISliderProp with 
        member x.name = name 
        member x.value = value }    

// === Slider Specific === 
let Minimum (value: double) = createProp "minimum" value 
let Maximum (value: double) = createProp "maximum" value 
let Value (value: double) = createProp "value" value 
let OnValueChanged (f: ValueChangedEventArgs -> unit) = createProp "valueChanged" f 
// === Slider Specific === 
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements 
let HorizontalLayout (options: LayoutOptions) = createProp "horizontalOptions" (box options)
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
let FormattedText (element: ViewElement) = createProp "formattedText" element
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

let slider (props: ISliderProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.Slider(?minimum = find "minimum", 
        ?maximum = find "maximum",
        ?value = find "value",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?valueChanged = find "valueChanged",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
        ?verticalOptions = find "verticalOptions",
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