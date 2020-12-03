namespace FolderDomain

type MyFolder = 
    {  Name: string
       Size: int
       FileCount: int
       AverageFileSize: float
       FileExtensions: string list}

type MyFile = 
    {  Name: string
       Size: int
       Extension: string}

type GenericFile =
    | MyFolder
    | MyFile
