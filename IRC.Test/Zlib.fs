module Zlib

open NUnit.Framework
open FsUnit
open Python

[<TestCase("eJxzrHItCqn0zC8AABBiA2g=", "AzErTyIop")>]
let ZlibDecompress encoded expectedResult =
    [encoded]
    |> runScript "zlib"
    |> should equal expectedResult
