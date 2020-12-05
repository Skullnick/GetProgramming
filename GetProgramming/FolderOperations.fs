module FolderOperations

open System.IO
  
let isValid path = 
    Directory.Exists path || File.Exists path
        
let isFolder path =
    if isValid path then
        let attribute = File.GetAttributes path
        attribute.HasFlag(FileAttributes.Directory)
    else
        failwith "Invalid Path"    

let rec getFolderSize (path: string) =
    let dirSize = 
        Directory.GetDirectories path
        |> Array.map getFolderSize
        |> Array.sum

    let fileSize = 
        Directory.GetFiles path
        |> Array.map (fun  x -> FileInfo(x).Length)
        |> Array.sum

    dirSize + fileSize

let getAverageFileSize path =
    let folders = Directory.GetDirectories path |> Array.map getFolderSize
    let files = Directory.GetFiles path |> Array.map (fun  x -> FileInfo(x).Length)  
    let totalCount = float(folders.Length + files.Length)
    let totalSize = float(Array.sum folders + Array.sum files)
    if totalCount <> 0.0 then totalSize / totalCount else 0.0

let getDistinctFileExtensions path = 
    Directory.GetFiles path
        |> Array.map (fun  x -> FileInfo(x).Extension)
        |> Array.distinct
    
let getFolderList path = 
    Directory.GetDirectories path 
    |> Array.toList
    |> List.map (fun x -> (x, getFolderSize x))
    |> List.sortBy (fun (path, size) -> -size)

