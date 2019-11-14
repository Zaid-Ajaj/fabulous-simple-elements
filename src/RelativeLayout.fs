[<RequireQualifiedAccess>]
module RelativeLayout 

open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open System.Data
open Util
open Fabulous
open Fabulous.XamarinForms

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
let Height (value: double) = createProp "height" value
let Width (value: double) = createProp "width" value 
let MinimumHeight (value: double) = createProp "minimumHeight" value 
let MinimumWidth (value: double) = createProp "minimumWidth" value 
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
let Ref(ref: ViewRef<RelativeLayout> -> unit) = createProp "ref" ref
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
let Padding (value: double) = createProp Keys.Padding (Thickness(value)) 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 
let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value 
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness  
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
// ===================================

let inline relativeLayout (props: IRelativeLayoutProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.RelativeLayout(?children = find "children",
        ?padding = Some (Util.applyPaddingSettings attributes), 
        ?margin = Some (Util.applyMarginSettings attributes),
        ?ref = find "ref",
        ?created = find "created",
        ?verticalOptions = find "verticalOptions",
        ?isClippedToBounds = find "isClippedToBounds",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
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
        ?styleId = find "styleId",
        ?gestureRecognizers = find "gestureRecognizers",
        ?classId = find "classId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeight = find "minimumHeight",
        ?minimumWidth = find "minimumHeight",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent",
        ?horizontalOptions = find "horizontalOptions")
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes