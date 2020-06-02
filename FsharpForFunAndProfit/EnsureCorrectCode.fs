module EnsureCorrectCode

type EmailAddress = EmailAddress of string

let sendEmail (EmailAddress email) = 
    printfn "Send an email to %s" email

let aliceEmail = EmailAddress "alice@example.com"


[<Measure>]
type cm

[<Measure>]
type inches

[<Measure>]
type feet = 
    static member toInches(feet : float<feet>) : float<inches> =
        feet * 12.0<inches/feet>

let meter = 100.0<cm>
let yard = 3.0<feet>

let yardInInches = feet.toInches(yard)

[<Measure>]
type GBP

[<Measure>]
type USD

let gbp10 = 10.0<GBP>
let usd10 = 10.0<USD>

[<NoEquality; NoComparison>]
type CustomerAccout = { CustomerAccoutId: int }

let x = { CustomerAccoutId = 1 }

//[<EntryPoint>]
//let main argv =
//    sendEmail aliceEmail
//    yardInInches |> printfn "Yards in inches: %f" 
//    (gbp10 + gbp10) |> printfn "Added Pounds: %f"

//    //Error sendEmail "Garytheclown@example.com"

//    0 // return an integer exit code

