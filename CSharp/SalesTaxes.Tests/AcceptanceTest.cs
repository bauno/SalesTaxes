using NUnit.Framework;
using System;
using SalesTaxes.Core;
using Moq;
using System.Collections.Generic;

namespace SalesTaxes.Tests
{
	[TestFixture ()]
	public class AcceptanceTest
	{		
		private Mock<Display> _display;
		private SalesTaxesApp _sut;
		private List<string> _printedLines;

		[SetUp]
		public void Init()
		{
			_printedLines = new List<string> ();
			_display = new Mock<Display> ();
			_display.Setup (d => d.PrintLine (It.IsAny<string> ()))
				.Callback<string> (s => _printedLines.Add (s));

			_sut =  new SalesTaxesApp (
				new ProductFactory (new DumbProductRegister(), new SaleInputLineParser()), 
				new SalesTaxCalculator (), 
				new ReceiptPrinter (_display.Object));
		}

		[Test]
		public void Input1()
		{
			var line1 = "1 book at 12.49";
			var line2 = "1 music CD at 14.99";
			var line3 = "1 chocolate bar at 0.85";			

			var input = new[]{ line1, line2, line3 };


			_sut.PrintSalesTaxes (input);


			var outLine1 = "1 book: 12.49";
			var outLine2 = "1 music CD: 16.49";
			var outLine3 = "1 chocolate bar: 0.85";
			var outLine4 = "Sales Taxes: 1.50";
			var outLine5 = "Total: 29.83";

			var outLines = new[]{ outLine1, outLine2, outLine3, outLine4, outLine5 };

			for (int i = 0; i < 4; i++) {
				Assert.AreEqual (outLines [i], _printedLines [i]);
			}

				
		}

		[Test]
		public void Input2()
		{
			var line1 = "1 imported box of chocolates at 10.00";
			var line2 = "1 imported bottle of perfume at 47.50";

			var input = new[]{ line1, line2 };

			_sut.PrintSalesTaxes (input);

			var outLine1 = "1 imported box of chocolates: 10.50";
			var outLine2 = "1 imported bottle of perfume: 54.65";
			var outLine3 = "Sales Taxes: 7.65";
			var outLine4 = "Total: 65.15";

			var outLines = new[]{ outLine1, outLine2, outLine3, outLine4 };

			for (int i = 0; i < 3; i++) {
				Assert.AreEqual (outLines [i], _printedLines [i]);
			}

		}


		[Test]
		public void Input3()
		{
			var line1 = "1 imported bottle of perfume at 27.99";
			var line2 = "1 bottle of perfume at 18.99";
			var line3 = "1 packet of headache pills at 9.75";
			var line4 = "1 box of imported chocolates at 11.25";

			var input = new[]{ line1, line2, line3, line4 };

			_sut.PrintSalesTaxes (input);

			var outLine1 = "1 imported bottle of perfume: 32.19";
			var outLine2 = "1 bottle of perfume: 20.89";
			var outLine3 = "1 packet of headache pills: 9.75";
			var outLine4 = "1 imported box of chocolates: 11.85";
			var outLine5 = "Sales Taxes: 6.70";
			var outLine6 = "Total: 74.68";

			var outLines = new[]{ outLine1, outLine2, outLine3, outLine4, outLine5, outLine6 };

			for (int i = 0; i < 5; i++) {
				Assert.AreEqual (outLines [i], _printedLines [i]);
			}
		}

	}

}

