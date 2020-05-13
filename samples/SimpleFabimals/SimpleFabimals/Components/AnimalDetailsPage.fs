// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Components

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open SimpleFabimals.Models

module AnimalDetails =
    type Msg = NoOp
    type CmdMsg = NoOp
    type ExternalMsg = NoOp
    
    type Model =
        { Animal: Animal }

    let init (animal: Animal) =
        { Animal = animal }
    
    let view model =
        dependsOn model.Animal (fun model animal ->
            // Currently Fabulous needs to handle its own ContentPage to support Routing inside Shell
            // This is a limitation of Xamarin.Forms. Might change in the future (https://github.com/xamarin/Xamarin.Forms/issues/5166)
            // So for now, we only declare the content of the page
            
            ScrollView.scrollView [
                ScrollView.Content <|
                    StackLayout.stackLayout [
                        StackLayout.MarginThickness (Thickness(20.))
                        StackLayout.Children [
                            Label.label [
                                Label.Text animal.Name
                                Label.HorizontalLayout LayoutOptions.Center
                                Label.Style Device.Styles.TitleStyle
                            ]
                            Label.label [
                                Label.Text animal.Location
                                Label.FontAttributes FontAttributes.Italic
                                Label.HorizontalLayout LayoutOptions.Center
                            ]
                            Image.image [
                                Image.Source <| Image.ImagePath animal.ImageUrl
                                Image.Width 200.
                                Image.Height 200.
                                Image.HorizontalLayout LayoutOptions.CenterAndExpand
                            ]
                            Label.label [
                                Label.Text animal.Details
                                Label.Style Device.Styles.BodyStyle
                            ]
                        ]
                    ]
            ]
        )