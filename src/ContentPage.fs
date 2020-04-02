[<RequireQualifiedAccess>]
module ContentPage

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IContentPageProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IContentPageProp with 
        member x.name = name 
        member x.value = value }

let Content (elem: ViewElement) = createProp Keys.Content elem 
let OnSizeAllocated (f: (double * double -> unit)) = createProp Keys.OnSizeAllocated f
let Title (value: string) = createProp Keys.Title value 
let ToolbarItems (elems: ViewElement list) = createProp Keys.ToolbarItems elems 
let IsBusy (condition: bool) = createProp Keys.IsBusy condition
let UseSafeArea (condition: bool) = createProp Keys.UseSafeArea condition 
let OnAppearing (handler: unit -> unit) = createProp Keys.Appearing handler 
let OnDisappearing (handler: unit -> unit) = createProp Keys.Disappearing handler 
let BackgroundImage (value: string) = createProp Keys.BackgroundImage value
// <Common Padding Props>
let Padding (value: double) = createProp Keys.Padding (Thickness(value)) 
let PaddingLeft (value: double) = createProp Keys.PaddingLeft value 
let PaddingRight (value: double) = createProp Keys.PaddingRight value 
let PaddingTop (value: double) = createProp Keys.PaddingTop value 
let PaddingBottom (value: double) = createProp Keys.PaddingBottom value 
let PaddingThickness (thickness: Thickness) = createProp Keys.Padding thickness 
// </Common Padding Props>
let Ref (viewRef : ViewRef<ContentPage>) = createProp Keys.Ref viewRef 
let Icon (name: string) = createProp Keys.Icon name 
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
let HasBackButton (condition: bool) = createProp Keys.HasBackButton condition 
let HasNavigationBar (condition: bool) = createProp Keys.HasNavigationBar condition 
let OnCreated (f: ContentPage -> unit) = createProp Keys.Created f
let ShellSearchHandler (value: ViewElement) = createProp Keys.ShellSearchHandler value

let inline contentPage (props: IContentPageProp list) : ViewElement =
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    let contentPage = 
        View.ContentPage(?content = find Keys.Content, 
            ?sizeAllocated = find Keys.OnSizeAllocated,
            ?title = find Keys.Title,
            ?icon = find Keys.Icon, 
            ?isBusy = find Keys.IsBusy, 
            ?ref = find Keys.Ref,
            ?appearing = find Keys.Appearing,
            ?disappearing = find Keys.Disappearing, 
            ?useSafeArea = find Keys.UseSafeArea,
            ?toolbarItems = find Keys.ToolbarItems,
            ?created = find Keys.Created, 
            ?backgroundImage = find Keys.BackgroundImage,
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
            ?rotationY = find Keys.RotationX,
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
            ?inputTransparent = find Keys.InputTransparent,
            ?shellSearchHandler = find Keys.ShellSearchHandler)

    [ Keys.HasBackButton, Util.tryFind<bool> Keys.HasBackButton attributes
      Keys.HasNavigationBar, Util.tryFind<bool> Keys.HasNavigationBar attributes ]
    |> List.choose (function | name, Some value -> Some (name, value) | _ -> None)
    |> List.fold (fun (elem: ViewElement) (propName, propValue) -> 
                  match propName with 
                  | Keys.HasBackButton -> elem.HasBackButton(propValue)
                  | Keys.HasNavigationBar -> elem.HasNavigationBar(propValue)
                  | _ -> elem) contentPage