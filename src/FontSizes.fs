[<RequireQualifiedAccess>]
module FontSize

type IFontSize = FontSize of string 

let Micro = FontSize "Micro"

let Small = FontSize "Small"

let Medium = FontSize "Medium"

let Large = FontSize "Large"