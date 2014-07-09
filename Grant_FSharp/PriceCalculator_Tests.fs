module PriceCalculator_Tests

open PriceCalculator
open FsUnit
open Xunit

let bookPrice = 5.0
let discounts =
    Map.empty
        .Add(2, 5.0)
        .Add(3, 10.0)
let calc = Calculator(bookPrice, discounts)

//discounts
//2 - 5%
//3 - 10%

[<Fact>]
let ``single books gives single book price`` () =
    calc.GetPrice [Goblet] |> should equal bookPrice

[<Fact>]
let ``two different books gives undiscounted price`` () =
    calc.GetPrice [Goblet;Wizard] |> should equal (bookPrice*2.0)

[<Fact>]
let ``two same books gives discounted price`` () =
    calc.GetPrice [Goblet;Goblet] |> should equal 9.5

[<Fact>]
let ``three same books gives discounted price`` () =
    calc.GetPrice [Goblet;Goblet;Goblet] |> should equal 13.5