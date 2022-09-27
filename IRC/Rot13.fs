module Rot13

let rec incrementChar nth c =
    if nth = 0 then c
    else
        let result =
            match c with
            | 'z' -> 'a'
            | 'Z' -> 'A'
            | _ -> int c + 1 |> char
        result |> incrementChar (nth - 1)

let decode str =
    str
    |> String.map (incrementChar 13)