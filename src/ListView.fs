[<RequireQualifiedAccess>]
module ListView 

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IListViewProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new IListViewProp with 
        member x.name = name 
        member x.value = value }    

let Items (elems: seq<ViewElement>) = createProp "items" elems 
let HasUnevenRows (condition: bool) = createProp "hasUnevenRows" condition 
let IsGroupingEnabled (condition: bool) = createProp "isGroupingEnabled" condition 
let IsPullToRefreshEnabled (condition: bool) = createProp "isPullToRefreshEnabled" condition 
let IsRefreshing (condition: bool) = createProp "isRefreshing" condition
let OnRefresh (handler: unit -> unit) = createProp "refreshCommand" handler 
let RowHeight (value: int) = createProp "rowHeight" value 
let SelectedItem (index: int option) = createProp "selectedItem" index
let SeparatorVisibility (visibility: SeparatorVisibility) = createProp "separatorVisibility" visibility
let SeperatorColor (color: Color) = createProp "seperatorColor" color 
let ItemAppearing (handler: int -> unit) = createProp "itemAppearing" handler 
let Ref (viewRef: ViewRef<ListView>) = createProp "ref" viewRef
let ItemDisappearing (handler: int -> unit) = createProp "itemDisappearing" handler 
let ItemSelected (handler: int option -> unit) = createProp "itemSelected" handler
let Refreshing (handler: unit -> unit) = createProp "refreshing" handler
let Margin (value: double) = createProp "margin" (Thickness(value)) 
let MarginLeft (value: double) = createProp "marginLeft" value 
let MarginRight (value: double) = createProp "marginRight" value 
let MarginTop (value: double) = createProp "marginTop" value 
let MarginBottom (value: double) = createProp "marginBottom" value 
let MarginThickness (thickness: Thickness) = createProp "margin" thickness 
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
// === Grid definitions ===
let GridRow (n: int) = createProp "gridRow" n 
let GridColumn (n: int) = createProp "gridColumn" n 
let GridRowSpan (n: int) = createProp "gridRowSpan" n
let GridColumnSpan (n: int) = createProp "gridColumnSpan" n
// === Grid definitions ===

// === FlexLayout definitions ===
let FlexOrder (n: int) = createProp "flexOrder" n
let FlexGrow (value: double) = createProp "flexGrow" value
let FlexShrink (value: double) = createProp "flexShrink" value
let FlexAignSelf (value: FlexAlignSelf) = createProp "flexAlignSelf" value
let FlexLayoutDirection (value: FlexDirection) = createProp "flexLayoutDirection" value
let FlexBasis (value: FlexBasis) = createProp "flexBasis" value
// === FlexLayout definitions ===
let SelectionMode (mode: ListViewSelectionMode) = createProp "selectionMode" mode

let OnCreated (f: ListView -> unit) = createProp "created" f
// === AbsoluteLayout definitions ===
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp "absoluteLayoutFlags" flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp "absoluteLayoutBounds" rectabgleBounds
// === AbsoluteLayout definitions === 
let listView (props: IListViewProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
        
    View.ListView(?items = find "items",
        ?hasUnevenRows = find "hasUnevenRows",
        ?ref = find "ref",
        ?selectionMode=find"selectionMode",
        ?isGroupingEnabled = find "isGroupingEnabled",
        ?isPullToRefreshEnabled = find "isPullToRefreshEnabled",
        ?isRefreshing = find "isRefreshing",
        ?refreshCommand = find "refreshCommand", 
        ?rowHeight = find "rowHeight", 
        ?selectedItem = find "selectedItem",
        ?created = find "created",
        ?separatorVisibility = find "separatorVisibility",
        ?separatorColor = find "separatorColor",
        ?itemAppearing = find "itemAppearing",
        ?itemDisappearing = find "itemDisappearing",
        ?refreshing = find "refreshing",
        ?itemSelected = find "itemSelected",
        ?margin = Some (box (Util.applyMarginSettings attributes)),
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
        ?horizontalOptions = find "horizontalOptions"
    )

    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes 
    