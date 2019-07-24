// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Components

open Fabulous.XamarinForms
open Xamarin.Forms
open SimpleFabimals.Models

module SearchHandlers =
    type Msg =
        | QueryChanged of string
        | AnimalSelected of Animal

    let animalSearchHandler animals dispatch =
        SearchHandler.searchHandler [
            SearchHandler.Placeholder "Enter search term"
            SearchHandler.ShowResults true
            SearchHandler.QueryChanged (fun (_, newValue) -> dispatch (QueryChanged newValue))
            SearchHandler.ItemSelected <|
                fun item ->
                    let data = item :?> ItemListElementData
                    let animal = data.Key.GetAttributeKeyed(ViewAttributes.TagAttribKey) :?> Animal
                    dispatch (AnimalSelected animal)
            SearchHandler.Items [
                for animal in animals do
                    yield Grid.grid [
                        Grid.Tag animal
                        Grid.PaddingThickness (Thickness(10.))
                        Grid.Columns [GridLength(0.15, GridUnitType.Star); GridLength(0.85, GridUnitType.Star)]
                        Grid.Children [
                            Image.image [
                                Image.SourceString animal.ImageUrl
                                Image.Aspect Aspect.AspectFill
                                Image.Height 40.
                                Image.Width 40.
                            ]
                            Label.label [
                                Label.Text animal.Name
                                Label.FontAttributes FontAttributes.Bold
                                Label.GridColumn 1
                            ]
                        ]
                    ]
            ]
        ]