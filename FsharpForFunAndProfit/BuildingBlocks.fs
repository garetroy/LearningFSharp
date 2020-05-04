module BuildingBlocks 

let add2 x = x + 2
let mult3 x = x * 3
let square x = x * x

let map2 = [1..10] |> List.map add2 |> printf "%A\n"
let map3 = [1..10] |> List.map mult3 |> printf "%A\n"
let map4 = [1..10] |> List.map square |> printf "%A\n"

let add2ThenMult3 = add2 >> mult3
let mult3ThenSqure = mult3 >> square

let map5 = [1..10] |> List.map add2ThenMult3 |> printf "%A\n"
let map6 = [1..10] |> List.map mult3ThenSqure |> printf "%A\n"

let logMsg location msg (value:int) = printf "Location: %s\n\t Message: %s\n\t Value: %i\n" location msg value; value 

let mult3ThenSquareLog =
    logMsg "mult3ThenSqureLog" "--Before--"
    >> mult3
    >> logMsg "mult3ThenSqureLog" "--Current--"
    >> square 
    >> logMsg "mult3ThenSquareLog" "--Result--"

let applyListMult3 A = A |> List.map mult3ThenSquareLog

let listOfFunctions = [mult3; square; add2; logMsg "RunAll" "Result"]

let allFunctions = List.reduce (>>) listOfFunctions

//Mini Languages
type DateScale = Hour | Hours | Day | Days | Week | Weeks
type DateDirection = Ago | Hence

let getDate interval scale direction = 
    let absHours = match scale with
        | Hour | Hours -> 1 * interval
        | Day | Days -> 24 * interval
        | Week | Weeks -> 24 * 7 * interval
    let signedHours = match direction with
        | Ago -> -1 * absHours  
        | Hence -> absHours

    System.DateTime.Now.AddHours(float(signedHours))

[<EntryPoint>]
let main argv =
    map2
    map3
    map4
    map5
    map6
    mult3ThenSquareLog 3
    applyListMult3 [1;392]
    allFunctions 3
    getDate 5 Days Ago
    0 // return an integer exit code

