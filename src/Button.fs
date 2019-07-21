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

let Text (text: string) = createProp "text" text

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

let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness 

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

let Image (source : string) = createProp "image" source
// ===================================

let OnCreated (f: Button -> unit) = createProp Keys.Created f

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
        ?horizontalOptions = find "horizontalOptions",
        ?image = find "image")
    |> fun element ->  Util.applyGridSettings element attributes  
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes 