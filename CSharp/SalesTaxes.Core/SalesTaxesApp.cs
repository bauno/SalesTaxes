using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Core
{
	public class SalesTaxesApp : SalesTaxes
	{
		ProductFactory _productFactory;

		TaxCalculator _taxCalculator;

		ProductPrinter _productPrinter;
		
		public SalesTaxesApp (ProductFactory productFactory, TaxCalculator taxCalculator, ProductPrinter productPrinter)
		{
			_productPrinter = productPrinter;
			_taxCalculator = taxCalculator;
			_productFactory = productFactory;
			
		}

		#region SalesTaxes implementation

		public void PrintSalesTaxes (IEnumerable<string> productLines)
		{
			var products = _productFactory.CreateProducts (productLines)
				.ToList ();
			foreach (var product in products) {
				product.CalculateTaxes (_taxCalculator);
			}
			_productPrinter.Print (products);
		}

		#endregion
	}
}

