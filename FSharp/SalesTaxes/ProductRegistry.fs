module ProductRegistry

    type TaxCategory = Drug | Book | Food | Other        
    let private productCategories = dict[
                                     "packet of headache pills", TaxCategory.Drug;
                                     "book", TaxCategory.Book;
                                     "chocolate bar", TaxCategory.Food;
                                     "box of chocolates", TaxCategory.Food 
                                     ]

    let getTaxCategory productDescription =
        if productCategories.ContainsKey(productDescription) 
         then productCategories.Item(productDescription)
         else TaxCategory.Other
                                             
