module KeyConcepts

type Shape =
    | Circle of radius:int
    | Rectangle of height:int * width:int
    | Point of x:int * y:int
    | Polygon of pointList:(int * int) list

let draw (shape:Shape) =
    match shape with 
    | Circle radius -> printf "Circle Radius %d\n" radius
    | Rectangle (height, width) -> printf  "Rectangle %dx%d\n" height width
    | Polygon points -> printf "Polygon of points %A\n" points
    | _ -> printf "Not supported"

let circle = Circle(10)
let rect = Rectangle(4,5)
let point = Point(33,12)
let polygon = Polygon([(1,3); (2,3); (3,3)])

[<EntryPoint>]
let main argv =
    [circle; rect; point; polygon] |> List.iter draw
    0 // return an integer exit code
