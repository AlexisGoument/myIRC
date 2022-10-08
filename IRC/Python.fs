module Python

open System.Diagnostics

let runScript script arguments =
    let arguments = (@"C:\Projets\RootMe\myIRC\IRC\scripts\" + script + ".py")::arguments
    let p = new Process(
        StartInfo = new ProcessStartInfo(
            FileName = @"python.exe",
            Arguments = String.concat " " arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = false
        )
    )
    if p.Start() |> not then
        failwith "Python script couldn't start"

    let mutable line = ""
    while not p.StandardOutput.EndOfStream do
        line <- p.StandardOutput.ReadLine()
        printfn "python> %s" line

    p.WaitForExit()
    line