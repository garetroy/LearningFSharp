module Sorting

open System

let rec quicksort list =
    match list with
    | [] ->
        []
    | firstElem::otherElements ->
        let smallerElements =
            otherElements
            |> List.filter (fun e -> e < firstElem)
            |> quicksort
        let largerElements = 
            otherElements
            |> List.filter (fun e -> e >= firstElem)
            |> quicksort
        List.concat [smallerElements; [firstElem]; largerElements]

let rec quicksort2 = function
    | [] -> []
    | first::rest ->
        let smaller,larger = List.partition ((>=) first) rest
        List.concat [quicksort2 smaller; [first]; quicksort2 larger]
        
//[<EntryPoint>]
//let main argv =
//    printfn  "HI"
//    quicksort [1;53;123;4;231;4;2;3] |> printf "%A"
//    quicksort [423;1;422;3;15;3;4] |> printf "%A"
//    0 // return an integer exit code

