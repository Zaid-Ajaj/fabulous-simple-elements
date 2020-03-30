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

let Text (value: string) = createProp Keys.Text value 
let Detail (value: string) = createProp Keys.Detail value 
let TextColor (color: Color) = createProp Keys.TextColor color
let Command (cmd: unit -> unit) = createProp Keys.Command cmd 
let CanExecute (cond: bool) = createProp Keys.CanExecute cond 
let IsEnabled (cond: bool) = createProp Keys.IsEnabled cond
let Height (value: double) = createProp Keys.Height value 
let StyleId (id: string) = createProp Keys.StyleId id
let Ref (viewRef: ViewRef<TextCell>) = createProp Keys.Ref viewRef 
let ClassId (id: string) = createProp Keys.ClassId id 
let AutomationId (id: string) = createProp Keys.AutomationId id
let OnCreated (f: Entry -> unit) = createProp Keys.Created f
// === AbsoluteLayout definitions ===
let AbsoluteLayoutFlags (flags: AbsoluteLayoutFlags) = createProp Keys.AbsoluteLayoutBounds flags 
let AbsoluteLayoutBounds (rectabgleBounds: Rectangle) = createProp Keys.AbsoluteLayoutBounds rectabgleBounds
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

    View.TextCell(?text=find Keys.Text,
        ?detail=find Keys.Detail,
        ?textColor=find Keys.TextColor,
        ?command=find Keys.Command,
        ?commandCanExecute=find Keys.CanExecute, 
        ?isEnabled=find Keys.IsEnabled, 
        ?height=find Keys.Height,
        ?classId=find Keys.ClassId, 
        ?styleId=find Keys.StyleId,
        ?ref=find Keys.Ref,
        ?automationId=find Keys.AutomationId,
        ?created=find Keys.Created) 

    |> fun element -> Util.applyGridSettings element attributes
    |> fun element -> Util.applyFlexLayoutSettings element attributes 
    |> fun element -> Util.applyAbsoluteLayoutSettings element attributes
    |> fun element -> Util.applyRelativeLayoutConstraints element attributes
    