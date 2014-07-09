module PriceCalculator_Tests

open PriceCalculator
open FsUnit
open Xunit

let bookPrice = 5.0
let discounts =
    Map.empty
        .Add(1, 0.0<percent>)
        .Add(2, 5.0<percent>)
        .Add(3, 10.0<percent>)
        .Add(4, 20.0<percent>)
        .Add(5, 25.0<percent>)
let calc = Calculator(bookPrice, discounts)

[<Fact>]
let ``single books gives single book price`` () =
    calc.GetPrice [Goblet] |> should equal bookPrice

[<Fact>]
let ``two same books gives undiscounted price`` () =
    calc.GetPrice [Goblet;Goblet] |> should equal (bookPrice*2.0)

[<Fact>]
let ``different books gives discounted price`` () =
    calc.GetPrice [Goblet;Wizard] |> should equal 9.5 // 5*2-5%
    calc.GetPrice [Goblet;Wizard;Demons] |> should equal 13.5 // 5*3-10%
    calc.GetPrice [Goblet;Wizard;Demons;Snakes] |> should equal 16.0 // 5*4-20%
    calc.GetPrice [Goblet;Wizard;Demons;Snakes;Philosoper] |> should equal 18.75 // 5*5-25%

[<Fact>]
let ``mix of different and same books applies discount to different ones`` () =
    calc.GetPrice [Goblet;Demons;Goblet] |> should equal 14.5 // 5*2-5% + 5

[<Fact>]
let ``multiple sets of same books applies discounts`` () =
    calc.GetPrice [Goblet;Demons;Goblet;Demons;Wizard;Philosoper] |> should equal 25.5 // 5*2-5% + 5*4-20%