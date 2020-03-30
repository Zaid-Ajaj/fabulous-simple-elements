[<RequireQualifiedAccess>]
module CollectionView
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type ICollectionViewProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new ICollectionViewProp with
        member x.name = name
        member x.value = value }

let Items (items: seq<ViewElement>) = createProp Keys.Items items
let SelectedItem (item: obj) = createProp Keys.SelectedItem item
let SelectedItems (items: seq<ViewElement>) = createProp Keys.SelectedItems items
let SelectionMode (mode: SelectionMode) = createProp Keys.SelectionMode mode
let SelectionChanged (f: SelectionChangedEventArgs -> unit) = createProp Keys.SelectionChanged f
let EmptyView (value: obj) = createProp Keys.EmptyView value
let ItemSizingStrategy (strategy: ItemSizingStrategy) = createProp Keys.ItemSizingStrategy strategy
let HorizontalLayout (options: LayoutOptions) = createProp Keys.HorizontalLayout options
let VerticalLayout (options: LayoutOptions) = createProp Keys.VerticalLayout options
let Margin (value: double) = createProp Keys.Margin (Thickness(value))
let MarginLeft (value: double) = createProp Keys.MarginLeft value
let MarginRight (value: double) = createProp Keys.MarginRight value
let MarginTop (value: double) = createProp Keys.MarginTop value
let MarginBottom (value: double) = createProp Keys.MarginBottom value
let MarginThickness (thickness: Thickness) = createProp Keys.Margin thickness
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements
let AnchorX (value: double) = createProp Keys.AnchorX value
let AnchorY (value: double) = createProp Keys.AnchorY value
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let HeightRequest (value: double) = createProp Keys.Height value
let InputTransparent (condition: bool) = createProp Keys.InputTransparent condition
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let IsTabStop (condition: bool) = createProp Keys.IsTabStop condition
let IsVisible (condition: bool) = createProp Keys.IsVisible condition
let MinimumHeight (value: double) = createProp Keys.MinimumHeight value
let MinimumWidth (value: double) = createProp Keys.MinimumWidth value
let Opacity (value: double) = createProp Keys.Opacity value
let Resources (values: (string * obj) list) = createProp Keys.Resources values
let Rotation (value: double) = createProp Keys.Rotation value
let RotationX (value: double) = createProp Keys.RotationX value
let RotationY (value: double) = createProp Keys.RotationY value
let Scale (value: double) = createProp Keys.Scale value
let ScaleX (value: double) = createProp Keys.ScaleX value
let ScaleY (value: double) = createProp Keys.ScaleY value
let TabIndex (index: int) = createProp Keys.TabIndex index
let TranslationX (value: double) = createProp Keys.TranslationX value
let TranslationY (value: double) = createProp Keys.TranslationY value
let WidthRequest (value: double) = createProp Keys.Width value
let StyleSheets (sheets: StyleSheet list) = createProp Keys.StyleSheets sheets
let Focused (f: FocusEventArgs -> unit) = createProp Keys.Focused f
let Unfocused (f: FocusEventArgs -> unit) = createProp Keys.Unfocused f
let Style (style: Style) = createProp Keys.Style style
let ClassId (id: string) = createProp Keys.ClassId id
let StyleId (id: string) = createProp Keys.StyleId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Ref (viewRef: ViewRef<CollectionView>) = createProp Keys.Ref viewRef
let Tag (tag: obj) = createProp Keys.Tag tag
let ItemsLayout (layout: IItemsLayout) = createProp Keys.ItemsLayout layout

let OnCreated (f: CollectionView -> unit) = createProp Keys.Created f

let collectionView (props: ICollectionViewProp list) : ViewElement =
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    
    View.CollectionView(
        ?items = find Keys.Items,
        ?selectedItem = find Keys.SelectedItem,
        ?selectedItems = find Keys.SelectedItems,
        ?selectionMode = find Keys.SelectionMode,
        ?selectionChanged = find Keys.SelectionChanged,
        ?emptyView = find Keys.EmptyView,
        ?itemSizingStrategy = find Keys.ItemSizingStrategy,
        ?horizontalOptions = find Keys.HorizontalLayout,
        ?verticalOptions = find Keys.VerticalLayout,
        ?margin = Some (Util.applyMarginSettings attributes),
        ?gestureRecognizers = find Keys.GestureRecognizers,
        ?anchorX = find Keys.AnchorX,
        ?anchorY = find Keys.AnchorY,
        ?backgroundColor = find Keys.BackgroundColor,
        ?height = find Keys.Height,
        ?inputTransparent = find Keys.InputTransparent,
        ?isEnabled = find Keys.IsEnabled,
        ?isTabStop = find Keys.IsTabStop,
        ?isVisible = find Keys.IsVisible,
        ?minimumHeight = find Keys.MinimumHeight,
        ?minimumWidth = find Keys.MinimumWidth,
        ?opacity = find Keys.Opacity,
        ?resources = find Keys.Resources,
        ?rotation = find Keys.Rotation,
        ?rotationX = find Keys.RotationX,
        ?rotationY = find Keys.RotationY,
        ?scale = find Keys.Scale,
        ?scaleX = find Keys.ScaleX,
        ?scaleY = find Keys.ScaleY,
        ?tabIndex = find Keys.TabIndex,
        ?translationX = find Keys.TranslationX,
        ?translationY = find Keys.TranslationY,
        ?width = find Keys.Width,
        ?styleSheets = find Keys.StyleSheets,
        ?focused = find Keys.Focused,
        ?unfocused = find Keys.Unfocused,
        ?style = find Keys.Style,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref,
        ?tag = find Keys.Tag,
        ?itemsLayout = find Keys.ItemsLayout
    )