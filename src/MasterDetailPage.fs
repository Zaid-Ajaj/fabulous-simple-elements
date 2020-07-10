[<RequireQualifiedAccess>]
module MasterDetailPage 

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets
open System

type IMasterDetailPageProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new IMasterDetailPageProp with 
        member x.name = name 
        member x.value = value }    

let MasterPage (page: ViewElement) = createProp Keys.Master page 
let DetailPage (page: ViewElement) = createProp Keys.Detail page 
let IsPresented (condition: bool) = createProp Keys.IsPresented condition
let MasterBehaviour (behaviour: MasterBehavior) = createProp Keys.MasterBehaviour behaviour
let IsPrensentedChanged (handler: bool -> unit) = createProp Keys.IsPresentedChanged handler
let Title (title: string) = createProp Keys.Title title 
let Icon (icon: string) = createProp Keys.Icon icon 
let IsBusy (value: bool) = createProp Keys.IsBusy value
let BackgroundImage (image: string) = createProp Keys.BackgroundImage image 

let Ref (viewRef: ViewRef<MasterDetailPage>) = createProp Keys.Ref viewRef
let Padding (value: double) = createProp Keys.Padding value 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 

let UseSafeArea (value: bool) = createProp Keys.UseSafeArea value 
let OnAppearing (handler: unit -> unit) = createProp Keys.Appearing handler
let OnDisappearing (handler: unit -> unit) = createProp Keys.Disappearing handler  
let ToolbarItems (items: ViewElement list) = createProp Keys.ToolbarItems items 
let AnchorX (value: double) = createProp Keys.AnchorX value 
let AnchorY (value: double) = createProp Keys.AnchorY value 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color    
let InputTransparent (value: bool) = createProp Keys.InputTransparent value 
let IsEnabled (value: bool) = createProp Keys.IsEnabled value 
let IsVisible (value: bool) = createProp Keys.IsVisible value 
let Height (value: double) = createProp Keys.Height value 
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value 
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value 
let Style (style: Style) = createProp Keys.Style style 
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let OnCreated (f: NavigationPage -> unit) = createProp Keys.Created f
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value 
let Scale (value: double) = createProp Keys.Scale value
let ScaleX (value: double) = createProp Keys.ScaleX value 
let ScaleY (value: double) = createProp Keys.ScaleY value 

let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value 
let Width (value: double) = createProp Keys.Width value
let Opacity (value: double) = createProp Keys.Opacity value
let IsTabStop (value: bool) = createProp Keys.IsTabStop value
let Focused (handler: FocusEventArgs -> unit) = createProp Keys.Focused handler
let Unfocused (handler: FocusEventArgs -> unit) = createProp Keys.Unfocused handler
let Tag (value: obj) = createProp Keys.Tag value

let inline masterDetailPage(props:IMasterDetailPageProp list) =
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    View.MasterDetailPage(?master=find Keys.Master,
        ?detail = find Keys.Detail,
        ?isPresented = find Keys.IsPresented,
        ?masterBehavior = find Keys.MasterBehaviour,
        ?isPresentedChanged = find Keys.IsPresentedChanged,
        ?title = find Keys.Title,
        ?icon = find Keys.Icon,
        ?isBusy = find Keys.IsBusy,
        ?backgroundImage = find Keys.BackgroundImage,
        ?padding = Some (Util.applyPaddingSettings attributes),
        ?useSafeArea = find Keys.UseSafeArea,
        ?appearing = find Keys.Appearing,
        ?disappearing = find Keys.Disappearing,
        ?toolbarItems = find Keys.ToolbarItems,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor, 
        ?inputTransparent = find Keys.InputTransparent,
        ?isEnabled = find Keys.IsEnabled, 
        ?isVisible = find Keys.IsVisible,
        ?ref = find Keys.Ref,
        ?height = find Keys.Height,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?styleId = find Keys.StyleId,
        ?style = find Keys.Style,
        ?classId = find Keys.ClassId,
        ?created = find Keys.Created,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?width = find Keys.Width,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?opacity = find Keys.Opacity,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
        ?isTabStop = find Keys.IsTabStop,
        ?focused = find Keys.Focused,
        ?unfocused = find Keys.Unfocused,
        ?tag = find Keys.Tag
        )