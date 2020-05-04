module ExtracingBoilerplate

let product n = 
    let initialValue = 1
    let action productSoFar x = productSoFar * x
    [1..n] |> List.fold action initialValue 

let sumOfOdds n =
    let initialValue = 1
    let action sumSoFar x = if x%2=0 then sumSoFar else sumSoFar+x
    [1..n] |> List.fold action initialValue

let alternatingSum n =
    let initialValue = (true, 0)
    let action (isNeg, sumSoFar) x = if isNeg then (false, sumSoFar-x) else (true, sumSoFar+x)
    [1..n] |> List.fold action initialValue |> snd

let sumOfSquareWithFold n =
    let initialValue = 0
    let action sumSoFar x = sumSoFar + x*x
    [1..n] |> List.fold action initialValue

type num = int

let getMax n = 
    let initialValue = num.MinValue
    let action currentMax x = if currentMax > x then currentMax else x
    [1..n] |> List.fold action initialValue

let getMaxInArray A = 
    match A with
    | [] ->
        0 
    | first :: rest ->
        let action currentMax x = if currentMax > x then currentMax else x
        A |> List.fold action first

[<EntryPoint>]
let main argv =
    printf "%d\n" (product 4)
    printf "%d\n" (sumOfOdds 3)
    printf "%d\n" (alternatingSum 4)
    printf "%d\n" (sumOfSquareWithFold 3)
    printf "%d\n" (getMaxInArray [3;4;133;42])
    0 // return an integer exit code

