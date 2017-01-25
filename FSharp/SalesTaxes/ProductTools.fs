module ProductTools
     let parseAndPrintProduct line =
        line        
        |> ProductFactory.parse
        |> printfn "%A"
         
     let rec printLines lines =
        match lines with
        |[] -> ()
        |x::xs ->
            parseAndPrintProduct x
            printLines xs