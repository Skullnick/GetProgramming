#load "Domain.fs"
#load "Operations.fs"

open Domain
open Operations
open System

let sampleCustomer = {Name = "Nick"; Id = Guid.NewGuid()}
let sampleAccount = {AccountID = Guid.NewGuid(); Customer = sampleCustomer; Balance = 500M}

let isValidCommand (command: string) = 
    if command = "w" || command = "d" || command = "x" then true else false

let isStopCommand (command: string) =
    if command = "x" then true else false

let getAmount (command :string) =
    match command with
    | "w" -> ("w", 25M)
    | "d" -> ("d", 50M)
    | _ -> ("x", 0M)

let processCommand account amount =
    match amount with
    | ("w", value) -> withdraw value account
    | ("d", value) -> deposit value account
    | _ -> account

let commands = ["d"; "d"; "d"; "w"; "w"; "f"; "o"; "x"]

commands
|> Seq.filter isValidCommand
|> Seq.takeWhile (not << isStopCommand)
|> Seq.map getAmount
|> Seq.fold processCommand sampleAccount