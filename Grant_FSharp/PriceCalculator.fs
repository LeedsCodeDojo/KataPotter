module PriceCalculator

type Book = 
    | Goblet
    | Wizard

type Calculator(bookPrice, discounts:Map<int,float>) =
    member this.GetPrice books =

        let discountPercent = 
            match books with
            | x::y::z::[] when x=y&&y=z -> discounts.[3]
            | x::y::[] when x=y -> discounts.[2]
            | _ -> 0.0

        let price = bookPrice * float (List.length books)

        price - (price / 100.0 * discountPercent)
