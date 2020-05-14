module PatternMatchingForConciseness

let firstPart, secondPart, _ = (1,2,3)

let elem1::elem2::rest = [1..10]

let listMatcher aList =
    match aList with
    | [] -> printfn "The list was empty"
    | [oneElement] -> printfn "this list has one element %A" oneElement
    | [first; second] -> printfn "lsit is %A and %A" first second
    | _ -> printfn "the list has more than two elements"

type Address = { Street: string; City: string;}
type Customer = { ID: int; Name: string; Address: Address; }

let customer1 = {   
                    ID = 1; 
                    Name = "Bob"; 
                    Address = { Street ="1234 main"; City = "WA" } 
                }

//Extracting Name of customer into variable name1
let { Name = name1 } = customer1

let { ID = id2; Name = name2 } = customer1

let { Name = name3; Address = { Street = street3 } } = customer1

//[<EntryPoint>]
//let main argv =
//    listMatcher [1;2;3;4] //more
//    listMatcher [1;2] // 1 , 2
//    listMatcher [1] // 1
//    listMatcher [] // []
//    printfn "The customer is called %s" name1
//    printfn "The customer called %s has id %i" name2 id2
//    printfn "The customer is called %s and lives on the street %s" name3 street3
//    0 // return an integer exit code

