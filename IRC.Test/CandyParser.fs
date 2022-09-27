module CandyParser

open NUnit.Framework
open Candy
open FsUnit

[<Test>]
let Candy1Parser () =
    match "Candy@root-me.org PRIVMSG ghost :370 / 5719" with
    | Candy1Said (370, 5719) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy1ParserWhenPrefix () =
    match "azdazdazdCandy@root-me.org PRIVMSG ghost :4480 / 1" with
    | Candy1Said (4480, 1) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy1ParserWhenNoSpace () =
    match "Candy@root-me.org PRIVMSG ghost :44/41" with
    | Candy1Said (44, 41) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy1ParserWhenMoreSpaces () =
    match "Candy@root-me.org PRIVMSG ghost :    4   /     481     " with
    | Candy1Said (4, 481) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy2Parser () =
    match "Candy@root-me.org PRIVMSG ghost :QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=" with
    | Candy2Said "AxcTNQ711lRbUieYZWJOTS2mdhjCY" -> ()
    | _ -> failwithf "Cannot find what Candy said"

[<Test>]
let Candy2ParserWhenMoreSpaces () =
    match "Candy@root-me.org PRIVMSG ghost :   QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=" with
    | Candy2Said "AxcTNQ711lRbUieYZWJOTS2mdhjCY" -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy3Parser () =
    match "Candy@root-me.org PRIVMSG ghost :gcGYR4aZjTgxy7w" with
    | Candy3Said str -> str |> should equal "tpTLE4nMwGtkl7j"
    | _ -> failwith "Cannot find what Candy said"
    
[<Test>]
let Candy3ParserWhenMoreSpaces () =
    match "Candy@root-me.org PRIVMSG ghost :     gcGYR4aZjTgxy7w    " with
    | Candy3Said str -> str |> should equal "tpTLE4nMwGtkl7j"
    | _ -> failwith "Cannot find what Candy said"