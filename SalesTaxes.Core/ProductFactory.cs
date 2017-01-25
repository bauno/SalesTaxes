using System;
using SalesTaxes.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Core
{
	public class ProductFactory : IProductFactory
	{
		InputLineParser _parser;

		ProductRegister _productRegister;

		public ProductFactory (ProductRegister productRegister, InputLineParser parser)
		{
			_productRegister = productRegister;
			_parser = parser;
			
		}

		public IEnumerable<SaleProduct> CreateProducts (IEnumerable<string> inputLines)
		{
			return inputLines.Select (
				line => new SaleProduct (
					_parser.Parse (line),
					_productRegister.GetTaxCategory (
						_parser.Parse (line).Description
					))
			);
				
//			var products = new List<SaleProduct> ();
//			foreach (var line in inputLines) {
//				var productLine = _parser.Parse (line);
//				var category = _productRegister.GetTaxCategory (productLine.Description);
//				products.Add (new SaleProduct (productLine, category));
//			}
//			return products;
		}
	}

}

