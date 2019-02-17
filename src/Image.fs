[<RequireQualifiedAccess>]
module Image

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IImageProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IImageProp with 
        member x.name = name 
        member x.value = value }

let Source (src: Xamarin.Forms.ImageSource) = createProp "source" src
let Aspect (aspect: Aspect) = createProp "aspect" aspect
let IsOpaque (cond: bool) = createProp "isOpaque" cond
let HorizontalLayout (options: LayoutOptions) = createProp "horizontalOptions" (box options)
let VerticalLayout (options: LayoutOptions) = createProp "verticalOptions" (box options)
let AnchorY (value: double) = createProp "anchorY" value 
let BackgroundColor (color: Color) = createProp "backgroundColor" color
let AnchorX (value: double) = createProp "anchorX" value 
let Scale (value: double) = createProp "scale" value
let ScaleX (value: double) = createProp "scaleX" value
let ScaleY (value: double) = createProp "scaleY" value
let Opacity (value: double) = createProp "opacity" value
let Rotation (value: double) = createProp "rotation" value 
let RotationX (value: double) = createProp "rotationX" value 
let RotationY (value: double) = createProp "rotationY" value 
let TranslationX (value: double) = createProp "translationX" value 
let TranslationY (value: double) = createProp "translationY" value

let Height (value: double) = createProp "heightRequest" value
let Width (value: double) = createProp "widthRequest" value
let Style (style: Style) = createProp "style" style 
let StyleSheets (sheets: StyleSheet list) = createProp "styleSheets" sheets
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let Ref (viewRef: ViewRef<Button>) = createProp "ref" viewRef 
let AutomationId (id: string) = createProp "automationId" id
let Resources (values: (string * obj) list) = createProp "resources" values 
let InputTransparent (condition: bool) = createProp "inputTransparent" condition
let IsEnabled (condition: bool) = createProp "isEnabled" condition
let IsVisible (condition: bool) = createProp "isVisible" condition
let IsTapStop (condition: bool) = createProp "isTabStop" condition
let TabIndex (index: int) = createProp "tabIndex" index
let Focused (f: FocusEventArgs -> unit) = createProp "focused" f
let Unfocused (f: FocusEventArgs -> unit) = createProp "unfocused" f
let MeasureInvalidated (f: System.EventArgs -> unit) = createProp "measureInvalidated" f
let ChildrenReordered (f: System.EventArgs -> unit) = createProp "childrenReordered" f
let SizeChanged (f: System.EventArgs -> unit) = createProp "sizeChanged" f
let OnCreated (f: Image -> unit) = createProp "created" f

let image (props: IImageProp list) =
    let attributes = 
        props 
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.Image(?source=find"source",
        ?aspect=find"aspect",
        ?isOpaque=find"isOpaque",
        ?horizontalOptions=find"horizontalOptions",
        ?verticalOptions=find"verticalOptions",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
        ?gestureRecognizers=find"gestureRecognizers",
        ?anchorX=find"anchorX",
        ?anchorY=find"anchorY",
        ?opacity=find"opacity",
        ?backgroundColor=find"backgroundColor",
        ?rotation=find"rotation",
        ?rotationX=find"rotationX",
        ?rotationY=find"rotationY",
        ?translationX=find"translationX",
        ?translationY=find"translationY",
        ?heightRequest=find"heightRequest",
        ?widthRequest=find"widthRequest",
        ?style=find"style",
        ?styleSheets=find"styleSheets",
        ?styleId=find"styleId",
        ?classId=find"classId",
        ?automationId=find"automationId",
        ?ref=find"ref",
        ?resources=find"resources",
        ?inputTransparent=find"inputTransparent",
        ?isEnabled=find"isEnabled",
        ?isVisible=find"isVisible",
        ?scale=find"scale",
        ?scaleX=find"scaleX",
        ?scaleY=find"scaleY",
        ?isTabStop=find"isTabStop",
        ?tabIndex=find"tabIndex",
        ?focused=find "focused",
        ?unfocused=find"unfocused",
        ?measureInvalidated=find"measureInvalidated",
        ?childrenReordered=find"childrenReordered",
        ?sizeChanged=find"sizeChanged",
        ?created=find"created") 
    |> fun element -> Util.applyGridSettings element attributes 
    |> fun element -> Util.applyFlexLayoutSettings element attributes