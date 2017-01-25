using System;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
	public class DumbProductRegister : ProductRegister
	{

		public DumbProductRegister ()
		{
			_productCategories = new Dictionary<string, TaxCategory>
			{
				{"packet of headache pills", TaxCategory.Drug},
				{"book", TaxCategory.Book},
				{"chocolate bar", TaxCategory.Food},
				{"box of chocolates", TaxCategory.Food},				
			};
		}

		private readonly Dictionary<string, TaxCategory> _productCategories;
			

		public TaxCategory GetTaxCategory(string productName)
		{
			if (_productCategories.ContainsKey(productName))
				return _productCategories[productName];
			return TaxCategory.Other;
		}
	}
}

