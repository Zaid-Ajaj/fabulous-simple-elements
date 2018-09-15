# Fabulous.SimpleElements [![Nuget](https://img.shields.io/nuget/v/Fabulous.SimpleElements.svg?colorB=green)](https://www.nuget.org/packages/Fabulous.SimpleElements)   [![Build Status](https://travis-ci.org/Zaid-Ajaj/fabulous-simple-elements.svg?branch=master)](https://travis-ci.org/Zaid-Ajaj/fabulous-simple-elements)


An alternative view rendering API for [Fabulous](https://github.com/fsprojects/Fabulous) that is easy to use and simple to read, inspired by Elmish on the web. 

### Install from Nuget
```
dotnet add package Fabulous.SimpleElements	
```
# Example Code
The library aims to unify both optional arguments and fluent extension methods for View elements into a list of attributes  
```fs
StackLayout.stackLayout [
    StackLayout.Padding 20.0 
    StackLayout.VerticalLayout LayoutOptions.Center
    StackLayout.Children [ 
        Label.label [ 
            Label.Text "Congrats, you have won!"; 
            Label.HorizontalTextAlignment TextAlignment.Center
            Label.MarginLeft 30.0
            Label.MarginRight 30.0
            Label.FontSize FontSize.Large 
        ]

        Button.button [ 
            Button.Text "Play Again"
            Button.OnClick (fun _ -> dispatch StartNewGame) 
        ]
    ]
]
```
# Running the samples
Each sample has it's own solution, open any of the samples in Visual Studio or Visual Studio for Mac, select your preferred project to start the app, either `<AppName>.Android` or `<AppName>.iOS` and run the project. 

### Fifteen Puzzle Sample
![fifteen-puzzle](assets/fifteen-puzzle.gif)

### LoginFlow sample 
![login-flow](assets/login.gif)

### Counter Sample 
![Counter](assets/counter.gif)