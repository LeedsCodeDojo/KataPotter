module PriceCalculator_Tests

open PriceCalculator
open FsUnit
open Xunit

[<Fact>]
let ``whatever`` () =
    calc 123 |> should equal 0