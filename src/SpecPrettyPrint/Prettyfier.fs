module Prettyfier
    open System.Text.RegularExpressions

    let prettyfyold (name : string) =
        name.Replace("__", " \" ")
           
    let prettyfy (name : string) = 
        let quoteReplacer = new Regex(@"__(\w+?)__")
        let decimalPointReplacer = new Regex(@"(\d+)p(\d+)")
        
        let replaceQuotes = function 
             name -> quoteReplacer.Replace(name, " \"$1\" ")
        
        let replaceDecimalPoints = function
            name -> decimalPointReplacer.Replace(name, "$1.$2")
        
        let replaceSpaces (name : string) = name.Replace('_', ' ')
       
        name
        |> replaceQuotes
        |> replaceDecimalPoints
        |> replaceSpaces
        
       