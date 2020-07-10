[<RequireQualifiedAccess>]
module WebView

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IWebViewProp = 
    abstract Name : string 
    abstract Value : obj 

let internal createProp name value = 
    { new IWebViewProp with 
        member x.Name = name 
        member x.Value = value }

let Source (source: WebViewSource) = createProp Keys.Source source
let Reload (value: bool) = createProp Keys.Reload value 
let Navigating (handler: WebNavigatingEventArgs -> unit) = createProp Keys.Navigating handler 
let Navigated (handler: WebNavigatedEventArgs -> unit) = createProp Keys.Navigated handler
let ReloadRequested (handler: EventArgs -> unit) = createProp Keys.ReloadRequested handler
let GestureRecognizers (recognizers: ViewElement list) = createProp Keys.GestureRecognizers recognizers 
let AnchorY (value: double) = createProp Keys.AnchorY value
let AnchorX (value: double) = createProp Keys.AnchorX value  
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value 
let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value
let Opacity (value: double) = createProp Keys.Opacity value
let Height (value: double) = createProp Keys.Height value 
let Width (value: double) = createProp Keys.Width value
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value 
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value 
let Style (style: Style) = createProp Keys.Style style 
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let Ref (viewRef: ViewRef<WebView>) = createProp Keys.Ref viewRef 
let OnCreated (handler: WebView -> unit) = createProp Keys.Created handler
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness 
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout options
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout options
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
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags 
let AbsoluteLayoutBounds (rectangleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectangleBounds
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
let Tag (value: obj) = createProp Keys.Tag value

let inline webView (props: IWebViewProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    View.WebView(?source = find Keys.Source, 
        ?reload = find Keys.Reload,
        ?navigated = find Keys.Navigated,
        ?navigating = find Keys.Navigating,
        ?reloadRequested = find Keys.ReloadRequested,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        margin = Util.applyMarginSettings attributes,
        ?width = find Keys.Width,
        ?height = find Keys.Height,
        ?gestureRecognizers = find Keys.GestureRecognizers,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor,
        ?scale = find Keys.Scale, 
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?style = find Keys.Style, 
        ?styleSheets = find Keys.StyleSheets,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId,
        ?automationId = find Keys.AutomationId,
        ?resources = find Keys.Resources,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?inputTransparent = find Keys.InputTransparent,
        ?ref = find Keys.Ref,
        ?created = find Keys.Created,
        ?tag = find Keys.Tag)
    
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    |> fun element -> Util.applyFlexLayoutSettings element attributes 
    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes