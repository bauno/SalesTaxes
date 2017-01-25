using System;
using NUnit.Framework;
using SalesTaxes.Core;

namespace SalesTaxes.Tests
{
	[TestFixture]
	public class TaxCalculatorTests
	{
		private TaxCalculator _sut;

		[SetUp]
		public void Init()
		{
			_sut = new SalesTaxCalculator ();

		}


		[TestCase(14.99, 1.5)]
		[TestCase(47.5, 4.75)]
		public void CanCalculateSaleTaxes(decimal price, decimal tax)
		{
			Assert.AreEqual (tax, _sut.GetSaleTaxAmount(price));
		}

		[TestCase(47.5, 2.4)]
		[TestCase(27.99, 1.4)]
		public void CanCalculateImportTaxes(decimal price, decimal tax)
		{
			Assert.AreEqual (tax, _sut.GetImportTaxAmount(price));
		}


	}
}

