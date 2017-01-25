using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Core
{
	public class ReceiptPrinter : ProductPrinter
	{
		#region ProductPrinter implementation

		public void Print (IEnumerable<Product> products)
		{
			var total = 0.0m;
			var totalTaxes = 0.0m;
			foreach (var product in products) {

				var builder = new StringBuilder ();
				builder.Append (product.Qty)
					.Append(" ");
				if (product.Imported)
					builder.Append ("imported ");
				builder.Append (product.Description)
					.Append (": ")
					.Append (product.GrossLinePrice.ToString ("n2"));
					

				_display.PrintLine(builder.ToString());

				total += product.GrossLinePrice;
				totalTaxes += product.Taxes;
			}
			var formattedTaxes = totalTaxes.ToString ("n2");
			var formattedTotal = total.ToString("n2");
			_display.PrintLine ($"Sales Taxes: {formattedTaxes}");
			_display.PrintLine ($"Total: {formattedTotal}");
		}

		#endregion

		private Display _display;

		public ReceiptPrinter (Display display)
		{
			_display = display;
			
		}
	}
}

