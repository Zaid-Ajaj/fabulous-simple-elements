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
        Map.tryFind "padding" map  
        |> Option.map (unbox<Thickness>)
        |> Option.defaultValue (Thickness(0.0))
    
    [ "paddingLeft", tryFind "paddingLeft"  map
      "paddingRight", tryFind "paddingRight" map
      "paddingTop", tryFind "paddingTop" map
      "paddingBottom", tryFind "paddingBottom" map ]
    |> List.choose (function 
                    | (name, Some value) -> Some (name, value)
                    | _ -> None) 
    |> List.fold (fun (current: Thickness) (propName, propValue : obj) -> 
                  match propName with 
                  | "paddingLeft" -> 
                      let paddingLeft = unbox<float> propValue 
                      Thickness(paddingLeft, current.Top, current.Right, current.Bottom)
                  | "paddingRight" -> 
                      let paddingRight = unbox<float> propValue 
                      Thickness(current.Left, current.Top, paddingRight, current.Bottom)
                  | "paddingTop" -> 
                      let paddingTop = unbox<float> propValue 
                      Thickness(current.Left, paddingTop, current.Right, current.Bottom) 
                  | "paddingBottom" -> 
                      let paddingBottom = unbox<float> propValue 
                      Thickness(current.Left, current.Top, current.Right, paddingBottom)
                  | _ -> current) initiaPadding