// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open IRCClient
open System

let mode = "!ep4"

[<EntryPoint>]
let main argv =
    async {
        // let client = new IRCClient("localhost", 6667)
        let client = new IRCClient("irc.root-me.org", 6667)
        do! client.ConnectAndListen mode
        do! client.Join("#root-me_challenge")
        client.SendTo("Candy", mode)
        while true do
            Console.ReadLine() |> client.Command
        return 0 // return an integer exit code
    } |> Async.RunSynchronously