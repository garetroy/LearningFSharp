module PartialApplication

let add x y = x + y

let z = add 1 2

let add42 = add 42

let genericLogger2 before after anyFunc input = 
    before input
    let result = anyFunc input
    after result
    result

let add1 input = input + 1

let testLogger = genericLogger2 (fun x -> printfn "Before=%i" x) (fun x -> printfn "After=%i" x) add1 2
let test2Logger = genericLogger2 (fun x -> printfn "StartedWith=%i" x) (fun x -> printfn "EndedWith=%i" x) add1 

//[<EntryPoint>]
//let main argv =
//    add42 2 |> printfn "Add42 2 %d"
//    add42 3 |> printfn "Add42 3 %d"
//    testLogger |> test2Logger
//    [1..3] |> List.map test2Logger
//    0 // return an integer exit code
