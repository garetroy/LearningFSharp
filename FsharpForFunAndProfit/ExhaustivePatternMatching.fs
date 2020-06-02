module ExhaustivePatternMatching

type State = New | Draft | Published | Inactive | Discontinued
let handleState state = 
    match state with 
    | New -> printfn "New"
    | Draft -> printfn "Draft"
    | Inactive -> printfn "Inactive"
    | Discontinued -> printfn "Discontinued"
    | _ -> printfn "Published"

let getFileInfo filePath = 
    let fi = new System.IO.FileInfo(filePath)
    if fi.Exists then Some(fi) else None

let goodFileName = "good.txt"
let badFileName = "bad.txt"

let processFileInfo filePath =
    let fileInfo = getFileInfo filePath
    match fileInfo with
    | Some fileInfo -> printfn "The file %s Exists" fileInfo.FullName
    | None -> printfn "The file does not Exist"

let rec movingAverages list = 
    match list with
    | [] -> []
    | x::y::rest ->
        let avg = (x+y)/2.0
        avg :: movingAverages (y::rest)
    | [_] -> []

let loggingAverages input =
    movingAverages input |> printfn "Averages of %A is %A" input 

//[<EntryPoint>]
//let main argv =
//    handleState Published 
//    processFileInfo goodFileName
//    processFileInfo badFileName
//    loggingAverages []
//    loggingAverages [1.0]
//    loggingAverages [1.0..3.0]
//    0 // return an integer exit code

