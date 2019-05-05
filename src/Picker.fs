[<RequireQualifiedAccess>]
module Picker

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IPickerProp =
    abstract name : string
    abstract value : obj

let internal createProp name value =
    { new IPickerProp with
        member x.name = name
        member x.value = value }

let ItemsSource (items: seq<'T>) = createProp "itemsSource" items
let SelectedIndex (index: int) = createProp "selectedIndex" index
let Title (value: string) = createProp "title" value
let TextColor (color: Color)= createProp "textColor" color
let OnIndexChanged (f: (int * 'T option) -> unit) = createProp "selectedIndexChanged" f
let HorizontalLayout (options: LayoutOptions) = createProp "horizontalOptions" options
let VerticalLayout (options: LayoutOptions) = createProp "verticalOptions" options
let Margin (value: double) = createProp Keys.Margin (Thickness(value))
let MarginLeft (value: double) = createProp Keys.MarginLeft value
let MarginRight (value: double) = createProp Keys.MarginRight value
let MarginTop (value: double) = createProp Keys.MarginTop value
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness
let GestureRecognizers (elements: ViewElement list) = createProp "gestureRecognizers" elements
let AnchorX (value: double) = createProp "anchorX" value
let AnchorY (value: double) = createProp "anchorY" value
let BackgroundColor (color: Color) = createProp "backgroundColor" color
let HeightRequest (value: double) = createProp "heightRequest" value
let InputTransparent (condition: bool) = createProp "inputTransparent" condition
let IsEnabled (condition: bool) = createProp "isEnabled" condition
let IsVisible (condition: bool) = createProp "isVisible" condition
let MinimumHeight (value: double) = createProp "minimumHeightRequest" value
let MinimumWidth (value: double) = createProp "minimumWidthRequest" value
let Opacity (value: double) = createProp "opacity" value
let Rotation (value: double) = createProp "rotation" value
let RotationX (value: double) = createProp "rotationX" value
let RotationY (value: double) = createProp "rotationY" value
let Scale (value: double) = createProp "scale" value
let Style (style: Style) = createProp "style" style
let TranslationX (value: double) = createProp "translationX" value
let TranslationY (value: double) = createProp "translationY" value
let WidthRequest (value: double) = createProp "widthRequest" value
let Resources (values: (string * obj) list) = createProp "resources" values
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let ScaleX (value: double) = createProp "scaleX" value
let ScaleY (value: double) = createProp "scaleY" value
let ClassId (id: string) = createProp "classId" id
let StyleId (id: string) = createProp "styleId" id
let AutomationId (id: string) = createProp "automationId" id
let Ref (viewRef: ViewRef<Picker>) = createProp "ref" viewRef
let GridRow (n: int) = createProp Keys.GridRow n
let GridColumn (n: int) = createProp Keys.GridColumn n
let GridRowSpan (n: int) = createProp Keys.GridRowSpan n
let GridColumnSpan (n: int) = createProp Keys.GridColumnSpan n
let FlexOrder (n: int) = createProp Keys.FlexOrder n
let FlexGrow (value: double) = createProp Keys.FlexGrow value
let FlexShrink (value: double) = createProp Keys.FlexShrink value
let FlexAignSelf (value: FlexAlignSelf) = createProp Keys.FlexAlignSelf value
let FlexLayoutDirection (value: FlexDirection) = createProp Keys.FlexLayoutDirection value
let FlexBasis (value: FlexBasis) = createProp Keys.FlexBasis value
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value
let XConstraint (value: Constraint) = createProp Keys.XConstraint value
let YConstraint (value: Constraint) = createProp Keys.YConstraint value

let OnCreated (f: Picker -> unit) = createProp "created" f

let inline picker (props: IPickerProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList

    let find name = Util.tryFind name attributes

    View.Picker(
        ?itemsSource = find "itemsSource",
        ?selectedIndex = find "selectedIndex",
        ?title = find "title",
        ?textColor = find "textColor",
        ?selectedIndexChanged = find "selectedIndexChanged",
        ?horizontalOptions = find "horizontalOptions",
        ?verticalOptions = find "verticalOptions",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?gestureRecognizers = find "gestureRecognizers",
        ?anchorX = find "anchorX",
        ?anchorY = find "anchorY",
        ?backgroundColor = find "backgroundColor",
        ?heightRequest = find "heightRequest",
        ?inputTransparent = find "inputTransparent",
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
        ?minimumHeightRequest = find "minimumHeightRequest",
        ?minimumWidthRequest = find "minimumWidthRequest",
        ?opacity = find "opacity",
        ?rotation = find "rotation",
        ?rotationX = find "rotationX",
        ?rotationY = find "rotationY",
        ?scale = find "scale",
        ?style = find "style",
        ?translationX = find "translationX",
        ?translationY = find "translationY",
        ?widthRequest = find "widthRequest",
        ?resources = find "resources",
        ?styleSheets = find "styleSheets",
        ?scaleX = find "scaleX",
        ?scaleY = find "scaleY",
        ?classId = find "classId",
        ?styleId = find "styleId",
        ?automationId = find "automationId",
        ?created = find "created",
        ?ref = find "ref"
    )
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes 