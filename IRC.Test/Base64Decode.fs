module Base64Decode

open NUnit.Framework
open FsUnit
open Base64

[<TestCase("QXhjVE5RNzExbFJiVWllWVpXSk9UUzJtZGhqQ1k=", "AxcTNQ711lRbUieYZWJOTS2mdhjCY")>]
[<TestCase("SnpEUDRZNkloRlA=", "JzDP4Y6IhFP")>]
let Base64Decode encoded expectedResult =
    decode encoded |> should equal expectedResult