module OutOfTheBox

type PersonalName = { FirstName:string; LastName:string }

type USAddress = 
    { Street:string; City:string; State:string; Zip:string}
type UKAddress =
    { Street:string; Town:string; PostCode:string }

type Address = 
    | US of USAddress
    | UK of UKAddress

type Person = 
    { Name:string; Address:Address }

let alice = {
    Name = "Alice";
    Address = US { Street="123 Main"; City="Portland"; State="OR"; Zip="97202" }}

let bob = {
    Name = "Bob";
    Address = UK { Street = "123 Mainnn"; Town="Govna"; PostCode="9123A" }}

type Suit = Club | Diamond | Spade | Heart
type Rank = Ace | Two | Three | Four | Five | Six | Seven | Eight
                | Nine | Ten | Jack | Queen | King

let compareCard card1 card2 = 
    if card1 < card2
    then printfn "%A is greather than %A" card2 card1
    else printfn "%A is greather than %A" card1 card2

let TwoClubs = Club, Two
let KingHearts = Heart, King
let QueenHearts = Heart, Queen

let hand = [ TwoClubs; Diamond, Five; KingHearts; QueenHearts]

[<EntryPoint>]
let main argv =
    printfn "Alice is %A" alice
    printfn "Bob is %A" bob 
    printfn "Bob is alice %A" (bob=alice)
    printfn "Bob is bob %A" (bob=bob)
    compareCard TwoClubs KingHearts
    compareCard KingHearts QueenHearts
    List.sort hand |> printfn "Sorted hand is %A"
    List.max hand |> printfn "High card is %A"
    List.min hand |> printfn "Low card is %A"
    0 // return an integer exit code
