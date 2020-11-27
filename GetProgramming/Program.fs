// Learn more about F# at http://fsharp.org

open System
open System.IO
open Domain
open Operations

[<EntryPoint>]
let main argv =
    let Joe = {FirstName = "Joe"; LastName="Blob"; Age= 22}
    if Joe |> isOlderThan 25 then printfn "Joe is an old cowboy" else printfn "Young Man!"
    0 // return an integer exit code
