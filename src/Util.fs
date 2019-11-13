module internal Util 

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

let inline tryFind<'t> name (map: Map<string, obj>) : Option<'t> =  
    map
    |> Map.tryFind name
    |> Option.map unbox<'t>   

let inline isDefined prop = 
    match prop with
    | (name, Some value) -> Some(name, value) 
    | _ -> None

let inline applyGridSettings (element: ViewElement) (map: Map<string, obj>) : ViewElement = 
    [  Keys.Row, tryFind Keys.Row map
       Keys.Column, tryFind Keys.Column map 
       Keys.RowSpan, tryFind Keys.RowSpan map
       Keys.ColumnSpan, tryFind Keys.ColumnSpan map ] 
    |> List.choose isDefined  
    |> List.fold (fun (elem: ViewElement) (propName, propValue) -> 
                    match propName with 
                    | Keys.Row -> elem.Row(int propValue)
                    | Keys.Column -> elem.Column(int propValue)
                    | Keys.RowSpan -> elem.RowSpan(int propValue)
                    | Keys.ColumnSpan -> elem.ColumnSpan(int propValue)
                    | _ -> elem) element

let inline applyAbsoluteLayoutSettings (element: ViewElement) (props: Map<string, obj>) : ViewElement =
    [ Keys.AbsoluteLayoutFlags, tryFind Keys.AbsoluteLayoutFlags props
      Keys.AbsoluteLayoutBounds, tryFind Keys.AbsoluteLayoutBounds props ]
    |> List.choose isDefined
    |> List.fold (fun (el: ViewElement) (propName, propValue) ->
                  match propName with 
                  | Keys.AbsoluteLayoutFlags -> el.LayoutFlags (unbox<AbsoluteLayoutFlags> propValue)
                  | Keys.AbsoluteLayoutBounds -> el.LayoutBounds (unbox<Rectangle> propValue)
                  | _ -> el) element

let inline applyRelativeLayoutConstraints (element: ViewElement) (props: Map<string, obj>) : ViewElement =
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

let inline applyFlexLayoutSettings (element: ViewElement) (props: Map<string, obj>) : ViewElement =
    [ Keys.Basis, tryFind Keys.Basis props
      Keys.Order, tryFind Keys.Order props
      Keys.Grow, tryFind Keys.Grow props
      Keys.Shrink, tryFind Keys.Shrink props
      Keys.FlexLayoutDirection, tryFind Keys.FlexLayoutDirection props
      Keys.AlignSelf, tryFind Keys.AlignSelf props]
    |> List.choose isDefined
    |> List.fold (fun (el: ViewElement) (propName, propValue) ->
                  match propName with 
                  | Keys.Basis -> el.Basis (unbox<FlexBasis> propValue)
                  | Keys.Order -> el.Order (int propValue)
                  | Keys.Grow -> el.Grow(double propValue)
                  | Keys.Shrink -> el.Shrink (single propValue)
                  | Keys.FlexLayoutDirection -> el.FlexLayoutDirection(unbox<FlexDirection> propValue)
                  | Keys.AlignSelf -> el.AlignSelf (unbox<FlexAlignSelf> propValue)
                  | _ -> el) element
    
let inline applyMarginSettings (map: Map<string, obj>) : Thickness = 
    let initialMargin = 
        Map.tryFind Keys.Margin map  
        |> Option.map unbox<Thickness>
        |> Option.defaultValue (Thickness(0.0))
    
    [ Keys.MarginLeft, tryFind Keys.MarginLeft map
      Keys.MarginRight, tryFind Keys.MarginRight map
      Keys.MarginTop, tryFind Keys.MarginTop map
      Keys.MarginBottom, tryFind Keys.MarginBottom map ]
    |> List.choose isDefined
    |> List.fold (fun (current: Thickness) (propName, propValue : obj) -> 
                  match propName with 
                  | Keys.MarginLeft -> 
                      let marginLeft = unbox<float> propValue 
                      Thickness(marginLeft, current.Top, current.Right, current.Bottom)
                  | Keys.MarginRight -> 
                      let marginRight = unbox<float> propValue 
                      Thickness(current.Left, current.Top, marginRight, current.Bottom)
                  | Keys.MarginTop -> 
                      let marginTop = unbox<float> propValue 
                      Thickness(current.Left, marginTop, current.Right, current.Bottom) 
                  | Keys.MarginBottom -> 
                      let marginBottom = unbox<float> propValue 
                      Thickness(current.Left, current.Top, current.Right, marginBottom)
                  | _ -> current) initialMargin

let inline applyPaddingSettings (map: Map<string, obj>) : Thickness = 
    let initialPadding = 
        Map.tryFind Keys.Padding map  
        |> Option.map unbox<Thickness>
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
                  | _ -> current) initialPadding