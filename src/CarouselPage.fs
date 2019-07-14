[<RequireQualifiedAccess>]
module CarouselPage

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type ICarouselPageProp = 
    abstract name : string 
    abstract value : obj


let createProp name value = 
    { new ICarouselPageProp with    
        member x.name = name
        member x.value = value }

let Children (children: ViewElement list) = createProp Keys.Children children
let BarBackgroundColor (color: Color) = createProp Keys.BarBackgroundColor color 
let BarTextColor (color: Color) = createProp Keys.BarTextColor color
let CurrentPage (pageIndex: int) = createProp Keys.CurrentPage pageIndex
let OnCurrentPageChanged (pageIndexChanged : int option -> unit) = createProp Keys.OnCurrentPageChanged pageIndexChanged
let Title (title: string) = createProp Keys.Title title
let BackgroundImage (source: string) = createProp Keys.BackgroundImage source
let Icon (source: string) = createProp Keys.Icon source
let IsBusy (isBusy: bool) = createProp  Keys.IsBusy isBusy

// <Common Padding Props>
let Padding (value: double) = createProp Keys.Padding value 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 
// </Common Padding Props>

let ToolbarItems (items: ViewElement list) = createProp Keys.ToolbarItems items
let UseSafeArea (useSafeArea: bool) = createProp Keys.UseSafeArea useSafeArea
let OnAppearing (onAppearing: unit -> unit) = createProp Keys.Appearing onAppearing
let OnDisappearing (onDisappearing: unit -> unit) = createProp Keys.Disappearing onDisappearing
let OnLayoutChanged (layoutChanged : unit -> unit) = createProp Keys.LayoutChanged layoutChanged

let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let AnchorY (value: double) = createProp Keys.AnchorY value 
let AnchorX (value: double) = createProp Keys.AnchorX value 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let Scale (value: double) = createProp Keys.Scale value 
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value 
let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value
let Opacity (value: double) = createProp Keys.Opacity value
let Height (value: double) = createProp Keys.HeightRequest value
let Width (value: double) = createProp Keys.WidthRequest value 
let MinimumHeight (value: double) = createProp Keys.MinimumHeightRequest value 
let MinimumWidth (value: double) = createProp Keys.MinimumWidthRequest value 
let Style (style: Style) = createProp Keys.Style style 
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition 
let OnCreated (f: NavigationPage -> unit) = createProp Keys.Created f
let IsTabStop (tabStop: bool) = createProp Keys.IsTabStop tabStop
let TabIndex (tabIndex: int) = createProp Keys.TabIndex tabIndex

let OnFocused (focused: FocusEventArgs -> unit) = createProp Keys.Focused focused
let OnUnfocused (unfocused: FocusEventArgs -> unit) = createProp Keys.Unfocused unfocused
let OnChildrenReordered (reordered: System.EventArgs -> unit) = createProp Keys.ChildrenReordered reordered
let OnMeasureInvalidated (measureInvalidated: System.EventArgs -> unit) = createProp Keys.MeasureInvalidated measureInvalidated
let OnSizeChanged (sizeChanged: SizeChangedEventArgs -> unit) = createProp Keys.SizeChanged sizeChanged
let Ref(ref: ViewRef<CarouselPage> -> unit) = createProp Keys.Ref ref

let inline carouselPage (props: ICarouselPageProp list) = 
    
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.CarouselPage(?children = find Keys.Children,
        ?currentPage = find Keys.CurrentPage, 
        ?currentPageChanged = find Keys.OnCurrentPageChanged,
        ?title = find Keys.Title,
        ?backgroundImage = find Keys.BackgroundImage, 
        ?icon = find Keys.Icon, 
        ?isBusy = find Keys.IsBusy,
        ?padding = Some (box (Util.applyPaddingSettings attributes)),
        ?toolbarItems = find Keys.ToolbarItems, 
        ?useSafeArea = find Keys.UseSafeArea,
        ?appearing = find Keys.Appearing,
        ?disappearing = find Keys.Disappearing,
        ?layoutChanged = find Keys.LayoutChanged,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor, 
        ?inputTransparent = find Keys.InputTransparent,
        ?isEnabled = find Keys.IsEnabled, 
        ?isVisible = find Keys.IsVisible,
        ?ref = find Keys.Ref,
        ?heightRequest = find Keys.HeightRequest,
        ?minimumHeightRequest = find Keys.MinimumHeightRequest,
        ?minimumWidthRequest = find Keys.MinimumWidthRequest,
        ?styleId = find Keys.StyleId,
        ?style = find Keys.Style,
        ?classId = find Keys.ClassId,
        ?created = find Keys.Created,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?widthRequest = find Keys.WidthRequest,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?opacity = find Keys.Opacity,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
        ?isTabStop = find Keys.IsTabStop,
        //?sizeChanged = find Keys.SizeChanged,
        ?focused = find Keys.Focused,
        ?unfocused = find Keys.Unfocused
        //?childrenReordered = find Keys.ChildrenReordered,
        //?measureInvalidated = find Keys.MeasureInvalidated
        )