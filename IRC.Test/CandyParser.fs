module CandyParser

open NUnit.Framework
open Candy

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
    | Candy2Said "QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=" -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let Candy2ParserWhenMoreSpaces () =
    match "Candy@root-me.org PRIVMSG ghost :   QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=" with
    | Candy2Said "QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=" -> ()
    | _ -> failwith "Cannot find what Candy said"
