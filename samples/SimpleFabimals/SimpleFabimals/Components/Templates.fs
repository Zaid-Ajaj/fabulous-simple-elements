// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Components

open Fabulous
open XamarinForms.InputTypes
open Xamarin.Forms
open SimpleFabimals.Models

module Templates =
    let animalTemplate animal =
        dependsOn animal (fun _ animal ->
            Grid.grid [
                Grid.Tag animal
                Grid.PaddingThickness (Thickness(10.))
                Grid.Columns [Auto; Auto]
                Grid.Rows [Auto; Auto]
                Grid.Children [
                    Image.image [
                        Image.Source <| Image.ImagePath animal.ImageUrl
                        Image.Aspect Aspect.AspectFill
                        Image.Height 40.
                        Image.Width 40.
                        Image.RowSpan 2
                    ]
                    Label.label [
                        Label.Text animal.Name
                        Label.FontAttributes FontAttributes.Bold
                        Label.Column 1
                    ]
                    Label.label [
                        Label.Text animal.Location
                        Label.FontAttributes FontAttributes.Italic
                        Label.VerticalLayout LayoutOptions.End
                        Label.Row 1
                        Label.Column 1
                    ]
                ]
            ]            
        )