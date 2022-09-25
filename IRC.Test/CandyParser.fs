module IRC.Test

open NUnit.Framework
open IRCClient

[<Test>]
let CandyParser () =
    match "Candy@root-me.org PRIVMSG ghost :370 / 5719" with
    | CandySaid (370, 5719) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let CandyParserWhenPrefix () =
    match "azdazdazdCandy@root-me.org PRIVMSG ghost :4480 / 1" with
    | CandySaid (4480, 1) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let CandyParserWhenNoSpace () =
    match "Candy@root-me.org PRIVMSG ghost :44/41" with
    | CandySaid (44, 41) -> ()
    | _ -> failwith "Cannot find what Candy said"

[<Test>]
let CandyParserWhenMoreSpaces () =
    match "Candy@root-me.org PRIVMSG ghost :    4   /     481     " with
    | CandySaid (4, 481) -> ()
    | _ -> failwith "Cannot find what Candy said"
