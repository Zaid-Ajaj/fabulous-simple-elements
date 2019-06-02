[<RequireQualifiedAccess>]
module TabbedPage 

open Fabulous.DynamicViews
open Fabulous.CustomControls
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type ITabbedPageProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new ITabbedPageProp with 
        member x.name = name 
        member x.value = value }    

let Children (children: ViewElement list) = createProp "children" children
let BarBackgroundColor (color: Color) = createProp "barBackgroundColor" color 
let BarTextColor (color: Color) = createProp "barTextColor" color
let CurrentPage (pageIndex: int) = createProp "currentPage" pageIndex
let OnCurrentPageChanged (pageIndexChanged : int option -> unit) = createProp "currentPageChanged" pageIndexChanged
let Title (title: string) = createProp "title" title
let BackgroundImage (source: string) = createProp "backgroundImage" source
let Icon (source: string) = createProp "icon" source
let IsBusy (isBusy: bool) = createProp "isBusy" isBusy

// <Common Padding Props>
let Padding (value: double) = createProp "padding" value 
let PaddingLeft (value: double) = createProp "paddingLeft" value 
let PaddingRight (value: double) = createProp "paddingRight" value 
let PaddingTop (value: double) = createProp "paddingTop" value 
let PaddingBottom (value: double) = createProp "paddingBottom" value 
let PaddingThickness (thickness: Thickness) = createProp "padding" thickness 
// </Common Padding Props>

let ToolbarItems (items: ViewElement list) = createProp "toolbarItems" items
let UseSafeArea (useSafeArea: bool) = createProp "useSafeArea" useSafeArea
let OnAppearing (onAppearing: unit -> unit) = createProp "appearing" onAppearing
let OnDisappearing (onDisappearing: unit -> unit) = createProp "disappearing" onDisappearing
let OnLayoutChanged (layoutChanged : unit -> unit) = createProp "layoutChanged" layoutChanged

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
let Height (value: double) = createProp "heightRequest" value
let Width (value: double) = createProp "widthRequest" value 
let MinimumHeight (value: double) = createProp "minimumHeightRequest" value 
let MinimumWidth (value: double) = createProp "minimumWidthRequest" value 
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

let OnFocused (focused: FocusEventArgs -> unit) = createProp "focused" focused
let OnUnfocused (unfocused: FocusEventArgs -> unit) = createProp "unfocused" unfocused
let OnChildrenReordered (reordered: System.EventArgs -> unit) = createProp "childrenReordered" reordered
let OnMeasureInvalidated (measureInvalidated: System.EventArgs -> unit) = createProp "measureInvalidated" measureInvalidated
let OnSizeChanged (sizeChanged: SizeChangedEventArgs -> unit) = createProp "sizeChanged" sizeChanged
let Ref(ref: ViewRef<TabbedPage> -> unit) = createProp "ref" ref

let inline tabbedPage (props: ITabbedPageProp list) =
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.TabbedPage(?children=find"children",
        ?barBackgroundColor=find"barBackgroundColor",
        ?barTextColor=find"barTextColor",
        ?currentPage=find"currentPage",
        ?currentPageChanged=find"currentPageChanged",
        ?title=find"title",
        ?backgroundImage=find"backgroundImage",
        ?icon=find"icon",
        ?padding=Some (box (Util.applyPaddingSettings attributes)),
        ?toolbarItems=find"toolbarItems", 
        ?useSafeArea=find"useSafeArea",
        ?appearing=find"appearing",
        ?disappearing=find"disappearing",
        ?layoutChanged=find"layoutChanged",
        ?isEnabled=find"isEnabled",
        ?isVisible=find"isVisible",
        ?anchorX=find"anchorX",
        ?anchorY=find"anchorY",
        ?backgroundColor=find"backgroundColor",
        ?scale=find"scale",
        ?rotation=find"rotation",
        ?rotationX=find"rotationX",
        ?rotationY=find"rotationY",
        ?translationX=find"translationX",
        ?translationY=find"translationY",
        ?opacity=find"opacity",
        ?heightRequest=find"heightRequest",
        ?widthRequest=find"WidthRequest",
        ?minimumHeightRequest=find"minimumHeightRequest",
        ?minimumWidthRequest=find"minimumWidthRequest",
        ?style=find"style",
        ?styleSheets=find"styleSheets",
        ?styleId=find"styleId",
        ?classId=find"classId",
        ?automationId=find"automationId",
        ?resources=find"resources",
        ?inputTransparent=find"inputTransparent",
        ?created=find"created",
        ?isTabStop=find"isTabStop",
        ?tabIndex=find"tabIndex",
        ?focused=find"focused",
        ?unfocused=find"unfocused",
        ?childrenReordered=find"childrenReordered",
        ?measureInvalidated=find"measureInvalidated",
        ?sizeChanged=find"sizeChanged",
        ?ref=find"ref")