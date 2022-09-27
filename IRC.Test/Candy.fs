module Candy

open NUnit.Framework
open FsUnit
open IRCClient

[<Test>]
let Candy1 () =
    match CandySaid "!ep1" "Candy@root-me.org PRIVMSG ghost :370 / 5719" with
    | Some answer -> answer |> should equal "!ep1 -rep 110007.16"
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy2 () =
    match CandySaid "!ep2" "Candy@root-me.org PRIVMSG ghost :QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=" with
    | Some answer -> answer |> should equal "!ep2 -rep AxcTNQ711lRbUieYZWJOTS2mdhjCY"
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy3 () =
    match CandySaid "!ep3" "Candy@root-me.org PRIVMSG ghost :gcGYR4aZjTgxy7w" with
    | Some answer -> answer |> should equal "!ep3 -rep tpTLE4nMwGtkl7j"
    | _ -> failwith "Cannot find what Candy said"