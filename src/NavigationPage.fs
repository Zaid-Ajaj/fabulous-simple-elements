[<RequireQualifiedAccess>]
module NavigationPage 

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type INavigationPageProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new INavigationPageProp with 
        member x.name = name 
        member x.value = value }    

let Pages (elems: ViewElement list) = createProp Keys.Pages elems 
let BarBackgroundColor (color: Color) = createProp Keys.BarBackgroundColor color 
let BarTextColor (color: Color) = createProp Keys.BarTextColor color 
let OnPopped (handler: NavigationEventArgs -> unit) = createProp Keys.OnPopped handler 
let OnPoppedToRoot (handler: NavigationEventArgs -> unit) = createProp Keys.OnPoppedToRoot handler 
let OnPushed (handler: NavigationEventArgs -> unit) = createProp Keys.Pushed handler 
let Ref (viewRef: ViewRef<NavigationPage>) = createProp Keys.Ref viewRef 
let Title (value: string) = createProp Keys.Title value 
let BackgroundImage (value: string) = createProp Keys.BackgroundImage value 
let Icon (value: string) = createProp Keys.Icon value 
let ToolbarItems (elems: ViewElement list) = createProp Keys.ToolbarItems elems 
let IsBusy (condition: bool) = createProp Keys.IsBusy condition
let UseSafeArea (condition: bool) = createProp Keys.UseSafeArea condition 
let OnAppearing (handler: unit -> unit) = createProp Keys.Appearing handler 
let OnDisappearing (handler: unit -> unit) = createProp Keys.Disappearing handler  
let Padding (value: double) = createProp Keys.Padding (Thickness(value)) 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let AnchorY (value: double) = createProp Keys.AnchorY value 
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let AnchorX (value: double) = createProp Keys.AnchorX value 
let Scale (value: double) = createProp Keys.Scale value 
let Rotation (value: double) = createProp Keys.Rotation value 
let RotationX (value: double) = createProp Keys.RotationX value 
let RotationY (value: double) = createProp Keys.RotationY value 
let TranslationX (value: double) = createProp Keys.TranslationX value 
let TranslationY (value: double) = createProp Keys.TranslationY value
let Opacity (value: double) = createProp Keys.Opacity value
let Height (value: double) = createProp Keys.Height value 
let IsClippedToBounds (condition: bool) = createProp Keys.IsClippedToBounds condition
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value 
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value 
let Width (value: double) = createProp Keys.Width value
let Style (style: Style) = createProp Keys.Style style 
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let Resources (values: (string * obj) list) = createProp Keys.Resources values 
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition 
let OnCreated (f: NavigationPage -> unit) = createProp Keys.Created f

let inline navigationPage (props: INavigationPageProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.NavigationPage(?pages = find Keys.Pages,
        ?barBackgroundColor = find Keys.BarBackgroundColor,
        ?created = find Keys.Created,
        ?barTextColor = find Keys.BarTextColor, 
        ?popped = find Keys.OnPopped, 
        ?ref = find Keys.Ref,
        ?title = find Keys.Title,
        ?poppedToRoot = find Keys.OnPoppedToRoot,
        ?pushed = find Keys.Pushed,
        ?toolbarItems = find Keys.ToolbarItems,
        ?backgroundImage = find Keys.BackgroundImage,
        ?isBusy = find Keys.IsBusy, 
        ?useSafeArea = find Keys.UseSafeArea,
        ?appearing = find Keys.Appearing,
        ?disappearing = find Keys.Disappearing,
        ?padding = Some (Util.applyPaddingSettings attributes),
        ?isEnabled = find Keys.IsEnabled,
        ?isVisible = find Keys.IsVisible,
        ?opacity = find Keys.Opacity,
        ?height = find Keys.Height,
        ?width = find Keys.Width,
        ?anchorX = find Keys.AnchorX, 
        ?anchorY = find Keys.AnchorY, 
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
        ?backgroundColor = find Keys.BackgroundColor,
        ?inputTransparent = find Keys.InputTransparent
    )