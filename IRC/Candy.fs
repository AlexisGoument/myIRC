module Candy

let nickname = "ghost"
let template = sprintf "Candy@root-me.org PRIVMSG %s :" nickname

let (|Candy1Said|_|) (str: string) =
    if (str.Contains template) then
        let part =
            str.Split ":"
            |> Array.last
        part.Split "/"
        |> function
            | [|a;b|] -> Some(int a, int b)
            | s -> None
    else None

let (|Candy2Said|_|) (str: string) =
    if (str.Contains template) then
        let part =
            str.Split ":"
            |> Array.last
        try
            part.Trim()
            |> Base64.decode
            |> Some
        with
            | :? System.FormatException as ex -> None
    else None

let (|Candy3Said|_|) (str: string) =
    if (str.Contains template) then
        let part =
            str.Split ":"
            |> Array.last

        part.Trim()
        |> Rot13.decode
        |> Some
    else None