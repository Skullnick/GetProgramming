// Learn more about F# at http://fsharp.org

open System
open System.IO
open Domain
open Operations
open Audit

let isValidCommand (command: char) = 
    if command = 'w' || command = 'd' || command = 'x' then true else false

let isStopCommand (command: char) =
    if command = 'x' then true else false

let getAmount (command :char) =
    match command with
    | 'w' -> ('w', 25M)
    | 'd' -> ('d', 50M)
    | _ -> ('x', 0M)

let processCommand account amount =
    match amount with
    | ('w', value) -> withdraw value account
    | ('d', value) -> deposit value account
    | _ -> account

[<EntryPoint>]
let main argv =

    //let withdrawWithConsole = auditAs "withdraw " auditToConsole withdraw 
    //let depositWithConsole = auditAs "deposit " auditToConsole deposit 
    //let withdrawWithFile = auditAs "withdraw " auditToFile withdraw 
    //let depositWithFile = auditAs "deposit " auditToFile deposit

    let sampleCustomer = {Name = "Nick"; Id = System.Guid.NewGuid()}
    let sampleAccount = {AccountID = System.Guid.NewGuid(); Customer = sampleCustomer; Balance = 500M}

    //sampleAccount
    //|> withdrawWithConsole 50M
    //|> depositWithConsole 100M
    //|> withdrawWithConsole 1000M
    //|> withdrawWithConsole 550M
    //|> ignore
    let consoleCommands = seq {
        while true do
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar }

    0 // return an integer exit code
