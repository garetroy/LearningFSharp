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

type FluentShape = {
    label : string;
    color : string;
    onClick: FluentShape -> FluentShape 
}

let defaultShape = {
    label = "";
    color = "";
    onClick = fun shape->shape
}

let click (shape:FluentShape) = 
    shape.onClick shape

let display (shape:FluentShape) = 
    printfn "My label=%s and my color %s" shape.label shape.color
    shape

let setLabel label shape =
    {shape with FluentShape.label = label}

let setColor color shape = 
    {shape with FluentShape.color = color}

let appendClickAction action shape = 
    {shape with FluentShape.onClick = shape.onClick >> action}

let setRedBox = setColor "red" >> setLabel "box"
let setBlueBox = setRedBox >> setColor "blue"

let changeColorOnClick color = appendClickAction (setColor color)

let redBox = defaultShape |> setRedBox
let blueBox = defaultShape |> setBlueBox

let redAction = redBox
                    |> display
                    |> changeColorOnClick "green"
                    |> click
                    |> display

let blueAction = blueBox 
                    |> display
                    |> appendClickAction (setLabel "box2" >> setColor "green")
                    |> click
                    |> display

let rainbow =
    ["red";"orange";"yellow";"green";"blue";"indigo";"violet"]

let showRainbow = 
    let setColorAndDisplay color = setColor color >> display
    rainbow
    |> List.map setColorAndDisplay
    |> List.reduce (>>)

let showRainbowAction = defaultShape |> showRainbow

type Point = {
    x : float;
    y : float;
    z : float;
}

let pow2Subtracted x y = (x - y) ** 2.0    

let getWidth points =
    match points with
        | [] -> -1.0
        | _ -> (pow2Subtracted points.[1].x points.[0].x) + (pow2Subtracted points.[1].y points.[0].y) |> sqrt  

let getHeight points =
    match points with
        | [] -> -1.0
        | _ -> (pow2Subtracted points.[2].x points.[1].x) + (pow2Subtracted points.[2].y points.[1].y) |> sqrt  

let logWidth points = points |> getWidth |> printf "%fx"; points
let logHeight points = points |> getHeight |> printf "%f"; points 

let logDim = logWidth >> logHeight 

type Color = Red | Blue | Yellow | White | Black
let logColor color =
    match color with
        | Red -> printf "Red"
        | Blue -> printf "Blue"
        | Yellow -> printf "Yellow"
        | White -> printf "White"
        | Black -> printf "Black"
        | _ -> printf "NoColor"
    color


type Shape3D = {
    Color : Color;
    Points: Point list;
    Width: Point list -> float;
    Height: Point list-> float;
    Log: Point list -> Point list  
}

let firstPoint = {
    x = 0.0
    y = 10.0
    z = 12.0
}

let secondPoint = {
    x = -12.0
    y = 3.0
    z = 5.0
}

let thirdPoint = {
    x = 4.0
    y = -5.0
    z = 19.0
}

let defaultPoints = [firstPoint; secondPoint; thirdPoint;]

//Faild... will try again with more knowledge
//let defaultShape = {
//    Color = Color.Black;
//    Points = defaultPoints;
//    Width = this.Points |> getWidth;
//    Height = this.Points |> getHeight;
//    Log = this.Points  |> logDim
//}

[<EntryPoint>]
let main argv =
    map2
    //map3
    //map4
    //map5
    //map6
    //mult3ThenSquareLog 3
    //applyListMult3 [1;392]
    //allFunctions 3
    getDate 5 Days Ago
    redAction
    blueAction
    showRainbow
    0 // return an integer exit code

