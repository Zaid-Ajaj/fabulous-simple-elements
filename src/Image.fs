[<RequireQualifiedAccess>]
module Image

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IImageProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IImageProp with 
        member x.name = name 
        member x.value = value }

let Source (src: InputTypes.Image.Value) = createProp Keys.Source src
let Aspect (aspect: Aspect) = createProp Keys.Aspect aspect
let IsOpaque (cond: bool) = createProp Keys.IsOpaque cond
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout (box options)
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout (box options)
let AnchorY (value: double) = createProp Keys.AnchorY value 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let AnchorX (value: double) = createProp Keys.AnchorX value 
let Scale (value: double) = createProp Keys.Scale value
let ScaleX (value: double) = createProp Keys.ScaleX value
let ScaleY (value: double) = createProp Keys.ScaleY value
let Opacity (value: double) = createProp Keys.Opacity value
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value 
let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value

let Height (value: double) = createProp Keys.Height value
let Width (value: double) = createProp Keys.Width value
let Style (style: Style) = createProp Keys.Style style 
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let Ref (viewRef: ViewRef<Button>) = createProp Keys.Ref viewRef 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let IsTapStop (condition: bool) = createProp Keys.IsTabStop condition
let TabIndex (index: int) = createProp Keys.TabIndex index
let Focused (f: FocusEventArgs -> unit) = createProp Keys.Focused f
let Unfocused (f: FocusEventArgs -> unit) = createProp Keys.Unfocused f
let OnCreated (f: Image -> unit) = createProp Keys.Created f
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements

let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
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
let Tag (value: obj) = createProp Keys.Tag value

let inline image (props: IImageProp list) =
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.Image(?source=find Keys.Source,
        ?aspect=find Keys.Aspect,
        ?isOpaque=find Keys.IsOpaque,
        ?horizontalOptions=find Keys.HorizontalLayout,
        ?verticalOptions=find Keys.VerticalLayout,
        ?margin = Some (Util.applyMarginSettings attributes),
        ?gestureRecognizers=find Keys.GestureRecognizers,
        ?anchorX=find Keys.AnchorX,
        ?anchorY=find Keys.AnchorY,
        ?opacity=find Keys.Opacity,
        ?backgroundColor=find Keys.BackgroundColor,
        ?rotation=find Keys.Rotation,
        ?rotationX=find Keys.RotationX,
        ?rotationY=find Keys.RotationY,
        ?translationX=find Keys.TranslationX,
        ?translationY=find Keys.TranslationY,
        ?height=find Keys.Height,
        ?width=find Keys.Width,
        ?style=find Keys.Style,
        ?styleSheets=find Keys.StyleSheets,
        ?styleId=find Keys.StyleId,
        ?classId=find Keys.ClassId,
        ?automationId=find Keys.AutomationId,
        ?ref=find Keys.Ref,
        ?resources=find Keys.Resources,
        ?inputTransparent=find Keys.InputTransparent,
        ?isEnabled=find Keys.IsEnabled,
        ?isVisible=find Keys.IsVisible,
        ?scale=find Keys.Scale,
        ?scaleX=find Keys.ScaleX,
        ?scaleY=find Keys.ScaleY,
        ?isTabStop=find Keys.IsTabStop,
        ?tabIndex=find Keys.TabIndex,
        ?focused=find Keys.Focused,
        ?unfocused=find Keys.Unfocused,
        ?created=find Keys.Created,
        ?tag = find Keys.Tag) 
    |> fun element -> Util.applyGridSettings element attributes 
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes 