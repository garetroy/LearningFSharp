module ConvenienceFunctionsAsInterfaces

open System

let addingCalculator input = input + 1
let loggingCalculator innerCalculator input = 
    printfn "Input is %A" input
    let result = innerCalculator input
    printfn "Result is %A" result
    result

let add1 input = input + 1
let times2 input = input * 2

let genericLogger anyFunc input = 
    printfn "Input is %A" input
    let result = anyFunc input
    printfn "Result is %A" result
    result 

let add1WithLogging = genericLogger add1
let times2WithLogging = genericLogger times2

let genericTimer anyFunc input = 
    let stopwatch = System.Diagnostics.Stopwatch()
    stopwatch.Start()
    let result = anyFunc input
    printfn "Elapsed ms is %d" stopwatch.ElapsedMilliseconds
    result

let add1WithTimer = genericTimer add1WithLogging


type Animal(noiseMakingStrategy) = 
    member this.MakeNoise = 
        noiseMakingStrategy() |> printfn "Making noise %s" 

let meowing() = "Meow"
let cat = Animal(meowing)

let woofOrBark() = if (DateTime.Now.Millisecond % 2 = 0)
                        then "Woof" else "Bark"

let dog = Animal(woofOrBark)

[<EntryPoint>]
let main argv =
    loggingCalculator addingCalculator 5
    add1WithLogging 15
    times2WithLogging 15
    [1..5] |> List.map add1WithLogging
    add1WithTimer 99
    cat.MakeNoise
    dog.MakeNoise
    dog.MakeNoise
    0 // return an integer exit code
