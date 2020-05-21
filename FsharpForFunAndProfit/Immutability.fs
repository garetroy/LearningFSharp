module Immutability

let list1 = [1;2;3;4]
let list2 = 0::list1
let list3 = list2.Tail

//[<EntryPoint>]
//let main argv =
//    printfn "List3 is %A" list3
//    System.Object.ReferenceEquals(list1, list3) |> printf "Same object in memory? %b"
//    0 // return an integer exit code

