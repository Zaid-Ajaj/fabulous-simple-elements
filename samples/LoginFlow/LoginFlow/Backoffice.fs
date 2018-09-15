namespace LoginFlow 

open Fabulous.Core

module Backoffice = 
    
    type State = { AuthorizationToken: string } 
    type Msg = 
    | Logout
    | OtherMsg

    let init() = { AuthorizationToken = "" }, Cmd.none

    let update msg state = state, Cmd.none 
    
    let render (state: State) dispatch = 
        let backoffice = StackLayout.stackLayout [
            StackLayout.Padding 20.0
            StackLayout.Children [
                Label.label [ Label.Text "Logged in!" ]
                Button.button [ 
                    Button.Text "Logout"
                    Button.OnClick (fun _ -> dispatch Logout)
                ]
            ]
        ]

        ContentPage.contentPage [ 
            ContentPage.Content backoffice
        ]
    

