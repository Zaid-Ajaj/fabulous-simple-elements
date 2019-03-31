module internal Util 

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

let tryFind<'t> name (map: Map<string, obj>) : Option<'t> =  
    map
    |> Map.tryFind name
    |> Option.map unbox<'t>   

let applyGridSettings (element: ViewElement) (map: Map<string, obj>) : ViewElement = 
    [  "gridRow", tryFind "gridRow" map
       "gridColumn", tryFind "gridColumn" map 
       "gridRowSpan", tryFind "gridRowSpan" map
       "gridColumnSpan", tryFind "gridColumnSpan" map ] 
    |> List.choose (function 
                    | (name, Some value) -> Some(name, value) 
                    | _ -> None)   
    |> List.fold (fun (elem: ViewElement) (propName, propValue) -> 
                    match propName with 
                    | "gridRow" -> elem.GridRow(int propValue)
                    | "gridColumn" -> elem.GridColumn(int propValue)
                    | "gridRowSpan" -> elem.GridRowSpan(int propValue)
                    | "gridColumnSpan" -> elem.GridColumnSpan(int propValue)
                    | _ -> elem) element

let isDefined = function 
| (name, Some value) -> Some(name, value) 
| _ -> None

let applyAbsoluteLayoutSettings (element: ViewElement) (props: Map<string, obj>) : ViewElement =
    [ "absoluteLayoutFlags", tryFind "absoluteLayoutFlags" props
      "absoluteLayoutBounds", tryFind "absoluteLayoutBounds" props ]
    |> List.choose isDefined
    |> List.fold (fun (el: ViewElement) (propName, propValue) ->
                  match propName with 
                  | "absoluteLayoutFlags" -> el.LayoutFlags (unbox<AbsoluteLayoutFlags> propValue)
                  | "absoluteLayoutBounds" -> el.LayoutBounds (unbox<Rectangle> propValue)
                  | _ -> el) element

let applyRelativeLayoutConstraints (element: ViewElement) (props: Map<string, obj>) : ViewElement =
    [ Keys.WidthConstraint, tryFind Keys.WidthConstraint props
      Keys.HeightConstraint, tryFind Keys.HeightConstraint props
      Keys.XConstraint, tryFind Keys.XConstraint props
      Keys.YConstraint, tryFind Keys.YConstraint props ]
    |> List.choose isDefined 
    |> List.fold (fun (el: ViewElement) (propName, propValue) ->
                  match propName with 
                  | Keys.WidthConstraint -> el.WidthConstraint (unbox propValue)
                  | Keys.HeightConstraint -> el.HeightConstraint (unbox propValue)
                  | Keys.XConstraint -> el.XConstraint (unbox propValue)
                  | Keys.YConstraint -> el.YConstraint (unbox propValue)
                  | _ -> el) element

let applyFlexLayoutSettings (element: ViewElement) (props: Map<string, obj>) : ViewElement =
    [ "flexBasis", tryFind "flexBasis" props
      "flexOrder", tryFind "flexOrder" props
      "flexGrow", tryFind "flexGrow" props
      "flexShrink", tryFind "flexShrink" props
      "flexLayoutDirection", tryFind "flexLayoutDirection" props
      "flexAlignSelf", tryFind "flexAlignSelf" props]
    |> List.choose (function 
                    | (name, Some value) -> Some(name, value) 
                    | _ -> None)
    |> List.fold (fun (el: ViewElement) (propName, propValue) ->
                  match propName with 
                  | "flexBasis" -> el.FlexBasis (unbox<FlexBasis> propValue)
                  | "flexOrder" -> el.FlexOrder (int propValue)
                  | "flexGrow" -> el.FlexGrow(double propValue)
                  | "flexShrink" -> el.FlexShrink (double propValue)
                  | "flexLayoutDirection" -> el.FlexLayoutDirection(unbox<FlexDirection> propValue)
                  | "flexAlignSelf" -> el.FlexAlignSelf (unbox<FlexAlignSelf> propValue)
                  | _ -> el) element
    
let applyMarginSettings (map: Map<string, obj>) : Thickness = 
    let initialMargin = 
        Map.tryFind "margin" map  
        |> Option.map (unbox<Thickness>)
        |> Option.defaultValue (Thickness(0.0))
    
    [ "marginLeft", tryFind "marginLeft"  map
      "marginRight", tryFind "marginRight" map
      "marginTop", tryFind "marginTop" map
      "marginBottom", tryFind "marginBottom" map ]
    |> List.choose (function 
                    | (name, Some value) -> Some (name, value)
                    | _ -> None) 
    |> List.fold (fun (current: Thickness) (propName, propValue : obj) -> 
                  match propName with 
                  | "marginLeft" -> 
                      let marginLeft = unbox<float> propValue 
                      Thickness(marginLeft, current.Top, current.Right, current.Bottom)
                  | "marginRight" -> 
                      let marginRight = unbox<float> propValue 
                      Thickness(current.Left, current.Top, marginRight, current.Bottom)
                  | "marginTop" -> 
                      let marginTop = unbox<float> propValue 
                      Thickness(current.Left, marginTop, current.Right, current.Bottom) 
                  | "marginBottom" -> 
                      let marginBottom = unbox<float> propValue 
                      Thickness(current.Left, current.Top, current.Right, marginBottom)
                  | _ -> current) initialMargin

let applyPaddingSettings (map: Map<string, obj>) : Thickness = 
    let initiaPadding = 
        Map.tryFind Keys.Padding map  
        |> Option.map (unbox<Thickness>)
        |> Option.defaultValue (Thickness(0.0))
    
    [ Keys.PaddingLeft, tryFind Keys.PaddingLeft  map
      Keys.PaddingRight, tryFind Keys.PaddingRight map
      Keys.PaddingTop, tryFind Keys.PaddingTop map
      Keys.PaddingBottom, tryFind Keys.PaddingBottom map ]
    |> List.choose isDefined
    |> List.fold (fun (current: Thickness) (propName, propValue : obj) -> 
                  match propName with 
                  | Keys.PaddingLeft -> 
                      let paddingLeft = unbox<float> propValue 
                      Thickness(paddingLeft, current.Top, current.Right, current.Bottom)
                  | Keys.PaddingRight -> 
                      let paddingRight = unbox<float> propValue 
                      Thickness(current.Left, current.Top, paddingRight, current.Bottom)
                  | Keys.PaddingTop -> 
                      let paddingTop = unbox<float> propValue 
                      Thickness(current.Left, paddingTop, current.Right, current.Bottom) 
                  | Keys.PaddingBottom -> 
                      let paddingBottom = unbox<float> propValue 
                      Thickness(current.Left, current.Top, current.Right, paddingBottom)
                  | _ -> current) initiaPadding