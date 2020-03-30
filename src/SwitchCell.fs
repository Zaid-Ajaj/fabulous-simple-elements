[<RequireQualifiedAccess>]
module SwitchCell 

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ISwitchCellProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new ISwitchCellProp with 
        member x.name = name 
        member x.value = value }

let IsOn (condition: bool) = createProp Keys.IsOn condition
let Text (value: string) = createProp Keys.Text value 
let OnChanged (handler: ToggledEventArgs -> unit) = createProp Keys.Changed handler 
let Height (value: double) = createProp Keys.Height value 
let IsEnabled (condition: bool) = createProp Keys.IsEnabled condition 
let StyleId (id: string) = createProp Keys.StyleId id
let Ref (viewRef: ViewRef<SwitchCell>) = createProp Keys.Ref viewRef 
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let OnCreated (f: SwitchCell -> unit) = createProp Keys.Created f
let inline switchCell (props: ISwitchCellProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes    
    View.SwitchCell(?on = find Keys.IsOn,
        ?ref = find Keys.Ref,
        ?created = find Keys.Created,
        ?text = find Keys.Text,
        ?onChanged = find Keys.Changed,
        ?height = find Keys.Height,
        ?isEnabled = find Keys.IsEnabled,
        ?styleId = find Keys.StyleId,
        ?classId = find Keys.ClassId,
        ?automationId = find Keys.AutomationId)