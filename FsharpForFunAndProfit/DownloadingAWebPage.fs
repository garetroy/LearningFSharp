module DownloadingAWebPage

open System.Net
open System
open System.IO

let fetchUrl callback url =
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    callback reader url

let myCallback (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let html1000 = html.Substring(0, 1000)
    printfn "Downloaded %s. First 1000 is %s" url html1000
    html

let google = fetchUrl myCallback "http://google.com"

let bakedIn = fetchUrl myCallback

let sites = ["http://google.com"; 
                "http://bing.com"; 
                "http://myspace.com"]

//[<EntryPoint>]
//let main argv =
//    sites |> List.map bakedIn 
//    0 // return an integer exit code


