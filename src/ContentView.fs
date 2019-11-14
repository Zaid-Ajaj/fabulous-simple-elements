[<RequireQualifiedAccess>]
module ContentView

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IContentViewProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new IContentViewProp with
        member x.name = name
        member x.value = value }
    
let Content (value: ViewElement) = createProp Keys.Content value
let IsClippedToBounds (condition: bool) = createProp Keys.IsClippedToBounds condition
let Padding (value: double) = createProp Keys.Padding (Thickness(value)) 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout options
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout options
let Margin (value: double) = createProp Keys.Margin (Thickness(value))
let MarginLeft (value: double) = createProp Keys.MarginLeft value
let MarginRight (value: double) = createProp Keys.MarginRight value
let MarginTop (value: double) = createProp Keys.MarginTop value
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements
let AnchorX (value: double) = createProp Keys.AnchorX value
let AnchorY (value: double) = createProp Keys.AnchorY value
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let FlexLayoutDirection (value: FlexDirection) = createProp Keys.FlexLayoutDirection value
let HeightRequest (value: double) = createProp Keys.Height value
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value
let Opacity (value: double) = createProp Keys.Opacity value
let Resources (values: (string * obj) list) = createProp Keys.Resources values
let Rotation (value: double) = createProp Keys.Rotation value
let RotationX (value: double) = createProp Keys.RotationX value
let RotationY (value: double) = createProp Keys.RotationY value
let Scale (value: double) = createProp Keys.Scale value
let ScaleX (value: double) = createProp Keys.ScaleX value
let ScaleY (value: double) = createProp Keys.ScaleY value
let TranslationX (value: double) = createProp Keys.TranslationX value
let TranslationY (value: double) = createProp Keys.TranslationY value
let WidthRequest (value: double) = createProp Keys.Width value
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let Focused (f: FocusEventArgs -> unit) = createProp Keys.Focused f
let Unfocused (f: FocusEventArgs -> unit) = createProp Keys.Unfocused f
let Style (style: Style) = createProp Keys.Style style
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<ContentView>) = createProp Keys.Ref viewRef
let Tag (tag: obj) = createProp Keys.Tag tag

let OnCreated (f: ContentView -> unit) = createProp Keys.Created f

let inline contentView (props: IContentViewProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes
    
    View.ContentView(
        ?content = find Keys.Content,
        ?isClippedToBounds = find Keys.IsClippedToBounds,
        ?padding = Some (Util.applyPaddingSettings attributes),
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        ?margin = Some (Util.applyMarginSettings attributes),
        ?gestureRecognizers = find Keys.GestureRecognizers,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor,
        ?height = find Keys.Height,
        ?inputTransparent = find Keys.InputTransparent,
        ?isEnabled = find Keys.IsEnabled,
        ?isVisible = find Keys.IsVisible,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?opacity = find Keys.Opacity,
        ?resources = find Keys.Resources,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?scale = find Keys.Scale,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?width = find Keys.Width,
        ?styleSheets = find Keys.StyleSheets,
        ?focused = find Keys.Focused,
        ?unfocused = find Keys.Unfocused,
        ?style = find Keys.Style,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref,
        ?tag = find Keys.Tag
    )