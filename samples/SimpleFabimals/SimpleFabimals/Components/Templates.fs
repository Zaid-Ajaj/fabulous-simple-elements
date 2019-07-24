// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Components

open System
open Fabulous
open Xamarin.Forms
open SimpleFabimals.Models

module Templates =
    let animalTemplate animal =
        dependsOn animal (fun _ animal ->
            Grid.grid [
                Grid.Tag animal
                Grid.PaddingThickness (Thickness(10.))
                Grid.Columns [GridLength.Auto; GridLength.Auto]
                Grid.Rows [GridLength.Auto; GridLength.Auto]
                Grid.Children [
                    Image.image [
                        Image.SourceString animal.ImageUrl
                        Image.Aspect Aspect.AspectFill
                        Image.Height 40.
                        Image.Width 40.
                        Image.GridRowSpan 2
                    ]
                    Label.label [
                        Label.Text animal.Name
                        Label.FontAttributes FontAttributes.Bold
                        Label.GridColumn 1
                    ]
                    Label.label [
                        Label.Text animal.Location
                        Label.FontAttributes FontAttributes.Italic
                        Label.VerticalLayout LayoutOptions.End
                        Label.GridRow 1
                        Label.GridColumn 1
                    ]
                ]
            ]            
        )