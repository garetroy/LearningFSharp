module DesiginingForCorrectness

type CartItem = string

type EmptyState = NoItems

type ActiveState = { UnpaidItems : CartItem list; }
type PaidForState = { PaidItems : CartItem list; 
                        Payment : decimal }

type Cart =
    | Empty of EmptyState
    | Active of ActiveState
    | PaidFor of PaidForState

let addToEmptyState item = 
    Active { UnpaidItems = [item] }

let addToActiveState state itemToAdd = 
    let newList = itemToAdd :: state.UnpaidItems
    Active { state with UnpaidItems = newList }

let removeFromActiveState state itemToRemove =
    let newList = state.UnpaidItems |> List.filter (fun i -> i<>itemToRemove)
    match newList with
    | [] -> Cart.Empty NoItems
    | _ -> Cart.Active { state with UnpaidItems=newList }

let payForActiveState state amount = 
    PaidFor { PaidItems = state.UnpaidItems; Payment = amount }

type EmptyState with
    member this.Add = addToEmptyState

type ActiveState with
    member this.Add = addToActiveState this
    member this.Remove = removeFromActiveState this
    member this.Pay = payForActiveState this

let addItemToCart cart item = 
    match cart with
    | Empty state -> state.Add item
    | Active state -> state.Add item
    | PaidFor state ->
        printfn "ERROR: The cart has already been paid for"
        cart

let removeItemFromCart cart item =
    match cart with
    | Empty state ->
        printfn "ERROR: The cart is empty"
        cart
    | Active state ->
        state.Remove item
    | PaidFor state ->
        printfn "ERROR: The cart has already been paid for"
        cart

let displayCart cart = 
    match cart with
    | Empty state -> 
        printfn "The cart is empty"
    | Active state ->
        printfn "The cart contains %A unpaid items" state.UnpaidItems
    | PaidFor state ->
        printfn "The cart contains %A paid items. Amoutn paid: %f"
            state.PaidItems state.Payment

type Cart with
    static member NewCart = Cart.Empty NoItems
    member this.Add = addItemToCart this
    member this.Remove = removeItemFromCart this
    member this.Display = displayCart this

let emptyCart = Cart.NewCart

let cartA = emptyCart.Add "A"
let cartAB = cartA.Add "B"
let cartB = cartAB.Remove "A"
let emptyCart2 = cartB.Remove "B"

//Print Errors
let emptyCart3 = emptyCart2.Remove "B"

let cartPaid cart = 
    match cart with 
    | Empty _ 
    | PaidFor _ -> cart 
    | Active state -> state.Pay 100m

[<EntryPoint>]
let main argv =
    printf "EmptyCart ->"; emptyCart.Display
    printf "cartA ->"; cartA.Display
    printf "cartAB ->"; cartAB.Display
    printf "cartB ->"; cartB.Display
    printf "emptyCart2 ->"; emptyCart2.Display
    printf "emptyCart3 ->"; emptyCart3.Display
    printf "cartAPaid ->"; (cartPaid cartA).Display
    printf "emptyCartPaid ->"; (cartPaid emptyCart).Display
    0 // return an integer exit code
