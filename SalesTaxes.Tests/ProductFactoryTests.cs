using System;
using Moq;
using SalesTaxes.Core;
using NUnit.Framework;
using System.Linq;

namespace SalesTaxes.Tests
{
	[TestFixture]
	public class ProductFactoryTests
	{
		private Mock<ProductRegister> _productRegister;
		private Mock<InputLineParser> _parser;

		[SetUp]
		public void Init()
		{
			_productRegister = new Mock<ProductRegister> ();
			_parser = new Mock<InputLineParser> ();
		}

		[Test]
		public void CanCreateProduct()
		{
			var line1 = "pippo";
			var line2 = "paperino";
			_parser.Setup (prop => prop.Parse (line1))
				.Returns (new InputProductLine {
				Description = "pluto",
				Imported = true,
				LinePrice = 55.11m,
				Qty = 10
			});

			_parser.Setup (prop => prop.Parse (line2))
				.Returns (new InputProductLine {
					Description = "clarabella",
					Imported = false,
					LinePrice = 99.66m,
					Qty = 12
				});



			_productRegister.Setup (p => p.GetTaxCategory ("pluto"))
				.Returns (TaxCategory.Drug);
			_productRegister.Setup (p => p.GetTaxCategory ("clarabella"))
				.Returns (TaxCategory.Book);

			var sut = new ProductFactory (_productRegister.Object, _parser.Object);

			var res = sut.CreateProducts (new[]{ line1, line2 });

			var product = res.First ();

			Assert.AreEqual ("pluto", product.Description);
			Assert.IsTrue (product.Imported);
			Assert.AreEqual (55.11m, product.NetLinePrice);
			Assert.AreEqual (10, product.Qty);
			Assert.AreEqual (TaxCategory.Drug, product.TaxCategory);

			product = res.Last ();
			Assert.AreEqual ("clarabella", product.Description);
			Assert.IsFalse (product.Imported);
			Assert.AreEqual (99.66m, product.NetLinePrice);
			Assert.AreEqual (12, product.Qty);
			Assert.AreEqual (TaxCategory.Book, product.TaxCategory);



				
		}
	}
}

