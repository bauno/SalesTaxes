using System;
using NUnit.Framework;
using SalesTaxes.Core;
using Moq;

namespace SalesTaxes.Tests
{
	[TestFixture]
	public class SaleProductTest
	{
		
		[Test]
		public void CanCalculateGrossProductPrice()
		{
			var productLine = new InputProductLine {
				LinePrice = 27.99m,
				Imported = true,
			};

			var taxCalculator = new Mock<TaxCalculator> ();

			taxCalculator.Setup (t => t.GetSaleTaxAmount (27.99m))
				.Returns (1.4m);
			taxCalculator.Setup (t => t.GetImportTaxAmount (27.99m))
				.Returns (2.8m);

			var product = new SaleProduct (productLine, TaxCategory.Other);
			product.CalculateTaxes(taxCalculator.Object);

			Assert.AreEqual(32.19, product.GrossLinePrice);
		}
	}
}

