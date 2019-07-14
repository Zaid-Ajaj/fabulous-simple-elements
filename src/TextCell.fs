[<RequireQualifiedAccess>]
module TextCell

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open Util

type ITextCellProp = 
    abstract name : string 
    abstract value : obj 

let internal createProp name value = 
    { new ITextCellProp with 
        member x.name = name 
        member x.value = value }

let Text (value: string) = createProp "text" value 
let Detail (value: string) = createProp "detail" value 
let TextColor (color: Color) = createProp "textColor" color
let Command (cmd: unit -> unit) = createProp "command" cmd 
let CanExecute (cond: bool) = createProp "canExecute" cond 
let IsEnabled (cond: bool) = createProp "isEnabled" cond
let Height (value: double) = createProp "height" value 
let StyleId (id: string) = createProp "styleId" id
let Ref (viewRef: ViewRef<TextCell>) = createProp "ref" viewRef 
let ClassId (id: string) = createProp "classId" id 
let AutomationId (id: string) = createProp "automationId" id
let OnCreated (f: Entry -> unit) = createProp "created" f
// === AbsoluteLayout definitions ===
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp "absoluteLayoutFlags" flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp "absoluteLayoutBounds" rectabgleBounds
// === AbsoluteLayout definitions === 
// === Relative Layout Constraints ===
let WidthConstraint (value: Constraint) = createProp Keys.WidthConstraint value
let HeightConstraint (value: Constraint) = createProp Keys.HeightConstraint value 
let XConstraint (value: Constraint) = createProp Keys.XConstraint value 
let YConstraint (value: Constraint) = createProp Keys.YConstraint value 
// ===================================

let inline textCell (props: ITextCellProp list) = 
    let attributes = 
        props 
        |> List.distinctBy (fun prop -> prop.name)
        |> List.map (fun prop -> prop.name, prop.value)  
        |> Map.ofList 
    
    let find name = Util.tryFind name attributes

    View.TextCell(?text=find"text",
        ?detail=find"detail",
        ?textColor=find"textColor",
        ?command=find"command",
        ?canExecute=find"canExeucte", 
        ?isEnabled=find"isEnabled", 
        ?height=find"height",
        ?classId=find"classId", 
        ?styleId=find"styleId",
        ?ref=find"ref",
        ?automationId=find"automationId",
        ?created=find"created") 

    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes 
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes
    