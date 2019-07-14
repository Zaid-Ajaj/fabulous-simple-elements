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

let IsOn (condition: bool) = createProp "on" condition
let Text (value: string) = createProp "text" value 
let OnChanged (handler: ToggledEventArgs -> unit) = createProp "onChanged" handler 
let Height (value: double) = createProp "height" value 
let IsEnabled (condition: bool) = createProp "isEnabled" condition 
let StyleId (id: string) = createProp "styleId" id
let Ref (viewRef: ViewRef<SwitchCell>) = createProp "ref" viewRef 
let ClassId (id: string) = createProp "classId" id 
let AutomationId (id: string) = createProp "automationId" id
let OnCreated (f: SwitchCell -> unit) = createProp "created" f
let inline switchCell (props: ISwitchCellProp list) : ViewElement = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes    
    View.SwitchCell(?on = find "on",?ref = find "ref", ?created = find "created", ?text = find "text", ?onChanged = find "onChanged", ?height = find "height", ?isEnabled = find "isEnabled", ?styleId = find "styleId", ?classId = find "classId", ?automationId = find "automationId")