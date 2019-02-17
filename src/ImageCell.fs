[<RequireQualifiedAccess>]
module ImageCell

open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Forms.StyleSheets

type IImageCellProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new IImageCellProp with 
        member x.name = name 
        member x.value = value }

let Source (src: Xamarin.Forms.ImageSource) = createProp "source" src
let Text (value: string) = createProp "text" value
let TextColor (color: Color) = createProp "textColor" color 
let Detail (value: string) = createProp "detail" value 
let DetailColor (color: Color) = createProp "detailColor" color 
let CanExecute (condition: bool) = createProp "canExecute" condition 
let OnClick (f: unit -> unit) = createProp "command" f
let IsEnabled (condition: bool) = createProp "isEnabled" condition
let Height (value: double) = createProp "height" value 
let StyleId (id: string) = createProp "styleId" id
let ClassId (id: string) = createProp "classId" id 
let Ref (viewRef: ViewRef<Button>) = createProp "ref" viewRef 
let AutomationId (id: string) = createProp "automationId" id
let OnCreated (f: ImageCell -> unit) = createProp "created" f

let imageCell (props: IImageCellProp list) = 
    let attributes = 
        props 
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.ImageCell(?imageSource=find"source",
        ?text=find"text",
        ?textColor=find"textColor",
        ?detail=find"detail",
        ?detailColor=find"detailColor",
        ?canExecute = find"canExecute",
        ?command = find "command",
        ?height = find "height",
        ?styleId=find"styleId",
        ?classId=find"classId",
        ?ref=find"ref",
        ?automationId=find"automationId",
        ?created = find "created")