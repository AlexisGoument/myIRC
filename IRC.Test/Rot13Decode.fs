module Rot13Decode

open NUnit.Framework
open FsUnit
open Rot13

[<TestCase("gcGYR4aZjTgxy7w", "tpTLE4nMwGtkl7j")>]
let Rot13Decode encoded expectedResult =
    decode encoded |> should equal expectedResult