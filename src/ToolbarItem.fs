[<RequireQualifiedAccess>]
module ToolbarItem 

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IToolbarItemProp = 
    abstract name : string 
    abstract value : obj 
    
let internal createProp name value = 
    { new IToolbarItemProp with 
        member x.name = name 
        member x.value = value }    

let Text (value: string) = createProp Keys.Text value 
let OnClick (handler: unit -> unit) = createProp Keys.Command handler 
let Priority (value: int) = createProp Keys.Priority value  
let Order (toolbarItemOrder: ToolbarItemOrder) = createProp Keys.Order toolbarItemOrder
let Icon (icon: string) = createProp Keys.Icon icon 
let Ref (viewRef: ViewRef<ToolbarItem>) = createProp Keys.Ref viewRef
let OnCreated (f: ToolbarItem -> unit) = createProp Keys.Created f
let StyleId (id: string) = createProp Keys.StyleId id
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let inline toolbarItem (props: IToolbarItemProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes
    View.ToolbarItem(?text=find Keys.Text,
        ?ref = find Keys.Ref,
        ?created = find Keys.Created,
        ?command = find Keys.Command,
        ?priority = find Keys.Priority,
        ?order = find Keys.Order,
        ?icon = find Keys.Icon,
        ?classId = find Keys.ClassId,
        ?styleId = find Keys.StyleId,
        ?automationId = find Keys.AutomationId)