using System;
using SalesTaxes.Core;
using System.Collections.Generic;

namespace SalesTaxes
{
	class MainClass
	{
		private static IEnumerable<string> Input1()
		{
			var line1 = "1 book at 12.49";
			var line2 = "1 music CD at 14.99";
			var line3 = "1 chocolate bar at 0.85";			

			return new[]{ line1, line2, line3 };

		}

		private static IEnumerable<string> Input2()
		{
			var line1 = "1 imported box of chocolates at 10.00";
			var line2 = "1 imported bottle of perfume at 47.50";

			return new[]{ line1, line2 };

		}

		private static IEnumerable<string> Input3()
		{
			var line1 = "1 imported bottle of perfume at 27.99";
			var line2 = "1 bottle of perfume at 18.99";
			var line3 = "1 packet of headache pills at 9.75";
			var line4 = "1 box of imported chocolates at 11.25";

			return new[]{ line1, line2, line3, line4 };

		}

		private static SalesTaxes.Core.SalesTaxes InitApp()
		{
			return new SalesTaxesApp (new ProductFactory (new DumbProductRegister (), 
				new SaleInputLineParser ()),
				new SalesTaxCalculator (),
				new ReceiptPrinter (new ConsoleDisplay ()));
		}

		public static void Main (string[] args)
		{
			var app = InitApp ();

			Console.WriteLine ("Printing Receipt for Input1...");
			Console.WriteLine ();
			app.PrintSalesTaxes (Input1());
			Console.WriteLine ();
			Console.WriteLine ("Printed. Press any key to continue");
			Console.ReadKey ();
			Console.WriteLine ();

			Console.WriteLine ("Printing Receipt for Input2...");
			Console.WriteLine ();
			app.PrintSalesTaxes (Input2());
			Console.WriteLine ();
			Console.WriteLine ("Printed. Press any key to continue");
			Console.ReadKey ();

			Console.WriteLine ();
			Console.WriteLine ("Printing Receipt for Input3...");
			Console.WriteLine ();
			app.PrintSalesTaxes (Input3());
			Console.WriteLine ();
			Console.WriteLine ("Printed. Press any key to continue");
			Console.ReadKey ();



				
		}
	}
}
