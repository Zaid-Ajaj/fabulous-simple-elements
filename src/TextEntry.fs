[<RequireQualifiedAccess>]
module TextEntry

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.InputTypes
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type ITextEntryProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new ITextEntryProp with 
        member x.name = name 
        member x.value = value }

let Placeholder (value: string) = createProp "placeholder" value 
let Text (value: string) = createProp "text" value 
let IsPassword (condition: bool) = createProp "isPassword" condition
let OnTextChanged (f: TextChangedEventArgs -> unit) = createProp "textChanged" f 
let PlaceholderColor (color: Color) = createProp "placeholderColor" color 
let TextColor (color: Color) = createProp "textColor" color
let OnCompleted (f: string -> unit) = createProp "completed" f
let Ref (viewRef : ViewRef<Entry>) = createProp "ref" viewRef
let HorizontalTextAlignment (alignment: TextAlignment) = createProp "horizontalTextAlignment" alignment
let VerticalTextAlignment (alignment: TextAlignment) = createProp "verticalTextAlignment" alignment
let FontSize (size: FontSize) = createProp "fontSize" size 
let FontAttributes (attributes: FontAttributes) = createProp "fontAttributes" attributes
let FontFamily (fontFamily: string) = createProp "fontFamily" fontFamily
let Keyboard (keyboard: Keyboard) = createProp "keyboard" keyboard
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
let Height (value: double) = createProp "height" value 
let MinimumHeight (value: double) = createProp "minimumHeight" value 
let MinimumWidth (value: double) = createProp "minimumWidth" value 
let Width (value: double) = createProp "width" value
let Style (style: Style) = createProp "style" style 
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition 
let OnCreated (f: Entry -> unit) = createProp "created" f
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value

let inline textEntry (props: ITextEntryProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.Entry(?text = find "text", 
        ?placeholder = find "placeholder",
        ?horizontalTextAlignment = find "horizontalTextAlignment",
        ?fontSize = find "fontSize", 
        ?ref = find "ref",
        ?created = find "created",
        ?fontFamily = find "fontFamily",
        ?fontAttributes = find "fontAttributes",
        ?keyboard = find "keyboard",
        ?margin = Some (Util.applyMarginSettings attributes),
        ?isPassword = find "isPassword",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
        ?textColor = find "textColor",
        ?textChanged = find "textChanged",
        ?verticalOptions = find "verticalOptions",
        ?opacity = find "opacity",
        ?height = find "height",
        ?width = find "width",
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
        ?gestureRecognizers = find "gestureRecognizers",
        ?classId = find "classId",
        ?styleId = find "styleId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeight = find "minimumHeight",
        ?minimumWidth = find "minimumHeight",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent",
        ?horizontalOptions = find "horizontalOptions"
    )
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes