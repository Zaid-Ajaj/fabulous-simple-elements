[<RequireQualifiedAccess>]
module SearchHandler
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ISearchHandlerProp =
    abstract name : string
    abstract value : obj
    
let internal createProp name value =
    { new ISearchHandlerProp with
        member x.name = name
        member x.value = value }
    
let ClearIcon (value: string) = createProp Keys.ClearIcon value
let ClearIconHelpText (value: string) = createProp Keys.ClearIconHelpText value
let ClearIconName (value : string) = createProp Keys.ClearIconName value
let ClearPlaceholderCommand (f: unit -> unit) = createProp Keys.ClearPlaceholderCommand f
let ClearPlaceholderEnabled (condition: bool) = createProp Keys.ClearPlaceholderEnabled condition
let ClearPlaceholderHelpText (value: string) = createProp Keys.ClearPlaceholderHelpText value
let ClearPlaceholderIcon (value: string) = createProp Keys.ClearPlaceholderIcon value
let ClearPlaceholderName (value: string) = createProp Keys.ClearPlaceholderName value
let Command (f: unit -> unit) = createProp Keys.Command f
let IsSearchEnabled (condition: bool) = createProp Keys.IsSearchEnabled condition
let Placeholder (value: string) = createProp Keys.Placeholder value
let Query (value: string) = createProp Keys.Query value
let QueryIcon (value: string) = createProp Keys.QueryIcon value
let QueryIconHelpText (value: string) = createProp Keys.QueryIconHelpText value
let QueryIconName (value: string) = createProp Keys.QueryIconName value
let SearchBoxVisibility (visibility: SearchBoxVisibility) = createProp Keys.SearchBoxVisibility visibility
let ShowResults (condition: bool) = createProp Keys.ShowResults condition
let Items (items: seq<ViewElement>) = createProp Keys.Items items
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let CancelButtonColor (color: Color) = createProp Keys.CancelButtonColor color
let FontAttributes (attributes: FontAttributes) = createProp Keys.FontAttributes attributes
let FontFamily (value: string) = createProp Keys.FontFamily value
let FontSize (size: FontSize.Value) = createProp Keys.FontSize size
let HorizontalTextAlignment (alignment: TextAlignment) = createProp Keys.HorizontalTextAlignment alignment
let Keyboard (keyboard: Keyboard) = createProp Keys.Keyboard keyboard
let PlaceholderColor (color: Color) = createProp Keys.PlaceholderColor color
let TextColor (color: Color) = createProp Keys.TextColor color
let Unfocused (f: unit -> unit) = createProp Keys.Unfocused f
let Focused (f: unit -> unit) = createProp Keys.Focused f
let QueryChanged (f: string * string -> unit) = createProp Keys.QueryChanged f
let QueryConfirmed (f: unit -> unit) = createProp Keys.QueryConfirmed f
let ItemSelected (f: ViewElement option -> unit) = createProp Keys.ItemSelected f

let inline searchHandler (props: ISearchHandlerProp list) : ViewElement =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)
        |> Map.ofList
        
    let find name = Util.tryFind name attributes

    View.SearchHandler(
        ?clearIcon = find Keys.ClearIcon,
        ?clearIconHelpText = find Keys.ClearIconHelpText,
        ?clearIconName = find Keys.ClearIconName,
        ?clearPlaceholderCommand = find Keys.ClearPlaceholderCommand,
        ?clearPlaceholderEnabled = find Keys.ClearPlaceholderEnabled,
        ?clearPlaceholderHelpText = find Keys.ClearPlaceholderHelpText,
        ?clearPlaceholderIcon = find Keys.ClearPlaceholderIcon,
        ?clearPlaceholderName = find Keys.ClearPlaceholderName,
        ?command = find Keys.Command,
        ?isSearchEnabled = find Keys.IsSearchEnabled,
        ?placeholder = find Keys.Placeholder,
        ?query = find Keys.Query,
        ?queryIcon = find Keys.QueryIcon,
        ?queryIconHelpText = find Keys.QueryIconHelpText,
        ?queryIconName = find Keys.QueryIconName,
        ?searchBoxVisibility = find Keys.SearchBoxVisibility,
        ?showsResults = find Keys.ShowResults,
        ?items = find Keys.Items,
        ?backgroundColor = find Keys.BackgroundColor,
        ?cancelButtonColor = find Keys.CancelButtonColor,
        ?fontAttributes = find Keys.FontAttributes,
        ?fontFamily = find Keys.FontFamily,
        ?fontSize = find Keys.FontSize,
        ?horizontalTextAlignment = find Keys.HorizontalTextAlignment,
        ?keyboard = find Keys.Keyboard,
        ?placeholderColor = find Keys.PlaceholderColor,
        ?textColor = find Keys.TextColor,
        ?unfocused = find Keys.Unfocused,
        ?focused = find Keys.Focused,
        ?queryChanged = find Keys.QueryChanged,
        ?queryConfirmed = find Keys.QueryConfirmed,
        ?itemSelected = find Keys.ItemSelected
    )