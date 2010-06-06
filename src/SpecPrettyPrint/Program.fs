
open System

open TestMethodsExtractor

module main = 
     
    [<EntryPoint>]
    let main(args:string[]) =
        
        // let args = [@"C:\Users\TLorenz\Documents\Visual Studio 2008\Projects\FSharp\SpecPrettyPrint\src\TestsStructureSamples\bin\Debug\TestsStructureSamples.dll"]
        
        if args.Length = 0 then printfn "usage: SpecPrettyPrint \"fullPathToTests1.dll\" \"fullPathToTests2.dll\"" 
        
        try
            for fullPath in args do
                printfn "%A" (getTestMethodTree fullPath)
        with
         | ex -> printfn "usage: SpecPrettyPrint \"fullPathToTests1.dll\" \"fullPathToTests2.dll\"\n Here the error: \n %A" ex       
        
        let key = Console.ReadLine()
        0