module Asynchronousprogramming

open System
open System.Threading

let userTimerWithCallback = 
    let event = new System.Threading.AutoResetEvent(false)

    let timer = new System.Timers.Timer(2000.0)
    timer.Elapsed.Add (fun _ -> event.Set() |> ignore)

    printfn "Waiting for timer at %O" DateTime.Now.TimeOfDay
    timer.Start()

    printfn "Doing something useful while waiting for an event"

    event.WaitOne() |> ignore

    printfn "Timer ticked at %O" DateTime.Now.TimeOfDay

let userTimerWithAsync = 
    let timer = new System.Timers.Timer(2000.0)
    let timerEvent = Async.AwaitEvent (timer.Elapsed) |> Async.Ignore

    printfn "Waiting for timer at %O" DateTime.Now.TimeOfDay
    timer.Start()

    printfn "doing something else useful while waiting for the event"

    Async.RunSynchronously timerEvent

    printfn "Timer ticket at %O" DateTime.Now.TimeOfDay

let filterWriteWithAsync = 
    use stream = new System.IO.FileStream("test2.txt", System.IO.FileMode.Create)

    printfn "Starting async write"
    let asyncResult = stream.BeginWrite(Array.empty, 0, 0, null, null)

    let async = asyncResult |> Async.AwaitIAsyncResult

    printfn "Doing something useful while waiting for write to complete"

    async |> ignore

    printfn "Async write completed"

let sleepWorkflow = async {
    printfn "Starting sleep workflow at %O" DateTime.Now.TimeOfDay
    do! Async.Sleep 2000
    printfn "Finished sleep workflow at %O" DateTime.Now.TimeOfDay
}

let nestedWorkflow = async {
    printfn "Starting parent"
    let! childWorkflow = Async.StartChild sleepWorkflow

    do! Async.Sleep 100
    printfn "Doing something useful while waiting"

    let! result = childWorkflow
    printfn "Finished parent"
}

let testLoop = async {
    for i in [1..100] do
        printf "%i before.." i

        do! Async.Sleep 10
        printfn "..after"
}

let cancelLoop = 
    use cancellationSource = new CancellationTokenSource()

    Async.Start (testLoop, cancellationSource.Token)

    Thread.Sleep(200)

    cancellationSource.Cancel()

    printfn "CancelledLoop"

let sleepWorkflowMs ms = async {
    printfn "%i ms workflow started" ms
    do! Async.Sleep ms
    printfn "%i ms workflow finsihed" ms
}

let workflowInSeries = async {
    let! sleep1 = sleepWorkflowMs 1000
    printfn "Finished one"
    let! sleep2 = sleepWorkflowMs 2000
    printfn "Finsihed two"
}

let sleep1 = sleepWorkflowMs 1000
let sleep2 = sleepWorkflowMs 2000

let runTime = [sleep1; sleep2]
                |> Async.Parallel
                |> Async.RunSynchronously

[<EntryPoint>]
let main argv =
    userTimerWithCallback
    userTimerWithAsync
    filterWriteWithAsync
    Async.RunSynchronously sleepWorkflow 
    Async.RunSynchronously nestedWorkflow
    cancelLoop 
    Async.RunSynchronously workflowInSeries
    runTime
    0 // return an integer exit code
