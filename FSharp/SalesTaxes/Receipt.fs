module Receipt
 open ProductTaxes
 open ProductFactory
 open Product

 let product = "%i %s: %2M"
 let importedProduct = "%i imported %s: %2M"
 let printProduct product =   
  let grossPrice = calculateGrossPrice product
  match product.Imported with
  |true -> printfn  "%i imported %s: %2M" product.Qty product.Description grossPrice
  |false -> printfn "%i %s: %2M" product.Qty product.Description grossPrice
  

 let rec printProducts products =
  match products with 
  |[] -> ()
  |x::xs -> 
    printProduct x
    printProducts xs
 let printTotal products =
  products  
  |> List.map calculateGrossPrice
  |> List.reduce (+) 
  |> printfn "Total: %2M\n" 
 
 let printTaxes products =
   products 
   |> List.map calculateTaxes
   |> List.reduce (+)
   |> approximate
   |> printfn "Sales Taxes: %2M"


 let printReceipt products=
   printProducts products
   printTaxes products
   printTotal products

 let printReceiptMoreFunctional products =  
  let receipt = [printProducts; printTaxes; printTotal]
  receipt
  |> List.iter (fun pp -> pp products)
  

