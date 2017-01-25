module ProductTaxes

 open ProductRegistry
 open ProductFactory
 open Product

 let approximate price =
  ((ceil (price*20m))/20m) 

 let calculateSalesTaxes price  =
  price * 0.1m  
 
 let calculateImportTaxes price  =
  price * 0.05m
 
 let importTaxes product= 
  if product.Imported then calculateImportTaxes product.LinePrice else 0.0m  

 let calculateTaxes product = 
  let saleTaxes = 
   if getTaxCategory product.Description = TaxCategory.Other 
   then calculateSalesTaxes product.LinePrice else 0.0m   
  saleTaxes + importTaxes product
  |> approximate

 let calculateGrossPrice product = 
  product.LinePrice + calculateTaxes product

