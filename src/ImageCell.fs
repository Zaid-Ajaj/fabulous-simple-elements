[<RequireQualifiedAccess>]
module ImageCell

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IImageCellProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IImageCellProp with 
        member x.name = name 
        member x.value = value }

let Image (src: Xamarin.Forms.Image) = createProp Keys.Image src
let Text (value: string) = createProp Keys.Text value
let TextColor (color: Color) = createProp Keys.TextColor color 
let Detail (value: string) = createProp Keys.Detail value 
let DetailColor (color: Color) = createProp Keys.DetailColor color 
let CanExecute (condition: bool) = createProp Keys.CanExecute condition 
let OnClick (f: unit -> unit) = createProp Keys.Command f
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition
let Height (value: double) = createProp Keys.Height value 
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let Ref (viewRef: ViewRef<Button>) = createProp Keys.Ref viewRef 
let AutomationId (id: string) = createProp Keys.AutomationId id
let OnCreated (f: ImageCell -> unit) = createProp Keys.Created f

let inline imageCell (props: IImageCellProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.ImageCell(?image=find Keys.Image,
        ?text=find Keys.Text,
        ?textColor=find Keys.TextColor,
        ?detail=find Keys.Detail,
        ?detailColor=find Keys.DetailColor,
        ?commandCanExecute = find Keys.CanExecute,
        ?command = find Keys.Command,
        ?height = find Keys.Height,
        ?styleId=find Keys.StyleId,
        ?classId=find Keys.ClassId,
        ?ref=find Keys.Ref,
        ?automationId=find Keys.AutomationId,
        ?created = find Keys.Created)