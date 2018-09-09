# Fabulous.SimpleElements [![Nuget](https://img.shields.io/nuget/v/Fabulous.SimpleElements.svg?colorB=green)](https://www.nuget.org/packages/Fabulous.SimpleElements)   [![Build Status](https://travis-ci.org/Zaid-Ajaj/Fabulous.SimpleElements.svg?branch=master)](https://travis-ci.org/Zaid-Ajaj/Fabulous.SimpleElements)


An alternative view rendering API for [Fabulous](https://github.com/fsprojects/Fabulous) that is easy to use and simple to read, inspired by Elmish on the web. 

### Install from Nuget
```
dotnet add package Fabulous.SimpleElements	
```
### Example Code
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
### Running the samples
To run a sample, you have to build the `Fabulous.SimpleElements` project first using `./build.sh` or `build.cmd` then open the solution of the sample and start the selected project. This is needed because (for some reason), Visual Studio can't make a project reference from the sample, but a dll reference will work fine, that's why we have to build the main project in release mode first. 