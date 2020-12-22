module Audit

open System
open System.IO
open Domain
open Operations

let getAccountFolderPath (account:Account) = 
     @"C:\Nick\Dev\FSharp\Output\" + account.Customer.Name + "\\" + string account.AccountID

let getAccountFilePath (account:Account) =
    getAccountFolderPath account + "\\Operations.txt"
  
let createAccountFile (account:Account)=
    let folderPath = getAccountFolderPath account
    let filePath = getAccountFilePath account
    let accountCreationMessage = "Account: " + string account.AccountID + " created."
    if not (Directory.Exists folderPath) then Directory.CreateDirectory folderPath |> ignore
    if not (File.Exists(filePath)) then File.WriteAllText(filePath, accountCreationMessage + Environment.NewLine)

let auditToFile (account: Account) (message: string) =
    let filePath = getAccountFilePath account
    if not (File.Exists filePath) then createAccountFile account
    File.AppendAllText(filePath, message + Environment.NewLine)

let auditToConsole (account: Account) (message: string) =
    let outputMessage = "Account: " + string account.AccountID + ": " + message
    Console.WriteLine(outputMessage)

let auditAs operationName audit operation (amount: decimal) (account: Account) =
    audit account ("Performing a " + operationName + " operation for " + string amount + "$")
    let newAccount = operation amount account
    if newAccount.Balance = account.Balance then
        audit account "Transaction Failed."
    else
        audit account ("Transaction accepeted! New Balance is : " + string newAccount.Balance + "$")
    newAccount
