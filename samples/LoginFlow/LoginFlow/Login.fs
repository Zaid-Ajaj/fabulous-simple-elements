namespace LoginFlow 

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms

module Login = 
    open System
    
    type LoginResult = 
    | Success of token:string
    | UsernameDoesNotExist
    | PasswordIncorrect
    | LoginError of errorMsg:string

    type LoginInfo = { 
        Username : string 
        Password : string 
    }

    type Msg = 
    | Login
    | ChangeUsername of string
    | ChangePassword of string
    | LoginSuccess of adminSecureToken: string
    | LoginFailed of error:string
    | UpdateValidationErrors 

    type State = {
        LoggingIn: bool
        InputUsername: string
        UsernameValidationErrors: string list
        PasswordValidationErrors: string list
        InputPassword: string
        HasTriedToLogin: bool
        LoginError: string option
    }


    let init() = 
        { InputUsername = ""
          InputPassword = ""
          UsernameValidationErrors =  [ ]
          PasswordValidationErrors =  [ ]
          HasTriedToLogin = false
          LoginError = None
          LoggingIn = false 
        }, Cmd.ofMsg UpdateValidationErrors

    let validateInput (state: State) =  
      let usernameRules = 
        [ String.IsNullOrWhiteSpace(state.InputUsername), "Field 'Username' cannot be empty"
          state.InputUsername.Trim().Length < 5, "Field 'Username' must at least have 5 characters" ]
      let passwordRules = 
        [ String.IsNullOrWhiteSpace(state.InputPassword), "Field 'Password' cannot be empty"
          state.InputPassword.Trim().Length < 5, "Field 'Password' must at least have 5 characters" ]
      let usernameValidationErrors = 
          usernameRules
          |> List.filter fst
          |> List.map snd
      let passwordValidationErrors = 
          passwordRules
          |> List.filter fst
          |> List.map snd
  
      usernameValidationErrors, passwordValidationErrors

    let login (credentials: LoginInfo) = 
        async {
            do! Async.Sleep 3000
            return Msg.LoginSuccess "<Authentication token here>"
        }

    let update msg (state: State) = 
        match msg with 
        | ChangeUsername name ->
            let nextState = { state with InputUsername = name }          
            nextState, Cmd.ofMsg UpdateValidationErrors
        | ChangePassword pass ->
            let nextState = { state with InputPassword = pass }        
            nextState, Cmd.ofMsg UpdateValidationErrors
        | UpdateValidationErrors ->
            let usernameErrors, passwordErrors =
                 validateInput state
            let nextState =
                { state with UsernameValidationErrors = usernameErrors
                             PasswordValidationErrors = passwordErrors }
            nextState, Cmd.none
        | Login ->
            let state = { state with HasTriedToLogin = true }
            let usernameErrors, passwordErrors = validateInput state
            let startLogin = List.isEmpty usernameErrors && List.isEmpty passwordErrors
            match startLogin with
            | false -> state, Cmd.none
            | true -> 
               let nextState = { state with LoggingIn = true } 
               let credentials = { 
                   Username = state.InputUsername
                   Password = state.InputPassword  
               }
              
               nextState, Cmd.ofAsyncMsg (login credentials)
        
        | LoginSuccess token -> 
            let nextState = { state with LoggingIn = false }
            nextState, Cmd.none
        
        | LoginFailed error ->
            let nextState = 
                { state with LoginError = Some error 
                             LoggingIn = false }

            nextState, Cmd.none

    let renderErrors (errors: string list) = 
        StackLayout.stackLayout [
            StackLayout.Children [ 
                for error in errors -> Label.label [ 
                    Label.Text error 
                    Label.TextColor Color.Red 
                    Label.HorizontalTextAlignment TextAlignment.Center
                ] 
            ]
        ]

    let (|NonEmpty|_|) = function 
        | [ ] -> None 
        | elements -> Some elements

    let render (state: State) dispatch = 
        
        let loginForm = StackLayout.stackLayout [
            StackLayout.Padding 20.0
            StackLayout.VerticalLayout LayoutOptions.Center
            StackLayout.Children [
                yield TextEntry.textEntry [
                    TextEntry.Placeholder "Username"
                    TextEntry.Text state.InputUsername
                    TextEntry.OnTextChanged (fun args -> dispatch (Msg.ChangeUsername args.NewTextValue))
                ]

                match state.UsernameValidationErrors with
                | NonEmpty errors when state.HasTriedToLogin -> yield renderErrors errors 
                | _ -> () 

                yield TextEntry.textEntry [
                    TextEntry.Placeholder "Password"
                    TextEntry.Text state.InputPassword
                    TextEntry.IsPassword true 
                    TextEntry.OnTextChanged (fun args -> dispatch (Msg.ChangePassword args.NewTextValue))
                ]

                match state.PasswordValidationErrors with
                | NonEmpty errors when state.HasTriedToLogin -> yield renderErrors errors 
                | _ -> ()  
               
                yield Button.button [ 
                    Button.Text "Login" 
                    Button.BackgroundColor Color.Crimson
                    Button.OnClick (fun _ -> dispatch Login)
                ]
            ]
        ]
        
        let loader = ActivityIndicator.activityIndicator [
            ActivityIndicator.Margin 40.0
            ActivityIndicator.IsRunning state.LoggingIn
        ]
        
        ContentPage.contentPage [
            ContentPage.Content (if state.LoggingIn then loader else loginForm)
        ]