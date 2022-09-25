module IRCClient

open System.Net.Sockets
open System.IO
open System.Threading
open System

let nickname = "ghost"

let (|CandySaid|_|) (str: string) =
    let template = sprintf "Candy@root-me.org PRIVMSG %s :" nickname //370 / 5719"
    if (str.Contains template) then
        let part =
            str.Split ":"
            |> Array.last
        part.Split "/"
        |> function
            | [|a;b|] -> Some(int a, int b)
            | s ->
                // let ss = String.concat ":" s
                // failwithf "fail with Candy saying unexpected numbers: %s" ss
                None
    else None

let compute nb1 nb2 =
    let nb = (sqrt (float nb1)) * (float nb2)
    Math.Round(nb, 2)

type IRCClient(server, port) =
    let client = new TcpClient(server, port)
    let stream = client.GetStream()
    let streamReader = new StreamReader(stream)
    let streamWriter = new StreamWriter(stream)
    let cancellationToken = new CancellationTokenSource()

    interface IDisposable with
        member x.Dispose() =
            if not cancellationToken.IsCancellationRequested then
                cancellationToken.Cancel()

    member this.Send (str: string) =
        printfn "--sending: %s" str
        streamWriter.WriteLine(str)

    member this.Command cmd =
        match cmd with
        | "quit" | "exit" -> Environment.Exit(0)
        | str -> this.Send str

    member this.Join room =
        async {
            sprintf "JOIN %s" room |> this.Send 
            do! Async.Sleep 3000
        }

    member this.SendTo(name, msg) =
        sprintf "PRIVMSG %s %s" name msg
        |> this.Send

    member this.Listen() =
        async {
            while true do
                if not streamReader.EndOfStream then
                    let str = streamReader.ReadLine()
                    match str with
                    | CandySaid (nb1, nb2) ->
                        Console.WriteLine str
                        let nb =
                            compute nb1 nb2
                            |> sprintf "!ep1 -rep %f"
                        this.SendTo("Candy", nb)
                    | _ -> Console.WriteLine str
        }

    member this.ConnectAndListen() =
        async {
            Async.Start(this.Listen(), cancellationToken.Token)
            sprintf "USER %s %s %s %s" nickname nickname nickname nickname |> this.Send 
            streamWriter.AutoFlush <- true
            sprintf "NICK %s" nickname |> this.Send 
            do! Async.Sleep 3000
        }
