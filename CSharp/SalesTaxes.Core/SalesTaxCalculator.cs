using System;

namespace SalesTaxes.Core
{
	public class SalesTaxCalculator : TaxCalculator
	{
		#region TaxCalculator implementation
		public decimal GetImportTaxAmount (decimal price)
		{
			return Round( price * 0.05m);


		}
		public decimal GetSaleTaxAmount (decimal price)
		{
			return Round(price * 0.1m );
		}
		#endregion


		//TODO: this should be a collaborator...don't know if I'll find the time.
		private decimal Round(decimal num)
		{
			var ceiling = Math.Ceiling (num * 20);
			return ceiling / 20;
		}
		
	}
}

