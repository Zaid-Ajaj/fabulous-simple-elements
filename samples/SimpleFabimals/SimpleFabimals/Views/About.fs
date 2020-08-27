// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace SimpleFabimals.Views

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System

module AboutStyles =
    let primaryColor = Color.FromHex("#96d1ff")
    let lightTextColor = Color.FromHex("#999999")

module About =
    type Msg =
        | ShowFabulous
        | ShowXamarinForms
        | ShowOriginalFabimalsSample
        | ShowSimpleElements
        
    type CmdMsg = GoToUrl of string

    let goToUrl url =
        SimpleFabimals.Helper.openUri(url)
        Cmd.none

    let mapCommands cmdMsg =
        match cmdMsg with
        | GoToUrl url -> goToUrl url

    let update msg =
        match msg with
        | ShowFabulous -> [GoToUrl "https://fsprojects.github.io/Fabulous"]
        | ShowXamarinForms -> [GoToUrl "https://docs.microsoft.com/en-us/xamarin/xamarin-forms"]
        | ShowOriginalFabimalsSample -> [GoToUrl "https://github.com/xamarin/xamarin-forms-samples/blob/master/UserInterface/Xaminals"]
        | ShowSimpleElements -> [GoToUrl "https://github.com/Zaid-Ajaj/fabulous-simple-elements"]

    let view dispatch =
        dependsOn () (fun _ () ->
            ContentPage.contentPage [
                ContentPage.Title "About"
                ContentPage.Content <|
                    ScrollView.scrollView [
                        ScrollView.Content <|
                            FlexLayout.flexLayout [
                                FlexLayout.Direction FlexDirection.Column
                                FlexLayout.Children [
                                    ContentView.contentView [
                                        ContentView.BackgroundColor AboutStyles.primaryColor
                                        ContentView.VerticalLayout LayoutOptions.FillAndExpand
                                        ContentView.HorizontalLayout LayoutOptions.Fill
                                        ContentView.PaddingThickness (Thickness(0., 40.))
                                        ContentView.Content <|
                                            Image.image [
                                                Image.Source <| Image.ImagePath "xamarin_logo.png"
                                                Image.HorizontalLayout LayoutOptions.Center
                                                Image.VerticalLayout LayoutOptions.Center
                                                Image.Height 64.
                                            ]
                                    ]
                                    StackLayout.stackLayout [
                                        StackLayout.Orientation StackOrientation.Vertical
                                        StackLayout.PaddingThickness (Thickness(16., 40.))
                                        StackLayout.Spacing 10.
                                        //StackLayout.FlexGrow 1. //throwing invalid cast exception
                                        StackLayout.Children [
                                            Label.label [
                                                Label.FontSize <| FontSize.fromValue 22.
                                                Label.FormattedText <|
                                                    FormattedString.formattedString [
                                                        FormattedString.Spans [
                                                            Span.span [
                                                                Span.Text "Fabulous Animals - Simple Elements"
                                                                Span.FontAttributes FontAttributes.Bold
                                                                Span.FontSize <| FontSize.fromValue 22.
                                                            ]
                                                            Span.span [
                                                                Span.Text " "
                                                            ]
                                                            Span.span [
                                                                Span.Text "1.0"
                                                                Span.ForegroundColor AboutStyles.lightTextColor
                                                            ]
                                                        ]
                                                    ]
                                            ]
                                            Label.label [
                                                Label.FormattedText <|
                                                    FormattedString.formattedString [
                                                        FormattedString.Spans [
                                                            Span.span [
                                                                Span.Text "This app is written in F# with "
                                                            ]
                                                            Span.span [
                                                                Span.Text "Fabulous"
                                                                Span.FontAttributes FontAttributes.Bold
                                                                Span.TextColor Color.Blue
                                                                Span.TextDecoration TextDecorations.Underline
                                                                Span.GestureRecognizers [
                                                                    TapGestureRecognizer.tapGestureRecognizer [
                                                                        TapGestureRecognizer.OnTapped (fun () -> dispatch ShowFabulous)
                                                                    ]
                                                                ]
                                                            ]
                                                            Span.span [
                                                                Span.Text " and "
                                                            ]
                                                            Span.span [
                                                                Span.Text "Fabulous Simple Elements"
                                                                Span.FontAttributes FontAttributes.Bold
                                                                Span.TextColor Color.Blue
                                                                Span.TextDecoration TextDecorations.Underline
                                                                Span.GestureRecognizers [
                                                                    TapGestureRecognizer.tapGestureRecognizer [
                                                                        TapGestureRecognizer.OnTapped (fun () -> dispatch ShowSimpleElements)
                                                                    ]
                                                                ]
                                                            ]
                                                            Span.span [
                                                                Span.Text "."
                                                            ]
                                                        ]
                                                    ]
                                            ]
                                            Label.label [
                                                Label.FormattedText <|
                                                    FormattedString.formattedString [
                                                        FormattedString.Spans [
                                                            Span.span [
                                                                Span.Text "It is a port of the "
                                                            ]
                                                            Span.span [
                                                                Span.Text "existing sample of Xaminals"
                                                                Span.FontAttributes FontAttributes.Bold
                                                                Span.TextColor Color.Blue
                                                                Span.TextDecoration TextDecorations.Underline
                                                                Span.GestureRecognizers [
                                                                    TapGestureRecognizer.tapGestureRecognizer [
                                                                        TapGestureRecognizer.OnTapped (fun () -> dispatch ShowOriginalFabimalsSample)
                                                                    ]
                                                                ]
                                                            ]
                                                            Span.span [
                                                                Span.Text ", written in C#/XAML with "
                                                            ]
                                                            Span.span [
                                                                Span.Text "Xamarin.Forms"
                                                                Span.FontAttributes FontAttributes.Bold
                                                                Span.TextColor Color.Blue
                                                                Span.TextDecoration TextDecorations.Underline
                                                                Span.GestureRecognizers [
                                                                    TapGestureRecognizer.tapGestureRecognizer [
                                                                        TapGestureRecognizer.OnTapped (fun () -> dispatch ShowXamarinForms)
                                                                    ]
                                                                ]
                                                            ]
                                                            Span.span [
                                                                Span.Text "."
                                                            ]
                                                        ]
                                                    ]
                                            ]
                                            Button.button [
                                                Button.MarginThickness (Thickness(0., 10., 0., 0.))
                                                Button.Text "Learn more"
                                                Button.OnClick (fun () -> dispatch ShowFabulous)
                                                Button.BackgroundColor AboutStyles.primaryColor
                                                Button.TextColor Color.White
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                    ]
                    
            ]
        )