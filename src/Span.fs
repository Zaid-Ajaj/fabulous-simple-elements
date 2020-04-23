[<RequireQualifiedAccess>]
module Span

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ISpanProp =
    abstract Name : string
    abstract Value : obj

let createProp name value =
    { new ISpanProp with
        member x.Name = name
        member x.Value = value }

let FontFamily (fontFamily: string) = createProp Keys.FontFamily fontFamily
let FontAttributes (attributes: FontAttributes) = createProp Keys.FontAttributes attributes
let FontSize (size: FontSize) = createProp Keys.FontSize size
let Text (text: string) = createProp Keys.Text text
let BackgroundColor (color: Color) = createProp Keys.BackgroundColor color
let ForegroundColor (color: Color) = createProp Keys.Foreground color
let LineHeight (height: double) = createProp Keys.LineHeight height
let TextDecoration (decoration: TextDecorations) = createProp Keys.TextDecoration decoration
let TextColor (color: Color) = createProp Keys.TextColor color
let GestureRecognizers (elements: ViewElement list) = createProp Keys.GestureRecognizers elements

let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id
let AutomationId (id: string) = createProp Keys.AutomationId id
let Created (handler: Span -> unit) = createProp Keys.Created handler
let Ref (ref: ViewRef<Span>) = createProp Keys.Ref ref

let inline span (props: ISpanProp list) =
    let attributes =
        props
        |> List.distinctBy (fun prop -> prop.Name)
        |> List.map (fun prop -> prop.Name, prop.Value)
        |> Map.ofList

    let find name = Util.tryFind name attributes

    View.Span(?fontFamily = find Keys.FontFamily,
        ?fontSize = find Keys.FontSize,
        ?fontAttributes = find Keys.FontAttributes,
        ?backgroundColor = find Keys.BackgroundColor,
        ?textColor = find Keys.TextColor,
        ?textDecorations = find Keys.TextDecoration,
        ?lineHeight = find Keys.LineHeight,
        ?text = find Keys.Text,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId,
        ?automationId = find Keys.AutomationId,
        ?created = find Keys.Created,
        ?ref = find Keys.Ref,
        ?gestureRecognizers = find Keys.GestureRecognizers)