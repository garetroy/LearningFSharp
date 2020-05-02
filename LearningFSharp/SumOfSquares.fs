// Learn more about F# at http://fsharp.org
//https://fsharpforfunandprofit.com/posts/fvsc-quicksort/

module SumOfSquares 

open System

let square x = x * x;

let sumOfSquares n = 
    [1..n] 
    |> List.map square 
    |> List.sum;

let squareF x = x * x;

let sumOfSquareF n =
    [1.0..n]
    |> List.map squareF
    |> List.sum

////[<EntryPoint>]
//let main argv =
//    printfn  "HI"
//    sumOfSquares 4 
//        |> (printfn "%i")
//    sumOfSquareF 2.1 
//        |> (printfn "%f")
//    0 // return an integer exit code

