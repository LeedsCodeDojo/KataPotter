module PriceCalculator

[<Measure>]
type percent

type Book = 
    | Goblet
    | Wizard
    | Demons
    | Snakes
    | Philosoper

type Calculator(bookPrice, discounts:Map<int,float<percent>>) =
    member this.GetPrice books =

        let rec calculatePrice remainingBooks =
            
            match remainingBooks with
            | [] -> 0.0
            | _ ->
                // group the books by title, including a count of how many
                let bookGroups = remainingBooks |> Seq.countBy id |> List.ofSeq
                
                // build a list of the books which have not had a discount applied
                let remaining = 
                    bookGroups
                    |> List.filter (fun (book,count) -> count > 1)
                    |> List.map fst

                // work out the price (including discount) of the current set of books
                let numDifferentBooks = Seq.length bookGroups
                let discountPercent = float discounts.[numDifferentBooks]
                let undiscountedPrice = bookPrice * (float numDifferentBooks)
                let price = undiscountedPrice - (undiscountedPrice / 100.0 * discountPercent)

                // return the current price plus the price of the remaining books, calculated recursively
                price + (calculatePrice remaining)

        calculatePrice books