[<RequireQualifiedAccess>]
module ContentPage

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IContentPageProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IContentPageProp with 
        member x.name = name 
        member x.value = value }

let Content (elem: ViewElement) = createProp "content" elem 
let OnSizeAllocated (f: (double * double -> unit)) = createProp "onSizeAllocated" f
let Title (value: string) = createProp "title" value 
let ToolbarItems (elems: ViewElement list) = createProp "toolbarItems" elems 
let IsBusy (condition: bool) = createProp "isBusy" condition
let UseSafeArea (condition: bool) = createProp "useSafeArea" condition 
let OnAppearing (handler: unit -> unit) = createProp "appearing" handler 
let OnDisappearing (handler: unit -> unit) = createProp "disappearing" handler 
let OnLayoutChanged (handler: unit -> unit) = createProp "layoutChanged" handler 
let BackgroundImage (value: string) = createProp "backgroundImage" value
let Padding (value: double) = createProp "padding" value 
let PaddingLeft (value: double) = createProp "paddingLeft" value 
let PaddingRight (value: double) = createProp "paddingRight" value 
let PaddingTop (value: double) = createProp "paddingTop" value 
let PaddingBottom (value: double) = createProp "paddingBottom" value 
let PaddingThickness (thickness: Thickness) = createProp "padding" thickness 
let Icon (name: string) = createProp "icon" name 
// === Grid definitions ===
let GridRow (n: int) = createProp "gridRow" n 
let GridColumn (n: int) = createProp "gridColumn" n 
let GridRowSpan (n: int) = createProp "gridRowSpan" n
let GridColumnSpan (n: int) = createProp "gridColumnSpan" n
// === Grid definitions ===
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
let IsClippedToBounds (condition: bool) = createProp "isClippedToBounds" condition
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
let HasBackButton (condition: bool) = createProp "hasBackButton" condition 
let HasNavigationBar (condition: bool) = createProp "hasNavigationBar" condition 

let contentPage (props: IContentPageProp list) =
    let attributes = 
        props 
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    let elem = View.ContentPage(
        ?content = find "content",
        ?onSizeAllocated = find "onSizeAllocated",
        ?title = find "title",
        ?icon = find "icon", 
        ?isBusy = find "isBusy",
        ?appearing = find "appearing",
        ?disappearing = find "disappearing", 
        ?useSafeArea = find "useSafeArea",
        ?toolbarItems = find "toolbarItems",
        ?layoutChanged = find "layoutChanged",
        ?backgroundImage = find "backgroundImage",
        ?padding = Some (box (Util.applyPaddingSettings attributes)),
        ?isEnabled = find "isEnabled",
        ?isVisible = find "isVisible",
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
        ?classId = find "classId",
        ?automationId = find "automationId",
        ?resources = find "resources",
        ?minimumHeightRequest = find "minimumHeightRequest",
        ?minimumWidthRequest = find "minimumHeightRequest",
        ?backgroundColor = find "backgroundColor",
        ?inputTransparent = find "inputTransparent"
    )
    
    let elemWithGridSettings = Util.applyGridSettings elem attributes

    [ "hasBackButton", Util.tryFind<bool> "hasBackButton" attributes
      "hasNavigationBar", Util.tryFind<bool> "hasNavigationBar" attributes ]
    |> List.choose (function | name, Some value -> Some (name, value) | _ -> None)
    |> List.fold (fun (elem: ViewElement) (propName, propValue) -> 
                  match propName with 
                  | "hasBackButton" -> elem.HasBackButton(propValue)
                  | "hasNavigationBar" -> elem.HasNavigationBar(propValue)
                  | _ -> elem) elemWithGridSettings