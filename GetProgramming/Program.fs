// Learn more about F# at http://fsharp.org

open System
open System.IO
open Domain
open Operations
open Audit

[<EntryPoint>]
let main argv =

    let withdrawWithConsole = auditAs "withdraw " auditToConsole withdraw 
    let depositWithConsole = auditAs "deposit " auditToConsole deposit 
    let withdrawWithFile = auditAs "withdraw " auditToFile withdraw 
    let depositWithFile = auditAs "deposit " auditToFile deposit

    let sampleCustomer = {Name = "Nick"; Id = System.Guid.NewGuid()}
    let sampleAccount = {AccountID = System.Guid.NewGuid(); Customer = sampleCustomer; Balance = 500M}

    sampleAccount
    |> withdrawWithConsole 50M
    |> depositWithConsole 100M
    |> withdrawWithConsole 1000M
    |> withdrawWithConsole 550M
    |> ignore

    0 // return an integer exit code
