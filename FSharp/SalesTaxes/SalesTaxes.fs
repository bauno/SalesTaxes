module SalesTaxes

open Receipt
open Input

[<EntryPoint>]
let main argv = 

 [Input1; Input2; Input3]
 |> List.iter (fun products -> 
    products
    |> List.map ProductFactory.parse
    |> printReceiptMoreFunctional
 )

 0 // return an integer exit code
