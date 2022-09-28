module Rot13

let rec incrementChar nth c =
    if nth = 0 then c
    else
        let result =
            match c with
            | 'z' -> 'a'
            | 'Z' -> 'A'
            | c when (c >= 'a' && c < 'z') ||
                            (c >= 'A' && c < 'Z')
                    -> int c + 1 |> char
            | _ -> c
        result |> incrementChar (nth - 1)

let decode str =
    str
    |> String.map (incrementChar 13)