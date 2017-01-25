using System;
using NUnit.Framework;
using SalesTaxes.Core;

namespace SalesTaxes.Tests
{
	[TestFixture]
	public class InputLineParserTests
	{
		SaleInputLineParser _sut;

		[SetUp]
		public void Init()
		{
			_sut = new SaleInputLineParser ();
		}

		[TestCase("1 book at 12.49", 1, "book", 12.49)]
		[TestCase("1 music CD at 14.99",1,"music CD", 14.99)]
		[TestCase("1 bottle of perfume at 18.99", 1, "bottle of perfume", 18.99)]
		[TestCase("1 packet of headache pills at 9.75", 1, "packet of headache pills", 9.75)]
		public void CanParseAllNotImportedLines (string line, int qty, string desc, double price)
		{
			var res = _sut.Parse (line);

			Assert.AreEqual (qty, res.Qty);
			Assert.AreEqual (desc, res.Description);
			Assert.AreEqual (price, res.LinePrice);
			Assert.IsFalse (res.Imported);
		}

		[TestCase("1 imported box of chocolates at 10.00", 1, "box of chocolates", 10.00)]
		[TestCase("1 imported bottle of perfume at 47.50", 1, "bottle of perfume", 47.50)]
		[TestCase("1 box of imported chocolates at 11.25", 1, "box of chocolates", 11.25)]
		public void CanParseAllImportedLines(string line, int qty, string desc, double price)
		{
			var res = _sut.Parse (line);

			Assert.AreEqual (qty, res.Qty);
			Assert.AreEqual (desc, res.Description);
			Assert.AreEqual (price, res.LinePrice);
			Assert.IsTrue (res.Imported);		
		}			

		[Test]
		public void WillFailWithInvalidLine()
		{
			var line = "pippo pioppo";
			Assert.Throws<ArgumentException> (() => _sut.Parse(line));
		}
			


	}
}

