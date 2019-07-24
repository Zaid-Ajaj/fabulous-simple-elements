[<RequireQualifiedAccess>]
module ListView 

open Fabulous
open Fabulous.XamarinForms
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
let SeparatorColor (color: Color) = createProp "separatorColor" color 
let ItemAppearing (handler: int -> unit) = createProp "itemAppearing" handler 
let Ref (viewRef: ViewRef<ListView>) = createProp "ref" viewRef
let ItemDisappearing (handler: int -> unit) = createProp "itemDisappearing" handler 
let ItemSelected (handler: int option -> unit) = createProp "itemSelected" handler
let Refreshing (handler: unit -> unit) = createProp "refreshing" handler

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
let Margin (value: double) = createProp Keys.Margin (Thickness(value)) 
let MarginLeft (value: double) = createProp Keys.MarginLeft value 
let MarginRight (value: double) = createProp Keys.MarginRight value 
let MarginTop (value: double) = createProp Keys.MarginTop value 
let MarginBottom (value: double) = createProp Keys.MarginBottom value 
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness  
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
let SelectionMode (mode: ListViewSelectionMode) = createProp "selectionMode" mode
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
let OnCreated (f: ListView -> unit) = createProp Keys.Created f
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutFlags flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
let inline listView (props: IListViewProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
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
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes
    