open System
open System.IO

let print (item: int) = 
    System.Console.WriteLine(item.ToString())

let printList list =
    List.map print list

let countWords (sentence: string) = 
    let words = sentence.Split(' ') // split expects a char - carefull
    ["'" + sentence + "' is [" + words.Length.ToString() + "] words long"]

let ToStringArr (list: string list) =
    List.toArray list

let saveToDisk lines =
     System.IO.File.WriteAllLines(@"C:\Work\FSharp\test.txt", lines);

let words = countWords "Hello My Name is Nick"
saveToDisk (ToStringArr words)

(* Unit 2 - Lesson 6 *)
let drive(petrol, distance) =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let drive2(petrol, distance) =
    if distance > 50 then petrol / 2.0
    elif distance > 25 then petrol - 10.0
    elif distance > 0 then petrol - 1.0
    else petrol

let drive3(petrol, distance) =
    match distance with
    | value when distance > 50 -> petrol / 2.0
    | value when distance > 25 -> petrol - 10.0
    | value when distance > 0 -> petrol - 1.0
    | _ -> petrol

(* Unit 2 - Lesson 7 *)
(* Unit 2 - Lesson 8 *)

let path = @"C:\Work\FSharp\test.txt"
let lastTime = File.GetLastAccessTime(path)
let formattedTime = lastTime.ToString "dd/mm/yyyy"
printfn "Last Time %s" formattedTime

(* Unit 3 - Lesson 9 *)

let splitPerson (person: string) =
    let elements = person.Split(' ')
    let name = elements.[0]
    let game = elements.[1]
    let score = int(elements.[2])
    name, game, score

let addNumbers arguments =
    let a, b, c, _ = arguments
    a + b

(* Unit 3 - Lesson 10 *)
type Car = 
    { Manufacturer: string 
      EngineSize: int
      NumberOfDoors: int }

let BMW : Car = {Manufacturer = "BMW"; EngineSize = 3; NumberOfDoors = 2}

type Address = 
    {Street: string
     City: string
     Country:string}

let ParisAddress = {Street = "Lincoln"; City = "Paris"; Country = "France"}
let CapeAddress = {Street = "Rondebosch"; City = "Cape Town"; Country = "South Africa"}

let isEqual = ParisAddress = CapeAddress
let isRefEqual = System.Object.ReferenceEquals(ParisAddress, CapeAddress)

let OrgevalAddress = { ParisAddress with Street = "Verte Salle"; City = "Orgeval"}

(* Unit 3 - Lesson 11 *)
(*
Partial application and currying
You might have heard the terms curried and partially applied functions before. The two
are sort of related. A curried function is a function that itself returns a function. Partial
application is the act of calling that curried function to get back a new function.
*)

let writeToFile (date: DateTime) filename text =
    let datefilename = date.ToString "ddmmyyyy" + "-" + filename
    let path = @"C:\Work\FSharp\" + datefilename + ".txt"
    File.WriteAllText(path, text);

let writeToTodayFile filename text = writeToFile DateTime.UtcNow.Date filename text
let write text = writeToTodayFile "Default" text 

(* Pipelining*)
let driveTo distance petrol = 
    match distance with
    | "Far" -> petrol / 2.0
    | "Medium" -> petrol - 10.0
    | _ -> 0.0

let startPetrol = 100.0

startPetrol
|> driveTo "Far"
|> driveTo "Medium"
|> printfn "%f"

(* Composing*)

let checkCreation (date: DateTime) =
    if date <= DateTime.Today.AddDays(-7.0) then
        "Old"
    else
        "New"

let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    >> checkCreation

let getDirectoryAge = 
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime

(* Unit 3 - Lesson 12 *)
(* .Organizing code.
Place related types together in namespaces
Place related stateless functions together in modules
*)

type Customer = 
    { Age: int
      Name: string }

let printAge customer =
    if customer.Age >= 18 then Console.WriteLine("Adult")
    elif customer.Age >= 13 then Console.WriteLine("TeenAger")
    else Console.WriteLine("Child")

let printAge2 writer customer = 
    if customer.Age >= 18 then writer "Adult"
    elif customer.Age >= 13 then writer "TeenAger"
    else writer "Child"

let writeTextToFile text = File.WriteAllText(@"C:\Work\FSharp\output.txt", text)

let printToConsoleAge customer = printAge2 Console.WriteLine customer
let writeToFileAge customer = printAge2 writeTextToFile customer

(* Unit 4 - Lesson 15*)

let myArray = [|1; 2; 3; 4; 5|]
let myList = [1; 2; 3; 4; 5]
let newList = myList @ myList